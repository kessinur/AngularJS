using AngularASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularASPNET.Controllers
{
    public class ClubController : Controller
    {
        private MyContext myContext = null;

        public ClubController()
        {
            myContext = new MyContext();
        }
        // GET: Club
        public JsonResult GetClubs()
        {
            List<Club> listClubs = myContext.Clubs.ToList();
            return Json(new { list = listClubs }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClubById(int id)
        {
            Club club = myContext.Clubs.Where(x => x.ClubId == id).SingleOrDefault();
            return Json(new { club = club }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddClub(Club club)
        {
            myContext.Clubs.Add(club);
            myContext.SaveChanges();
            return Json(new { status = "Club is added successfully" });
        }

        public JsonResult UpdateClub(Club club)
        {
            myContext.Entry(club).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Club is updated successfully" });
        }

        public JsonResult DeleteClub(int id)
        {
            Club club = myContext.Clubs.Where(x => x.ClubId == id).SingleOrDefault();
            myContext.Clubs.Remove(club);
            myContext.SaveChanges();
            return Json(new { status = "Club is deleted successfully" });
        }
    }
}