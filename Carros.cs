using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeReflection
{
    public class Car
    {
        public string Chassi { get; set; }

        public int Id { get; set; }

        public string Color { get; set; }

        private string _LabelPlate = "x3434DSFSDF";
        protected string LabelPlate { get => _LabelPlate; set => _LabelPlate = value; }


        public Car(string chassi, int id, string color)
        {
            this.Chassi = chassi;
            this.Id = id;
            this.Color = color;
        }

        public Car(string chassi, int id, string color, string labelPlate)
        {
            this.Chassi = chassi;
            this.Id = id;

            this.Color = color;
            this.LabelPlate = labelPlate;
        }
        public Car()
        {
            this.Chassi = "teste default";
            this.Id = 1234;

            this.Color = "cyano";
            this.LabelPlate = "12334234";

        }

    }
}
