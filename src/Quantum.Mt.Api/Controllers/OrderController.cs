using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quantum.Mt.Domain.Models;

namespace Quantum.Mt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        [HttpGet]
        public string Get() => "Ok";

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string customerNumber)
        {
            var (accepted, rejected) = await _client.GetResponse<OrderSubmissionAccepted, OrderSubmissionRejected>(
                new OrderSubmissionAccepted
                {
                    OrderId = id,
                    Timestamp = InVar.Timestamp,
                    CustomerNumber = customerNumber
                });

            return accepted.IsCompletedSuccessfully
                ? (IActionResult) Ok(accepted.Result.Message)
                : BadRequest(rejected.Result.Message);
        }

        private readonly IRequestClient<SubmitOrder> _client;
        private readonly ILogger<OrderController> _logger;
    }
}