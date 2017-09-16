using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Models
{

    public class Wedding : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Partner1 { get; set; }

        public string Partner2 { get; set; }

        public DateTime WeddingDate { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public int Zip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Attendee> Attendees { get; set; }

        public Wedding()
        {
            Attendees = new List<Attendee>();
        }
    }

}