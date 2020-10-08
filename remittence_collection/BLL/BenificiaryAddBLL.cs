using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using remittence_collection.Models;
using remittence_collection.Repository;

namespace remittence_collection.BLL
{
    public interface IBeneficiaryAddBLL{
        List<State> GetAllState();
        List<Beneficiary> GetAllBeneficiaries();
        Beneficiary GetRemitterById(string beneficiaryId);
        Task<string> AddBeneficiary(Beneficiary beneficiary);

    }
    public class BenificiaryAddBLL : IBeneficiaryAddBLL
    {
        
        IBeneficiaryAdd _beneficiaryAdd;
        public BenificiaryAddBLL(IBeneficiaryAdd beneficiaryAdd)
        {
            _beneficiaryAdd = beneficiaryAdd;
        }

        public List<State> GetAllState()
        {
            return _beneficiaryAdd.GetAllStates();
        }

        public List<Beneficiary> GetAllBeneficiaries()
        {
            return _beneficiaryAdd.GetAllBeneficiary();
        }

        public Beneficiary GetRemitterById(string beneficiaryId)
        {
            return _beneficiaryAdd.GetBeneficiaryById(beneficiaryId);
        }

        public Task<string> AddBeneficiary(Beneficiary beneficiary){
            Random generator = new Random();
            string number = generator.Next(0, 999999).ToString("D6");
            beneficiary.RemitterId = "BN-"+number;
            beneficiary.ActionDate = DateTime.Now;
            return _beneficiaryAdd.RegisterBeneficiary(beneficiary);
        }
    }
}