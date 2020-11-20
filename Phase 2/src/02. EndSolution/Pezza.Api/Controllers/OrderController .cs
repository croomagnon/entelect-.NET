﻿namespace Pezza.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Pezza.Api.Controllers.CleanArchitecture.WebUI.Controllers;
    using Pezza.Api.Helpers;
    using Pezza.Common.DTO;
    using Pezza.Common.Entities;
    using Pezza.Core.Order.Commands;
    using Pezza.Core.Order.Queries;

    [ApiController]
    public class OrderController : ApiController
    {
        /// <summary>
        /// Get Order by Id.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.Mediator.Send(new GetOrderQuery { Id = id });

            return ResponseHelper.ResponseOutcome<Order>(result, this);
        }


        /// <summary>
        /// Get all Orders.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Search()
        {
            var result = await this.Mediator.Send(new GetOrdersQuery());

            return ResponseHelper.ResponseOutcome<Order>(result, this);
        }

        /// <summary>
        /// Create Order.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Order
        ///     {        
        ///       "customerId": "1"
        ///       "restaurantId": "1"
        ///       "amount": "1.00"
        ///     }
        /// </remarks>
        /// <param name="data"></param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Order>> Create(OrderDataDTO data)
        {
            var result = await this.Mediator.Send(new CreateOrderCommand
            {
                Data = data
            });

            return ResponseHelper.ResponseOutcome<Order>(result, this);
        }

        // <summary>
        /// Remove Order by Id.
        /// </summary>
        /// <param name="id"></param> 
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new DeleteOrderCommand { Id = id });

            return ResponseHelper.ResponseOutcome(result, this);
        }
    }
}
