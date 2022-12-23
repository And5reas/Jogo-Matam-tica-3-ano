using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmJogo : Form
    {
        #region Variáveis Globais
        int posLinha = 0, posColuna = 0, andar = 22,
            DebugSwith;
        string controle;
        #endregion
        #region Fase 1
        static string[,] labirinto = new string[23, 31]
            {
            {"1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1"},
            {"1","1","1","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","1"},
            {"1","1","1","0","1","1","1","0","1","1","1","1","1","1","1","0","1","1","1","1","1","0","1","1","1","1","1","1","1","0","1"},
            {"1","1","1","0","1","0","1","0","1","0","0","0","0","0","1","0","1","0","0","0","1","0","1","0","0","0","0","0","1","0","1"},
            {"1","1","1","0","1","0","1","0","1","0","1","1","1","0","1","0","1","1","1","0","1","0","1","0","1","1","1","1","1","0","1"},
            {"1","0","1","0","1","0","1","0","1","0","1","0","1","0","1","0","0","0","0","0","1","0","1","0","0","0","0","0","0","0","1"},
            {"1","0","1","0","1","0","1","0","1","0","1","0","1","0","1","1","1","1","1","1","1","0","1","1","1","1","1","1","1","1","1"},
            {"1","0","1","0","1","0","1","0","1","0","1","0","0","0","0","0","1","0","0","0","0","0","1","0","0","0","0","0","0","0","1"},
            {"1","0","1","1","1","0","1","0","1","0","1","0","1","1","1","0","1","1","1","1","1","1","1","0","1","1","1","1","1","1","1"},
            {"1","0","0","0","0","0","0","0","1","0","1","0","1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0"},
            {"1","1","1","1","1","1","1","0","1","0","1","1","1","0","1","1","1","1","1","1","1","1","1","0","1","1","1","1","1","1","1"},
            {"0","0","0","0","0","0","1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","0","0","0","0","1"},
            {"1","1","1","1","1","0","1","0","1","1","1","1","1","1","1","1","1","1","1","1","1","0","1","0","1","0","1","1","1","0","1"},
            {"1","0","0","0","1","0","1","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","1","0","1","0","1","0","1","0","1"},
            {"1","1","1","0","1","0","1","0","1","1","1","1","1","1","1","1","1","1","1","0","1","0","1","0","1","0","1","0","1","0","1"},
            {"1","0","1","0","1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","1","0","1","0","1","0","1"},
            {"1","0","1","0","1","0","1","1","1","1","1","1","1","1","1","1","1","0","1","1","1","0","1","0","1","0","1","0","1","0","1"},
            {"1","0","1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","1","0","1","0","1","0","0","0","1"},
            {"1","0","1","0","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","0","1","0","1","0","1","0","1","0","1","1","1"},
            {"1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","1","0","1","0","1","0","1","1","1"},
            {"1","0","1","0","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","0","1","1","1","0","1","0","1","0","1","1","1"},
            {"1","0","1","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","1","0","1","0","1","1","1"},
            {"1","0","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","0","1","1","1"},
            };
        #endregion



        public FrmJogo()
        {
            InitializeComponent();
        }

        #region Controles
        private void FrmJogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString().ToLower() == "a" || e.KeyChar.ToString().ToLower() == "d" ||
               e.KeyChar.ToString().ToLower() == "w" || e.KeyChar.ToString().ToLower() == "s")
            {
                TmrAndar.Start();
                controle = e.KeyChar.ToString().ToLower();
            }
            //Ativar e desativar o Debug Mode
            else if(e.KeyChar.ToString().ToLower() == "y")
            {
                if(DebugSwith % 2 == 0)
                {
                    //Mostrar posição do personagem
                    DebugSwith++;
                    labelX.Visible = true;
                    labelY.Visible = true;
                    LblX.Visible = true;
                    LblY.Visible = true;
                }
                else
                {
                    //Esconder posição do personagem
                    DebugSwith++;
                    labelX.Visible = false;
                    labelY.Visible = false;
                    LblX.Visible = false;
                    LblY.Visible = false;
                }
            }
        }
        #endregion

        #region Load form
        private void FrmJogo_Load(object sender, EventArgs e)
        {
            //FASES DESATIVADAS
            PBX_Fase2.Enabled = false;
            PBX_Fase3.Enabled = false;
            PBX_Fase4.Enabled = false;
            PBX_Fase5.Enabled = false;
            PBX_Fase6.Enabled = false;

            //ESCONDER FASES
            PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            PBX_Fase4.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            PBX_Fase5.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            PBX_Fase6.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");

            //PAINEL DE FASES
            PNL_Fases.Visible = false;
            PNL_Fases.Location = new Point(0, 0);

            //PAINEL MENU
            PnlMenu.Location = new Point(0, 0);
            PnlMenu.Visible = true;

            TmrAndar.Stop();
            //Esconder posição do personagem
            labelX.Visible = false;
            labelY.Visible = false;
            LblX.Visible = false;
            LblY.Visible = false;
        }
        #endregion

        #region Andar
        private void TmrAndar_Tick(object sender, EventArgs e)
        {
            //Coletar a informação de onde o pesonagem está nas posições X e Y
            int x = PbxPersonagem.Location.X;
            int y = PbxPersonagem.Location.Y;

            labelX.Text = x.ToString();
            labelY.Text = y.ToString();

            if (controle == "a")
            {
                if (posColuna == 0) return;
                if (labirinto[posLinha, posColuna - 1] == "1")
                {
                    PbxPersonagem.Location = new Point(x - andar, y);
                    posColuna--;
                }
            }
            else if (controle == "d")
            {
                if (posColuna == 30) return;
                if (labirinto[posLinha, posColuna + 1] == "1")
                {
                    PbxPersonagem.Location = new Point(x + andar, y);
                    posColuna++;
                }
            }
            else if (controle == "w")
            {
                if (posLinha == 0) return;
                if (labirinto[posLinha - 1, posColuna] == "1")
                {
                    PbxPersonagem.Location = new Point(x, y - andar);
                    posLinha--;
                }
            }
            else if (controle == "s")
            {
                if (posLinha == 22) return;
                if (labirinto[posLinha + 1, posColuna] == "1")
                {
                    PbxPersonagem.Location = new Point(x, y + andar);
                    posLinha++;
                }
            }
        }
        #endregion

        #region EFEITO BOTOES MENU

        //ENTRAR E SAIR DO JOGAR
        private void PBX_Jogar_MouseHover(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(250, 150);
            PBX_Jogar.Location = new Point(290, 235);
        }

        private void PBX_Jogar_MouseLeave(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(220, 120);
            PBX_Jogar.Location = new Point(307, 235);
        }


        //ENTRAR E SAIR DO OPCOES
        private void PBX_Opcoes_MouseHover(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(250, 150);
            PBX_Opcoes.Location = new Point(290, 400);
        }

        private void PBX_Opcoes_MouseLeave(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(220, 120);
            PBX_Opcoes.Location = new Point(307, 400);
        }

        //ENTRAR E SAIR DO SAIR
        private void PBX_Sair_MouseHover(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(250, 150);
            PBX_Sair.Location = new Point(290, 562);
        }

        private void PBX_Sair_MouseLeave(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(220, 120);
            PBX_Sair.Location = new Point(307, 562);
        }

        //ENTRAR E SAIR DA FASE 1
        private void PBX_Fase1_MouseHover(object sender, EventArgs e)
        {
            PBX_Fase1.Size = new Size(256, 196);
            PBX_Fase1.Location = new Point(0, 0);
        }
        private void PBX_Fase1_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase1.Size = new Size(228, 170);
            PBX_Fase1.Location = new Point(14, 14);
        }

        //ENTRAR E SAIR DA FASE 2
        private void PBX_Fase2_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_Fase2_MouseLeave(object sender, EventArgs e)
        {

        }

        //ENTRAR E SAIR DA FASE 3
        private void PBX_Fase3_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_Fase3_MouseLeave(object sender, EventArgs e)
        {

        }

        //ENTRAR E SAIR DA FASE 4
        private void PBX_Fase4_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_Fase4_MouseLeave(object sender, EventArgs e)
        {

        }

        //ENTRAR E SAIR DA FASE 5
        private void PBX_Fase5_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_Fase5_MouseLeave(object sender, EventArgs e)
        {

        }

        //ENTRAR E SAIR DA FASE 6
        private void PBX_Fase6_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_Fase6_MouseLeave(object sender, EventArgs e)
        {

        }
        #endregion

        #region Click Jogar
        private void PBX_Jogar_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = true;
        }
        #endregion
    }
}
