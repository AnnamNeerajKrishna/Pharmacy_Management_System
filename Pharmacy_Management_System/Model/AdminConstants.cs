using System.Collections.Generic;

namespace Pharmacy_Management_System.Model
{
    public class AdminConstants
    {
        public static List<Admin> _admin = new List<Admin>()
        {
            new Admin(){AdminName="admin2",Contact="1234567891",EmailID="admin2@gmail.com",Password="admin2",Role="administrator" },
            new Admin(){AdminName="admin",Contact="1234567895",EmailID="admin@gmail.com",Password="admin",Role="administrator"}
        };
    }
}
