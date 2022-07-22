using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Services
{
    public class DrugService
    {
        private readonly DrugDAL _drug;
        public DrugService(DrugDAL drug)
        {
            _drug=drug;
        }
        public string AddDrug(Drugs drugs)
        {
          _drug.AddDrug(drugs);
            return "Drug is Successfully Added";
        }
        public void DeleteDrug(int id)
        {
            _drug.DeleteDrug(id);
        }
        public List<Drugs> GetAllDrugs()
        {
            return _drug.GetAllDrugs();
            
        }
        public Drugs GetDrugById(int id)
        {
            return _drug.GetDrugById(id);
        }
        public void UpdateDrug(int id, Drugs drug)
        {
            _drug.UpdateDrug(id, drug);
        }

    }
}
