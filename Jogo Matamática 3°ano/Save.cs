using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Jogo_Matamática_3_ano
{
    public class Save
    {
        PictureBox fase2;
        PictureBox fase3;
        private static byte id = 1;
        private byte loadSave;

        public Save(PictureBox fase2, PictureBox fase3)
        {
            this.fase2 = fase2;
            this.fase3 = fase3;
        }

        public void Load()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SAVE.db"}"))
            {
                db.Open();

                SqliteCommand sql = new SqliteCommand("SELECT * FROM Salvar", db);
                SqliteDataReader leitor = sql.ExecuteReader();
                if (leitor.Read())
                    loadSave = Convert.ToByte(leitor["Save"]);
                if (loadSave == 2)
                {
                    fase2.Enabled = true;
                    fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                }
                else if (loadSave == 3)
                {
                    fase2.Enabled = true;
                    fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                    fase3.Enabled = true;
                    fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_5.png");
                }
            }
        }
        public void save(int fase)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SAVE.db"}"))
            {
                db.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE TABLE IF NOT EXISTS Salvar (id INTEGER PRIMARY KEY AUTOINCREMENT, Save INTEGER)");

                SqliteCommand sql = new SqliteCommand(sb.ToString(), db);
                sql.ExecuteNonQuery();

                sb.Clear();
                sb.Append("UPDATE Salvar SET ");
                sb.Append("Save = @Save ");
                sb.Append("WHERE id = @id");

                SqliteCommand sql2 = new SqliteCommand(sb.ToString(), db);
                sql2.Parameters.AddWithValue("@Save", fase);
                sql2.Parameters.AddWithValue("@id", id);
                sql2.ExecuteNonQuery();
            }
        }
    }
}
