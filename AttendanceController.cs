using SOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SOP.Controllers
{
    public class AttendanceController : Controller
    {
        SOPDbContext sop = new SOPDbContext();
        // GET: Class
        [Authorize(Roles = "Teacher")]
        public ActionResult Class()
        {
            var classes = sop.Classes.ToList();
            return View(classes);
        }

        public ActionResult ClassView()
        {
            var classes = sop.Classes.ToList();
            return View(classes);
        }

        // GET Students from Class
        [Authorize(Roles = "Teacher")]
        public ActionResult Student(string id)
        {

            Session["ClassID"] = id.ToString();

            var name = sop.Classes.Where(c => c.Class_ID == id).Single();
            ViewBag.Message = name.Class_Name;

            var students = sop.Students.Where(c => c.Class_ID == id).ToList();

            return View(students);
        }

        //Mark Attendance
        [Authorize(Roles = "Teacher")]
        public ActionResult Save(string[] Attendance, string[] grno, DateTime date)
        {
            string cid = Session["ClassID"].ToString();

            for (int i = 0; i < grno.Length; i++)
            {
                if (ModelState.IsValid)
                {
                    sop.Attendances.Add(new Attendance
                    {
                        Attendance_Status = Attendance[i],
                        Std_GRNO = grno[i],
                        Class_ID = cid,

                        Attendance_Date = date
                    });
                    sop.SaveChanges();
                }
            }
            return RedirectToAction("Class");
        }

        [Authorize]
        public ActionResult Index(string id)
        {
            // string cid = Session["ClassID"].ToString();
            Console.WriteLine(id);
            
             var name = sop.Classes.Where(c => c.Class_ID == id).Single();

            
            ViewBag.Message = name.Class_Name;

            Dictionary<string, string> dict = new Dictionary<string, string>();

            var vmAttendance = new SOP.ViewModel._AttendanceViewModel();

            vmAttendance.students= sop.Students.Where(c => c.Class_ID == id).ToList();

            vmAttendance.dates = sop.Attendances.Where(c => c.Class_ID == id)
                .GroupBy(a => a.Attendance_Date)
                .Select(a => a.Key);

            string key;

            foreach(var item in sop.Attendances)
            {
                key = item.Std_GRNO + "-" + item.Attendance_Date;
                dict.Add(key, item.Attendance_Status);
            }

            vmAttendance.dict = dict;


            return View(vmAttendance);
        }





    }
}