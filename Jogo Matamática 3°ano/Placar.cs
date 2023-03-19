using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmPlacar : Form
    {
        public FrmPlacar()
        {
            InitializeComponent();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            consultar(txtProcurar.Text);
        }

        private void consultar(string achar)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SCORE.db"}"))
            {
                db.Open();
                try
                {
                    if (achar != "")
                    {
                        SqliteCommand sql = new SqliteCommand("SELECT * FROM SaveScorePlayer WHERE namePlayer == @namePlayer ORDER BY scorePlayer DESC", db);
                        sql.Parameters.AddWithValue("@namePlayer", achar);
                        SqliteDataReader leitor = sql.ExecuteReader();
                        List<SaveScorePlayer> saveScorePlayers = new List<SaveScorePlayer>();
                        while (leitor.Read())
                        {
                            SaveScorePlayer saveScorePlayer = new SaveScorePlayer()
                            {
                                Player = leitor["namePlayer"].ToString(),
                                Score = Convert.ToInt32(leitor["scorePlayer"])
                            };
                            saveScorePlayers.Add(saveScorePlayer);
                        }
                        leitor.Close();
                        DgvPlacar.DataSource = saveScorePlayers;
                    }
                    else
                    {
                        SqliteCommand sql = new SqliteCommand("SELECT * FROM SaveScorePlayer ORDER BY scorePlayer DESC", db);
                        SqliteDataReader leitor = sql.ExecuteReader();
                        List<SaveScorePlayer> saveScorePlayers = new List<SaveScorePlayer>();
                        while (leitor.Read())
                        {
                            SaveScorePlayer saveScorePlayer = new SaveScorePlayer()
                            {
                                Player = leitor["namePlayer"].ToString(),
                                Score = Convert.ToInt32(leitor["scorePlayer"])
                            };
                            saveScorePlayers.Add(saveScorePlayer);
                        }
                        leitor.Close();
                        DgvPlacar.DataSource = saveScorePlayers;
                    }
                }
                catch
                {
                    MessageBox.Show("Parece que não existe nenhum Score salvo :(", "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Placar_Load(object sender, EventArgs e)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SCORE.db"}"))
            {
                db.Open();
                try
                {
                    SqliteCommand sql = new SqliteCommand("SELECT * FROM SaveScorePlayer ORDER BY scorePlayer DESC", db);
                    SqliteDataReader leitor = sql.ExecuteReader();
                    List<SaveScorePlayer> saveScorePlayers = new List<SaveScorePlayer>();
                    while (leitor.Read())
                    {
                        SaveScorePlayer saveScorePlayer = new SaveScorePlayer()
                        {
                            Player = leitor["namePlayer"].ToString(),
                            Score = Convert.ToInt32(leitor["scorePlayer"])
                        };
                        saveScorePlayers.Add(saveScorePlayer);
                    }
                    leitor.Close();
                    DgvPlacar.DataSource = saveScorePlayers;
                }
                catch
                {
                    MessageBox.Show("Parece que não existe nenhum Score salvo :(", "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
