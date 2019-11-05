using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string model, string color, string registrationNumber)
        {
            Model = model;
            Color = color;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            return $"Model: {Model}, Color: {Color}, RegistrationNumber: {RegistrationNumber}";
        }
    }
}
