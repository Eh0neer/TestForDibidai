using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForDibiai.Model
{
    public class Abonent
    {
        public int Id { get; set; }
        public required string FName { get; set; }
        public required string LName { get; set; }
        public string? MName { get; set; }
        public required Address Address { get; set; }
        public required List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
