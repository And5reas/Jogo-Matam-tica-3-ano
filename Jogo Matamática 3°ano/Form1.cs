﻿using System;
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
        //MENU
        int ativouMenu = 0;

        int andarQtdPx = 6,
            DebugSwith,
            posXPlayer, posYPlayer, posXColision, posYColision, posX2Player, posY2Player,
            animationPlayer, countAnimation;
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

            if (e.KeyChar == 27)
            {
                if (ativouMenu == 0 && PNL_Pause.Enabled != false) {
                    PNL_Pause.Visible = true;
                    PNL_Pause.Location = new Point(0, 0);
                    PBX_fundoPause.Location = new Point(0, 0);
                    PBX_fundoPause.Size = new Size(1314, 1015);
                    ativouMenu = 1;
                }else if (ativouMenu == 1)
                {
                    PNL_Pause.Visible = false;
                    ativouMenu = 0;
                }
            }
        }
        #endregion

        #region Load form
        private void FrmJogo_Load(object sender, EventArgs e)
        {
            //PAUSE
            PNL_Pause.Visible = false;
            PNL_Pause.Enabled = false;

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
            TmrMainGameManager.Start();
            
            //Esconder posição do personagem 
            labelX.Visible = false;
            labelY.Visible = false;
            LblX.Visible = false;
            LblY.Visible = false;

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(46, 161);
            PbxPersonagem.Location = new Point(46, 136);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\direita\\direita_1.png");
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

            //Mudar a animação do Player
            animationPlayer = (countAnimation % 3) + 1;

            //Controles para fazer o player andar
            if (goLeft == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer - andarQtdPx, posYPlayer);
                PbxColision.Location = new Point(posXColision - andarQtdPx, posYColision);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\esquerda\\esquerda_" + animationPlayer + ".png");
            }
            else if (goRight == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer + andarQtdPx, posYPlayer);
                PbxColision.Location = new Point(posXColision + andarQtdPx, posYColision);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\direita\\direita_" + animationPlayer + ".png");
            }
            else if (goUp == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer - andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision - andarQtdPx);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\costas\\costas_" + animationPlayer + ".png");
            }
            else if (goDown == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer + andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision + andarQtdPx);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\frente\\frente_" + animationPlayer + ".png");
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

        #region EFEITO BOTOES MENU

        //ENTRAR E SAIR DO JOGAR
        private void PBX_Jogar_MouseHover(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(250, 150);
            PBX_Jogar.Location = new Point(530, 284);
        }

        private void PBX_Jogar_MouseLeave(object sender, EventArgs e)
        {
            PBX_Jogar.Size = new Size(220, 120);
            PBX_Jogar.Location = new Point(547, 284);
        }


        //ENTRAR E SAIR DO OPCOES
        private void PBX_Opcoes_MouseHover(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(250, 150);
            PBX_Opcoes.Location = new Point(530, 449);
        }

        private void PBX_Opcoes_MouseLeave(object sender, EventArgs e)
        {
            PBX_Opcoes.Size = new Size(220, 120);
            PBX_Opcoes.Location = new Point(547, 449);
        }

        //ENTRAR E SAIR DO SAIR
        private void PBX_Sair_MouseHover(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(250, 150);
            PBX_Sair.Location = new Point(530, 611);
        }

        private void PBX_Sair_MouseLeave(object sender, EventArgs e)
        {
            PBX_Sair.Size = new Size(220, 120);
            PBX_Sair.Location = new Point(547, 611);
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

        private void PbxPersonagem_Click(object sender, EventArgs e)
        {

        }

        private void PbxColision_Click(object sender, EventArgs e)
        {

        }

        //ENTRAR E SAIR DA FASE 3
        private void PBX_Fase3_MouseHover(object sender, EventArgs e)
        {

        }

        private void PNL_Fases_Paint(object sender, PaintEventArgs e)
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

        #region Start fase 1
        private void PBX_Fase1_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            #region Load Wall

            //Colocando as paredes em seus lugares
            pictureBox1.Location = new Point(112, 180); pictureBox1.Size = new Size(32, 198);
            pictureBox2.Location = new Point(150, 354); pictureBox2.Size = new Size(182, 24);
            pictureBox3.Location = new Point(336, 211); pictureBox3.Size = new Size(31, 343);
            pictureBox4.Location = new Point(187, 180); pictureBox4.Size = new Size(32, 149);
            pictureBox5.Location = new Point(262, 231); pictureBox5.Size = new Size(32, 117);
            pictureBox6.Location = new Point(224, 180); pictureBox6.Size = new Size(952, 25);
            pictureBox7.Location = new Point(407, 230); pictureBox7.Size = new Size(31, 221);
            pictureBox8.Location = new Point(444, 230); pictureBox8.Size = new Size(147, 25);
            pictureBox9.Location = new Point(444, 426); pictureBox9.Size = new Size(438, 25);
            pictureBox10.Location = new Point(557, 377); pictureBox10.Size = new Size(36, 43);
            pictureBox11.Location = new Point(522, 323); pictureBox11.Size = new Size(142, 30);
            pictureBox12.Location = new Point(480, 279); pictureBox12.Size = new Size(36, 122);
            pictureBox13.Location = new Point(626, 211); pictureBox13.Size = new Size(33, 89);
            pictureBox14.Location = new Point(700, 230); pictureBox14.Size = new Size(105, 25);
            pictureBox15.Location = new Point(665, 277); pictureBox15.Size = new Size(140, 25);
            pictureBox16.Location = new Point(776, 261); pictureBox16.Size = new Size(29, 10);
            pictureBox17.Location = new Point(845, 211); pictureBox17.Size = new Size(37, 142);
            pictureBox18.Location = new Point(695, 323); pictureBox18.Size = new Size(144, 30);
            pictureBox19.Location = new Point(630, 354); pictureBox19.Size = new Size(34, 47);
            pictureBox20.Location = new Point(670, 378); pictureBox20.Size = new Size(540, 23);
            pictureBox21.Location = new Point(917, 229); pictureBox21.Size = new Size(37, 71);
            pictureBox22.Location = new Point(1139, 211); pictureBox22.Size = new Size(37, 89);
            pictureBox23.Location = new Point(960, 230); pictureBox23.Size = new Size(144, 24);
            pictureBox24.Location = new Point(960, 278); pictureBox24.Size = new Size(173, 24);
            pictureBox25.Location = new Point(960, 327); pictureBox25.Size = new Size(216, 24);
            pictureBox26.Location = new Point(917, 327); pictureBox26.Size = new Size(37, 44);
            pictureBox27.Location = new Point(920, 406); pictureBox27.Size = new Size(37, 300);
            pictureBox28.Location = new Point(1141, 426); pictureBox28.Size = new Size(37, 148);
            pictureBox29.Location = new Point(995, 427); pictureBox29.Size = new Size(139, 22);
            pictureBox30.Location = new Point(995, 455); pictureBox30.Size = new Size(33, 251);
            pictureBox31.Location = new Point(1071, 479); pictureBox31.Size = new Size(33, 251);
            pictureBox32.Location = new Point(1107, 554); pictureBox32.Size = new Size(33, 20);
            pictureBox33.Location = new Point(773, 479); pictureBox33.Size = new Size(37, 75);
            pictureBox34.Location = new Point(845, 457); pictureBox34.Size = new Size(37, 197);
            pictureBox35.Location = new Point(773, 579); pictureBox35.Size = new Size(37, 99);
            pictureBox36.Location = new Point(187, 686); pictureBox36.Size = new Size(729, 20);
            pictureBox37.Location = new Point(224, 635); pictureBox37.Size = new Size(514, 20);
            pictureBox38.Location = new Point(187, 455); pictureBox38.Size = new Size(32, 225);
            pictureBox39.Location = new Point(262, 585); pictureBox39.Size = new Size(477, 20);
            pictureBox40.Location = new Point(373, 532); pictureBox40.Size = new Size(394, 20);
            pictureBox41.Location = new Point(707, 559); pictureBox41.Size = new Size(27, 20);
            pictureBox42.Location = new Point(262, 403); pictureBox42.Size = new Size(27, 176);
            pictureBox43.Location = new Point(373, 481); pictureBox43.Size = new Size(361, 20);
            pictureBox44.Location = new Point(74, 403); pictureBox44.Size = new Size(182, 24);
            pictureBox45.Location = new Point(112, 455); pictureBox45.Size = new Size(69, 24);
            pictureBox46.Location = new Point(112, 506); pictureBox46.Size = new Size(32, 224);
            pictureBox47.Location = new Point(555, 261); pictureBox47.Size = new Size(36, 56);
            pictureBox48.Location = new Point(38, 128); pictureBox48.Size = new Size(1217, 25);
            pictureBox49.Location = new Point(0, 128); pictureBox49.Size = new Size(32, 60);
            pictureBox50.Location = new Point(36, 183); pictureBox50.Size = new Size(32, 547);
            pictureBox51.Location = new Point(38, 736); pictureBox51.Size = new Size(1234, 24);
            pictureBox52.Location = new Point(1218, 159); pictureBox52.Size = new Size(37, 509);
            pictureBox53.Location = new Point(1261, 648); pictureBox53.Size = new Size(21, 82);
            #endregion
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
