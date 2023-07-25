using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HotelABC.Entities
{
    public  class SuiteNames
    {
        [Key]
        public int PkName { get; set; }
        public string NameS { get; set; }
    }
}
