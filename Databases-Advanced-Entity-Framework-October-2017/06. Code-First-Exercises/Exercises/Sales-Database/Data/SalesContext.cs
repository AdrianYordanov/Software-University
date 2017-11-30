namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products
        {
            get;
            set;
        }

        public DbSet<Customer> Customers
        {
            get;
            set;
        }

        public DbSet<Store> Stores
        {
            get;
            set;
        }

        public DbSet<Sale> Sales
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.StoreId);
            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}