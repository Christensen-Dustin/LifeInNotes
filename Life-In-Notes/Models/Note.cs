using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class Note
    {
        // represents the noteId
        public int Id { get; set; }

        [Required(ErrorMessage = "The Theme field is required")]
        // Type of entry
        public TType? Type { get; set; }

        [Required(ErrorMessage = "The Type field is required")]
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

        // Represents the EntryId related to the entry
        public int EntryId { get; set; }
    }
}
