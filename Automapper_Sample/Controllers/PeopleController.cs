using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automapper_Sample.Factory;
using Automapper_Sample.Factory.Concrete;
using Automapper_Sample.Models.ViewModels;

namespace Automapper_Sample.Controllers
{
    public class PeopleController : Controller
    {
        PersonFactory _factory = new PersonFactory();

        // GET: People
        public ActionResult Index()
        {
            return View(_factory.GetItems());
        }

        // GET: People/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_factory.GetItem(id));
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(PersonVM person)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_factory.GetItem(id));
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonVM person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _factory.UpdateItem(person);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
