using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForDibiai.Model
{
    public class Address
    {
        public int Id { get; set; }
        public required Street Street { get; set; }
        public required string HouseNumber { get; set; }
    }
}
