using AutoMapper;
using Backend.Entities;
using Backend.Models.Addresses;

namespace Backend.Mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, UpdateAddressDto>();
        }
    }
    
}
