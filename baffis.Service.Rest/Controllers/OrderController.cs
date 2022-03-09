using baffis.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace baffis.Service.Rest.Controllers
{
    [Route("api/v1.0/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Atributos
        private readonly BusinessLogic.Interface.IOrder businessLogicOrder;
        #endregion
        public OrderController(IOrder businessLogicOrder)
        {
            this.businessLogicOrder = businessLogicOrder;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public Task<IEnumerable<Model.Order>> Get()
        {
            try
            {
                var items = businessLogicOrder.List();
                return Task.FromResult(items);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            {
                try
                {
                    var items = businessLogicOrder.Read(new Model.Order(id));
                    return Task.FromResult(items);
                }
                catch (Exception e)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    throw;
                }
            }
        }

        [HttpGet("{subscriber}")]
        public Task<IActionResult> isSubscribed(string subscriber)
        {
            {
                try
                {
                    var items = businessLogicOrder.isSubscribed(subscriber);
                    return Task.FromResult(items);
                }
                catch (Exception e)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    throw;
                }
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post(Model.Order item)
        {
            try
            {
                businessLogicOrder.Create(item);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(Model.Order item)
        {
            try
            {
                businessLogicOrder.Update(item);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{subscriber}")]
        public void Delete(string subscriber)
        {
            try
            {
                    businessLogicOrder.Delete(new Model.Order(subscriber));
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }
    }
}
