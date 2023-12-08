using LocalDatabaseApp.Models;

namespace LocalDatabaseApp.Interfaces
{
    public interface IDarbuotojasService
    {
        public List<Darbuotojas> GetDarbuotojai();

        public int InsertDarbuotojas(string name, string id, string lastName);
        public int ModifyDarbuotojas(string name, string id, string lastName);
    }
}
