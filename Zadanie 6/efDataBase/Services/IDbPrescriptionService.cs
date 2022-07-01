using efDataBase.Models.DTO;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public interface IDbPrescriptionService
    {
        Task<SomeSortOfPrescription> GetPrescription(int id);

    }
}
