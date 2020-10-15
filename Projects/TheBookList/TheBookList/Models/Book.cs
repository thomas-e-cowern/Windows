using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBookList.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Title { get; set; }

        public string Author { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool Finished { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }
    }
}
