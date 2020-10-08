using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using remittence_collection.Models;

namespace remittence_collection.Repository
{
    public class BeneficiaryAdd : IBeneficiaryAdd
    {
        RemittenceCollectionContext _context;
        public BeneficiaryAdd(RemittenceCollectionContext context)
        {
            _context = context;
        }
        public List<Beneficiary> GetAllBeneficiary()
        {
            return _context.Beneficiaries
                        .Include(r => r.Remitter)
                        .Include(c => c.Nationality)
                        .ToList();
        }

        public Beneficiary GetBeneficiaryById(string beneficiaryId)
        {
            return _context.Beneficiaries
                        .Include(r => r.Remitter)
                        .Include(c => c.Nationality)
                        .FirstOrDefault(id => id.BeneficiaryId == beneficiaryId);
        }

        public List<Beneficiary> GetAllBeneficiaryByRemitterId(string remitterId)
        {
            return _context.Beneficiaries
                        .Include(r => r.Remitter)
                        .Include(c => c.Nationality)
                        .Where(id => id.RemitterId == remitterId)
                        .ToList();
        }

        public List<State> GetAllStates(){
            return _context.States
                        .Include(c => c.Country)
                        .ToList();
        }

        public async Task<string> RegisterBeneficiary(Beneficiary beneficiary)
        {
            try{
                await _context.Beneficiaries.AddAsync(beneficiary);
                await _context.SaveChangesAsync();
            }
            catch(Exception e){
                return e.Message;
            }
            return "Beneficiary Saved Successfully.";
        }
    }
}