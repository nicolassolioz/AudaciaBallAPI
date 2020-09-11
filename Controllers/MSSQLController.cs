using AudaciaBallAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AudaciaBallAPI.Services;
using System.Web.Http;
using Newtonsoft.Json;

namespace AudaciaBallAPI.Controllers
{
    public class MssqlController : Controller
    {
        private string Name;
        private MssqlRepository mssqlRepository;
        // GET: MSSQL
        public ActionResult Index()
        {
            return View();
        }

        public MssqlController()
        {
            
        }

        [System.Web.Http.Route("{name:string}")]
        [System.Web.Http.HttpGet]
        public string AddPlayer(string name)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddPlayer(name);
            return "done";
        }


        [System.Web.Http.Route("{name:string}/{idPlayer1:int}/{idPlayer2:int}")]
        [System.Web.Http.HttpGet]
        public string AddTeam(string name, int idPlayer1, int idPlayer2)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddTeam(idPlayer1, idPlayer2);
            this.mssqlRepository.AddPlayerTeam(name, this.mssqlRepository.GetLastInsertedTeam());
            return "done";
        }

        [System.Web.Http.Route("{scoreBlue:int}/{scoreRed:int}/{idPlayerBlue:int}/{idPlayerRed:int}")]
        [System.Web.Http.HttpGet]
        public string AddGame(int scoreBlue, int scoreRed, int idPlayerBlue, int idPlayerRed)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddGame(scoreBlue, scoreRed, idPlayerBlue, idPlayerRed);
 
            return "done";
        }

        [System.Web.Http.Route("{int:idPlayer")]
        [System.Web.Http.HttpGet]
        public string GetGameHistory(int idPlayer)
        {
            this.mssqlRepository = new MssqlRepository(); 
            List<Game> results = this.mssqlRepository.GetGameHistory(idPlayer);
            string result = "";

            foreach (Game game in results)
            {
                result += game.idGame + " " + game.scoreBlue + " - " + game.scoreRed + "<br />";
            }
          

            return result;
        }

        [System.Web.Http.Route("")]
        [System.Web.Http.HttpGet]
        public string GetGames()
        {
            this.mssqlRepository = new MssqlRepository(); 
            List<Game> results = this.mssqlRepository.GetGames();
            string result = "";

            foreach (Game game in results)
            {
                result += game.idGame + " " + game.scoreBlue + " - " + game.scoreRed + "<br />";
            }
          

            return result;
        }

        [System.Web.Http.Route("")]
        [System.Web.Http.HttpGet]
        public string GetPlayers()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetPlayers();
            string result = "";

            foreach (Player player in results)
            {
                result += player.idPlayer + " " + player.name + "<br />";
            }


            return result;
        }

        [System.Web.Http.Route("")]
        [System.Web.Http.HttpGet]
        public string GetTeams()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetTeams();
            string result = "";

            foreach (Player player in results)
            {
                result += player.idPlayer + " " + player.name + "<br />";
            }


            return result;
        }





    }
}