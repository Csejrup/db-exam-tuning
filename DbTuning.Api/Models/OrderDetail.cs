namespace DbTuning.Api.Models;

public class OrderDetail
{
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public DateTime OrderDate { get; set; } 

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}