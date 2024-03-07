﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
        }

        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Status { get; set; } = null!;
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
