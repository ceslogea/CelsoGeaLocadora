using S2CelsoGea.Context;
using S2CelsoGea.Context.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2CelsoGea.Controllers
{
    public class EmprestimoController : Controller
    {
        S2CelsoGeaContext db;
        Repo<Jogo> repo;
        public EmprestimoController()
        {
            repo = new Repo<Jogo>();
            db = new S2CelsoGeaContext();
        }

        // GET: Emprestimo
        public ActionResult Get()
        {
            db.Jogos.Include("WithUser").ToList();
            return View();
        }

        // GET: Emprestimo
        public ActionResult Post(int jogoId, int userId)
        {
            var jogoEmprestado = repo.First(jogoId);
            jogoEmprestado.WithUser_Id = userId;
            repo.Save(jogoEmprestado);

            return View("Index");
        }
    }
}
