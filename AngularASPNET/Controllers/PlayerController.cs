using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularASPNET.Models;
using AngularASPNET.Param;

namespace AngularASPNET.Controllers
{
    public class PlayerController : Controller
    {
        private MyContext myContext = null;
        Player player = new Player();
        public PlayerController()
        {
            myContext = new MyContext();
        }
        // GET: Player
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = myContext.Players.ToList();
            return Json(new { list = listPlayers }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int? id)
        {
            Player player = myContext.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(PlayerParam playerParam)
        {
            player.Name = playerParam.Name;
            player.Country = playerParam.Country;
            player.Age = playerParam.Age;
            player.Clubs = myContext.Clubs.Find(playerParam.Club_Id);
            myContext.Players.Add(player);
            myContext.SaveChanges();
            return Json(new { status = "Player is added successfully" });
        }

        [HttpPost]
        public JsonResult EditPlayer(PlayerParam playerParam)
        {
            var play = myContext.Players.Where(x => x.PlayerId == playerParam.PlayerId).SingleOrDefault();
            play.Name = playerParam.Name;
            play.Country = playerParam.Country;
            play.Age = playerParam.Age;
            play.Clubs = myContext.Clubs.Find(playerParam.Club_Id);
            myContext.Entry(play).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Player is updated successfully" });
        }

        public JsonResult DeletePlayer(int id)
        {
            Player player = myContext.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            myContext.Players.Remove(player);
            myContext.SaveChanges();
            return Json(new { status = "Player is deleted successfully" });
        }
    }
}