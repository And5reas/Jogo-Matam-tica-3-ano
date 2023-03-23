using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;

namespace Jogo_Matamática_3_ano
{
    public class Save
    {
        PictureBox fase2;
        PictureBox fase3;
        private static byte id = 1;
        private byte loadSave;
        private string EscolhaPerson, ObjPerson;
        private int score_total_player;

        public Save(PictureBox fase2, PictureBox fase3)
        {
            this.fase2 = fase2;
            this.fase3 = fase3;
        }

        public void createTableSalvar()
        {
            if (!File.Exists(SaveScorePlayer.pathFileDB + "//SAVE.db"))
                using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SAVE.db"}"))
                {
                    db.Open();

                    SqliteCommand sql = new SqliteCommand("CREATE TABLE IF NOT EXISTS Salvar (id INTEGER PRIMARY KEY AUTOINCREMENT, Save INTEGER, EscolhaPerson VARCHAR(10), ObjPerson VARCHAR(10), ScoreTotal INTEGER)", db);
                    sql.ExecuteNonQuery();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Salvar VALUES (");
                    sb.Append("NULL, @Save, NULL, NULL, NULL)");

                    sql.CommandText = sb.ToString();

                    sql.Parameters.AddWithValue("@Save", 1);
                    sql.ExecuteNonQuery();
                }
        }
        public Tuple<string, string, int> Load()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SAVE.db"}"))
            {

                db.Open();
                SqliteCommand sql = new SqliteCommand("SELECT * FROM Salvar", db);
                SqliteDataReader leitor = sql.ExecuteReader();

                while (leitor.Read())
                {
                    loadSave = Convert.ToByte(leitor["Save"]);
                    EscolhaPerson = leitor["EscolhaPerson"].ToString();
                    ObjPerson = leitor["ObjPerson"].ToString();
                    score_total_player = Convert.ToInt32(leitor["ScoreTotal"]);
                }
                if (EscolhaPerson == "")
                    EscolhaPerson = "Nada";
                if (ObjPerson == "")
                    ObjPerson = "Nada";


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
                return new Tuple<string, string, int>(EscolhaPerson, ObjPerson, score_total_player);
            }
        }
        public void save(int fase, string escolhaPerson, string objPerson)
        {
            if (File.Exists(SaveScorePlayer.pathFileDB + "//SAVE.db"))
            {
                if (MessageBox.Show("Deseja sobrescrever um jogo salvo?", "Salvar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SAVE.db"}"))
                    {
                        db.Open();

                        StringBuilder sb = new StringBuilder();
                        sb.Append("UPDATE Salvar ");
                        sb.Append("SET Save = @Save, EscolhaPerson = @EscolhaPerson, ObjPerson = @ObjPerson ");
                        sb.Append("WHERE id = @id");

                        SqliteCommand sql = new SqliteCommand(sb.ToString(), db);
                        sql.Parameters.AddWithValue("@Save", fase);
                        sql.Parameters.AddWithValue("@EscolhaPerson", escolhaPerson);
                        sql.Parameters.AddWithValue("@ObjPerson", objPerson);
                        sql.Parameters.AddWithValue("@id", id);
                        sql.ExecuteNonQuery();
                    }
                    MessageBox.Show("Jogo salvo com sucesso :)", "SALVO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
    }
}
