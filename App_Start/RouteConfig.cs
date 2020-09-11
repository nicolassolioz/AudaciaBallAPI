using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AudaciaBallAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "AddPlayer",
                url: "AddPlayer/{name}",
                defaults: new { controller = "Mssql", action = "AddPlayer" }
            );

            routes.MapRoute(
                name: "AddTeam",
                url: "AddTeam/{name}/{idPlayer1}/{idPlayer2}",
                defaults: new { controller = "Mssql", action = "AddTeam" }
            );

            routes.MapRoute(
                name: "GetGameHistory",
                url: "GetGameHistory/{idPlayer}",
                defaults: new { controller = "Mssql", action = "GetGameHistory"}
            );

            routes.MapRoute(
                name: "GetGames",
                url: "GetGames",
                defaults: new { controller = "Mssql", action = "GetGames"}
            );

            routes.MapRoute(
                name: "GetPlayers",
                url: "GetPlayers",
                defaults: new { controller = "Mssql", action = "GetPlayers" }
            );

            routes.MapRoute(
                name: "GetTeams",
                url: "GetTeams",
                defaults: new { controller = "Mssql", action = "GetTeams" }
            );

            routes.MapRoute(
                name: "AddGame",
                url: "AddGame/{scoreBlue}/{scoreRed}/{idPlayerBlue}/{idPlayerRed}",
                defaults: new { controller = "Mssql", action = "AddGame" }
            );
        }
    }
}
