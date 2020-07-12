using AutoMapper;
using CRM.API.DTOs;
using CRM.API.Models;
using CRM.API.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.API.Commands
{
    public class CreateContactCommand : IRequest<ContactDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDTO>
    {
        private readonly ContactsRepository contactsRepository;
        private readonly IMapper mapper;

        public CreateContactCommandHandler(ContactsRepository contactsRepository, IMapper mapper)
        {
            this.contactsRepository = contactsRepository;
            this.mapper = mapper;
        }

        public async Task<ContactDTO> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            Contact contact = mapper.Map<Contact>(request);

            contact = await this.contactsRepository.InsertAsync(contact);

            return mapper.Map<ContactDTO>(contact);
        }
    }
}
