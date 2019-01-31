using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WideWorldImporters.API.Models;
using WorldWideImporters.Model;

namespace WorldWideImporters.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly ApplicationDbContext DbContext;

        public WarehouseController(ILogger<WarehouseController> logger, ApplicationDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [HttpGet("StockItem")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStockItemsAsync(int pageSize = 10, int pageNumber = 1, int? lastEditedBy = null, int? 
            colorID = null, int? outerPackageID = null, int? supplierID = null, int? unitPackageID = null)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetStockItemsAsync));
            var response = new PagedResponse<StockItem>();

            try
            {
                //Get the propsoed query from repository
                var query = DbContext.GetStockItems();

                //Set paging values
                response.PageSize = pageSize;
                response.PageNumber = pageNumber;

                //Get the total rows
                response.ItemsCount = await query.CountAsync();

                //Get the specific page from database
                response.Model = await query.Paging(pageSize, pageNumber).ToListAsync();

                response.Message = string.Format("Page '{0}' of '{1}', Total of products: '{2}' ", 
                    response.PageNumber, response.PageCount, response.ItemsCount);

                Logger?.LogInformation("The stock items have been retrived successfully");
            } catch(Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact technical support.";
                Logger?.LogCritical("There was an error on '{0}' invocation: '{1}'", nameof(GetStockItemsAsync), ex);
            }

            return response.ToHttpResponse();
        }
    }
}