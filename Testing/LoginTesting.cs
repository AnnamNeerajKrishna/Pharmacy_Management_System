using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System;


namespace Testing
{
    public class LoginTesting
    {
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<PharmacyContextDb> bldr = new DbContextOptionsBuilder<PharmacyContextDb>();
            bldr.UseSqlServer(connectionString: @"Server=LAPTOP-SF5JKCA0\SQLEXPRESS;Database=PharmacyDb;Integrated Security=True;trusted_connection=true");
            PharmacyContextDb context = new PharmacyContextDb(bldr.Options);
            
        }
        //Test]

    }
}
