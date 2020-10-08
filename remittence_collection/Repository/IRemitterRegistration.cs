using System.Collections.Generic;
using System.Threading.Tasks;
using remittence_collection.Models;

namespace remittence_collection.Repository
{
    public interface IRemitterRegistration
    {
         Task<string> RegisterRemitter(Remitter remitter);
         List<Country> GetAllCountries();
         List<IDType> GetAllIDTypes();
         List<RemitterType> GetAllRemitterTypes();
         List<Remitter> GetAllRemitters();
         Remitter GetRemitterById(string remitterId);
         string GetLatestRemitterID();
    }
}