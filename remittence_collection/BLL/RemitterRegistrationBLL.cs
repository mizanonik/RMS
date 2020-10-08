using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using remittence_collection.Models;
using remittence_collection.Repository;

namespace remittence_collection.BLL
{
    public interface IRemitterRegistrationBLL{
        Task<string> RegisterRemitter(Remitter remitter);
        List<Country> GetAllCountries();
        List<IDType> GetAllIDTypes();
        List<RemitterType> GetAllRemitterTypes();
        List<Remitter> GetAllRemitters();
        Remitter GetRemitterById(string remitterId);
    }
    public class RemitterRegistrationBLL : IRemitterRegistrationBLL
    {
        IRemitterRegistration _remitterRegistration;
        public RemitterRegistrationBLL(IRemitterRegistration remitterRegistration)
        {
            _remitterRegistration = remitterRegistration;
        }

        public List<Country> GetAllCountries()
        {
            return _remitterRegistration.GetAllCountries();
        }

        public List<IDType> GetAllIDTypes()
        {
            return _remitterRegistration.GetAllIDTypes();
        }

        public List<Remitter> GetAllRemitters()
        {
            return _remitterRegistration.GetAllRemitters();
        }

        public List<RemitterType> GetAllRemitterTypes()
        {
            return _remitterRegistration.GetAllRemitterTypes();
        }

        public Remitter GetRemitterById(string remitterId)
        {
            return _remitterRegistration.GetRemitterById(remitterId);
        }

        public Task<string> RegisterRemitter(Remitter remitter){
            Random generator = new Random();
            string number = generator.Next(0, 999999).ToString("D6");
            remitter.RemitterId = "RMS-"+number;
            remitter.ActionDate = DateTime.Now;
            return _remitterRegistration.RegisterRemitter(remitter);
        }

        // private string GenerateRemitterId(){
        //     var remitterId = _remitterRegistration.GetLatestRemitterID().Split('-');

        // }
    }
}