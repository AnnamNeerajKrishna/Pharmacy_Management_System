using Pharmacy_Management_System.Model;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Repository
{
    public interface IDrugsRepository
    {
        
        
        List<Drugs> GetAllDrugs();
        Drugs GetDrugById(int id);
        void DeleteDrug(int id);
        void UpdateDrug(int id,Drugs drug);
        string AddDrug(Drugs drugs);

        
    }
}
