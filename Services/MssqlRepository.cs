using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AudaciaBallAPI.Models;

namespace AudaciaBallAPI.Services
{
    public class MssqlRepository
    {
        private const string CacheKey = "MssqlStore";

        public MssqlRepository()
        {

        }

        public string getPlayerName(int id)
        {
            string playerName = "";
            var dataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player Where idPlayer = @uid";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@uid", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            playerName = (string)dr["playerName"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return playerName;
        }

        public int getQuota(int id)
        {
            int quota = 0;

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_User Where uid = @uid";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@uid", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            quota = (int)dr["quota"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return quota;
        }
        public string getUsername(int id)
        {
            var ctx = HttpContext.Current;
            string username = "";

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_User Where uid = @uid";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@uid", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            username = (string)dr["username"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return username;
        }

        public List<Game> GetGameHistory(int idPlayer)
        {
            var ctx = HttpContext.Current;
            List<Game> results = new List<Game>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Game Where fk_idPlayerBlue = @idPlayer OR fk_idPlayerRed = @idPlayer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idPlayer", idPlayer);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Game game = new Game();
                                    game.idGame = (int)dr["idGame"];
                                    game.scoreBlue = (int)dr["scoreBlue"];
                                    game.scoreRed = (int)dr["scoreRed"];
                                    game.gameDate = (DateTime)dr["date"];
                                    game.fk_idPlayerBlue = (int)dr["fk_idPlayerBlue"];
                                    game.fk_idPlayerRed = (int)dr["fk_idPlayerRed"];

                                    results.Add(game);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public List<Game> GetGames()
        {
            var ctx = HttpContext.Current;
            List<Game> results = new List<Game>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Game";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Game game = new Game();
                                    game.idGame = (int)dr["idGame"];
                                    game.scoreBlue = (int)dr["scoreBlue"];
                                    game.scoreRed = (int)dr["scoreRed"];
                                    game.gameDate = (DateTime)dr["date"];
                                    game.fk_idPlayerBlue = (int)dr["fk_idPlayerBlue"];
                                    game.fk_idPlayerRed = (int)dr["fk_idPlayerRed"];

                                    results.Add(game);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public List<Player> GetPlayers()
        {
            var ctx = HttpContext.Current;
            List<Player> results = new List<Player>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player WHERE fk_idTeam IS NULL";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Player player = new Player();
                                    player.idPlayer = (int)dr["idPlayer"];
                                    player.name = (string)dr["name"];

                                    results.Add(player);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public List<Player> GetTeams()
        {
            var ctx = HttpContext.Current;
            List<Player> results = new List<Player>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player WHERE fk_idTeam IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Player player = new Player();
                                    player.idPlayer = (int)dr["idPlayer"];
                                    player.name = (string)dr["name"];

                                    results.Add(player);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }


        public int AddAmount(int uid, int amount)
        {
            int result = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    amount = this.getQuota(uid) + amount;
                    string query = "UPDATE T_User SET quota = @amount WHERE uid = @uid";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@uid", uid);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return this.getQuota(uid);
        }

        public void AddTeam(int idPlayer1, int idPlayer2)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Team (fk_idPlayer1, fk_idPlayer2) VALUES (@idPlayer1, @idPlayer2)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idPlayer1", idPlayer1);
                    cmd.Parameters.AddWithValue("@idPlayer2", idPlayer2);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddGame(int scoreBlue, int scoreRed, int idPlayerBlue, int idPlayerRed)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;
            DateTime today = DateTime.Now;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Game (scoreBlue, scoreRed, fk_idPlayerBlue, fk_idPlayerRed, date) VALUES (@scoreBlue, @scoreRed, @idPlayerBlue, @idPlayerRed, @gameDate)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@scoreBlue", scoreBlue);
                    cmd.Parameters.AddWithValue("@scoreRed", scoreRed);
                    cmd.Parameters.AddWithValue("@idPlayerBlue", idPlayerBlue);
                    cmd.Parameters.AddWithValue("@idPlayerRed", idPlayerRed);
                    cmd.Parameters.AddWithValue("@gameDate", today);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetLastInsertedTeam()
        {
            var ctx = HttpContext.Current;
            int idTeam = 0;

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 T_Team.idTeam FROM T_Team ORDER BY T_Team.idTeam DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idTeam = (int)dr["idTeam"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return idTeam;
        }

        public void AddPlayer(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Player (name) VALUES (@name)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int AddPlayerTeam(string name, int idTeam)
        {
            int result = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Player (name, fk_idTeam) VALUES (@name, @idTeam)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idTeam", idTeam);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 1;
        }

        public string[] GetAllMssqlRows()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (string[])ctx.Cache[CacheKey];
            }

            string[] empty = new string[1];
            empty[0] = "empty";
            return empty;
        }

    }
}