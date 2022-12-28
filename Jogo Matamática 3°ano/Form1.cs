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
        //MENU
        int ativouMenu = 0;

        int andarQtdPx = 6,
            DebugSwith,
            posXPlayer, posYPlayer, posXColision, posYColision, posX2Player, posY2Player,
            animationPlayer, countAnimation, animationSpeed;
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

            //Pause
            if (e.KeyChar == 27)
            {
                if (ativouMenu == 0 && PNL_Pause.Enabled != false) {
                    PNL_Pause.Visible = true;
                    PNL_Pause.Location = new Point(0, 0);
                    TmrMainGameManager.Stop();
                    ativouMenu = 1;
                }else if (ativouMenu == 1)
                {
                    PNL_Pause.Visible = false;
                    TmrMainGameManager.Start();
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
            //PBX_Fase2.Enabled = false;
            PBX_Fase3.Enabled = false;
            PBX_Fase4.Enabled = false;
            PBX_Fase5.Enabled = false;
            PBX_Fase6.Enabled = false;

            //ESCONDER FASES
            //PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
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
            
            //Esconder posição do personagem 
            labelX.Visible = false;
            labelY.Visible = false;
            LblX.Visible = false;
            LblY.Visible = false;

            //Resetar as paredes
            ResetWalls();
        }
        #endregion

        #region MainGameMenager
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
            animationSpeed = countAnimation / 4;

            animationPlayer = (animationSpeed % 3) + 1;

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
            PBX_Fase2.Size = new Size(256, 196);
            PBX_Fase2.Location = new Point(0, 0);
        }

        private void PBX_Fase2_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase2.Size = new Size(228, 170);
            PBX_Fase2.Location = new Point(14, 14);
        }

        //ENTRAR E SAIR DA FASE 3
        private void PBX_Fase3_MouseHover(object sender, EventArgs e)
        {
            PBX_Fase3.Size = new Size(256, 196);
            PBX_Fase3.Location = new Point(0, 0);
        }

        private void PBX_Fase3_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase3.Size = new Size(228, 170);
            PBX_Fase3.Location = new Point(14, 14);
        }

        //ENTRAR E SAIR DA FASE 4
        private void PBX_Fase4_MouseHover(object sender, EventArgs e)
        {
            PBX_Fase4.Size = new Size(256, 196);
            PBX_Fase4.Location = new Point(0, 0);
        }

        private void PBX_Fase4_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase4.Size = new Size(228, 170);
            PBX_Fase4.Location = new Point(14, 14);
        }

        //ENTRAR E SAIR DA FASE 5
        private void PBX_Fase5_MouseHover(object sender, EventArgs e)
        {
            PBX_Fase5.Size = new Size(256, 196);
            PBX_Fase5.Location = new Point(0, 0);
        }

        private void PBX_Fase5_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase5.Size = new Size(228, 170);
            PBX_Fase5.Location = new Point(14, 14);
        }

        //ENTRAR E SAIR DA FASE 6
        private void PBX_Fase6_MouseHover(object sender, EventArgs e)
        {
            PBX_Fase6.Size = new Size(256, 196);
            PBX_Fase6.Location = new Point(0, 0);
        }

        private void PBX_Fase6_MouseLeave(object sender, EventArgs e)
        {
            PBX_Fase6.Size = new Size(228, 170);
            PBX_Fase6.Location = new Point(14, 14);
        }

        private void PbxPersonagem_Click(object sender, EventArgs e)
        {

        }

        private void PbxColision_Click(object sender, EventArgs e)
        {

        }

        private void PNL_Fases_Paint(object sender, PaintEventArgs e)
        {

        }

        //ENTRAR E SAIR BTN VOLTAR INICIO SETA
        private void PBX_VoltarInicio_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_VoltarInicio_MouseLeave(object sender, EventArgs e)
        {

        }
        #endregion

        #region Start fase 1
        private void PBX_Fase1_Click(object sender, EventArgs e)
        {
            //Start da fase
            TmrMainGameManager.Start();

            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_1.png");

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(46, 161);
            PbxPersonagem.Location = new Point(46, 136);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\direita\\direita_1.png");

            #region Load Wall fase 1

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

        #region Start fase 2
        private void PBX_Fase2_Click(object sender, EventArgs e)
        {
            //Start da fase
            TmrMainGameManager.Start();

            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_2.png");

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(17, 705);
            PbxPersonagem.Location = new Point(17, 680);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\direita\\direita_1.png");

            #region Load Wall fase 2

            //Colocando as paredes em seus lugares
            pictureBox1.Location = new Point(88, 179); pictureBox1.Size = new Size(38, 327);
            pictureBox2.Location = new Point(159, 179); pictureBox2.Size = new Size(39, 274);
            pictureBox3.Location = new Point(204, 179); pictureBox3.Size = new Size(351, 25);
            pictureBox4.Location = new Point(231, 210); pictureBox4.Size = new Size(40, 491);
            pictureBox5.Location = new Point(132, 477); pictureBox5.Size = new Size(93, 29);
            pictureBox6.Location = new Point(447, 210); pictureBox6.Size = new Size(37, 220);
            pictureBox7.Location = new Point(303, 232); pictureBox7.Size = new Size(138, 25);
            pictureBox8.Location = new Point(303, 263); pictureBox8.Size = new Size(37, 119);
            pictureBox9.Location = new Point(346, 355); pictureBox9.Size = new Size(64, 27);
            pictureBox10.Location = new Point(374, 282); pictureBox10.Size = new Size(67, 25);
            pictureBox11.Location = new Point(374, 313); pictureBox11.Size = new Size(36, 21);
            pictureBox12.Location = new Point(88, 532); pictureBox12.Size = new Size(38, 191);
            pictureBox13.Location = new Point(132, 532); pictureBox13.Size = new Size(66, 25);
            pictureBox14.Location = new Point(159, 563); pictureBox14.Size = new Size(39, 91);
            pictureBox15.Location = new Point(132, 678); pictureBox15.Size = new Size(66, 45);
            pictureBox16.Location = new Point(303, 403); pictureBox16.Size = new Size(37, 320);
            pictureBox17.Location = new Point(374, 403); pictureBox17.Size = new Size(67, 27);
            pictureBox18.Location = new Point(374, 436); pictureBox18.Size = new Size(36, 94);
            pictureBox19.Location = new Point(416, 505); pictureBox19.Size = new Size(68, 25);
            pictureBox20.Location = new Point(447, 455); pictureBox20.Size = new Size(37, 44);
            pictureBox21.Location = new Point(346, 554); pictureBox21.Size = new Size(209, 30);
            pictureBox22.Location = new Point(520, 232); pictureBox22.Size = new Size(35, 316);
            pictureBox23.Location = new Point(520, 153); pictureBox23.Size = new Size(35, 20);
            pictureBox24.Location = new Point(596, 153); pictureBox24.Size = new Size(34, 548);
            pictureBox25.Location = new Point(374, 604); pictureBox25.Size = new Size(216, 26);
            pictureBox26.Location = new Point(374, 654); pictureBox26.Size = new Size(216, 25);
            pictureBox27.Location = new Point(374, 685); pictureBox27.Size = new Size(36, 16);
            pictureBox28.Location = new Point(676, 175); pictureBox28.Size = new Size(37, 548);
            pictureBox29.Location = new Point(757, 153); pictureBox29.Size = new Size(38, 300);
            pictureBox30.Location = new Point(719, 476); pictureBox30.Size = new Size(146, 24);
            pictureBox31.Location = new Point(831, 175); pictureBox31.Size = new Size(34, 295);
            pictureBox32.Location = new Point(910, 175); pictureBox32.Size = new Size(39, 376);
            pictureBox33.Location = new Point(719, 527); pictureBox33.Size = new Size(185, 24);
            pictureBox34.Location = new Point(757, 581); pictureBox34.Size = new Size(192, 24);
            pictureBox35.Location = new Point(757, 610); pictureBox35.Size = new Size(33, 91);
            pictureBox36.Location = new Point(796, 677); pictureBox36.Size = new Size(306, 23);
            pictureBox37.Location = new Point(796, 627); pictureBox37.Size = new Size(306, 24);
            pictureBox38.Location = new Point(1068, 427); pictureBox38.Size = new Size(34, 194);
            pictureBox39.Location = new Point(992, 153); pictureBox39.Size = new Size(34, 452);
            pictureBox40.Location = new Point(103, 427); pictureBox40.Size = new Size(30, 26);
            pictureBox41.Location = new Point(1068, 179); pictureBox41.Size = new Size(112, 25);
            pictureBox42.Location = new Point(1146, 210); pictureBox42.Size = new Size(34, 513);
            pictureBox43.Location = new Point(1068, 232); pictureBox43.Size = new Size(34, 173);
            pictureBox44.Location = new Point(1108, 380); pictureBox44.Size = new Size(32, 25);
            pictureBox45.Location = new Point(11, 118); pictureBox45.Size = new Size(1270, 29);
            pictureBox46.Location = new Point(16, 153); pictureBox46.Size = new Size(37, 535);
            pictureBox47.Location = new Point(0, 677); pictureBox47.Size = new Size(10, 92);
            pictureBox48.Location = new Point(12, 731); pictureBox48.Size = new Size(1269, 21);
            pictureBox49.Location = new Point(1230, 153); pictureBox49.Size = new Size(42, 535);
            pictureBox50.Location = new Point(1274, 680); pictureBox50.Size = new Size(10, 45);
            #endregion
        }
        #endregion

        #region Start fase 3
        private void PBX_Fase3_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_3.png");
        }
        #endregion

        #region Resetar as paredes
        public void ResetWalls()
        {
            pictureBox1.Location = new Point(0, 0); pictureBox1.Size = new Size(10, 10);
            pictureBox2.Location = new Point(11, 0); pictureBox2.Size = new Size(10, 10);
            pictureBox3.Location = new Point(22, 0); pictureBox3.Size = new Size(10, 10);
            pictureBox4.Location = new Point(33, 0); pictureBox4.Size = new Size(10, 10);
            pictureBox5.Location = new Point(44, 0); pictureBox5.Size = new Size(10, 10);
            pictureBox6.Location = new Point(55, 0); pictureBox6.Size = new Size(10, 10);
            pictureBox7.Location = new Point(66, 0); pictureBox7.Size = new Size(10, 10);
            pictureBox8.Location = new Point(77, 0); pictureBox8.Size = new Size(10, 10);
            pictureBox9.Location = new Point(88, 0); pictureBox9.Size = new Size(10, 10);
            pictureBox10.Location = new Point(99, 0); pictureBox10.Size = new Size(10, 10);
            pictureBox11.Location = new Point(0, 11); pictureBox11.Size = new Size(10, 10);
            pictureBox12.Location = new Point(11, 11); pictureBox12.Size = new Size(10, 10);
            pictureBox13.Location = new Point(22, 11); pictureBox13.Size = new Size(10, 10);
            pictureBox14.Location = new Point(33, 11); pictureBox14.Size = new Size(10, 10);
            pictureBox15.Location = new Point(44, 11); pictureBox15.Size = new Size(10, 10);
            pictureBox16.Location = new Point(55, 11); pictureBox16.Size = new Size(10, 10);
            pictureBox17.Location = new Point(66, 11); pictureBox17.Size = new Size(10, 10);
            pictureBox18.Location = new Point(77, 11); pictureBox18.Size = new Size(10, 10);
            pictureBox19.Location = new Point(88, 11); pictureBox19.Size = new Size(10, 10);
            pictureBox20.Location = new Point(99, 11); pictureBox20.Size = new Size(10, 10);
            pictureBox21.Location = new Point(0, 22); pictureBox21.Size = new Size(10, 10);
            pictureBox22.Location = new Point(11, 22); pictureBox22.Size = new Size(10, 10);
            pictureBox23.Location = new Point(22, 22); pictureBox23.Size = new Size(10, 10);
            pictureBox24.Location = new Point(33, 22); pictureBox24.Size = new Size(10, 10);
            pictureBox25.Location = new Point(44, 22); pictureBox25.Size = new Size(10, 10);
            pictureBox26.Location = new Point(55, 22); pictureBox26.Size = new Size(10, 10);
            pictureBox27.Location = new Point(66, 22); pictureBox27.Size = new Size(10, 10);
            pictureBox28.Location = new Point(77, 22); pictureBox28.Size = new Size(10, 10);
            pictureBox29.Location = new Point(88, 22); pictureBox29.Size = new Size(10, 10);
            pictureBox30.Location = new Point(99, 22); pictureBox30.Size = new Size(10, 10);
            pictureBox31.Location = new Point(0, 33); pictureBox31.Size = new Size(10, 10);
            pictureBox32.Location = new Point(11, 33); pictureBox32.Size = new Size(10, 10);
            pictureBox33.Location = new Point(22, 33); pictureBox33.Size = new Size(10, 10);
            pictureBox34.Location = new Point(33, 33); pictureBox34.Size = new Size(10, 10);
            pictureBox35.Location = new Point(44, 33); pictureBox35.Size = new Size(10, 10);
            pictureBox36.Location = new Point(55, 33); pictureBox36.Size = new Size(10, 10);
            pictureBox37.Location = new Point(66, 33); pictureBox37.Size = new Size(10, 10);
            pictureBox38.Location = new Point(77, 33); pictureBox38.Size = new Size(10, 10);
            pictureBox39.Location = new Point(88, 33); pictureBox39.Size = new Size(10, 10);
            pictureBox40.Location = new Point(99, 33); pictureBox40.Size = new Size(10, 10);
            pictureBox41.Location = new Point(0, 44); pictureBox41.Size = new Size(10, 10);
            pictureBox42.Location = new Point(11, 44); pictureBox42.Size = new Size(10, 10);
            pictureBox43.Location = new Point(22, 44); pictureBox43.Size = new Size(10, 10);
            pictureBox44.Location = new Point(33, 44); pictureBox44.Size = new Size(10, 10);
            pictureBox45.Location = new Point(44, 44); pictureBox45.Size = new Size(10, 10);
            pictureBox46.Location = new Point(55, 44); pictureBox46.Size = new Size(10, 10);
            pictureBox47.Location = new Point(66, 44); pictureBox47.Size = new Size(10, 10);
            pictureBox48.Location = new Point(77, 44); pictureBox48.Size = new Size(10, 10);
            pictureBox49.Location = new Point(88, 44); pictureBox49.Size = new Size(10, 10);
            pictureBox50.Location = new Point(99, 44); pictureBox50.Size = new Size(10, 10);
            pictureBox51.Location = new Point(0, 55); pictureBox51.Size = new Size(10, 10);
            pictureBox52.Location = new Point(11, 55); pictureBox52.Size = new Size(10, 10);
            pictureBox53.Location = new Point(22, 55); pictureBox53.Size = new Size(10, 10);
        }
        #endregion

        #region Click Jogar
        private void PBX_Jogar_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = true;
        }
        #endregion

        #region Fechar Jogo
        //SAIR ATRAVES DO INICIO DO JOGO
        private void PBX_Sair_Click(object sender, EventArgs e)
        {
            PNL_SairInicio.Visible = true;
        }

        private void PBX_SimInicio_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PBX_NaoInicio_Click(object sender, EventArgs e)
        {
            PNL_SairInicio.Visible = false;
        }


        //SAIR ATRAVES DO MENU DE PAUSE
        private void PBX_SairPause_Click(object sender, EventArgs e)
        {
            PNL_Sair.Visible = true;
        }
        private void BTN_NaoSair_Click(object sender, EventArgs e)
        {
            PNL_Sair.Visible = false;
        }

        private void BTN_SimSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmJogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        #endregion

        #region Continuar jogando
        private void PBX_Continuar_Click(object sender, EventArgs e)
        {
            PNL_Pause.Visible = false;
            TmrMainGameManager.Start();
            ativouMenu = 0;
        }
        #endregion

        #region MODOS DE VOLTAR AO INICIO
        private void PBX_VoltarInicio_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = false;
            PnlMenu.Visible = true;
        }
        #endregion
    }
}
