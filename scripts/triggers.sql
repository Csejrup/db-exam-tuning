-- Function to update order totals
CREATE OR REPLACE FUNCTION update_order_total()
RETURNS TRIGGER AS $$
BEGIN
UPDATE Orders
SET Total = (
    SELECT SUM(Quantity * Price)
    FROM OrderDetails
    WHERE OrderID = NEW.OrderID
)
WHERE OrderID = NEW.OrderID;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger for insert and update on OrderDetails
CREATE TRIGGER trigger_update_order_total
    AFTER INSERT OR UPDATE ON OrderDetails
                        FOR EACH ROW EXECUTE FUNCTION update_order_total();
