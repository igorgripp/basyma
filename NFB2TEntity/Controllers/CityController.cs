using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFB2TEntity.Models;

namespace NFB2TEntity.Controllers
{
    public class CityController : Controller
    {
        
        public ActionResult AjaxCities(string idState)
        {
            CityModel obCity = new CityModel();
            List<tblCidade> listDBCities = obCity.getCitiesByState(Convert.ToInt32(idState));

            List<CityModel> listModelCities = new List<CityModel>();
            foreach (tblCidade dbCity in listDBCities)
            {
                CityModel obCityAux = new CityModel();
                obCityAux.codCidade = dbCity.codCidade;
                obCityAux.codUF = dbCity.codUF;
                obCityAux.noCidade = dbCity.noCidade;

                listModelCities.Add(obCityAux);
            }

            return Json(listModelCities, JsonRequestBehavior.AllowGet);

        }

    }
}
