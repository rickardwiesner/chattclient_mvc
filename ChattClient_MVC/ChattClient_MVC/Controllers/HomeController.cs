﻿using ChattClient_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChattClient_MVC.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            //    LitosServiceReference.ProductServiceClient serviceRef = new LitosServiceReference.ProductServiceClient();

            //    var products = serviceRef.GetProducts();

            //    return View(products.ToList());

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

        [HttpPost]
        public void SendMessage(string textInput)
        {
            ChattServiceReference.ChattServiceClient serviceRef = new ChattServiceReference.ChattServiceClient();

            var userId = User.Identity.GetUserId();
            var currentUser = context.Users.FirstOrDefault(x => x.Id == userId);

            var timeStamp = DateTime.Now;
            serviceRef.SendMessage(textInput, userId, currentUser.UserName, timeStamp);
        }
        [HttpGet]
        public ActionResult GetMessages()
        {
            ChattServiceReference.ChattServiceClient serviceRef = new ChattServiceReference.ChattServiceClient();

            var allMessages = serviceRef.GetAll();

            return View(allMessages.ToList());
        }

        [HttpGet]
        public int RollTheDice()
        {
            RobertRollTheDice.DiceServiceClient serviceDice = new RobertRollTheDice.DiceServiceClient();

            var numberOnDice = serviceDice.GetNumbers();

            return numberOnDice;
        }

        [HttpGet]
        public string GetQuote()
        {
            QuoteServiceRef.QuoteServiceClient serviceRef = new QuoteServiceRef.QuoteServiceClient();

            var quote = serviceRef.Get();

            return quote;
        }
    }
}