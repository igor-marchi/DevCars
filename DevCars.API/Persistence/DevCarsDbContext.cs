using DevCars.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Persistence
{
    public class DevCarsDbContext
    {
        public DevCarsDbContext()
        {
            Cars = new List<Car>
            {
                new Car(1, "123ABC", "HONDA", "CIVIC", 2021, 100000, "CINZA", new DateTime(2021, 1, 1)),
                new Car(2, "456ABC", "TOYOTA", "COROLLA", 2021, 130000, "AZUL", new DateTime(2021, 1, 1)),
                new Car(3, "789ABC", "CHEVROLET", "ONIX", 2021, 80000, "BRANCO", new DateTime(2021, 1, 1)),
            };

            Customers = new List<Customer>
            {
                new Customer(1, "LUCIANO HANG", "1234567", new DateTime(1990, 1, 1)),
                new Customer(2, "GUSTAVO PEIXOTO", "1234567", new DateTime(1990, 1, 1)),
                new Customer(3, "GABRIEL NUNES", "1234567", new DateTime(1990, 1, 1)),
            };
        }

        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }
    }
}