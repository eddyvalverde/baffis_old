using baffis.DataAccess.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.DataAccess
{
    public class Payment : IPayment
    {
        #region Atributos
        private readonly Interface.IConnectionManager connectionManager;
        #endregion
        public Payment(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        

        public IActionResult Create(Model.Payment item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idorder_val = item.order.IDOrder };

                var sql = "INSERT INTO Payment(IDOrder,PaymentDate) VALUES(@idorder_val,NOW());";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }

        public IEnumerable<Model.Payment> List()
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var sqlcommand = "SELECT IdPayment, PaymentDate, p.cost, p.IDOrder,SubscribedOn,ExpiresOn,PaymentDay,o.Cost FROM PAYMENT p INNER JOIN ORDERS o ON p.IDOrder = o.IDOrder WHERE p.REMOVED=FALSE;";
                _connection.Open();
                var resultado = _connection.Query<baffis.Model.Payment, baffis.Model.Order, baffis.Model.Payment>(
                    sqlcommand,
                    map: (payment, order) =>
                    {
                        payment.order = order;
                        return payment;
                    },
                    splitOn: "IDOrder");
                _connection.Close();
                return resultado;
            }
        }
    }
}
