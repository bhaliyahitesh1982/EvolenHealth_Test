using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentHealth.Models
{
    public class CustomListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // can be add other parameters to manage the required properties

        // Can be use DataContext or the data connection to manage Data 
    }
}