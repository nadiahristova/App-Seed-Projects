using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Article : BasicModel
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime LastModifiedAt { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        //public User Author { get; set; }
    }
}
