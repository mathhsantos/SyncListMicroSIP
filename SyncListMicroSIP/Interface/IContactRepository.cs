using SyncListMicroSIP.Models;

namespace SyncListMicroSIP.Interface
{
    public interface IContactRepository
    {
        Task InsertContact(Contact contact);
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetOneContact(string id);
        Task<Contact> DeleteContact(string id);
        Task<bool> SaveChanges();
    }
}
