using System;
using System.Collections.Generic;
using CrudEF.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudEF.DB;

public partial class ArtisianContext : DbContext
{
    public ArtisianContext()
    {
    }

    public ArtisianContext(DbContextOptions<ArtisianContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Artisian> Artisians { get; set; }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactArtisian> ContactArtisians { get; set; }

    public virtual DbSet<ContactCustomer> ContactCustomers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

    public virtual DbSet<DataArtisian> DataArtisians { get; set; }

    public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public virtual DbSet<DeliveryProvider> DeliveryProviders { get; set; }

    public virtual DbSet<DepartmentManufactory> DepartmentManufactories { get; set; }

    public virtual DbSet<DepartmentProduct> DepartmentProducts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ManufactoryHub> ManufactoryHubs { get; set; }

    public virtual DbSet<NetworkArtisian> NetworkArtisians { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Rewiew> Rewiews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("address_id_primary");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Artisian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("artisian_id_primary");

            entity.ToTable("Artisian");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.ToTable("BankDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountCurrencyType)
                .HasMaxLength(50)
                .HasColumnName("accountCurrencyType");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .HasColumnName("accountNumber");
            entity.Property(e => e.DataArtisianId).HasColumnName("dataArtisianId");

            entity.HasOne(d => d.DataArtisian).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.DataArtisianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankDetail_DataArtisian");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_id_primary");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ContactArtisian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contactartisian_id_primary");

            entity.ToTable("ContactArtisian");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataArtisianId).HasColumnName("dataArtisianId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.DataArtisian).WithMany(p => p.ContactArtisians)
                .HasForeignKey(d => d.DataArtisianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactArtisian_DataArtisian");
        });

        modelBuilder.Entity<ContactCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contactcustomer_id_primary");

            entity.ToTable("ContactCustomer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContactCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customerId");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_id_primary");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_addressid_foreign");
        });

        modelBuilder.Entity<CustomerDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_CustomerDiscount");

            entity.ToTable("CustomerDiscount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("discount");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CustomerDiscount)
                .HasForeignKey<CustomerDiscount>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CustomerDiscount_Customer");
        });

        modelBuilder.Entity<DataArtisian>(entity =>
        {
            entity.HasKey(e => e.ArtisianId).HasName("dataartisian_id_primary");

            entity.ToTable("DataArtisian");

            entity.HasIndex(e => e.AddressId, "addresId").IsUnique();

            entity.Property(e => e.ArtisianId)
                .ValueGeneratedOnAdd()
                .HasColumnName("artisianId");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Address).WithOne(p => p.DataArtisian)
                .HasForeignKey<DataArtisian>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DataArtisian_Address");

            entity.HasOne(d => d.Artisian).WithOne(p => p.DataArtisian)
                .HasForeignKey<DataArtisian>(d => d.ArtisianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DataArtisian_Artisian");
        });

        modelBuilder.Entity<DeliveryOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_DeliveryOrder");

            entity.ToTable("DeliveryOrder");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.DeliveryAddressId).HasColumnName("deliveryAddressId");
            entity.Property(e => e.DeliveryProviderId).HasColumnName("deliveryProviderId");
            entity.Property(e => e.ShippingAddressId).HasColumnName("shippingAddressId");

            entity.HasOne(d => d.DeliveryAddress).WithMany(p => p.DeliveryOrderDeliveryAddresses)
                .HasForeignKey(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deliveryorder_address_delivery");

            entity.HasOne(d => d.DeliveryProvider).WithMany(p => p.DeliveryOrders)
                .HasForeignKey(d => d.DeliveryProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryProvider_DeliveryOrder");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.DeliveryOrderShippingAddresses)
                .HasForeignKey(d => d.ShippingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deliveryorder_address_shipping");
        });

        modelBuilder.Entity<DeliveryProvider>(entity =>
        {
            entity.ToTable("DeliveryProvider");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DepartmentManufactory>(entity =>
        {
            entity.ToTable("DepartmentManufactory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ManufactoryId).HasColumnName("manufactoryId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Manufactory).WithMany(p => p.DepartmentManufactories)
                .HasForeignKey(d => d.ManufactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentManufactory_ManufactoryHub");
        });

        modelBuilder.Entity<DepartmentProduct>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.ProductId });

            entity.ToTable("DepartmentProduct");

            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.CountProduct).HasColumnName("countProduct");
            entity.Property(e => e.InProduces).HasColumnName("inProduces");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentProducts)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentProduct_DepartmentManufactory");

            entity.HasOne(d => d.Product).WithMany(p => p.DepartmentProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentProduct_ProductCatalog");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_DepartmentManufactory");
        });

        modelBuilder.Entity<ManufactoryHub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufactoryhub_id_primary");

            entity.ToTable("ManufactoryHub");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.ArtisianId).HasColumnName("artisianId");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.HasOne(d => d.Address).WithMany(p => p.ManufactoryHubs)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("manufactoryhub_addressid_foreign");

            entity.HasOne(d => d.Artisian).WithMany(p => p.ManufactoryHubs)
                .HasForeignKey(d => d.ArtisianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("manufactoryhub_artisianid_foreign");
        });

        modelBuilder.Entity<NetworkArtisian>(entity =>
        {
            entity.ToTable("NetworkArtisian");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataArtisianId).HasColumnName("dataArtisianId");
            entity.Property(e => e.Descriptioon)
                .HasMaxLength(500)
                .HasColumnName("descriptioon");
            entity.Property(e => e.SocialNetwork)
                .HasMaxLength(500)
                .HasColumnName("socialNetwork");

            entity.HasOne(d => d.DataArtisian).WithMany(p => p.NetworkArtisians)
                .HasForeignKey(d => d.DataArtisianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NetworkArtisian_DataArtisian");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_id_primary");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("orderDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_customerid_foreign");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_DeliveryOrder");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderitem_id_primary");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderitem_orderid_foreign");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_ProductCatalog");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_id_primary");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IsSuccessful).HasColumnName("isSuccessful");
            entity.Property(e => e.PaymentMethodId).HasColumnName("paymentMethodId");
            entity.Property(e => e.ReceipId).HasColumnName("receipId");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_paymentmethodid_foreign");

            entity.HasOne(d => d.Receip).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReceipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Receip");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("paymentmethod_id_primary");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Method)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("method");
        });

        modelBuilder.Entity<ProductCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_id_primary");

            entity.ToTable("ProductCatalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCatalogs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_categoryid_foreign");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ProductPrice");

            entity.ToTable("ProductPrice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("beginDate");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 0)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productprice_productcatalog");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Receipt");

            entity.ToTable("Receipt");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AmountToPay)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amountToPay");
            entity.Property(e => e.CustomerDiscountId).HasColumnName("customerDiscountId");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.CustomerDiscount).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.CustomerDiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Receipt_Discount");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Receipt)
                .HasForeignKey<Receipt>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Receipt_Order");
        });

        modelBuilder.Entity<Rewiew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rewiew_id_primary");

            entity.ToTable("Rewiew");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rewiews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rewiew_customerid_foreign");

            entity.HasOne(d => d.Product).WithMany(p => p.Rewiews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rewiew_prodictid_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
