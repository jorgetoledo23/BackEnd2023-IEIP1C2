using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public string getInfo()
        {
            return $"DNI: {DNI}, LastName: {LastName}, Name: {Name}";
        }

    }

}
