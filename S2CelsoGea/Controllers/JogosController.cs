using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using S2CelsoGea.Context.ContextModels;
using S2CelsoGea.Infra;

namespace S2CelsoGea.Controllers
{
    [CustomAuthorizeAttribute]
    public class JogosController : Controller
    {
        private S2CelsoGeaContext db = new S2CelsoGeaContext();

        // GET: Jogoes
        public ActionResult Index()
        {
            ViewBag.Users = db.Users.ToList();
            var jogosList = db.Jogos.Include("WithUser").ToList();
            return View(jogosList);
        }

        // GET: Jogoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,WithUser_Id")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogoes/Emprestar/5
        public ActionResult Emprestar(int? id)
        {
            ViewBag.Users = db.Users.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,WithUser_Id")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // POST: Jogoes/EditComEmprestimo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Emprestar([Bind(Include = "Id,Name,WithUser_Id")] Jogo jogo)
        {
            ViewBag.Users = db.Users.ToList();
            if (jogo.WithUser_Id == null || jogo.WithUser_Id < 0)
            {
                ModelState.AddModelError("WithUser_Id", "É necessário selecionar um Amigo para emprestar o jogo.");
                return View(jogo);
            }

            return Edit(jogo);
        }

        // GET: Jogoes/Devolucao/5
        public ActionResult Devolucao(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jogo jogo = db.Jogos.Find(id);
            jogo.WithUser_Id = null;
            return Edit(jogo);
        }


        // GET: Jogoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogos.Find(id);
            db.Jogos.Remove(jogo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
