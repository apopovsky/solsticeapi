namespace SolsticeData
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public interface IContacRepository
    {
        IList<Contact> GetAll();
        Contact GetById(Guid id);
        void AddContact(Contact value);
        void UpdateContact(Guid id, Contact contact);
        void DeleteContact(Contact contact);
        Contact GetByMail(string email);
        IList<Contact> GetByPhone(string phoneNumber);
    }

    public class ContactRepository : IContacRepository
    {
        private readonly SolsticeDataContext _dataContext;

        public ContactRepository()
        {
            _dataContext = new SolsticeDataContext();
        }

        public IList<Contact> GetAll()
        {
            return _dataContext.Contacts.Include(c => c.Address).ToList();
        }

        public Contact GetById(Guid id)
        {
            return _dataContext.Contacts.Include(c=>c.Address).SingleOrDefault(x=>x.Id==id);
        }

        public void AddContact(Contact value)
        {
            _dataContext.Contacts.Add(value);
            _dataContext.SaveChanges();
        }

        public void UpdateContact(Guid id, Contact contact)
        {
            var existing = _dataContext.Contacts.Find(id);
            if (existing != null && contact != null)
            {
                existing.Name = contact.Name;
                existing.Birthdate = contact.Birthdate;
                existing.Company = contact.Company;
                existing.Email = contact.Email;
                existing.Image = contact.Image;
                existing.PersonalPhoneNumber = contact.PersonalPhoneNumber;
                existing.WorkPhoneNumber = contact.WorkPhoneNumber;
                existing.Profile = contact.Profile;

                if (contact.Address != null)
                {
                    existing.Address = contact.Address;
                }

                _dataContext.SaveChanges();
            }
        }

        public void DeleteContact(Contact contact)
        {
            _dataContext.Contacts.Remove(contact);
            _dataContext.SaveChanges();
        }

        public Contact GetByMail(string email)
        {
           return _dataContext.Contacts.Include(c=>c.Address).FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public IList<Contact> GetByPhone(string phoneNumber)
        {
            return _dataContext.Contacts.Include(c => c.Address).
                Where(x => x.PersonalPhoneNumber.Equals(phoneNumber, StringComparison.OrdinalIgnoreCase) || x.WorkPhoneNumber.Equals(phoneNumber, StringComparison.OrdinalIgnoreCase) ).ToList();
        }
    }
}
