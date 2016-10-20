using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Store.Models;
using System;

namespace Store.Controllers
{
    public class CartsController : Controller
    {
        private CodingTempleECommerceEntities db = new CodingTempleECommerceEntities();

        // GET: Carts
        public ActionResult Index()
        {
            string sesKey = null;

            try
            {
                sesKey = Session["SessionKey"].ToString();
            }
            catch (NullReferenceException)
            {
                return View();
            }

            var carts = db.Carts.Where(c => c.SessionKey == sesKey).Include(c => c.Product).Include(c => c.User);
           
            return View(carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SessionKey,Qty,UserID,ProductID,DateCreated")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "Id", "ProductName", cart.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", cart.UserID);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "Id", "ProductName", cart.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", cart.UserID);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SessionKey,Qty,UserID,ProductID,DateCreated,ProductPrice")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "Id", "ProductName", cart.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", cart.UserID);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
