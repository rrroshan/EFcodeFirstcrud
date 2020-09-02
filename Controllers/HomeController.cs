using EfCodeFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfCodeFirstApp.Controllers
{
    public class HomeController : Controller
    {
        StudenContext db = new StudenContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList(); 
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {

            if(ModelState.IsValid== true)
            {

                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //   ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";
                    TempData["InsertMessage"] = "<script>alert('Data Inserted !!')</script>";
                    TempData["Successfull"] = "Data Inserted Successfully !!";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

                else
                {

                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(Model => Model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid==true)
            {


                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //  ViewBag.UpdateMessage = "<script>alert('Data Updated!!')</script>";
                    TempData["UpdateInsertMessage"] = "<script>alert('Data Inserted !!')</script>";
                    TempData["SuccessfullUpdateparagraph"] = "Data Updated  Successfully !!";
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated!!')</script>";


                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var StudenIdRow = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(StudenIdRow);
        }

        [HttpPost]

        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"]=("<script>alert('Data Deleted!!')</script>");
            }
            else
            {
                TempData["DeleteMessage"] = ("<script>alert('Data Not Deleted!!')</script>");

            }
            return RedirectToAction("Index");
        }





    }
}