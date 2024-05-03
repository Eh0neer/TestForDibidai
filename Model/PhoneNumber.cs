using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForDibiai.Model
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public PhoneNumberType Type { get; set; }
        public required string Number { get; set; }
    }

    public enum PhoneNumberType
    {
        Home,
        Work,
        Mobile

    }
}
