using CRM.API.Data;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Repositories
{
    // TODO: Add generic base Repository<T> (for model)
    public class ContactsRepository
    {
        private readonly CRMContext context;

        public ContactsRepository(CRMContext context)
        {
            this.context = context;
        }

        // Should be from generic base
        public async Task<List<Contact>> GetAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        // Should be from generic base
        public async Task<Contact> GetByIdAsync(Guid id)
        {
            return await context.Contacts.FindAsync(id);
        }

        public async Task<Contact> InsertAsync(Contact contact)
        {
            await context.AddAsync(contact);
            await context.SaveChangesAsync();

            return await GetByIdAsync(contact.Id);
        }

        // Additional functions
    }
}
