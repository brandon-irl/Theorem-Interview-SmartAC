using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration
{
    [Route("alerts")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Alert>> Get()
        {
            return await _mediator.Send(new AlertQuery());
        }

        [HttpPost]
        [Route("resolve")]
        public async Task<IActionResult> Resolve(int alertId)
        {
            await _mediator.Send(new ResolveAlertCommand(alertId));
            return NoContent();
        }
    }
}