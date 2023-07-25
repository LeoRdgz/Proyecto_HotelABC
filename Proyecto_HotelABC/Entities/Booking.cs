using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HotelABC.Entities
{
    public class Booking
    {
        [Key]
        public int IdReservation { get; set; }

        public int Days { get; set; }

        public int AmountPerson { get; set; }

        public int Suite { get; set; }

        [ForeignKey("Count")]
        public int? CountId { get; set; }
        public Count User { get; set; }

        [ForeignKey("SuiteNames")]
        public int? SuiteId { get; set; }
        public SuiteNames SuiteName { get; set; }


    }
}
