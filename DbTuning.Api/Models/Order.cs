namespace DbTuning.Api.Models;

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }

    public Customer Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}