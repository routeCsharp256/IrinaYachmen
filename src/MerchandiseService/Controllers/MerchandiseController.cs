using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.HttpModels;
using MerchandiseService.Infrastructure.Commands;
using MerchandiseService.Infrastructure.Queries;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("api/merch")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;
        private readonly IMediator _mediator;

        public MerchandiseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("merch/{id:long}")]
        public async Task<ActionResult<int>> GetInformationAboutIssueOfMerch(long id, CancellationToken token)
        {
            var query = new GetInfoAboutRequestMerchQuery()
            {
                Sku = id
            };
            var result = await _mediator.Send(query, token);
            return result;
        }
        
        [HttpPost]
        public async Task<IActionResult> RequestMerch(RequestMerchModelRequest model, CancellationToken token)
        {
            var createRequestMerchCommand = new CreateRequestMerchCommand()
            {
                Sku = model.Sku,
                Quantity = model.Quantity,
                Status = model.Status,
                EmployeeSku = model.EmployeeSku,
                RequestDateTime = model.RequestDateTime,
                MerchPackType = model.MerchPack
            };

            var result = await _mediator.Send(createRequestMerchCommand, token);
            
            return Ok(result);
        }
    }
}