using Microsoft.EntityFrameworkCore;
using DBase.Models;

namespace DBase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierID);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Warehouse)
            .WithMany(w => w.Products)
            .HasForeignKey(p => p.WarehouseID);

            // UTC Datetime
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasConversion(
                v => v, // Store as is
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Ensure it's treated as UTC
            );

            // Seed data for Suppliers
            Guid ID_Supplier1 = Guid.NewGuid();
            Guid ID_Supplier2 = Guid.NewGuid();

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { ID_Supplier = ID_Supplier1, SupplierName = "Supplier A", ContactName = "Alice", Email = "alice@supplier.com", Phone = "123-456-7890" },
                new Supplier { ID_Supplier = ID_Supplier2, SupplierName = "Supplier B", ContactName = "Bob", Email = "bob@supplier.com", Phone = "098-765-4321" }
            );

            // Seed data for Warehouses
            Guid ID_Warehouse1 = Guid.NewGuid();
            Guid ID_Warehouse2 = Guid.NewGuid();

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { ID_Warehouse = ID_Warehouse1, WarehouseName = "Warehouse 1", Location = "Location A", ManagerName = "Manager A", Capacity = 1000 },
                new Warehouse { ID_Warehouse = ID_Warehouse2, WarehouseName = "Warehouse 2", Location = "Location B", ManagerName = "Manager B", Capacity = 2000 }
            );
            
            // Seed data for Products
            Guid ID_Product1 = Guid.NewGuid();
            Guid ID_Product2 = Guid.NewGuid();
            Guid ID_Product3 = Guid.NewGuid();

            modelBuilder.Entity<Product>().HasData(
                new Product { ID_Product = ID_Product1, SupplierID = ID_Supplier1, WarehouseID = ID_Warehouse1, ProductName = "Product 1", UnitPrice = 10.00m, QuantityInStock = 100 },
                new Product { ID_Product = ID_Product2, SupplierID = ID_Supplier1, WarehouseID = ID_Warehouse1, ProductName = "Product 2", UnitPrice = 15.00m, QuantityInStock = 200 },
                new Product { ID_Product = ID_Product3, SupplierID = ID_Supplier2, WarehouseID = ID_Warehouse2, ProductName = "Product 3", UnitPrice = 20.00m, QuantityInStock = 150 }
            );

            // Seed data for Customers
            Guid ID_Customer1 = Guid.NewGuid();
            Guid ID_Customer2 = Guid.NewGuid();

            modelBuilder.Entity<Customer>().HasData(
                new Customer { ID_Customer = ID_Customer1, CustomerName = "John Doe", Phone = "111-222-3333", Email = "john.doe@example.com", Address = "123 Main St, Anytown, USA" },
                new Customer { ID_Customer = ID_Customer2, CustomerName = "Jane Smith", Phone = "444-555-6666", Email = "jane.smith@example.com", Address = "456 Elm St, Othertown, USA" }
            );
            
            // Seed data for Orders
            Guid ID_Order1 = Guid.NewGuid();
            Guid ID_Order2 = Guid.NewGuid();

            modelBuilder.Entity<Order>().HasData(
                new Order { ID_Order = ID_Order1, CustomerID = ID_Customer1, TotalAmount = 25.00m, OrderDate = DateTime.UtcNow, Status = "Completed" },
                new Order { ID_Order = ID_Order2, CustomerID = ID_Customer2, TotalAmount = 30.00m, OrderDate = DateTime.UtcNow, Status = "Pending" }
            );
            
            // Seed data for OrderDetails
            Guid ID_OrderDetails1 = Guid.NewGuid();
            Guid ID_OrderDetails2 = Guid.NewGuid();
            Guid ID_OrderDetails3 = Guid.NewGuid();

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { ID_OrderDetails = ID_OrderDetails1, OrderId = ID_Order1, ProductId = ID_Product1, Quantity = 2, UnitPrice = 10.00m },
                new OrderDetail { ID_OrderDetails = ID_OrderDetails2, OrderId = ID_Order1, ProductId = ID_Product2, Quantity = 1, UnitPrice = 15.00m },
                new OrderDetail { ID_OrderDetails = ID_OrderDetails3, OrderId = ID_Order2, ProductId = ID_Product3, Quantity = 1, UnitPrice = 20.00m }
            );
        }
    }
}