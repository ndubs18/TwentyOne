using Casino;
using Casino.TwentyOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwentyOneWebApp.Controllers
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
        [HttpPost]
        public ActionResult Play(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", player);
            }
            TwentyOneGame game = new TwentyOneGame();
            game.Players.Add(player);
            player.isActivelyPlaying = true;
            player.Hand = new List<Card>();
            player.Stay = false;
            game.Dealer = new TwentyOneDealer()
            {
                Hand = new List<Card>(),
                Stay = false,
                Deck = new Deck(),
            };
            game.Dealer.Deck.Shuffle();
            return View(game);
        }
    }
}