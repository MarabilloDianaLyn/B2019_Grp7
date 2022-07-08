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
    public class MainTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: MainTasks
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            List<MainTask> maintasks;

            maintasks = db.MainTasks.ToList();

            return View(maintasks.Where(x => x.User == currentUser));
        }
       
        public ActionResult todoIndex()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            var maintasks = db.MainTasks.Include("ToDos").ToList();
                      
            return View(maintasks.Where(x => x.User == currentUser));
        }


        // GET: MainTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                MainTask mainTask = db.MainTasks
                .Include(t => t.ToDos)
                .Where(m => m.Id == id).FirstOrDefault();
            if (mainTask == null)
            {
                return HttpNotFound();
            }
            return View(mainTask);
        }

        // GET: MainTasks/Create
        [HttpGet]
        public ActionResult Create()
        {
            MainTask mainTask = new MainTask();
            mainTask.ToDos.Add(new ToDo() { TodoId = 1 });
            return View(mainTask);
        }

        // POST: MainTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainTask mainTask)
        {
            if (ModelState.IsValid)
            {
                mainTask.ToDos.RemoveAll(n => n.Description == "0");

                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                mainTask.User = currentUser;
                db.MainTasks.Add(mainTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(mainTask);
        }

        // GET: MainTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainTask mainTask = db.MainTasks
            .Include(t => t.ToDos)
            .Where(m => m.Id == id).FirstOrDefault();
            return View(mainTask);
        }

        // POST: MainTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainTask mainTask)
        {

            List<ToDo> todoDetails = db.ToDos.Where(d => d.TaskId==mainTask.Id).ToList();
            db.ToDos.RemoveRange(todoDetails);
            db.SaveChanges();


            IEnumerable<ToDo> myToDoes = db.ToDos.ToList().Where(d => d.TaskId == mainTask.Id);

            int completeCount = 0;
            foreach (ToDo toDo in myToDoes)
            {
                if (toDo.isDone)
                {
                    completeCount++;
                }
            }
            

            ViewBag.Percent = Math.Round(100f * ((float)completeCount / (float)todoDetails.Count()));
            ViewBag.count = completeCount;
            ViewBag.dd = 0;

                mainTask.ToDos.RemoveAll(n => n.Description == "0");

            db.MainTasks.Add(mainTask);
            db.Entry(mainTask).State = EntityState.Modified;
            db.ToDos.AddRange(mainTask.ToDos);
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: MainTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                MainTask mainTask = db.MainTasks
                .Include(t => t.ToDos)
                .Where(m => m.Id == id).FirstOrDefault();
            
            if (mainTask == null)
            {
                return HttpNotFound();
            }
            return View(mainTask);
        }

        // POST: MainTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            MainTask mainTask = db.MainTasks.Find(id);
            db.MainTasks.Remove(mainTask);
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

        [HttpGet]
        public ActionResult ViewTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainTask mainTask = db.MainTasks
            .Include(t => t.ToDos)
            .Where(m => m.Id == id).FirstOrDefault();
            return View(mainTask);
        }

        // POST: MainTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewTask(MainTask mainTask)
        {
            List<ToDo> todoDetails = db.ToDos.Where(d => d.TaskId == mainTask.Id).ToList();
            db.ToDos.RemoveRange(todoDetails);
            db.SaveChanges();

            mainTask.ToDos.RemoveAll(n => n.Description == "0");

            db.MainTasks.Add(mainTask);
            db.Entry(mainTask).State = EntityState.Modified;
            db.ToDos.AddRange(mainTask.ToDos);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        

    }
}
