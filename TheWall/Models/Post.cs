using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{

    public class Post : BaseEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage="Can't post a blank message!")]
        [DataType(DataType.Text)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }

}