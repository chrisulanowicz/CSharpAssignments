using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{

    public class Comment
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        [Required(ErrorMessage="Can't make a blank comment!")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

}