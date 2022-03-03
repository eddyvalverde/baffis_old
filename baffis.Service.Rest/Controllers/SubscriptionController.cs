﻿using baffis.BusinessLogic.Interface;
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
    public class SubscriptionController : ControllerBase
    {
        #region Atributos
        private readonly BusinessLogic.Interface.ISubscription businessLogicSubscription;
        #endregion
        public SubscriptionController(ISubscription businessLogicSubscription)
        {
            this.businessLogicSubscription = businessLogicSubscription;
        }
        // GET: api/<SubscriptionController>
        [HttpGet]
        public Task<IEnumerable<Model.Subscription>> Get()
        {
            try
            {
                var items = businessLogicSubscription.List();
                return Task.FromResult(items);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }

        // GET api/<SubscriptionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubscriptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}