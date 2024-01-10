using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public partial class MyPymesContext : DbContext
{
    public MyPymesContext()
    {
    }

    public MyPymesContext(DbContextOptions<MyPymesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrencyType> CurrencyTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceState> InvoiceStates { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPriceCost> ProductPriceCosts { get; set; }

    public virtual DbSet<ProductPurchase> ProductPurchases { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SuperUser> SuperUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrencyType>(entity =>
        {
            entity.HasKey(e => e.IdcurrencyType).HasName("pk_Currency_Type");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer).HasName("pk_Customer");

            entity.HasOne(d => d.IdcustomerTypeNavigation).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_currency_type");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.IdcustomerType).HasName("pk_Customer_Type");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Idinvoice).HasName("pk_Invoice");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Invoice_Customer");

            entity.HasOne(d => d.IdinvoiceStateNavigation).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice_invoice_state");

            entity.HasOne(d => d.IdpaymentTypeNavigation).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Invoice_Payment_Type");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.IdinvoiceDetail).HasName("pk_Invoice_Detail");

            entity.HasOne(d => d.IdinvoiceNavigation).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice_detail_invoice");

            entity.HasOne(d => d.IdproducPriceCostNavigation).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Invoice_Detail_Product_Price_Cost");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice_detail_product");
        });

        modelBuilder.Entity<InvoiceState>(entity =>
        {
            entity.HasKey(e => e.IdinvoiceState).HasName("pk_Invoice_state");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.IdpaymentType).HasName("pk_Payment_Type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("pk_Product");

            entity.HasOne(d => d.IdproductCategoryNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_product_category");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.IdProductCategory).HasName("pk_Product_Category");
        });

        modelBuilder.Entity<ProductPriceCost>(entity =>
        {
            entity.HasKey(e => e.IdproducPriceCost).HasName("pk_Product_Price_Cost");

            entity.HasOne(d => d.IdcurrencyTypeNavigation).WithMany(p => p.ProductPriceCosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Product_Price_Cost_Currency_Type");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.ProductPriceCosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Product_Price_Cost_Product");
        });

        modelBuilder.Entity<ProductPurchase>(entity =>
        {
            entity.HasKey(e => e.Idpurchase).HasName("pk_Product_Order");

            entity.HasOne(d => d.IdproductNavigation).WithOne(p => p.ProductPurchase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Product_Order_Product");

            entity.HasOne(d => d.IdproviderNavigation).WithOne(p => p.ProductPurchase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Product_Order_Provider");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Idprovider).HasName("pk_Provider");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("pk_Roles");
        });

        modelBuilder.Entity<SuperUser>(entity =>
        {
            entity.HasKey(e => e.IdsuperUser).HasName("pk_Super_User");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.SuperUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Super_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
