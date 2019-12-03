using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class SQLNoteRepository : INoteRepository
    {
        private readonly AppDBContext context;

        // Construtor to bring in AppDBContext
        public SQLNoteRepository(AppDBContext context)
        {
            this.context = context;
        }

        // Adds a note to the list
        public Note Add(Note note)
        {
            // Adds new note to list
            context.Notes.Add(note);

            // Saves changes to the DB
            context.SaveChanges();

            // Returns the note
            return note;
        }

        // Deletes a specified Note
        public Note Delete(int id)
        {
            // Find the note
            Note note = context.Notes.Find(id);

            // Verfiy that the note exists
            if (note != null)
            {
                // Remove the note
                context.Notes.Remove(note);

                // Save the changes
                context.SaveChanges();
            }

            // Return the removed/deleted note
            return note;
        }

        // All Notes
        public IEnumerable<Note> GetAllNotes(int entryId)
        {
            // Return all Notes
            return context.Notes.Where(n => n.EntryId == entryId);
        }

        // Retrieves a specified Note
        public Note GetNote(int id)
        {
            return context.Notes.Find(id);
        }

        // Update a Note
        public Note Update(Note noteChanges)
        {
            // Attach changes to the database (context)
            var note = context.Notes.Attach(noteChanges);

            // Change the state to modified
            note.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Save the changes to the DATABASE
            context.SaveChanges();

            // Return the changed data
            return noteChanges;
        }
    }
}
