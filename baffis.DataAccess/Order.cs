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
    class Order : IOrder
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
                _connection.Open();
                /*var resultado1 = _connection.Query<Model.Articulo>(
                    "usp_ConsultaArticulos",
                    commandType: System.Data.CommandType.StoredProcedure);*/

                var resultado = _connection.Query<baffis.Model.Order, baffis.Model.Subscription, baffis.Model.Order>(
                    "usp_OrdersConsult",
                    map: (order, subscription) =>
                    {
                        order.Subscription = subscription;
                        return order;
                    },
                    splitOn: "IdMarca",
                    commandType: System.Data.CommandType.StoredProcedure);
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
