using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class SQLEntryRepository : IEntryRepository
    {
        private readonly AppDBContext context;

        // Construtor to bring in AppDBContext
        public SQLEntryRepository(AppDBContext context)
        {
            this.context = context;
        }

        // Adds an entry to the list
        public Entry Add(Entry entry)
        {
            // Adds new entry to list
            context.Entries.Add(entry);

            // Saves changes to the DB
            context.SaveChanges();

            // Returns the entry
            return entry;
        }

        // Deletes a specified Entry
        public Entry Delete(int id)
        {
            // Find the entry
            Entry entry = context.Entries.Find(id);

            // Verfiy that the entry exists
            if (entry != null)
            {
                // Remove the entry
                context.Entries.Remove(entry);

                // Save the changes
                context.SaveChanges();
            }

            // Return the removed/deleted entry
            return entry;
        }

        // All Entries
        public IEnumerable<Entry> GetAllEntries(string userId)
        {
            // Return all Entries
            return context.Entries.Where(e => e.UserId == userId);
        }

        // Retrieves a specified Entry
        public Entry GetEntry(int id)
        {
            return context.Entries.Find(id);
        }

        // Update an entry
        public Entry Update(Entry entryChanges)
        {
            // Attach changes to the database (context)
            var entry = context.Entries.Attach(entryChanges);

            // Change the state to modified
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Save the changes to the DATABASE
            context.SaveChanges();

            // Return the changed data
            return entryChanges;
        }
    }
}
