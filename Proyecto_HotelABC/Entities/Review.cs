using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records;

namespace Proyecto_HotelABC.Entities
{
    public class Review
    {
        [Key] public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ReviewDate { get; set; }
        public decimal Rating { get; set; }
    }
}
