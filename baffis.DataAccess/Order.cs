﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.DataAccess.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace baffis.DataAccess
{
    public class Order : IOrder
    {
        #region Atributos
        private readonly Interface.IConnectionManager connectionManager;

        #endregion
        public Order(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public IActionResult Create(Model.Order item)
        {
            throw new NotImplementedException();
        }

        

        public IActionResult Delete(Model.Order item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Order> List()
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var sqlcommand = "SELECT IDOrder,Subscriber,SubscribedOn,ExpiresOn,PaymentDay,o.Cost,o.IDSubscription, Title, Description, s.Cost FROM Orders o INNER JOIN SUBSCRIPTION s  ON o.IDSubscription = s.IDSubscription AND s.REMOVED=FALSE";
                _connection.Open();
                var resultado = _connection.Query<baffis.Model.Order, baffis.Model.Subscription, baffis.Model.Order>(
                    sqlcommand,
                    map: (order,subscription) =>
                    {
                        order.Subscription= subscription;
                        return order;
                    },
                    splitOn: "IDSubscription");
                _connection.Close();
                return resultado;
            }
        }

        public IActionResult Read(Model.Order item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idorder_val = item.IDOrder};
                var sqlcommand = "SELECT IDOrder,Subscriber,SubscribedOn,ExpiresOn,PaymentDay,o.Cost,o.IDSubscription, Title, Description, s.Cost FROM Orders o INNER JOIN SUBSCRIPTION s  ON o.IDSubscription = s.IDSubscription AND o.REMOVED = FALSE AND IDOrder = @idorder_val";
                _connection.Open();
                var result = _connection.Query<baffis.Model.Order, baffis.Model.Subscription, baffis.Model.Order>(
                    sql: sqlcommand,
                    param: parameters,
                    map: (order, subscription) =>
                    {
                        order.Subscription = subscription;
                        return order;
                    },
                    splitOn: "IDSubscription");
                _connection.Close();
                if (result.Count() == 1)
                {
                    return new OkObjectResult(result.First());
                }
                else
                {
                    return new NotFoundResult();
                }

            }
        }

        public IActionResult Update(Model.Order item)
        {
            throw new NotImplementedException();
        }
    }
}
