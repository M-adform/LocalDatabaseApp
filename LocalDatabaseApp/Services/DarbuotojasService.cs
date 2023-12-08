using LocalDatabaseApp.Interfaces;
using LocalDatabaseApp.Models;

namespace LocalDatabaseApp.Services
{
    public class DarbuotojasService : IDarbuotojasService
    {
        private readonly IDarbuotojasRepository _darbuotojasRepository;
        public DarbuotojasService(IDarbuotojasRepository darbuotojasRepository)
        {
            _darbuotojasRepository = darbuotojasRepository;
        }

        public List<Darbuotojas> GetDarbuotojai()
        {
            return _darbuotojasRepository.GetDarbuotojai().ToList();
        }

        public int InsertDarbuotojas(string name, string id, string lastname)
        {
            return _darbuotojasRepository.InsertDarbuotojas(name, id, lastname);
        }

        public int ModifyDarbuotojas(string name, string id, string lastname)
        {
            return _darbuotojasRepository.ModifyDarbuotojas(name, id, lastname);
        }

    }
}
