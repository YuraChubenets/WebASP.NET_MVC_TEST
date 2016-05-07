using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC_AngularJS.Models;

namespace WebAppMVC_AngularJS.Controllers
{
    public class PeopleController : Controller
    {
        private DataContext _db = new DataContext();
       

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: All People
        public JsonResult getAllPeoples()
        {
            var peopleList = _db.People.ToList();
            return Json(peopleList, JsonRequestBehavior.AllowGet);
        }

        // GET: People/Details/"nickName"
        public ActionResult getPeopleByNickName(string nickName)
        {
            if (string.IsNullOrWhiteSpace(nickName) && string.IsNullOrEmpty(nickName) )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            People people =  _db.People.FirstOrDefault(p=>p.NickName==nickName);
            if (people == null)
            {
                return null;
            }

            return Json(people, JsonRequestBehavior.AllowGet);
        }

        // POST: People/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]       
        public string AddPeople(People people)
        {
            var flag = false;
            flag = _db.People.Any(p => p.NickName == people.NickName);

            if (ModelState.IsValid & !flag)
            {
                _db.People.Add(people);
                _db.SaveChanges();
                return "people insert";
            }
            else
            {
                return "Invalid People";
            }           
        }

        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
