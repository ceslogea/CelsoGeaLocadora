using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using S2CelsoGea.Context.ContextModels;
using S2CelsoGea.Infra;

namespace S2CelsoGea.Controllers
{
    public class UsersController : Controller
    {
        private S2CelsoGeaContext db = new S2CelsoGeaContext();

        // GET: Users
        [CustomAuthorizeAttribute]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Email,Telefone,Password,ConfirmPassword")] User user)
        {
            var name = user.UserName.ToLowerInvariant();
            var usersList = db.Users.ToList();
            if (usersList.Any(r => r.UserName.ToLowerInvariant().Equals(name)))
            {
                ModelState.AddModelError(string.Empty, "Usuário já cadastrado.");
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        [CustomAuthorizeAttribute]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,Telefone,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [CustomAuthorizeAttribute]
        public ActionResult Delete(int? id)
        {
            ViewBag.IdInUse = false;
            if (db.Jogos.Any(r => r.WithUser_Id == id))
            {
                ModelState.AddModelError(string.Empty, "Este usuário possui um ou mais jogos emprestados, efetue a devolução para lberar ua exclusão.");
                ViewBag.IdInUse = true;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute]
        public ActionResult DeleteConfirmed(int id)
        {


            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region Login

        [HttpGet]
        [CustomAuthorizeAttribute]
        public ActionResult LogOut()
        {
            if (Session["USER"] != null)
                Session.Remove("USER");

            if (Session["USER_ID"] != null)
                Session.Remove("USER_ID");

            return View("login");
        }

        // GET: List
        [HttpGet]
        public ActionResult login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var db = new S2CelsoGeaContext())
            {
                var login = db.Users.FirstOrDefault(r => r.UserName.Equals(user.UserName) && r.Password.Equals(user.Password));

                if (login != null)
                {
                    Session["USER"] = login.UserName.ToString();
                    Session["USER_ID"] = login.Id.ToString();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou Senha Inválidos.");
                    return View();
                }


            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

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
