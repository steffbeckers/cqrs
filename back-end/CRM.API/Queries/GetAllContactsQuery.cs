using AutoMapper;
using CRM.API.DTOs;
using CRM.API.Models;
using CRM.API.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.API.Queries
{
    public class GetAllContactsQuery : IRequest<List<ContactDTO>>
    {
    }

    // Might be better to move to Handlers dir?
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactDTO>>
    {
        private readonly ContactsRepository contactsRepository;
        private readonly IMapper mapper;

        public GetAllContactsQueryHandler(ContactsRepository contactsRepository, IMapper mapper)
        {
            this.contactsRepository = contactsRepository;
            this.mapper = mapper;
        }

        public async Task<List<ContactDTO>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            List<Contact> contacts = await contactsRepository.GetAsync();

            return mapper.Map<List<Contact>, List<ContactDTO>>(contacts);
        }
    }
}
