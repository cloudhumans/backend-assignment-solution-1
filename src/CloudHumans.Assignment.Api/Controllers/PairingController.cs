using Microsoft.AspNetCore.Mvc;
using CloudHumans.Assignment.Application;
using CloudHumans.Assignment.Domain.ValueObjects;
using CloudHumans.Assignment.Application.DataTransferObjects.PairingService;
using CloudHumans.Assignment.Application.DataTransferObjects;

namespace CloudHumans.Assignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PairingController : ControllerBase
    {
        private readonly PairingService pairingService;

        public PairingController(PairingService pairingService)
        {
            this.pairingService = pairingService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PairingResponse), 200)]
        [ProducesResponseType(typeof(BusinessExceptionResponse), 400)]
        public ActionResult PairProToProject([FromBody] ProApplicationRequest proApplication)
        {
            try
            {
                return Ok(pairingService.PairProToProject(proApplication));
            }
            catch (BusinessException ex)
            {
                return BadRequest(new BusinessExceptionResponse(ex.Code, ex.Message));
            }
        }
    }
}