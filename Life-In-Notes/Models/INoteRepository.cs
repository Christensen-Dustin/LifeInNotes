using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public interface INoteRepository
    {
        // Retrieves Note via ID
        Note GetNote(int id);

        // Retrieves all Notes in the database pertaining to an entry
        IEnumerable<Note> GetAllNotes(int entryId);

        // Create and add a New Note
        Note Add(Note note);

        // Updates a Note
        Note Update(Note noteChanges);

        // Deletes a Note
        Note Delete(int id);
    }
}
