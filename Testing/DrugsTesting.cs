using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System;

namespace Testing
{
    public class DrugsTesting
    {
        DrugDAL d;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<PharmacyContextDb> bldr = new DbContextOptionsBuilder<PharmacyContextDb>();
            bldr.UseSqlServer(connectionString: @"Server=LAPTOP-SF5JKCA0\SQLEXPRESS;Database=PharmacyDb;Integrated Security=True;trusted_connection=true");
            PharmacyContextDb context = new PharmacyContextDb(bldr.Options);
            d = new DrugDAL(context);
        }

        [Test]
        public void GetAllDrugTesting()
        {

            //Act
            var res = d.GetAllDrugs();
            //Assert
            Assert.AreEqual(res != null, true);
        }
        [Test]
        public void GetAllDrugByID()
        {
            var res = d.GetDrugById(1);

            Assert.AreEqual(res!=null,true);
        }
        [Test]
        public void AddDrugTesting()
        {
            Drugs dr = new Drugs { 
                DrugId=0,
                DrugName="Paracetomal",
                DrugPrice=10,
                DrugQuantity=100,
                MfdDate= System.DateTime.Now,
                ExpDate=new DateTime(2023,02,03),
                SupplierId=2,
            };
            var res=d.AddDrug(dr);
            string req = "Drug is Successfully Added";
            Assert.AreEqual(req, res);
        }
        [Test]

        public void UpdateTesting()
        {
            Drugs dr = new Drugs
            {
                DrugId = 4,
                DrugName = "Paracetomal",
                DrugPrice = 10,
                DrugQuantity = 200,
                MfdDate = new DateTime(2021,03,04),
                ExpDate = new DateTime(2023, 02, 03),
                SupplierId = 2,
            };
            d.UpdateDrug(4,dr);
           var item= d.GetDrugById(4);
            Assert.AreEqual(dr.DrugQuantity,item.DrugQuantity);

        }
    }
}
