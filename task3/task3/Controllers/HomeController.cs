﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task3.Models;
using task3.Utils;

namespace task3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendEmail()
        {
            return View(new Email());
        }

        [HttpPost]
        public ActionResult SendEmail(Email model, HttpPostedFileBase postedFile)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    model.filename = postedFile.FileName;

                    string serverPath = Server.MapPath("~/Uploads/");
                    model.Path = serverPath + model.filename;
                    postedFile.SaveAs(model.Path);

                    EmailSending es = new EmailSending();
                    es.Send(toEmail, subject, contents, model.filename, model.Path);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new Email());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

       
    }
}