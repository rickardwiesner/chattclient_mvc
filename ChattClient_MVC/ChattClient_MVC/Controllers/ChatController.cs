using ChattClient_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChattClient_MVC.Controllers
{
    public class ChatController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            ChattServiceReference.ChattServiceClient serviceRef = new ChattServiceReference.ChattServiceClient();

            var allMessages = serviceRef.GetAll();

            return View(allMessages.ToList());
        }
        public ActionResult SendMessage(string textInput)
        {
            ChattServiceReference.ChattServiceClient serviceRef = new ChattServiceReference.ChattServiceClient();

            var userId = User.Identity.GetUserId();
            var currentUser = context.Users.FirstOrDefault(x => x.Id == userId);

            var timeStamp = DateTime.Now;
            serviceRef.SendMessage(textInput, userId, currentUser.UserName, timeStamp);
            return Redirect("/Chat/Index");
        }
    }
}