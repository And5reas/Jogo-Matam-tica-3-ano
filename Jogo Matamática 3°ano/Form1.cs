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
            PnlMenu.Location = new Point(0, 0);
            PnlMenu.Visible = false;
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
    }
}
