using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System.Data.Entity.Validation;
using NFB2TEntity.Models;

namespace NFB2TEntity.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private dbNF_B2TEntity db = new dbNF_B2TEntity();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var State = new StateModel();
            var City = new CityModel();

            ViewBag.States = State.getAllStates();
            ViewBag.Cities = City.getAllCities();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCliente Client, ClientModel modelClient)
        {
            var State = new StateModel();
            var City = new CityModel();

            ViewBag.States = State.getAllStates();
            ViewBag.Cities = City.getAllCities();

            if (Client.codCidade > 0)
            {
                var tblCity = City.getTblCidadeById(Client.codCidade);
                ViewData["City"] = tblCity;
                ViewData["State"] = tblCity.tblUF;
            }
            else
            {
                ViewData["City"] = new tblCidade();
                ViewData["State"] = new tblUF();
            }

            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(Client.nuCPF) && String.IsNullOrEmpty(Client.nuCNPJ))
                {
                    TempData["WarningMessage"] += "É necessário o preenchimento do CPF ou do CNPJ do destinatário.";
                    return View(modelClient);
                }
                else if (Client.codCidade < 1)
                {
                    TempData["WarningMessage"] += "É necessário escolher a Cidade do cliente.";
                    return View(modelClient);
                }
                else
                {
                    try
                    {
                        db.tblClientes.Add(Client);
                        db.SaveChanges();
                        TempData["SucessMessage"] = "Cliente salvo no banco de dados.";
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                TempData["ErrorMessage"] = "Propriedade: " + validationError.PropertyName + ". Error: " + validationError.ErrorMessage;
                            }
                        }
                        return View(modelClient);
                    }

                }
            }
            else
            {
                TempData["ErrorMessage"] = "Verifique se todos os campos obrigatórios foram preenchidos corretamente.";
                return View(modelClient);
            }

            return View();

        }

        [HttpGet]
        public ActionResult Search()
        {
            var State = new StateModel();
            var City = new CityModel();

            ViewBag.States = State.getAllStates();
            ViewBag.Cities = City.getAllCities();

            return View();
        }

        [HttpPost]
        public ActionResult Search(ClientModel Client)
        {

            var State = new StateModel();
            var City = new CityModel();

            ViewBag.States = State.getAllStates();
            ViewBag.Cities = City.getAllCities();

            if (Client.codCidade > 0)
            {
                var tblCity = City.getTblCidadeById(Client.codCidade);
                ViewData["City"] = tblCity;
                ViewData["State"] = tblCity.tblUF;
            }
            else
            {
                ViewData["City"] = new tblCidade();
                ViewData["State"] = new tblUF();
            }

            ViewBag.ClientList = Client.searchClient();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var Client = new ClientModel(id);
            if (Client == null)
            {
                TempData["ErrorMessage"] = "Cliente não encontrado na base de dados. Favor pesquisar um cliente existente!";
                return RedirectToAction("Index", "Client");
            }

            ViewBag.States = db.tblUFs.ToList();

            ViewBag.Cities = db.tblCidades.ToList();

            var City = new CityModel();
            var tblCity = City.getTblCidadeById(Client.codCidade);
            ViewData["City"] = tblCity;
            ViewData["State"] = tblCity.tblUF;


            return View(Client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCliente Client, ClientModel modelClient)
        {
            var State = new StateModel();
            var City = new CityModel();

            ViewBag.States = State.getAllStates();
            ViewBag.Cities = City.getAllCities();

            if (Client.codCidade > 0)
            {
                var tblCity = City.getTblCidadeById(Client.codCidade);
                ViewData["City"] = tblCity;
                ViewData["State"] = tblCity.tblUF;
            }
            else
            {
                ViewData["City"] = new tblCidade();
                ViewData["State"] = new tblUF();
            }

            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(Client.nuCPF) && String.IsNullOrEmpty(Client.nuCNPJ))
                {
                    TempData["WarningMessage"] += "É necessário o preenchimento do CPF ou do CNPJ do destinatário.";
                    return View(modelClient);
                }
                else if (Client.codCidade < 1)
                {
                    TempData["WarningMessage"] += "É necessário escolher a Cidade do cliente.";
                    return View(modelClient);
                }
                else
                {
                    try
                    {
                        db.Entry(Client).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["SucessMessage"] = "Cliente atualizado no banco de dados.";
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                TempData["ErrorMessage"] = "Propriedade: " + validationError.PropertyName + ". Error: " + validationError.ErrorMessage;
                            }
                        }
                        return View(modelClient);
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Verifique se todos os campos obrigatórios foram preenchidos corretamente.";
                return View(modelClient);
            }
            return RedirectToAction("Index", "Client");
        }

        public ActionResult AjaxDeleteClient(string idClient)
        {
            tblCliente dbClient = db.tblClientes.Find(Convert.ToInt32(idClient));

            try
            {
                db.tblClientes.Remove(dbClient);
                db.SaveChanges();
                TempData["SucessMessage"] = "Cliente excluido do banco de dados.";
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        TempData["ErrorMessage"] = "Propriedade: " + validationError.PropertyName + ". Error: " + validationError.ErrorMessage;
                    }
                }
            }

            return Json(new
            {
                RedirectUrl = Url.Action("Search","Client")

            }, JsonRequestBehavior.AllowGet);
        }

    }
}
