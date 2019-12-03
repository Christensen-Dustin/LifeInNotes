using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public interface IEntryRepository
    {
        // Retrieves Entry via ID
        Entry GetEntry(int Id);

        // Retrieves all Entrys in the database pertaining to the user
        IEnumerable<Entry> GetAllEntries(string userId);

        // Create and add a New Entry
        Entry Add(Entry entry);

        // Updates an Entry
        Entry Update(Entry entryChanges);

        // Deletes an Entry
        Entry Delete(int id);
    }
}
