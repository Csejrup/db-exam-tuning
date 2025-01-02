using DbTuning.Api.Data;
using DbTuning.Api.Models;
using DbTuning.Api.Repositories;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services;
using DbTuning.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

// Register Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "PostgresApp API v1");
        options.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}

// Product Endpoints
app.MapGet("/api/products", async (IProductService productService) =>
{
    return Results.Ok(await productService.GetAllProductsAsync());
});

app.MapGet("/api/products/{id:int}", async (int id, IProductService productService) =>
{
    var product = await productService.GetProductByIdAsync(id);
    return product != null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/api/products", async (Product product, IProductService productService) =>
{
    await productService.AddProductAsync(product);
    return Results.Created($"/api/products/{product.ProductID}", product);
});

app.MapPut("/api/products/{id:int}", async (int id, Product updatedProduct, IProductService productService) =>
{
    var product = await productService.GetProductByIdAsync(id);
    if (product == null) return Results.NotFound();

    updatedProduct.ProductID = id;
    await productService.UpdateProductAsync(updatedProduct);
    return Results.NoContent();
});

app.MapDelete("/api/products/{id:int}", async (int id, IProductService productService) =>
{
    await productService.DeleteProductAsync(id);
    return Results.NoContent();
});

// Customer Endpoints
app.MapGet("/api/customers", async (ICustomerService customerService) =>
{
    return Results.Ok(await customerService.GetAllCustomersAsync());
});

app.MapGet("/api/customers/{id:int}", async (int id, ICustomerService customerService) =>
{
    var customer = await customerService.GetCustomerByIdAsync(id);
    return customer != null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/api/customers", async (Customer customer, ICustomerService customerService) =>
{
    await customerService.AddCustomerAsync(customer);
    return Results.Created($"/api/customers/{customer.CustomerID}", customer);
});

app.MapPut("/api/customers/{id:int}", async (int id, Customer updatedCustomer, ICustomerService customerService) =>
{
    var customer = await customerService.GetCustomerByIdAsync(id);
    if (customer == null) return Results.NotFound();

    updatedCustomer.CustomerID = id;
    await customerService.UpdateCustomerAsync(updatedCustomer);
    return Results.NoContent();
});

app.MapDelete("/api/customers/{id:int}", async (int id, ICustomerService customerService) =>
{
    await customerService.DeleteCustomerAsync(id);
    return Results.NoContent();
});

// Order Endpoints
app.MapGet("/api/orders", async (IOrderService orderService) =>
{
    return Results.Ok(await orderService.GetAllOrdersAsync());
});

app.MapGet("/api/orders/{id:int}", async (int id, IOrderService orderService) =>
{
    var order = await orderService.GetOrderByIdAsync(id);
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.MapPost("/api/orders", async (Order order, IOrderService orderService) =>
{
    await orderService.AddOrderAsync(order);
    return Results.Created($"/api/orders/{order.OrderID}", order);
});

app.MapPut("/api/orders/{id:int}", async (int id, Order updatedOrder, IOrderService orderService) =>
{
    var order = await orderService.GetOrderByIdAsync(id);
    if (order == null) return Results.NotFound();

    updatedOrder.OrderID = id;
    await orderService.UpdateOrderAsync(updatedOrder);
    return Results.NoContent();
});

app.MapDelete("/api/orders/{id:int}", async (int id, IOrderService orderService) =>
{
    await orderService.DeleteOrderAsync(id);
    return Results.NoContent();
});

// OrderDetail Endpoints
app.MapGet("/api/orderdetails/{orderId:int}", async (int orderId, IOrderDetailService orderDetailService) =>
{
    return Results.Ok(await orderDetailService.GetOrderDetailsByOrderIdAsync(orderId));
});

app.MapGet("/api/orderdetails/{orderId:int}/{productId:int}", async (int orderId, int productId, IOrderDetailService orderDetailService) =>
{
    var orderDetail = await orderDetailService.GetOrderDetailByIdAsync(orderId, productId);
    return orderDetail != null ? Results.Ok(orderDetail) : Results.NotFound();
});

app.MapPost("/api/orderdetails", async (OrderDetail orderDetail, IOrderDetailService orderDetailService) =>
{
    await orderDetailService.AddOrderDetailAsync(orderDetail);
    return Results.Created($"/api/orderdetails/{orderDetail.OrderID}/{orderDetail.ProductID}", orderDetail);
});

app.MapPut("/api/orderdetails/{orderId:int}/{productId:int}", async (int orderId, int productId, OrderDetail updatedOrderDetail, IOrderDetailService orderDetailService) =>
{
    var orderDetail = await orderDetailService.GetOrderDetailByIdAsync(orderId, productId);
    if (orderDetail == null) return Results.NotFound();

    updatedOrderDetail.OrderID = orderId;
    updatedOrderDetail.ProductID = productId;
    await orderDetailService.UpdateOrderDetailAsync(updatedOrderDetail);
    return Results.NoContent();
});

app.MapDelete("/api/orderdetails/{orderId:int}/{productId:int}", async (int orderId, int productId, IOrderDetailService orderDetailService) =>
{
    await orderDetailService.DeleteOrderDetailAsync(orderId, productId);
    return Results.NoContent();
});

app.Run();
