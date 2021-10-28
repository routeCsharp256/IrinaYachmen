using System;
using System.Threading;
using System.Threading.Tasks;
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

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> RequestMerch(long id, CancellationToken token)
        {
            await _merchandiseService.RequestMerch(id, token);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetInformationAboutIssueOfMerch(CancellationToken token)
        {
            var merchandiseItem = await _merchandiseService.GetInformationAboutIssueOfMerch(token);
            if (merchandiseItem is null)
            {
                return NotFound();
            }
            return Ok(merchandiseItem);
        }
    }
}