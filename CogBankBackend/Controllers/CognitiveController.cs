using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CogBankBackend.Models;

namespace CogBankBackend.Controllers
{
    public class CognitiveController : Controller
    {
        // GET: Cognitive
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cognitive
        public ActionResult Vision()
        {
            // Computer Vision
            // Content Moderator
            // Custom Vision Service
            // Emotion API
            // Face API
            // Video Indexer

            CognitiveModel cognitiveModel = new CognitiveModel();

            if (cognitiveModel.cognitiveFeature == "false")
            {
                // do something
            }
            return View();
        }

        // GET: Cognitive
        public ActionResult Speech()
        {
            // Bing Speech Service
            // Custom Speech
            // Speaker Recognition
            // Translator Speech
            return View();
        }
    }
}