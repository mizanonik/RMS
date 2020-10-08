using Microsoft.AspNetCore.Mvc;
using remittence_collection.BLL;
using remittence_collection.Models;

namespace remittence_collection.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RemittenceCollection : ControllerBase
    {
        IBeneficiaryAddBLL _beneficiaryAddBLL;
        public RemittenceCollection(IBeneficiaryAddBLL beneficiaryAddBLL)
        {
            _beneficiaryAddBLL = beneficiaryAddBLL;
        }
        public IActionResult AddBeneficiary([FromBody] Beneficiary beneficiary){
            var msg =  _beneficiaryAddBLL.AddBeneficiary(beneficiary);
            return Ok(msg);
        }
    }
}