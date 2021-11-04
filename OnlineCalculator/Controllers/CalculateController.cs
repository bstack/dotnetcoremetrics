using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCalculator.Models;
using System.Net.Mime;
using System.Threading;

namespace OnlineCalculator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Consumes("application/json")]
	[Produces("application/json")]
	public class CalculatorController : ControllerBase
	{
		

		private readonly ILogger<CalculatorController> _logger;

		public CalculatorController(ILogger<CalculatorController> logger)
		{
			_logger = logger;
		}

		[HttpPost("v1/add")]
		[Consumes(MediaTypeNames.Application.Json)]
		public int Add(
			[FromBody] CalculateRequest request)
		{
			Thread.Sleep(request.DelayInMilliseconds);

			return request.Number1 + request.Number2;
		}

		[HttpPost("v1/multiply")]
		[Consumes(MediaTypeNames.Application.Json)]
		public int Multiply(
			[FromBody] CalculateRequest request)
		{
			Thread.Sleep(request.DelayInMilliseconds);

			return request.Number1 * request.Number2;
		}
	}
}
