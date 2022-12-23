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
using System.Threading;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmJogo : Form
    {
        #region Variáveis Globais
        int andarQtdPx = 6,
            DebugSwith, posXPlayer, posYPlayer, posXColision, posYColision, posX2Player, posY2Player;
        bool goLeft, goRight, goDown, goUp;
        #endregion
        public FrmJogo()
        {
            InitializeComponent();
        }

        #region Controles
        //Movimento do player
        private void FrmJogo_KeyDown(object sender, KeyEventArgs e)
        {
            //Tecla precionada
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
            }
        }
        private void FrmJogo_KeyUp(object sender, KeyEventArgs e)
        {
            //Tecla "solta"
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }
        }

        private void FrmJogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ativar e desativar o Debug Mode
            if(e.KeyChar.ToString().ToLower() == "y")
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
            PnlMenu.Visible = true;
            TmrMainGameManager.Start();
            PbxColision.Location = new Point(46, 161);
            PbxPersonagem.Location = new Point(46, 136);
            
            //Esconder posição do personagem
            labelX.Visible = false;
            labelY.Visible = false;
            LblX.Visible = false;
            LblY.Visible = false;
        }
        #endregion

        #region Andar

        private void TmrColisao_Tick(object sender, EventArgs e)
        {
            //Coletar a informação de onde o pesonagem está nas posições X e Y
            posXPlayer = PbxPersonagem.Location.X;
            posYPlayer = PbxPersonagem.Location.Y;

            //Coletar a informação de onde a colisão do personagem está está nas posições X e Y
            posXColision = PbxColision.Location.X;
            posYColision = PbxColision.Location.Y;

            //Colisão com paredes
            foreach (Control g in this.Controls)
            {
                if (g is PictureBox)
                {
                    if ((string)g.Tag == "Parede")
                    {
                        if (PbxColision.Bounds.IntersectsWith(g.Bounds))
                        {
                            if (goUp == true)
                            {
                                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer + andarQtdPx);
                                PbxColision.Location = new Point(posXColision, posYColision + andarQtdPx);
                                goUp = false;
                            }
                            else if (goLeft == true)
                            {
                                PbxPersonagem.Location = new Point(posXPlayer + andarQtdPx, posYPlayer);
                                PbxColision.Location = new Point(posXColision + andarQtdPx, posYColision);
                                goLeft = false;
                            }
                            else if (goRight == true)
                            {
                                PbxPersonagem.Location = new Point(posXPlayer - andarQtdPx, posYPlayer);
                                PbxColision.Location = new Point(posXColision - andarQtdPx, posYColision);
                                goRight = false;
                            }
                            else if (goDown == true)
                            {
                                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer - andarQtdPx);
                                PbxColision.Location = new Point(posXColision, posYColision - andarQtdPx);
                                goDown = false;
                            }
                            else
                            {
                                PbxPersonagem.Location = new Point(posX2Player, posY2Player);
                                PbxColision.Location = new Point(posX2Player, posY2Player + 25);
                            }
                        }
                    }
                }
            }
        }

        private void TmrMainGameManager_Tick(object sender, EventArgs e)
        {
            //Coletar a informação de onde o pesonagem está nas posições X2 e Y2
            posX2Player = PbxPersonagem.Location.X;
            posY2Player = PbxPersonagem.Location.Y;

            //Coletar insformação para o degubMode "y"
            labelX.Text = posXPlayer.ToString();
            labelY.Text = posYPlayer.ToString();

            //Controles para fazer o player andar
            if (goLeft == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer - andarQtdPx, posYPlayer);
                PbxColision.Location = new Point(posXColision - andarQtdPx, posYColision);
            }
            else if (goRight == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer + andarQtdPx, posYPlayer);
                PbxColision.Location = new Point(posXColision + andarQtdPx, posYColision);
            }
            else if (goUp == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer - andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision - andarQtdPx);
            }
            else if (goDown == true)
            {   
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer + andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision + andarQtdPx);
            }
            
            //Pegar moedas com Tag Vitamina
            foreach (Control f in this.Controls)
            {
                if (f is PictureBox)
                {
                    if ((string)f.Tag == "Vitamina")
                    {
                        if (PbxPersonagem.Bounds.IntersectsWith(f.Bounds))
                        {
                            f.Visible = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region Menu

        //ENTRAR E SAIR DO JOGAR
        private void PBX_Jogar_MouseHover(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(250, 150);
        }

        private void PBX_Jogar_MouseLeave(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(220, 120);
        }


        //ENTRAR E SAIR DO OPCOES
        private void PBX_Opcoes_MouseHover(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(250, 150);
        }

        private void PBX_Opcoes_MouseLeave(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(220, 120);
        }

        //ENTRAR E SAIR DO SAIR
        private void PBX_Sair_MouseHover(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(250, 150);
        }
        private void PBX_Sair_MouseLeave(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(220, 120);
        }
        #endregion

        #region Click Jogar
        private void PBX_Jogar_Click(object sender, EventArgs e)
        {
            PnlMenu.Visible = false;
        }
        #endregion
    }
}
