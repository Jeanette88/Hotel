using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class CustomerReview
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int HotelId { get; set; }
        public int? Stars { get; set; }
        public string? Text { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
