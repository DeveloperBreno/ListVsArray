using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListVsArray.MyModel
{
    class PersonArrayPhones : Person
    {
        public PhoneNumber[] PhoneNumbers { get; set; }
    }
}
