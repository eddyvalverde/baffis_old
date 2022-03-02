using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;


namespace baffis.DataAccess
{
    public class Currency : ICurrency
    {
        #region Atributos
        private readonly Interface.IConnectionManager connectionManager;


        #endregion
        public Currency(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public IActionResult Create(Model.Currency item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Model.Currency item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Currency> List()
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                _connection.Open();
                var resultado = _connection.Query<baffis.Model.Currency>(
                    "USP_LISTCURRENCY",
                    commandType: System.Data.CommandType.StoredProcedure);
                _connection.Close();
                return resultado;
            }
        }

        public IActionResult Read(Model.Currency item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Model.Currency item)
        {
            throw new NotImplementedException();
        }
    }
}
