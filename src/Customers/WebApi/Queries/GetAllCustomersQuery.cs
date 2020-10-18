using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YtDeveloppement.EventSourcing.Customers.Dal;
using YtDeveloppement.EventSourcing.Customers.WebApi.Dtos;

namespace YtDeveloppement.EventSourcing.Customers.WebApi.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
        public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;

            public GetAllCustomersHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<CustomerDto>>(await _customerRepository.GetAllAsync());
            }
        }
    }
}
