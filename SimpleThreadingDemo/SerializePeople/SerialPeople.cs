using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    public class SerialPeople
    {
        public readonly Person p = null;

        public static void Main(string[] args)
        {
        }

        public SerialPeople()
        {
            p = new Person("John", new DateTime(2000,10,1), Person.Gender.Male);
        }
        
    }
}
