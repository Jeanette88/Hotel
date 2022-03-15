using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotel.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<CardInfo> CardInfos { get; set; } = null!;
        public virtual DbSet<CardInfoCustomer> CardInfoCustomers { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<ContactPerson> ContactPersons { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerReview> CustomerReviews { get; set; } = null!;
        public virtual DbSet<CustomersInformationBooking> CustomersInformationBookings { get; set; } = null!;
        public virtual DbSet<DiscountLevel> DiscountLevels { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductsBill> ProductsBills { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<StatusLog> StatusLogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_Method_ID");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill.Payment_Method_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill.Status_ID");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BillId).HasColumnName("Bill_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.GuestAmount).HasColumnName("Guest_Amount");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("FK_Bookings.Bill_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings.Customer_ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings.Room_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings.Status_ID");
            });

            modelBuilder.Entity<CardInfo>(entity =>
            {
                entity.ToTable("Card_Info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Card_Number")
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e._3digits).HasColumnName("3Digits");
            });

            modelBuilder.Entity<CardInfoCustomer>(entity =>
            {
                entity.ToTable("Card_Info_Customers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardInfoId).HasColumnName("Card_Info_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.HasOne(d => d.CardInfo)
                    .WithMany(p => p.CardInfoCustomers)
                    .HasForeignKey(d => d.CardInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Info_Customers.Card_Info_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CardInfoCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Info_Customers.Customer_ID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Cities__737584F6D6F494AE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities.Country_ID");
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("Contact_Persons");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.PhoneNr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Nr")
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ContactPeople)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Persons.Customer_ID");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Countrie__737584F6F7408AC5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_ID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.LocationId).HasColumnName("Location_ID");

                entity.Property(e => e.PhoneNr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Nr")
                    .IsFixedLength();

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers.Discount_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers.Location_ID");
            });

            modelBuilder.Entity<CustomerReview>(entity =>
            {
                entity.ToTable("Customer_Reviews");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.HotelId).HasColumnName("Hotel_ID");

                entity.Property(e => e.Text).HasMaxLength(3000);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerReviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Reviews.Customer_ID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.CustomerReviews)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Reviews.Hotel_ID");
            });

            modelBuilder.Entity<CustomersInformationBooking>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Customers_Information_Booking");

                entity.Property(e => e.Arrival).HasColumnType("date");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("date")
                    .HasColumnName("Check out");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.Name).HasMaxLength(101);

                entity.Property(e => e.NumberOfBeds).HasColumnName("Number of beds");

                entity.Property(e => e.NumberOfGuests).HasColumnName("Number of guests");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomSize).HasColumnName("Room Size");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<DiscountLevel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeRoleId).HasColumnName("Employee_Role_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.PhoneNr).HasColumnName("Phone_Nr");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.EmployeeRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees.Employee_Role_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees.Status_ID");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("Employee_Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(50)
                    .HasColumnName("Hotel_Name");

                entity.Property(e => e.LocationId).HasColumnName("Location_ID");

                entity.Property(e => e.PhoneNr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Nr")
                    .IsFixedLength();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotels.Location_ID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Postal_Code")
                    .IsFixedLength();

                entity.Property(e => e.Street).HasMaxLength(216);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations.City_ID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations.Country_ID");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingId).HasColumnName("Booking_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Message1)
                    .HasMaxLength(3000)
                    .HasColumnName("Message");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages.Booking_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages.Customer_ID");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ProductsBill>(entity =>
            {
                entity.ToTable("Products_Bill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BillId).HasColumnName("Bill_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.ProductsBills)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Bill.Bill_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsBills)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Bill.Product_ID");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HotelId).HasColumnName("Hotel_ID");

                entity.Property(e => e.RoomTypeId).HasColumnName("Room_Type_ID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms.Hotel_ID");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms.Room_Type_ID");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("Room_Types");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NumberOfBeds).HasColumnName("Number_of_Beds");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SizeM2).HasColumnName("Size(m2)");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusLog>(entity =>
            {
                entity.ToTable("Status_logs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("date")
                    .HasColumnName("Changed_Date");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StatusLogs)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_logs.Status_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
