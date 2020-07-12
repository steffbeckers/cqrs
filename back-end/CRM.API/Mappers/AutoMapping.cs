using AutoMapper;
using CRM.API.Commands;
using CRM.API.DTOs;
using CRM.API.Models;

namespace CRM.API.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<CreateContactCommand, Contact>();
        }
    }
}
