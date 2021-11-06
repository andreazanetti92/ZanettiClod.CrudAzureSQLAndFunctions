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
    public class InsertProduct
    {
        private readonly IProductServices _productServices;

        public InsertProduct(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [Function("InsertProduct")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("InsertProduct");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var product = await req.ReadFromJsonAsync<Product>();

            await _productServices.InsertProduct(product);

            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
