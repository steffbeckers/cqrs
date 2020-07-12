using AutoMapper;
using CRM.API.DTOs;
using CRM.API.Models;
using CRM.API.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.API.Queries
{
    public class GetContactByIdQuery : IRequest<ContactDTO>
    {
        public Guid Id { get; set; }

        public GetContactByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDTO>
    {
        private readonly ContactsRepository contactsRepository;
        private readonly IMapper mapper;

        public GetContactByIdQueryHandler(ContactsRepository contactsRepository, IMapper mapper)
        {
            this.contactsRepository = contactsRepository;
            this.mapper = mapper;
        }

        public async Task<ContactDTO> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            Contact contact = await contactsRepository.GetByIdAsync(request.Id);

            return mapper.Map<ContactDTO>(contact);
        }
    }
}
