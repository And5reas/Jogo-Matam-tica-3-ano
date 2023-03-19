using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public class SaveScorePlayer
    {
        public static string pathFileDB = Path.Combine(Application.LocalUserAppDataPath);
        public int idPlayer { get; set; }
        public string namePlayer { get; set; }
        public int scorePlayer { get; set; }
        public decimal timePlayer { get; set; }

        public void setScore(string name, int score)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={pathFileDB + "//SCORE.db"}"))
            {
                db.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE TABLE IF NOT EXISTS SaveScorePlayer (");
                sb.Append("idPlayer INTEGER PRIMARY KEY AUTOINCREMENT, ");
                sb.Append("namePlayer VARCHAR(50) NOT NULL, ");
                sb.Append("scorePLayer INTEGER)");

                SqliteCommand sql = new SqliteCommand(sb.ToString(), db);
                sql.ExecuteNonQuery();

                sb.Clear();
                sb.Append("INSERT INTO SaveScorePlayer VALUES (NULL, ");
                sb.Append("@namePlayer, @scorePLayer)");

                SqliteCommand sql2 = new SqliteCommand(sb.ToString(), db);
                sql2.Parameters.AddWithValue("@namePlayer", name);
                sql2.Parameters.AddWithValue("@scorePLayer", score);
                sql2.ExecuteNonQuery();
            }
        }






    }
}