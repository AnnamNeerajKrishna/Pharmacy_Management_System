using Pharmacy_Management_System.Model;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_Management_System.Repository
{
    public class DrugDAL : IDrugsRepository
    {
        private readonly PharmacyContextDb _db;
        public DrugDAL(PharmacyContextDb db)
        {
                _db= db;    
        }
        public string AddDrug(Drugs drugs)
        {
            _db.DrugDetails.Add(drugs);
            _db.SaveChanges();
            return "Drug is Successfully Added";
        }

        public void DeleteDrug(int id)
        {
            var item =_db.DrugDetails.FirstOrDefault(c=>c.DrugId == id);
            if (item != null) 
            {
                _db.DrugDetails.Remove(item);
                _db.SaveChanges() ;
            }
        }

        public List<Drugs> GetAllDrugs()
        {
            var list= _db.DrugDetails.ToList();
            return list;
        }

        public Drugs GetDrugById(int id)
        {
            var item = _db.DrugDetails.FirstOrDefault(c => c.DrugId == id);
            if (item == null)
            {
                return null;
            }
            else
            {
                return item;    
            }
        }

        public void UpdateDrug(int id, Drugs drug)
        {
            var item=_db.DrugDetails.FirstOrDefault(d => d.DrugId == id);
            if(item != null)
            {
                _db.Entry(item).CurrentValues.SetValues(drug);
                _db.SaveChanges();
            }
            
        }
    }
}
