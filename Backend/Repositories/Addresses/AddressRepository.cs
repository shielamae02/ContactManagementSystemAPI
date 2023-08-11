using Backend.Data;
using Backend.Entities;
using Backend.Exceptions.Contacts;
using Backend.Repositories.Contacts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IContactRepository _contactRepository;

        public AddressRepository(DataContext context, IContactRepository contactRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        
    }
}
