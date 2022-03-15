using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CardInfoCustomers = new HashSet<CardInfoCustomer>();
            ContactPeople = new HashSet<ContactPerson>();
            CustomerReviews = new HashSet<CustomerReview>();
            Messages = new HashSet<Message>();

        }


        public int Id { get; set; }
        public int LocationId { get; set; }
        public int DiscountId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNr { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual DiscountLevel Discount { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CardInfoCustomer> CardInfoCustomers { get; set; }
        public virtual ICollection<ContactPerson> ContactPeople { get; set; }
        public virtual ICollection<CustomerReview> CustomerReviews { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
