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
        private readonly BusinessLogic.Interface.IOrder businessLogicCurrency;
        #endregion
        // GET: api/<OrderController>
        [HttpGet]
        public Task<IEnumerable<Model.Order>> Get()
        {
            try
            {
                var articulos = businessLogicCurrency.List();
                return Task.FromResult(articulos);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
