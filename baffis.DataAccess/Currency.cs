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
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { country_val=item.Country, name_val=item.Name, code_val=item.Code, symbol_val=item.SYMBOL };
                var sql = "CALL usp_createcurrency(@country_val, @name_val, @code_val, @symbol_val);";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }

        public IActionResult Delete(Model.Currency item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idcurrency_val = item.IdCurrency};
                var sql = "CALL usp_deletecurrency(@idcurrency_val);";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
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
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idcurrency_val = item.IdCurrency};
                var sql = "usp_readcurrency";
                
                _connection.Open();

                var resultado = _connection.Query<baffis.Model.Currency>(
                    sql: sql, param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                _connection.Close();
                
                return new OkObjectResult(resultado.First());
            }
        }

        public IActionResult Update(Model.Currency item)
        {
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
                var parameters = new { idcurrency_val=item.IdCurrency,country_val = item.Country, name_val = item.Name, code_val = item.Code, symbol_val = item.SYMBOL };
                var sql = "CALL usp_updatecurrency(@idcurrency_val,@country_val, @name_val, @code_val, @symbol_val);";

                _connection.Open();

                var resultado = _connection.Execute(
                    sql: sql, param: parameters);
                _connection.Close();

                return new OkObjectResult("200");
            }
        }
    }
}
