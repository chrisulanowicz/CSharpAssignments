using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{

    public class User : BaseEntity
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Wedding Wedding { get; set; }
        public List<Attendee> RSVPs { get; set; }

        public User()
        {
            RSVPs = new List<Attendee>();
        }

    }

}