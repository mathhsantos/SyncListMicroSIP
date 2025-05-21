using Microsoft.EntityFrameworkCore;
using SyncListMicroSIP.Data;
using SyncListMicroSIP.Interface;
using SyncListMicroSIP.Models;

namespace SyncListMicroSIP.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _db;
        public ContactRepository(ContactDbContext db)
        {
            _db = db;
        }

        public async Task InsertContact(Contact contact)
        {
            await _db.Contacts.AddAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var contacts = await _db.Contacts.AsNoTracking().ToListAsync();

            return contacts;
        }

        public async Task<Contact> GetOneContact(string id)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(x => x.Number == id);

            return contact;
        }

        public async Task<Contact> DeleteContact(string id)
        {
            var contact = await GetOneContact(id);

            if(contact == null)
            {
                return contact;
            }

            _db.Contacts.Remove(contact);

            return contact;
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
