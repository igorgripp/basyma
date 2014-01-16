using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using NFB2TEntity.Models;

namespace NFB2TEntity.Controllers
{
    public class UserController : Controller
    {
        private dbNF_B2TEntity db = new dbNF_B2TEntity();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.tblUsuarios.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            tblUsuario usuario = db.tblUsuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.tblUsuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblUsuario usuario = db.tblUsuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblUsuario usuario = db.tblUsuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuario usuario = db.tblUsuarios.Find(id);
            db.tblUsuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NFB2TEntity.Models.LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if(login.IsValid(login.dcLogin, login.dcSenha)){
                    var user = new UserModel(login.dcLogin, login.dcSenha);
                    FormsAuthentication.SetAuthCookie(user.noUsusario, false);
                }else{
                    TempData["ErrorMessage"] = "Usuário e/ou senha incorreto(s)!";
                }
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}