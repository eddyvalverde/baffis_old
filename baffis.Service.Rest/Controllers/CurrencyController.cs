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
    public class CurrencyController : ControllerBase
    {
        #region Atributos
        private readonly BusinessLogic.Interface.ICurrency businessLogicCurrency;
        #endregion
        public CurrencyController(ICurrency businessLogicCurrency)
        {
            this.businessLogicCurrency = businessLogicCurrency;
        }
        // GET: api/<CurrencyController>
        [HttpGet]
        public Task<IEnumerable<Model.Currency>> Get()
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

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            try
            {
                var item = businessLogicCurrency.Read(new Model.Currency(id));
                return Task.FromResult(item);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public void Post(Model.Currency value)
        {
            try
            {
                businessLogicCurrency.Create(value);                
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }

        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public void Put(Model.Currency value)
        {
            if (value.IdCurrency == 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;              
            }
            else
            {
                try
                {
                    businessLogicCurrency.Update(value);
                }
                catch (Exception e)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    throw;
                }
            }            
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                try
                {
                    businessLogicCurrency.Delete(new Model.Currency(id));
                }
                catch (Exception e)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    throw;
                }
            }
        }
    }
}
