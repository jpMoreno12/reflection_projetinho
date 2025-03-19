using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeReflection
{
    public class User
    {
        public int Year {get; set;}
        public string Name {get; set;}

        public User()
        { 
            this.Year = 12;
            this.Name = "joao";
        }

        public User(int year, string name)
        {
            this.Year = year;
            this.Name = name;
        }
    }
}
