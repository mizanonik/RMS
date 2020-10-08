using System.Collections.Generic;
using System.Threading.Tasks;
using remittence_collection.Models;

namespace remittence_collection.Repository
{
    public interface IBeneficiaryAdd
    {         
         Task<string> RegisterBeneficiary(Beneficiary beneficiary);
         List<Beneficiary> GetAllBeneficiary();
         Beneficiary GetBeneficiaryById(string beneficiaryId);
         List<State> GetAllStates();
    }
}