using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using MerchandiseService.HttpModels;
using MerchandiseService.Infrastructure.Commands;
using MerchandiseService.Infrastructure.Queries;
using MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("api/merch")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDbConnectionFactory<NpgsqlConnection> _factory;

        public MerchandiseController(IMediator mediator, IDbConnectionFactory<NpgsqlConnection> factory)
        {
            _mediator = mediator;
            _factory = factory;
        }
        [HttpGet("merch/{id:long}")]
        public async Task<RequestMerchandiseResponse[]> GetInformationAboutIssueOfMerch(long id, CancellationToken token)
        {
            var query = new GetInfoAboutRequestMerchQuery()
            {
                Sku = id
            };
            var result = await _mediator.Send(query, token);
            return result.Items.Select(it => new RequestMerchandiseResponse
            {
                Sku = it.Sku,
                Quantity = it.Quantity,
                Status = it.Status,
                MerchPackType = it.MerchPackType
            }).ToArray();
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
                MerchPackType = model.MerchPackType
            };

            var result = await _mediator.Send(createRequestMerchCommand, token);
            
            return Ok(result);
        }
        
        [HttpGet("merch-pack-type-id-by-name/{name}")]
        public async Task<long> GetRequestMerchPackTypeIdByName([FromRoute] string name, CancellationToken cancellationToken)
        {
            var connection = await _factory.CreateConnection(cancellationToken);
            return await connection.QuerySingleAsync<long>($"SELECT id from merch_pack_type WHERE name = '{name}'");
        }
    }
}