using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmInserirScore : Form
    {
        public int scorePlayer;
        public FrmInserirScore(int scorePlayer)
        {
            InitializeComponent();
            this.scorePlayer = scorePlayer;
            LblScore.Text = "Seus pontos: " + scorePlayer;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            if (validarApelido() == true)
            {
                SaveScorePlayer.setScore(TxtNomePlayer.Text, scorePlayer);
                this.Close();
            }
        }

        private bool validarApelido()
        {
            if (TxtNomePlayer.Text != "")
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={SaveScorePlayer.pathFileDB + "//SCORE.db"}"))
                {
                    db.Open();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("CREATE TABLE IF NOT EXISTS SaveScorePlayer (");
                    sb.Append("namePlayer VARCHAR(10) PRIMARY KEY NOT NULL, ");
                    sb.Append("scorePLayer INTEGER)");

                    SqliteCommand sql = new SqliteCommand(sb.ToString(), db);
                    sql.ExecuteNonQuery();

                    sb.Clear();
                    sb.Append("SELECT * FROM SaveScorePlayer ORDER BY scorePlayer DESC");

                    sql.CommandText = sb.ToString();

                    SqliteDataReader leitor = sql.ExecuteReader();
                    while (leitor.Read())
                    {
                        if (TxtNomePlayer.Text == leitor["namePlayer"].ToString())
                        {
                            MessageBox.Show("Opa, parece que já existe este apelido\nEscreva outro apelido", "Erro",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                            return (false);
                        }
                    }
                    leitor.Close();
                    return (true);
                }
            }
            else
            {
                MessageBox.Show("Opa, parece que você não escreveu seu apelido", "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return (false);
        }
    }
}
