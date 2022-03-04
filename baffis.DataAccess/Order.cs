using System;
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
                var sqlcommand = "SELECT o.IDSubscription,Subscriber,SubscribedOn,ExpiresOn,PaymentDay,o.Cost  Title, Description, s.Cost FROM ORDER o INNER JOIN SUBSCRIPTION s  ON o.IDSubscription = s.IDSubscription WHERE o.REMOVED=FALSE;";
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
            throw new NotImplementedException();
        }

        public IActionResult Update(Model.Order item)
        {
            throw new NotImplementedException();
        }
    }
}
