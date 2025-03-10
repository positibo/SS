using MediatR;
using Microsoft.AspNetCore.Mvc;
using SS.CodingChallenge.Api.Source.Domain.UseCases;

namespace SS.CodingChallenge.Api.Source.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator mediator;

        public CandidateController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string zipCode) =>
           Ok(await mediator.Send(new GetCandidatesByZipCodeQuery(zipCode)));
    }
}
