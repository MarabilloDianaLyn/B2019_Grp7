using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using AI_TaskM.Models;

namespace AI_TaskM.Controllers
{
    public class ToDosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ToDos
        public ActionResult Index()
        {

            dynamic dy = new ExpandoObject();
            return View();
        }
        public List<MainTask> getMainTasks()
        {
            List<MainTask> Ltask = db.MainTasks.ToList();
            return Ltask;
        }
        public List<ToDo> gettoddo()
        {
            List<ToDo> Ltodo = db.ToDos.ToList();
            return Ltodo;
        }
    }
    
}