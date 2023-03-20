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
        public string Player { get; set; }
        public int Score { get; set; }

        public static void setScore(string name, int score)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={pathFileDB + "//SCORE.db"}"))
            {
                db.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE TABLE IF NOT EXISTS SaveScorePlayer (");
                sb.Append("namePlayer VARCHAR(10) PRIMARY KEY NOT NULL, ");
                sb.Append("scorePLayer INTEGER)");

                SqliteCommand sql = new SqliteCommand(sb.ToString(), db);
                sql.ExecuteNonQuery();

                sb.Clear();
                sb.Append("INSERT INTO SaveScorePlayer VALUES (");
                sb.Append("@namePlayer, @scorePLayer)");

                sql.CommandText = sb.ToString();
                sql.Parameters.AddWithValue("@namePlayer", name);
                sql.Parameters.AddWithValue("@scorePLayer", score);
                sql.ExecuteNonQuery();
            }
        }
    }
}