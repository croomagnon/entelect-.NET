﻿namespace Pezza.Core.Customer.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Entities;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Mapping;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public partial class CreateCustomerCommand : IRequest<Result<CustomerDTO>>
    {
        public CustomerDataDTO Data { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerDTO>>
    {
        private readonly IDataAccess<Customer> DataAccess;

        public CreateCustomerCommandHandler(IDataAccess<Customer> DataAccess)
            => this.DataAccess = DataAccess;

        public async Task<Result<CustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var outcome = await this.DataAccess.SaveAsync(request.Data.Map());

            return (outcome != null) ? Result<CustomerDTO>.Success(outcome.Map()) : Result<CustomerDTO>.Failure("Error creating a Customer");
        }
    }
}
