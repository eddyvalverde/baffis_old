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
    class Subscription : ISubscription
    {
        #region Atributos
        private readonly Interface.IConnectionManager connectionManager;

        #endregion
        public Subscription(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }
        public IActionResult Create(Model.Subscription item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Model.Subscription item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Subscription> List()
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                _connection.Open();
                /*var resultado1 = _connection.Query<Model.Articulo>(
                    "usp_ConsultaArticulos",
                    commandType: System.Data.CommandType.StoredProcedure);*/

                var resultado = _connection.Query<baffis.Model.Subscription, baffis.Model.Currency, baffis.Model.Subscription>(
                    "usp_OrdersConsult",
                    map: (subscription, currency) =>
                    {
                        subscription.Currency = currency;
                        return subscription;
                    },
                    splitOn: "IdMarca",
                    commandType: System.Data.CommandType.StoredProcedure);
                _connection.Close();
                return resultado;
            }
        }

        public IActionResult Read(Model.Subscription item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Model.Subscription item)
        {
            throw new NotImplementedException();
        }
        
    }
}
