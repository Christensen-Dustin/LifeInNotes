using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class Entry
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // represents the entryId
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of Entry field is required")]
        [MaxLength(50, ErrorMessage = "Name of Entry cannot exceed 50 characters")]
        // Name of entry
        public string Name { get; set; }

        [Required(ErrorMessage ="The Theme field is required")]
        // Type of entry
        public TType? Type { get; set; }

        [Required(ErrorMessage ="The Type field is required")]
        // Theme of Entry
        public Theme? Theme { get; set; }

        [Required(ErrorMessage = "Date of Entry field required")]
        // Date Entry was entered
        public string Date { get; set; }

        // A reference date for entries needing additional dates
        public string RefDate { get; set; }

        [Required(ErrorMessage = "The Content field is required")]
        // Content of the entry
        public string Content { get; set; }

        // Represents the UserId related to the entry
        public string UserId { get; set; }
    }
}
