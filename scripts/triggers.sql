-- Function to update order totals
CREATE OR REPLACE FUNCTION update_order_total()
RETURNS TRIGGER AS $$
BEGIN
-- Update only if relevant columns have changed
    IF (TG_OP = 'INSERT' OR NEW.Quantity <> OLD.Quantity OR NEW.Price <> OLD.Price) THEN
UPDATE Orders
SET Total = (
    SELECT SUM(Quantity * Price)
    FROM OrderDetails
    WHERE OrderID = NEW.OrderID
)
WHERE OrderID = NEW.OrderID;
END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger for insert and update on OrderDetails
DROP TRIGGER IF EXISTS trigger_update_order_total ON OrderDetails;
CREATE TRIGGER trigger_update_order_total
    AFTER INSERT OR UPDATE OF Quantity, Price ON OrderDetails
    FOR EACH ROW EXECUTE FUNCTION update_order_total();
