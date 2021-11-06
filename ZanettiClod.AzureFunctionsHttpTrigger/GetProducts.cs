using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ZanettiClod.AppCore.Interfaces.Services;
using ZanettiClod.Domain;

namespace ZanettiClod.AzureFunctionsHttpTrigger
{
    public class GetProducts
    {
        private readonly IProductServices _productService;

        public GetProducts(IProductServices productService)
        {
            _productService = productService;
        }

        [Function("GetProducts")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetProducts");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var products = await _productService.GetAllProducts();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(products);

            return response;
        }
    }
}
