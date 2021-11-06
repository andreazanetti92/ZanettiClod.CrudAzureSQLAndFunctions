using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ZanettiClod.AppCore.Interfaces.Services;

namespace ZanettiClod.AzureFunctionsHttpTrigger
{
    public class DeleteProduct
    {
        private readonly IProductServices _productServices;

        public DeleteProduct(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [Function("DeleteProduct")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteProduct/{id:int}")] HttpRequestData req,
            FunctionContext executionContext, int id)
        {
            var logger = executionContext.GetLogger("DeleteProduct");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            await _productServices.DeleteProduct(id);

            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
