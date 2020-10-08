using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using remittence_collection.Models;

namespace remittence_collection.Repository
{
    public class RemitterRegistration : IRemitterRegistration
    {
        RemittenceCollectionContext _context;
        public RemitterRegistration(RemittenceCollectionContext context)
        {
            _context = context;
        }
        public async Task<string> RegisterRemitter(Remitter remitter)
        {
            try{
                await _context.Remitters.AddAsync(remitter);
                await _context.IDs.AddAsync(remitter.PrimaryID);
                await _context.IDs.AddAsync(remitter.SecondaryID);
                await _context.SaveChangesAsync();
            }
            catch(Exception e){
                return e.Message;
            }
            return "Remitter Saved Successfully.";
        }
        public List<Country> GetAllCountries(){
            return _context.Countries.ToList();
        }
        public List<IDType> GetAllIDTypes(){
            return _context.IDTypes.ToList();
        }
        public List<RemitterType> GetAllRemitterTypes(){
            return _context.RemitterTypes.ToList();
        }
        public List<Remitter> GetAllRemitters(){
            return _context.Remitters
                    .Include(pid => pid.PrimaryID)
                    .Include(sid => sid.SecondaryID)
                    .Include(pidType => pidType.PrimaryID.IDType)
                    .Include(sidType => sidType.SecondaryID.IDType)
                    .Include(n => n.Nationality)
                    .Include(rt => rt.RemitterType)
                    .ToList();
        }
        public Remitter GetRemitterById(string remitterId){
            return _context.Remitters
                    .Include(pid => pid.PrimaryID)
                    .Include(sid => sid.SecondaryID)
                    .Include(pidType => pidType.PrimaryID.IDType)
                    .Include(sidType => sidType.SecondaryID.IDType)
                    .Include(n => n.Nationality)
                    .Include(rt => rt.RemitterType)
                    .FirstOrDefault(id => id.RemitterId == remitterId);
        }
        public string GetLatestRemitterID(){
            return _context.Remitters.OrderByDescending(dt => dt.ActionDate).Select(rid => rid.RemitterId).First();
        }
    }
}