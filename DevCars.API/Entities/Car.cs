using DevCars.API.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Car
    {
        public Car(int id, string vinCod, string brand, string model, int year, decimal price, string color, DateTime productionDate)
        {
            Id = id;
            VinCod = vinCod;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
            ProductionDate = productionDate;

            RegisteredAt = DateTime.Now;
            Status = CarStatusEnum.Available;
        }

        public int Id { get; private set; }
        public string VinCod { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public decimal Price { get; private set; }
        public string Color { get; private set; }
        public DateTime ProductionDate { get; private set; }

        public CarStatusEnum Status { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        public void Update(string color, decimal price)
        {
            Color = color;
            Price = price;
        }

        public void SetAsSusupended()
        {
            Status = CarStatusEnum.Suspended;
        }
    }
}