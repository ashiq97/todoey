using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todoey.Models;

namespace Todoey.Controllers
{
    public class todoController : Controller
    {
        // GET: todo
        public ActionResult Index()
        {
            using (DbModels db = new DbModels())
            {

                return View(db.todoes.ToList());
            }

        }

        // GET: todo/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels db = new DbModels())
            {
                return View(db.todoes.FirstOrDefault(x => x.Id == id));
            }

                //return View();
        }

        // GET: todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: todo/Create
        [HttpPost]
        public ActionResult Create(todo todo)
        {
            try
            {
                // TODO: Add insert logic here

                using (DbModels db = new DbModels())
                {
                    if(ModelState.IsValid == true)
                    {
                        db.todoes.Add(todo);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: todo/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels db = new DbModels())
            {
                return View(db.todoes.FirstOrDefault(x => x.Id == id));
            }
        }

        // POST: todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, todo todo)
        {
            try
            {
                // TODO: Add update logic here

                using (DbModels db = new DbModels())
                {
                    db.Entry(todo).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: todo/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels db = new DbModels())
            {
                return View(db.todoes.FirstOrDefault(x => x.Id == id));
            }
            return View();
        }

        // POST: todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels db = new DbModels())
                {
                    todo todo = db.todoes.FirstOrDefault(x => x.Id == id);
                    db.todoes.Remove(todo);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
