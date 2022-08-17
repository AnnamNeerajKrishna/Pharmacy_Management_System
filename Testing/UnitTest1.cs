using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;

namespace Testing
{
    public class Tests
    {

        SupplierDAL s;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<PharmacyContextDb> bldr = new DbContextOptionsBuilder<PharmacyContextDb>();
            bldr.UseSqlServer(connectionString: @"Server=LAPTOP-SF5JKCA0\SQLEXPRESS;Database=PharmacyDb;Integrated Security=True;trusted_connection=true");
            PharmacyContextDb context = new PharmacyContextDb(bldr.Options);
            s = new SupplierDAL(context);
        }

        [Test]
        

        public void SupplierGetTesting()
        {
            
            //Act
            var res = s.GetSupplier(2);
            //Assert
            Assert.AreEqual(res!=null,true);
        }

        [Test]
        public void SupplierPostTesting()
        {
            Supplier su=new Supplier { 
                SupplierId=0,
                SupplierName= "Bhargava",
                EmailID= "Bhargava@gmail.com",
                Contact= "7894562136",
                DrugAvailable= "Hold"

            };
            var res = s.AddSupplier(su);
            string req = "Supplier Added Successfully";
            Assert.AreEqual(res, req);
        }
        [Test]

        public void SupplierDeleteTesting()
        {
            var res=s.DeleteSupplier(3);
          //  Supplier supplier = new Supplier();

            Assert.AreEqual(res!=null,true);

        }
    }
}