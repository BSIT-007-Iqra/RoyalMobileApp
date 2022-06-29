using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMobileApp.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
       public int UserID { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public string Password { get; set; }
    }
}
