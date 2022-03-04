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
    public class Subscription : ISubscription
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
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new {title_val = item.Title, description_val = item.Description, cost_val = item.Cost, idcurrency_val = item.Currency.IdCurrency};
                
                var sql = "INSERT INTO SUBSCRIPTION(Title,Description,Cost,IdCurrency) VALUES(@title_val,@description_val, @cost_val, @idcurrency_val);";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }

        public IActionResult Delete(Model.Subscription item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idsubscription_val = item.IdSubscription };

                var sql = "UPDATE SUBSCRIPTION " +
                    "SET REMOVED = TRUE" +
                    " WHERE IdSUBSCRIPTION = @idsubscription_val;";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }

        public IEnumerable<Model.Subscription> List()
        {            
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var sqlcommand = "SELECT IdSUBSCRIPTION, Title, Description, Cost, s.IdCurrency,COUNTRY,NAME,CODE,SYMBOL FROM SUBSCRIPTION s INNER JOIN CURRENCY c ON s.IdCurrency = c.IdCurrency WHERE s.REMOVED=FALSE;";
                _connection.Open();
                var resultado = _connection.Query<baffis.Model.Subscription, baffis.Model.Currency, baffis.Model.Subscription>(
                    sqlcommand,
                    map: (subscription, currency) =>
                    {
                        subscription.Currency = currency;
                        return subscription;
                    },
                    splitOn: "IdCurrency");
                _connection.Close();
                return resultado;
            }
        }

        public IActionResult Read(Model.Subscription item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idsubscription_val = item.IdSubscription};
                var sqlcommand = "SELECT IdSUBSCRIPTION, Title, Description, Cost, s.IdCurrency,COUNTRY,NAME,CODE,SYMBOL FROM SUBSCRIPTION s,CURRENCY c WHERE s.IdCurrency = c.IdCurrency AND s.IdSUBSCRIPTION=@idsubscription_val AND s.REMOVED=FALSE;";
                _connection.Open();
                var result = _connection.Query<baffis.Model.Subscription, baffis.Model.Currency, baffis.Model.Subscription>(
                    sql:sqlcommand,
                    param:parameters,
                    map: (subscription, currency) =>
                    {
                        subscription.Currency = currency;
                        return subscription;
                    },
                    splitOn: "IdCurrency");
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

        public IActionResult Update(Model.Subscription item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idsubscription_val = item.IdSubscription,title_val = item.Title, description_val = item.Description, cost_val = item.Cost, idcurrency_val = item.Currency.IdCurrency };

                var sql = "UPDATE SUBSCRIPTION " +
                    "SET Title = @title_val, Description = @description_val, Cost = @cost_val, IdCurrency = @idcurrency_val " +
                    "WHERE IdSUBSCRIPTION = @idsubscription_val AND REMOVED=FALSE;";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }
        
    }
}
