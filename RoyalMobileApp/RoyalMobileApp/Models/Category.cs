using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMobileApp.Models
{
    public class Category
    {
        [PrimaryKey,AutoIncrement]
       public int CategoryID { get; set; }
       public string CatName { get; set; }
       public string Detail { get; set; }
       public string Image{ get; set; }
    }
}
