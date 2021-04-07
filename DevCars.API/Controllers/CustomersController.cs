using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;

        public CustomersController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(4, model.FullName, model.Document, model.BirthDate);
            _dbContext.Customers.Add(customer);

            return NoContent();
        }

        [HttpPost("{id}/orders")]
        public IActionResult CreateOrder(int id, [FromBody] AddOrderInputModel model)
        {
            var extraItems = model.ExtraItems.Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);

            if (car == null)
            {
                return NotFound("car not founded");
            }

            var order = new Order(1, model.IdCar, model.IdCustomer, car.Price, extraItems);

            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == model.IdCustomer);

            if (customer == null)
            {
                return NotFound("customer not founded");
            }

            customer.Purchase(order);

            return CreatedAtAction(nameof(GetOrder), new { id = customer.Id, orderId = order.Id }, model);
        }

        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound("Customer not founded");
            }

            var order = customer.Orders.SingleOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound("Order not founded");
            }

            var extraItems = order.ExtraItems.Select(e => e.Description).ToList();

            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, order.TotalCost, extraItems);

            return Ok(orderViewModel);
        }
    }
}