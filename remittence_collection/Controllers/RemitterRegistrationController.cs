using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using remittence_collection.BLL;
using remittence_collection.Models;

namespace remittence_collection.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RemitterRegistrationController : ControllerBase
    {
        IRemitterRegistrationBLL _remitterRegistrationBLL;
        public RemitterRegistrationController(IRemitterRegistrationBLL remitterRegistrationBLL)
        {
            _remitterRegistrationBLL = remitterRegistrationBLL;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Remitter remitter){
            if(!ModelState.IsValid){
                return BadRequest("Insufficient data provided");
            }
            string message = await _remitterRegistrationBLL.RegisterRemitter(remitter);
            return Ok(message);
        }
        public IActionResult GetAllCountries(){
            var countries = _remitterRegistrationBLL.GetAllCountries();
            return Ok(countries);
        }
        public IActionResult GetAllIDTypes(){
            var idTypes = _remitterRegistrationBLL.GetAllIDTypes();
            return Ok(idTypes);
        }
        public IActionResult GetAllRemitterTypes(){
            var remitterTypes = _remitterRegistrationBLL.GetAllRemitterTypes();
            return Ok(remitterTypes);
        }
        public IActionResult GetAllRemitter(){
            var remitters = _remitterRegistrationBLL.GetAllRemitters();
            return Ok(remitters);
        }

        public IActionResult GetRemitterById(string remitterId){
            var remitter = _remitterRegistrationBLL.GetRemitterById(remitterId);
            return Ok(remitter);
        }
    }
}