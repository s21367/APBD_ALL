using efDataBase.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfDoctor>> GetDoctors();
        Task<string> DeleteDoctor(int id);
        Task<string> AddDoctor(SomeSortOfDoctor doctor);
        Task<string> EditDoctor(SomeSortOfDoctor doctor, int id);
    }
}
