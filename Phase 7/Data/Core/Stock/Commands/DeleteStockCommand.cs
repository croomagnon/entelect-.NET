﻿namespace Pezza.Core.Stock.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public partial class DeleteStockCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, Result>
    {
        private readonly IDataAccess<Common.Entities.Stock> DataAccess;

        public DeleteStockCommandHandler(IDataAccess<Common.Entities.Stock> DataAccess)
            => this.DataAccess = DataAccess;

        public async Task<Result> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var outcome = await this.DataAccess.DeleteAsync(request.Id);

            return (outcome) ? Result.Success() : Result.Failure("Error deleting a Stock");
        }
    }
}
