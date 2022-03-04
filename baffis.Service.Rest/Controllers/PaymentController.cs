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
    public class PaymentController : ControllerBase
    {
        #region Atributos
        private readonly BusinessLogic.Interface.IPayment businessLogicPayment;

        #endregion
        public PaymentController(IPayment businessLogicPayment)
        {
            this.businessLogicPayment = businessLogicPayment;
        }
        // GET: api/<PaymentController>
        [HttpGet]
        public Task<IEnumerable<Model.Payment>> Get()
        {
            try
            {
                var items = businessLogicPayment.List();
                return Task.FromResult(items);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post(Model.Payment value)
        {
            try
            {
                var items = businessLogicPayment.Create(value);
                
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
