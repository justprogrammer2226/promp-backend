using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promp.Extensions;
using Promp.Models.Prom;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using Promp.Services.PromService;

namespace Promp.Controllers
{
    [ApiController]
    [Route("prom")]
    [Authorize]
    public class PromController : ControllerBase
    {
        private readonly IPromService PromService;

        public PromController(IPromService promService)
        {
            PromService = promService;
        }

        [HttpGet("tokens")]
        public async Task<IActionResult> GetAllTokens()
        {
            var userId = HttpContext.GetCurrentUserId();
            var tokens = await PromService.GetAllTokens(userId);
            return Ok(tokens);
        }

        [HttpPost("tokens")]
        public async Task<IActionResult> AddToken(PromApiTokenModel model)
        {
            var addedModel = await PromService.SaveToken(model);
            return Ok(addedModel);
        }

        [HttpDelete("tokens/{token}")]
        public async Task<IActionResult> RemoveToken(string token)
        {
            var userId = HttpContext.GetCurrentUserId();
            await PromService.RemoveToken(token, userId);
            return Ok();
        }

        [HttpGet("products/list")]
        public async Task<IActionResult> GetProducts([FromQuery] List<string> selectedPromTokens, [FromQuery] string searchText, [FromQuery] SearchProductsBy searchBy, [FromQuery] ProductAvailabilityBy availabilityBy)
        {
            var products = await PromService.GetProducts(new SearchProductsModel(selectedPromTokens, searchText, searchBy, availabilityBy));
            return Ok(products);
        }

        [HttpPost("products/edit")]
        public async Task<IActionResult> EditProducts(IEnumerable<ProductEditModel> products)
        {
            await PromService.EditProducts(products);
            return Ok();
        }
    }
}
