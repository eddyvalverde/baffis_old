using baffis.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace baffis.BusinessLogic
{
    public class Currency : ICurrency
    {
        #region Atributos
        DataAccess.Interface.ICurrency articuloDataAccess;
        #endregion
        public Currency(DataAccess.Interface.ICurrency articuloDataAccess)
        {
            this.articuloDataAccess = articuloDataAccess;
        }

        public IActionResult Create(Model.Currency item)
        {
            return articuloDataAccess.Create(item);
        }

        public IActionResult Delete(Model.Currency item)
        {
            return articuloDataAccess.Delete(item);
        }

        public IEnumerable<Model.Currency> List()
        {
            return articuloDataAccess.List();
        }

        public IActionResult Read(Model.Currency item)
        {
            return articuloDataAccess.Read(item);
        }

        public IActionResult Update(Model.Currency item)
        {
            return articuloDataAccess.Update(item);
        }
    }
}
