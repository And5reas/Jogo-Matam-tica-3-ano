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
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Media;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmJogo : Form
    {
        #region Variáveis Globais //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Classes
        public SoundPlayer SomTema;
        Save salvar;
        Utilits utilits;
        Thread nt;

        string escolhaPerson, objPerson;

        //A letra da pergunta
        char PerguntaLetra;

        //TEMPO DE JOGO
        int tempSeg, tempMin;

        //MENU
        int ativouMenu = 0, infoMenu, helpIndex = 1;

        //Alocar a fase que o player está 1, 2 ,3, 4...
        int fase, wins,

            //Swiths do debugMode
            DebugSwith, DebugSwithBust, DebugParedeSwith,

            //Variáveis de posição do player
            andarQtdPx = 6,
            posXPlayer, posYPlayer, posXColision, posYColision, posX2Player, posY2Player,
            animationPlayer, countAnimation, animationSpeed,

            //Variáveis que controla as animações
            ControleAnimacao = 0,

            //Variáveis de Vitaminas, Cristais e aleatorizar as perguntas
            contVitaminas = 0, contCristais = 0, randomPergunta = 0, auxCont = 0,

            //Controla o TmrPergunta
            tempPergunta = 0,

            //Score do player
            Score = 0, score_total_player = 0, CristalBuffTime = 0;

        //Controles do player
        bool goLeft, goRight, goDown, goUp,

            //Variável para ver se o debug está ativo ou não
            DebugSwithB,

            //Ativar apenas números
            JustNum;

        //Tirar as paredes no modo degub
        string paredesStatusDebug = "Parede";

        //Variáveis para as osperações matemáticas de perguntas
        Double num1, num2, num3, num4, resultado;

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public FrmJogo()
        {
            InitializeComponent();
            SomTema = new SoundPlayer(@Directory.GetCurrentDirectory() + "\\Sons\\menu.wav");
        }

        #region Controles //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Movimento do player
        private void FrmJogo_KeyDown(object sender, KeyEventArgs e)
        {
            //Tecla precionada
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = true;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = true;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                e.Handled = true; focoNoForm();
            }
        }
        private void FrmJogo_KeyUp(object sender, KeyEventArgs e)
        {
            //Tecla "solta"
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = false;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = false;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
                e.Handled = true; focoNoForm();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
                e.Handled = true; focoNoForm();
            }
        }

        private void FrmJogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ativar e desativar o Debug Mode
            if (e.KeyChar.ToString().ToLower() == "y")
            {
                //Debug ativo
                if (DebugSwith % 2 == 0)
                {
                    //Mostrar posição do personagem
                    DebugSwith++;
                    labelX.Visible = true;
                    labelY.Visible = true;
                    LblX.Visible = true;
                    LblY.Visible = true;
                    LblBust.Visible = true;
                    LblWallStatus.Visible = true;
                    DebugSwithB = true;
                    TmrDebug.Start();
                }
                //Debug Desativo
                else
                {
                    //Esconder posição do personagem
                    DebugSwith++;
                    labelX.Visible = false;
                    labelY.Visible = false;
                    LblX.Visible = false;
                    LblY.Visible = false;
                    LblBust.Visible = false;
                    LblWallStatus.Visible = false;
                    DebugSwithB = false;
                    TmrDebug.Stop();
                }
            }

            //Fazer o Personagem andar mais rápido
            if (e.KeyChar.ToString().ToLower() == "b" && DebugSwithB == true)
            {
                DebugSwithBust++;
                if (DebugSwithBust % 2 != 0)
                {
                    andarQtdPx = 50;
                    LblBust.Text = "Busted";
                }
                else
                {
                    andarQtdPx = 6;
                    LblBust.Text = "Normal";
                }
            }

            //Fazer o Personagem andar pelas paredes
            if (e.KeyChar.ToString().ToLower() == "n" && DebugSwithB == true)
            {
                DebugParedeSwith++;
                if (DebugParedeSwith % 2 != 0)
                {
                    paredesStatusDebug = "Sem paredes";
                    LblWallStatus.Text = "Paredes desativadas";
                }
                else
                {
                    paredesStatusDebug = "Parede";
                    LblWallStatus.Text = "Ativas";
                }
            }

            //Mostrar a pergunta sem pegar vitaminas
            if (e.KeyChar.ToString().ToLower() == "p" && DebugSwithB == true && PnlPerguntas.Visible != true)
            {
                if (contVitaminas == 8)
                {
                    contVitaminas = 0;
                }
                contVitaminas++;
                PerguntaLetra = utilits.perguntasEntrada(fase, contVitaminas);
                randomPergunta = utilits.getRandom();
                ControleAnimacao = 900;
                TmrAnimation.Start();
                TmrPergunta.Start();
            }

            //Pular o tempo da pergunta
            if (e.KeyChar.ToString().ToLower() == "o" && DebugSwithB == true && PnlPerguntas.Visible == true)
            {
                sairPergunta();
            }

            //Pause
            if (e.KeyChar == 27 && (PNL_SemTempo.Visible != true && PNL_Fases.Visible != true && PnlPerguntas.Visible != true))
            {
                if (ControleAnimacao == 0) {
                    if (ativouMenu == 0 && PNL_Pause.Enabled != false)
                    {
                        PNL_Pause.Visible = true;
                        TmrMainGameManager.Stop();
                        TMR_Tempo.Stop();
                        ativouMenu = 1;
                    }
                    else if (ativouMenu == 1)
                    {
                        PNL_Pause.Visible = false;
                        TmrMainGameManager.Start();
                        TMR_Tempo.Start();
                        ativouMenu = 0;
                    }
                }
            }

            if (e.KeyChar.ToString().ToLower() == "j")
            {
                z += 1;
                SaveScorePlayer.setScore("Andreas" + z, 10);
            }
            focoNoForm();
        }
        int z;
        //Verificar se são números que estão entrando, apenas.
        private void Verificar(object sender, KeyPressEventArgs e)
        {
            if (JustNum == true)
            {
                if (e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || (e.KeyChar > 47 && e.KeyChar < 58))
                {
                    e.KeyChar = e.KeyChar;
                }
                else
                {
                    e.KeyChar = Convert.ToChar(0);
                    e.Handled = true;
                }
            }
            else
            {
                e.KeyChar = e.KeyChar;
            }
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Load form //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void FrmJogo_Load(object sender, EventArgs e)
        {
            //Estanciar as classes
            salvar = new Save(PBX_Fase2, PBX_Fase3);
            #region Estanciar Utilits
            utilits = new Utilits
                (
                TmrMainGameManager,
                PbxPersonagem,
                PBX_Sair,
                PBX_Jogar,
                PNL_Fases,
                panel4,
                panel3,
                panel5,
                panel6,
                panel2,
                panel1,
                PbxColision,
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                pictureBox12,
                pictureBox13,
                pictureBox14,
                pictureBox15,
                pictureBox16,
                pictureBox17,
                pictureBox18,
                pictureBox19,
                pictureBox20,
                pictureBox21,
                pictureBox22,
                pictureBox23,
                pictureBox24,
                pictureBox25,
                pictureBox26,
                pictureBox27,
                pictureBox28,
                pictureBox29,
                pictureBox30,
                pictureBox31,
                pictureBox32,
                pictureBox33,
                pictureBox34,
                pictureBox35,
                pictureBox36,
                pictureBox37,
                pictureBox38,
                pictureBox39,
                pictureBox40,
                pictureBox41,
                pictureBox42,
                pictureBox43,
                pictureBox44,
                pictureBox45,
                pictureBox46,
                pictureBox47,
                pictureBox48,
                pictureBox49,
                pictureBox50,
                pictureBox51,
                pictureBox52,
                pictureBox53,
                TMR_Tempo,
                LBL_Tempo,
                TmrAnimation,
                PBX_Ambiente1,
                PBX_Ambiente2,
                PBX_Ambiente3,
                PBX_Ambiente4,
                PBX_Ambiente5,
                PBX_Ambiente6,
                PBX_Ambiente7,
                PBX_Vitamina1,
                PBX_Vitamina2,
                PBX_Vitamina3,
                PBX_Vitamina4,
                PBX_Vitamina5,
                PBX_Vitamina6,
                PBX_Vitamina7,
                PbxCerca,
                PnlPerguntas,
                TxtResposta,
                LblResposta,
                PbxBtnCerto,
                PbxBtn2,
                PbxBtn4,
                PbxBtn3,
                PbxBtn1,
                Lbl_de_Ajuda,
                TmrPergunta,
                LblResposta2,
                TxtResposta2,
                LblResposta3,
                TxtResposta3,
                PbxCristal1,
                PbxCristal2,
                PbxCristal3,
                PbxContVitaminas,
                PbxContCristais,
                LblContVitaminas,
                LblContCristais,
                LblScore,
                PBX_Help,
                LBL_txtHelp,
                LBL_txtHelp2,
                pictureBox58,
                pictureBox60,
                PBX_Vitoria,
                LblResposta4,
                TxtResposta4,
                PbxVinheta1,
                PbxVinheta2,
                SomTema,
                pictureBox61,
                PBX_Placar
                );
            #endregion

            //"Remover" os paineis 4 5 e 6
            utilits.removePnlsFases_4_5_6();

            //Desabilitar btn menu
            PBX_Jogar.Enabled = false;
            PBX_Sair.Enabled = false;
            PBX_Placar.Enabled = false;

            //Timers
            TmrMainGameManager.Stop();
            TmrDebug.Stop();
            TmrAnimation.Stop();

            //PAUSE
            PNL_Pause.Location = new Point(0, 109);
            PNL_Info.Location = new Point(281, -18);
            PNL_Pause.Visible = false;
            PNL_Pause.Enabled = false;

            //FASES DESATIVADAS
            PBX_Fase2.Enabled = false;
            PBX_Fase3.Enabled = false;

            //ESCONDER FASES
            PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");

            //PAINEL DE FASES
            PNL_Fases.Visible = false;
            PNL_Fases.Location = new Point(0, 0);

            //PAINEL MENU
            PnlMenu.Location = new Point(0, 0);
            PnlMenu.Visible = true;

            //Painel perguntas
            PnlPerguntas.Location = new Point(10, 960);
            PnlPerguntas.Visible = false;

            //Painel de help
            PNL_Help.Location = new Point(273, 170);

            //Esconder opções debugMode
            labelX.Visible = false;
            labelY.Visible = false;
            LblX.Visible = false;
            LblY.Visible = false;
            LblBust.Visible = false;
            LblWallStatus.Visible = false;

            //Organizer objetos do pnlPergunta
            utilits.resetarObjetosPergunta(contVitaminas);

            //Mostrar a "vinheta
            ControleAnimacao = utilits.vinheta();
            TmrAnimation.Start();

            //Definir o que pode digitar nos txt de pergunta
            JustNum = false;
            
            salvar.Load();
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region MainGameMenager //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
                    if ((string)g.Tag == paredesStatusDebug)
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
                            //Se caso a colisão entrar na parede
                            else
                            {
                                PbxPersonagem.Location = new Point(posX2Player, posY2Player);
                                PbxColision.Location = new Point(posX2Player + 11, posY2Player + 33);
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
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\esquerda\\esquerda_" + animationPlayer + ".png");
            }
            else if (goRight == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer + andarQtdPx, posYPlayer);
                PbxColision.Location = new Point(posXColision + andarQtdPx, posYColision);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_" + animationPlayer + ".png");
            }
            else if (goUp == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer - andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision - andarQtdPx);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\costas\\costas_" + animationPlayer + ".png");
            }
            else if (goDown == true)
            {
                PbxPersonagem.Location = new Point(posXPlayer, posYPlayer + andarQtdPx);
                PbxColision.Location = new Point(posXColision, posYColision + andarQtdPx);
                countAnimation++;
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\frente\\frente_" + animationPlayer + ".png");
            }

            //Pegar moedas com Tag Vitamina
            foreach (Control f in this.Controls)
            {
                if (f is PictureBox)
                {
                    if ((string)f.Tag == "Vitamina" && f.Visible == true)
                    {
                        if (PbxColision.Bounds.IntersectsWith(f.Bounds))
                        {
                            f.Visible = false;
                            contVitaminas++;
                            PerguntaLetra = utilits.perguntasEntrada(fase, contVitaminas);
                            randomPergunta = utilits.getRandom();
                            ControleAnimacao = 900;
                            TmrAnimation.Start();
                            TmrPergunta.Start();
                        }
                    }
                }
            }

            //Pegar moedas com Tag Cristal
            foreach (Control h in this.Controls)
            {
                if (h is PictureBox)
                {
                    if ((string)h.Tag == "Cristal" && h.Visible == true)
                    {
                        if (PbxColision.Bounds.IntersectsWith(h.Bounds))
                        {
                            h.Visible = false;
                            contCristais++;

                            //Exibir para o player (Placar)
                            LblContCristais.Text = "x" + contCristais;
                            if (contCristais != 3)
                                CristalBuffTime = 6;
                            if (contCristais == 3)
                            {
                                Score += 100;
                                LblScore.ForeColor = Color.Orange;
                                LblScore.Text = Score.ToString();
                            }
                        }
                    }
                }
            }

            //Ganhar a fase
            foreach (Control h in this.Controls)
            {
                if (h is PictureBox)
                {
                    if ((string)h.Tag == "Vitória" && h.Visible == true)
                    {
                        if (PbxColision.Bounds.IntersectsWith(h.Bounds) && fase == 1)
                        {
                            vitoriaSet();
                            PBX_Fase2.Enabled = true;
                            PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                            utilits.setMusicStop(SomTema);
                            objPerson = "Tocha";
                            if (wins == 0)
                                wins += 1;
                        }
                        if (PbxColision.Bounds.IntersectsWith(h.Bounds) && fase == 2)
                        {
                            vitoriaSet();
                            PBX_Fase3.Enabled = true;
                            PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_3.png");
                            objPerson = "Flores";
                            if (wins == 1)
                                wins += 1;
                        }
                        if (PbxColision.Bounds.IntersectsWith(h.Bounds) && fase == 3)
                        {
                            vitoriaSet();
                            objPerson = "Gelo";
                            if (wins == 2)
                                wins += 1;
                        }
                    }
                }
            }

            // Para abrir o form de inserção de dados quando o player zerar o jogo
            if (wins == 3)
            {
                this.Enabled = false;
                
                nt = new Thread(abrirInsercaoNome);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
                wins += 3;
            }
            // Reativar o form depois que preencher o insertScore
            if (nt != null)
                if (!nt.IsAlive)
                    this.Enabled = true;

            if (contVitaminas == 7)
            {
                if ((contCristais == 1 || contCristais == 2 || contCristais == 3) && auxCont == 0)
                {
                    auxCont += 1;
                    Score += 100;
                    LblScore.Text = Score.ToString();
                }
            }
        }

        private void vitoriaSet()
        {
            TmrMainGameManager.Stop();
            TMR_Tempo.Stop();
            utilits.animcaoWin = 1;
            PBX_Vitoria.Visible = false;
            ControleAnimacao = 1;
            TmrAnimation.Start();
            score_total_player += Score;
            contVitaminas = 0;
            contCristais = 0;
            // Atualizar o score total
            LBL_ScoreTotal.Text = score_total_player.ToString();
        }

        private void abrirInsercaoNome()
        {
            Application.Run(new FrmInserirScore(score_total_player));
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region EFEITO BOTOES MENU //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
        private void PBX_Placar_MouseHover(object sender, EventArgs e)
        {
            PBX_Placar.Size = new Size(250, 150);
            PBX_Placar.Location = new Point(530, 449);
        }

        private void PBX_Placar_MouseLeave(object sender, EventArgs e)
        {
            PBX_Placar.Size = new Size(220, 120);
            PBX_Placar.Location = new Point(547, 449);
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
        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Start fase 1 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Fase1_Click(object sender, EventArgs e)
        {
            //Diretório das imagens que estamos usando para a fase
            string diretorioVit = "\\img\\itens\\maca_animada.gif",
                   diretorioCristal = "\\img\\itens\\cristal_animado.gif",
                   diretorioAmbiente = "\\img\\ambiente\\mapa_1\\arbusto_macas_mapa1.png",
                   diretorioObjeto = "\\img\\itens\\tocha_animada.gif";

            //Fase atual
            fase = 1;

            //TEMPO DE FASE
            tempMin = 2;
            tempSeg = 0;
            LBL_Tempo.Text = "2:00";

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PBX_btnVoltaHelp.Visible = false;
            PNL_Help.Visible = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_1.png");
            this.BackColor = Color.SeaGreen;
            PBX_Vitoria.Image = Image.FromFile(Directory.GetCurrentDirectory() + diretorioObjeto);
            PbxPartBaixo.BackColor = Color.SeaGreen;
            PbxPartBaixo.Location = new Point(-2, 757);
            PbxPartBaixo.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\Parte de baixo\\fase" + fase + ".png");

            //Setar a cerca da fase
            PbxCerca.Location = new Point(1181, 554);
            PbxCerca.Visible = true;

            //Setar a posição inicial da colisão e personagem e imagen
            ControleAnimacao = 700;

            //ORGANIZAR O PLACAR DA FASE
            utilits.setPlacar(fase);
            Score = 0;

            //SETAR TRANSPARENCIA ITENS
            utilits.itensTrans();

            //SETAR IMAGEM DOS ITENS
            utilits.setarVitaminas(fase, 22, 26, diretorioVit);
            utilits.setCrist(fase, 22, 26, diretorioCristal);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR AMBIENTE
            utilits.setAmbiente(fase, 66, 55, diretorioAmbiente);

            //Carregar as paredes
            utilits.loadWalls(fase);

            //Setar a música da fase
            utilits.setMusic("floresta_1");

            PBX_Help.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\help\\mapa_" + fase + "\\infoHelp_" + helpIndex + ".png");
        }
        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Start fase 2 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Fase2_Click(object sender, EventArgs e)
        {
            //Diretório das imagens que estamos usando para a fase
            string diretorioVit = "\\img\\itens\\bifeCru_animado.gif",
                   diretorioCristal = "\\img\\itens\\cristal_animado.gif",
                   diretorioAmbiente = "\\img\\ambiente\\mapa_2\\buracos_mapa2.png",
                   diretorioObjeto = "\\img\\itens\\bastao_flores.gif";

            //Fase atual
            fase = 2;

            //TEMPO DE FASE
            tempMin = 2;
            tempSeg = 15;
            LBL_Tempo.Text = "2:15";

            //Start da fase
            TMR_Tempo.Start();

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_2.png");
            this.BackColor = Color.Gray;
            PBX_Vitoria.Image = Image.FromFile(Directory.GetCurrentDirectory() + diretorioObjeto);
            PbxPartBaixo.BackColor = Color.Gray;
            PbxPartBaixo.Location = new Point(-2, 757);
            PbxPartBaixo.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\Parte de baixo\\fase" + fase + ".png");

            //Setar a cerca da fase
            PbxCerca.Location = new Point(1191, 650);
            PbxCerca.Visible = true;

            //Setar a posição inicial da colisão e personagem e imagen
            ControleAnimacao = 700;
            TmrAnimation.Start();

            //ORGANIZAR O PLACAR DA FASE
            utilits.setPlacar(fase);
            Score = 0;

            //SETAR TRANSPARENCIA ITENS
            utilits.itensTrans();

            //SETAR IMAGEM DOS ITENS
            utilits.setarVitaminas(fase, 22, 26, diretorioVit);
            utilits.setCrist(fase, 22, 26, diretorioCristal);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR TRANSPARENCIA
            utilits.setAmbiente(fase, 45, 49, diretorioAmbiente);

            //Carregar as paredes
            utilits.loadWalls(fase);

            //Setar a música da fase
            utilits.setMusic("caverna");
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Start fase 3 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Fase3_Click(object sender, EventArgs e)
        {
            //Diretório das imagens que estamos usando para a fase
            string diretorioVit = "\\img\\itens\\cereja_animada.gif",
                   diretorioCristal = "\\img\\itens\\cristal_animado.gif",
                   diretorioAmbiente = "\\img\\ambiente\\mapa_5\\arvoreNeve.png",
                   diretorioObjeto = "\\img\\itens\\roupaGelo_animada.gif";

            //Fase atual
            fase = 3;

            //TEMPO DE FASE
            tempMin = 2;
            tempSeg = 15;
            LBL_Tempo.Text = "2:15";

            //Setar a posição inicial da colisão e personagem e imagen
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_1.png");

            //Start da fase
            TMR_Tempo.Start();
            ControleAnimacao = 700;
            TmrAnimation.Start();

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;
            PBX_AmbVilao.Visible = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_3.png");
            this.BackColor = Color.SeaGreen;
            PBX_Vitoria.Image = Image.FromFile(Directory.GetCurrentDirectory() + diretorioObjeto);
            PbxPartBaixo.BackColor = Color.SeaGreen;
            PbxPartBaixo.Location = new Point(-2, 757);
            PbxPartBaixo.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\Parte de baixo\\fase" + fase + ".png");

            //Setar a cerca da fase
            PbxCerca.Location = new Point(1171, 646);
            PbxCerca.Visible = true;

            //ORGANIZAR O PLACAR DA FASE
            utilits.setPlacar(fase);
            Score = 0;

            //SETAR TRANSPARENCIA ITENS
            utilits.itensTrans();

            //SETAR IMAGEM DOS ITENS
            utilits.setarVitaminas(fase, 28, 33, diretorioVit);
            utilits.setCrist(fase, 22, 26, diretorioCristal);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR AMBIENTE
            utilits.setAmbiente(fase, 66, 55, diretorioAmbiente);

            //Carregar as paredes
            utilits.loadWalls(fase);

            //Setar a música da fase
            utilits.setMusic("gelo");
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Abertura de jogo/Funções Iniciais //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Jogar_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = true;
            PnlMenu.Visible = false;
            PNL_MostrarFases.Location = new Point(150, 51);
        }

        // Placar
        private void PBX_Placar_Click(object sender, EventArgs e)
        {
            nt = new Thread(abrirPlacar);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void abrirPlacar()
        {
            Application.Run(new FrmPlacar());
        }

        //ESCOLHER GERALDO
        private void PBX_Escolha1_Click(object sender, EventArgs e)
        {
            PNL_MostrarFases.Visible = true;
            escolhaPerson = "masculino";
            objPerson = "Madeira";
        }

        //ESCOLHER JOAQUINA
        private void PBX_Escolha2_Click(object sender, EventArgs e)
        {
            PNL_MostrarFases.Visible = true;
            escolhaPerson = "feminino";
        }

        //Animação escolha GERALDO
        private void PBX_Escolha1_MouseHover(object sender, EventArgs e)
        {
            PBX_Escolha1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculinoMadeira\\frente\\frente_maior2.png");
            LBL_Nome1.ForeColor = Color.GreenYellow;
        }

        private void PBX_Escolha1_MouseLeave(object sender, EventArgs e)
        {
            PBX_Escolha1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculinoMadeira\\frente\\frente_maior.png");
            LBL_Nome1.ForeColor = Color.Coral;
        }

        //Animação escolha JOAQUINA
        private void PBX_Escolha2_MouseHover(object sender, EventArgs e)
        {
            PBX_Escolha2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\feminino\\frente\\frente_pedra_maior2.png");
            LBL_Nome2.ForeColor = Color.GreenYellow;
        }

        private void PBX_Escolha2_MouseLeave(object sender, EventArgs e)
        {
            PBX_Escolha2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\feminino\\frente\\frente_pedra_maior.png");
            LBL_Nome2.ForeColor = Color.Coral;
        }

        //BTN voltar do menu fases
        private void PBX_VoltarFase_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = false;
            PnlMenu.Visible = true;
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Fechar Jogo //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //SAIR ATRAVES DO INICIO DO JOGO
        private void PBX_Sair_Click(object sender, EventArgs e)
        {
            PNL_SairInicio.Visible = true;
        }

        private void PBX_SimInicio_Click(object sender, EventArgs e)
        {
            Close();
            if (nt != null)
                nt.Abort(); 
        }

        private void PBX_NaoInicio_Click(object sender, EventArgs e)
        {
            PNL_SairInicio.Visible = false;
        }

        private void FrmJogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nt != null)
                nt.Abort();
        }
        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region MENU PAUSE //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //CONTINUAR JOGANDO
        private void PBX_Continuar_Click(object sender, EventArgs e)
        {
            PNL_Pause.Visible = false;
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            ativouMenu = 0;
        }

        //BOTAO SAIR
        private void PBX_SairPause_Click(object sender, EventArgs e)
        {
            infoMenu = 1;
            PNL_Info.Visible = true;
            PBX_Info.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\textos\\txtSair.png");
        }
        private void BTN_NaoInfo_Click(object sender, EventArgs e)
        {
            PNL_Info.Visible = false;
        }

        private void BTN_SimInfo_Click(object sender, EventArgs e)
        {
            //FECHAR O JOGO
            if (infoMenu == 1)
            {
                Close();
            }

            //REINICIAR JOGO
            if (infoMenu == 2)
            {
                (tempMin, tempSeg, andarQtdPx, ControleAnimacao, contCristais, contVitaminas, Score) = utilits.resetFaseInts(fase);
                mostrarTodasPbx();
                ativouMenu = 0;
                TmrMainGameManager.Start();
                TMR_Tempo.Start();
                PNL_Info.Visible = false;
                PNL_Pause.Visible = false;
            }
            //VOLTAR PARA O MENU FASES
            if (infoMenu == 3)
            {
                (tempMin, tempSeg, andarQtdPx, ControleAnimacao, contCristais, contVitaminas, Score) = utilits.resetFaseInts(fase);
                mostrarTodasPbx();
                ativouMenu = 0;
                TmrMainGameManager.Stop();
                TMR_Tempo.Stop();
                PNL_Pause.Visible = false;
                PNL_Info.Visible = false;
                PNL_Fases.Visible = true;
                LBL_Tempo.Text = "";
                esconderTodasPbx();
                utilits.setMusic("menu");
            }
        }

        //REINICIAR FASE
        private void PBX_Reiniciar_Click(object sender, EventArgs e)
        {
            infoMenu = 2;
            PNL_Info.Visible = true;
            PBX_Info.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\textos\\txtReiniciar.png");
        }

        //VOLTAR A SELECAO DE FASES
        private void PBX_Inicio_Click(object sender, EventArgs e)
        {
            helpIndex = 1;
            infoMenu = 3;
            PNL_Info.Visible = true;
            PBX_Info.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\textos\\txtInicio.png");
        }

        private void PBX_Salvar_Click(object sender, EventArgs e)
        {
            salvar.save(fase);
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region MODOS DE VOLTAR AO INICIO //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_VoltarInicio_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = false;
            PnlMenu.Visible = true;
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region LÓGICA DE TEMPO DE JOGO E DO SCORE //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TMR_Tempo_Tick(object sender, EventArgs e)
        {
            if (contVitaminas == 7)
            {
                TMR_Tempo.Interval = 70;
                if (tempSeg <= 60)
                {
                    if (tempSeg == 0)
                    {
                        tempMin--;
                        if (tempMin >= 0)
                        {
                            tempSeg = 60;
                        }
                    }
                    if (tempSeg <= 10)
                    {
                        tempSeg--;
                        if (tempSeg == -1)
                        {
                            LBL_Tempo.Text = "0:00";
                            TMR_Tempo.Stop();
                        }
                        else
                        {
                            LBL_Tempo.ForeColor = Color.White;
                            LBL_Tempo.Text = tempMin.ToString() + ":" + "0" + tempSeg.ToString();
                        }
                    }
                }
                if (tempSeg >= 10)
                {
                    tempSeg--;
                    LBL_Tempo.ForeColor = Color.White;
                    LBL_Tempo.Text = tempMin.ToString() + ":" + tempSeg.ToString();
                }

                //Sistema de pontos
                if (tempSeg != -1) {
                    Score += 2;

                    utilits.LBLScore(530, 520, 490);
                    LblScore.Text = Score.ToString();
                }
            }
            else
            {
                TMR_Tempo.Interval = 1000;
                if (tempSeg <= 60)
                {
                    if (tempSeg == 0)
                    {
                        tempMin--;

                        if (tempMin >= 0)
                        {
                            tempSeg = 60;
                        }
                    }
                    if (tempSeg <= 10)
                    {
                        tempSeg--;
                        if (tempSeg == -1)
                        {
                            PNL_Pause.Enabled = false;
                            TMR_Tempo.Stop();
                            TMR_SemTempo.Start();
                            PNL_SemTempo.Location = new Point(365, 307);
                            PNL_SemTempo.Visible = true;
                            TmrMainGameManager.Stop();
                        }
                        else
                        {
                            LBL_Tempo.ForeColor = Color.White;
                            LBL_Tempo.Text = tempMin.ToString() + ":" + "0" + tempSeg.ToString();
                        }
                    }
                    if (tempSeg >= 10)
                    {
                        tempSeg--;
                        LBL_Tempo.ForeColor = Color.White;
                        LBL_Tempo.Text = tempMin.ToString() + ":" + tempSeg.ToString();
                    }
                }

                //Correção por conta das vitaminas que add tempo
                else
                {
                    tempMin++;
                    tempSeg = tempSeg - 60;
                    LBL_Tempo.ForeColor = Color.White;
                    LBL_Tempo.Text = tempMin.ToString() + ":" + "0" + tempSeg.ToString();
                }

                //Sistema de pontos
                Score++;
                if (CristalBuffTime == 0)
                {
                    LblScore.ForeColor = Color.WhiteSmoke;
                    LblScore.Text = Score.ToString();
                    utilits.LBLScore(570, 550, 545);
                    if (DebugSwithB == false)
                        andarQtdPx = 6;
                }
                else
                {
                    utilits.LBLScore(530, 520, 490);
                    if (contCristais == 1)
                    {
                        Score += 3;
                        LblScore.ForeColor = Color.Yellow;
                        LblScore.Text = Score + "+" + (contCristais + 3);
                        andarQtdPx = 8;
                    }
                    else if (contCristais == 2)
                    {
                        Score += 7;
                        LblScore.ForeColor = Color.Orange;
                        LblScore.Text = Score + "+" + (contCristais + 6);
                        andarQtdPx = 8;
                    }
                    CristalBuffTime--;
                }
            }
        }

        //ANIMACAO SEM TEMPO
        private void TMR_SemTempo_Tick(object sender, EventArgs e)
        {
            LBL_SemTempo.ForeColor = LBL_SemTempo.ForeColor == Color.Brown ? Color.Gainsboro : Color.Brown;
            LBL_SemTempo2.ForeColor = LBL_SemTempo2.ForeColor == Color.Brown ? Color.Gainsboro : Color.Brown;
        }

        //VOLTAR A JOGAR
        private void BTN_SimTempo_Click(object sender, EventArgs e)
        {
            PNL_Pause.Enabled = true;
            PNL_SemTempo.Visible = false;
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\masculino\\direita\\direita_1.png");
            (tempMin, tempSeg, andarQtdPx, ControleAnimacao, contCristais, contVitaminas, Score) = utilits.resetFaseInts(fase);
            mostrarTodasPbx();
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
        }

        //SAIR DO JOGO
        private void BTN_SimTempo2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //APERTAR NO BOTAO NAO
        private void BTN_NaoTempo_Click(object sender, EventArgs e)
        {
            PNL_SemTempo.Visible = false;
            PNL_SemTempo2.Location = new Point(365, 307);
            PNL_SemTempo2.Visible = true;
        }

        private void BTN_NaoTempo2_Click(object sender, EventArgs e)
        {
            PNL_SemTempo2.Visible = false;
            PNL_SemTempo.Visible = true;
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Funções //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void mostrarTodasPbx()
        {
            foreach (Control j in Controls)
            {
                if (j is PictureBox)
                {
                    if (j.Visible == false && (string)j.Tag != "Parede" && (string)j.Tag != "Colision")
                    {
                        j.Visible = true;
                    }
                }
            }
        }
        public void esconderTodasPbx()
        {
            foreach (Control j in Controls)
            {
                if (j is PictureBox)
                {
                    if (j.Visible == true && (string)j.Tag != "Parede" && (string)j.Tag != "Colision")
                    {
                        j.Visible = false;
                    }
                }
            }
        }

        public void sairPergunta()
        {
            ControleAnimacao = utilits.rodarSaidaPerguntas();
            focoNoForm();
            TmrAnimation.Start();
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Animações //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TmrAnimation_Tick(object sender, EventArgs e)
        {
            //ControleAnimacao = 0 | Animação personagem ganhando fase
            if (ControleAnimacao > 0 && ControleAnimacao < 671)
                ControleAnimacao = utilits.ganharFase(ControleAnimacao, escolhaPerson, objPerson);

            //ControleAnimacao = 700 | Animações do personagem entrando na fase
            if (ControleAnimacao > 671 && ControleAnimacao < 753)
                ControleAnimacao = utilits.entrandoFase(ControleAnimacao, escolhaPerson, objPerson, fase);

            //ControleAnimacao = 800 | Animação do portão
            if (ControleAnimacao > 753 && ControleAnimacao < 837)
                ControleAnimacao = utilits.doorOpen(ControleAnimacao);

            //controleAnimações = 900 | Animação da pergunta aparecendo
            if (ControleAnimacao == 970)
                JustNum = utilits.setarBtnPergunta(fase);
            if (ControleAnimacao > 837 && ControleAnimacao < 971)
                ControleAnimacao = utilits.aparecendoPergunta(ControleAnimacao);


            //controleAnimações = 1000 | Animação da pergunta desaparecendo
            if (ControleAnimacao == 1068)
            {
                JustNum = false;
                tempPergunta = 0;
            }
            if (ControleAnimacao > 971 && ControleAnimacao < 1069)
                ControleAnimacao = utilits.aparecendoPergunta(ControleAnimacao, contVitaminas);


            //controleAnimações = 1100 | Animação da vinheta
            if (ControleAnimacao > 1070 && ControleAnimacao < 1709)
                ControleAnimacao = utilits.vinheta(ControleAnimacao);

        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Estética das caixas de texto //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TxtResposta_TextChanged(object sender, EventArgs e)
        {
            if (TxtResposta.MaxLength <= 4)
            {
                LblResposta.Text = TxtResposta.Text;
            }
            else
            {
                LblResposta.Text = TxtResposta.Text + "|";
            }
        }
        private void TxtResposta2_TextChanged(object sender, EventArgs e)
        {
            if (TxtResposta2.MaxLength <= 4)
            {
                LblResposta2.Text = TxtResposta2.Text;
            }
            else
            {
                LblResposta2.Text = TxtResposta2.Text + "|";
            }
        }
        private void TxtResposta3_TextChanged(object sender, EventArgs e)
        {
            if (TxtResposta3.MaxLength <= 4)
            {
                LblResposta3.Text = TxtResposta3.Text;
            }
            else
            {
                LblResposta3.Text = TxtResposta3.Text + "|";
            }
        }
        private void TxtResposta4_TextChanged(object sender, EventArgs e)
        {
            if (TxtResposta4.MaxLength <= 4)
            {
                LblResposta4.Text = TxtResposta4.Text;
            }
            else
            {
                LblResposta4.Text = TxtResposta4.Text + "|";
            }
        }
        private void LblResposta_Click(object sender, EventArgs e)
        {
            LblResposta.Font = new Font("Snap ITC", 24);
            LblResposta.Text = "|";
            TxtResposta.Enabled = true;
            TxtResposta.Focus();
            TxtResposta.Clear();
        }
        private void LblResposta2_Click(object sender, EventArgs e)
        {
            LblResposta2.Font = new Font("Snap ITC", 24);
            LblResposta2.Text = "|";
            TxtResposta2.Enabled = true;
            TxtResposta2.Focus();
            TxtResposta2.Clear();
        }
        private void LblResposta3_Click(object sender, EventArgs e)
        {
            LblResposta3.Font = new Font("Snap ITC", 24);
            LblResposta3.Text = "|";
            TxtResposta3.Enabled = true;
            TxtResposta3.Focus();
            TxtResposta3.Clear();
        }
        private void LblResposta4_Click(object sender, EventArgs e)
        {
            LblResposta4.Font = new Font("Snap ITC", 24);
            LblResposta4.Text = "|";
            TxtResposta4.Enabled = true;
            TxtResposta4.Focus();
            TxtResposta4.Clear();
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Btn perguntas correção //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PbxBtnCerto_Click(object sender, EventArgs e)
        {
            tempSeg = utilits.addTempo(10, tempSeg);
            Score = utilits.addScorePonto(20, Score);
            sairPergunta();
        }

        private void PbxBtn1_Click(object sender, EventArgs e)
        {
            tempSeg = utilits.addTempo(-5, tempSeg);
            Score = utilits.addScorePonto(-20, Score);
            sairPergunta();
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Correção de perguntas e tempo das perguntas //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TmrPergunta_Tick(object sender, EventArgs e)
        {
            tempPergunta++;
            if (tempPergunta == PrbTempPerg.Maximum - 2)
            {
                tempSeg = utilits.addTempo(-5, tempSeg);
                Score = utilits.addScorePonto(-20, Score);
                sairPergunta();
            }
            if (tempPergunta >= 0 && tempPergunta <= 4000)
            {
                PrbTempPerg.Value = tempPergunta;
            }
            if (fase == 1) //Resposta de texto da fase 1
            {
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text != "" && TxtResposta2.Text != "" && TxtResposta3.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                        resultado = 0;
                        resultado = (num1 - (num2 + num3)) * -1;
                    }
                    if (resultado == 27)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        Lbl_de_Ajuda.Text = "Você Acertou!! ＜（＾－＾）＞";
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                    else if (resultado > 17 && resultado < 37)
                    {
                        Lbl_de_Ajuda.Text = "Você está perto! :)";
                    }
                    else
                    {
                        Lbl_de_Ajuda.Text = num1.ToString() + " - " + num2.ToString() + " + " + num3.ToString() + " é igua a " + resultado + "\nVocê está longe do resultado :(";
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 7 * 4)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 6 * 3)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 7 * 8)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 7 * 4 && num2 == 6 * 3 && num3 == 7 * 8)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 10)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (TxtResposta4.Text != "")
                    {
                        num4 = Convert.ToDouble(TxtResposta4.Text);
                    }
                    if (num1 == 64 / 2) 
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 448 / 4) 
                    { 
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 93 / 3)
                    { 
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num4 == 535 / 5)
                    {
                        LblResposta4.ForeColor = Color.Green;
                        LblResposta4.Enabled = false;
                    }
                    if (num1 == 64 / 2 && num2 == 448 / 4 && num3 == 93 / 3 && num4 == 535 / 5)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 33)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
            }
            if (fase == 2) //Resposta de texto da fase 2
            {
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 10 / 10)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 10 / 5)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 10 / 2)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 10 / 10 && num2 == 10 / 5 && num3 == 10 / 2)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 5 * 5)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 4 * 4)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 3 * 3)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 5 * 5 && num2 == 4 * 4 && num3 == 3 * 3)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 30 / 6)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 28 / 4)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 30 / 3)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 30 / 6 && num2 == 28 / 4 && num3 == 30 / 3)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 10)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 7)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 45)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 16)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (num1 == 53)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 5)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num1 == 53 && num2 == 5)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text.ToLower() == "cento e cinquenta e um")
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                    }
                }
            }
            if (fase == 3) //Resposta de texto da fase 3
            {
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 7)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 31549)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (num1 == 75 - 24)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 124 - 34)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num1 == 75 - 24 && num2 == 124 - 34)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 5371)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (TxtResposta4.Text != "")
                    {
                        num4 = Convert.ToDouble(TxtResposta4.Text);
                    }
                    if (num1 == 3 + 3)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 3 + 6)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 3 + 9)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num4 == 3 + 12)
                    {
                        LblResposta4.ForeColor = Color.Green;
                        LblResposta4.Enabled = false;
                    }
                    if (num1 == 3 + 3 && num2 == 3 + 6 && num3 == 3 + 9 && num4 == 3 + 12)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 10)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 16)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 23)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 10 && num2 == 16 && num3 == 23)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 5 / 70)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 86)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 54391)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (num1 == 95 - 64)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 24 + 34)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num1 == 95 - 64 && num2 == 24 + 34)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 5344)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (TxtResposta4.Text != "")
                    {
                        num4 = Convert.ToDouble(TxtResposta4.Text);
                    }
                    if (num1 == 5 + 5)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 5 + 10)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 5 + 15)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num4 == 5 + 20)
                    {
                        LblResposta4.ForeColor = Color.Green;
                        LblResposta4.Enabled = false;
                    }
                    if (num1 == 5 + 5 && num2 == 5 + 10 && num3 == 5 + 15 && num4 == 5 + 20)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 15)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 24)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 36)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 15 && num2 == 24 && num3 == 36)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 5 * 9)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (TxtResposta4.Text != "")
                    {
                        num4 = Convert.ToDouble(TxtResposta4.Text);
                    }
                    if (num1 == 23)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 42)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 74)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num4 == 86)
                    {
                        LblResposta4.ForeColor = Color.Green;
                        TxtResposta4.Enabled = false;
                    }
                    if (num1 == 23 && num2 == 42 && num3 == 74 && num4 == 86)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 53194)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (num1 == 75 - 75)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 124 - 96)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num1 == 75 - 75 && num2 == 124 - 96)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 3271)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (TxtResposta4.Text != "")
                    {
                        num4 = Convert.ToDouble(TxtResposta4.Text);
                    }
                    if (num1 == 7 + 7)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 7 + 14)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 7 + 21)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num4 == 7 + 28)
                    {
                        LblResposta4.ForeColor = Color.Green;
                        LblResposta4.Enabled = false;
                    }
                    if (num1 == 7 + 7 && num2 == 7 + 14 && num3 == 7 + 21 && num4 == 7 + 28)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'f')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (TxtResposta2.Text != "")
                    {
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                    }
                    if (TxtResposta3.Text != "")
                    {
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                    }
                    if (num1 == 14)
                    {
                        LblResposta.ForeColor = Color.Green;
                        LblResposta.Enabled = false;
                    }
                    if (num2 == 25)
                    {
                        LblResposta2.ForeColor = Color.Green;
                        LblResposta2.Enabled = false;
                    }
                    if (num3 == 33)
                    {
                        LblResposta3.ForeColor = Color.Green;
                        LblResposta3.Enabled = false;
                    }
                    if (num1 == 14 && num2 == 25 && num3 == 33)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
                if (randomPergunta == 3 && PerguntaLetra == 'g')
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 5 + 70)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        sairPergunta();
                        focoNoForm();
                        TxtResposta.Clear(); TxtResposta2.Clear(); TxtResposta3.Clear(); TxtResposta4.Clear();
                        num1 = 0; num2 = 0; num3 = 0; num4 = 0; resultado = 0;
                    }
                }
            }
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region HELP do jogo //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void PBX_bntVaiHelp_Click(object sender, EventArgs e)
        {
            helpIndex++;
            PBX_btnVoltaHelp.Visible = true;
            if (helpIndex == 5)
            {
                PNL_Pause.Enabled = true;
                PNL_Help.Visible = false;
                TMR_Tempo.Start();
                TmrAnimation.Start();
            }
            else
                 utilits.helpImg(fase, helpIndex);
        }
        private void PBX_btnVoltaHelp_Click(object sender, EventArgs e)
        {
            helpIndex--;
            PBX_bntVaiHelp.Visible = true;
            if (helpIndex == 1)
            {
                PBX_btnVoltaHelp.Visible = false;
                utilits.helpImg(fase, helpIndex);
            }
            else
            {
                utilits.helpImg(fase, helpIndex);
            }   
        }

        private void LBL_HelpSair_Click(object sender, EventArgs e)
        {
            helpIndex = 1;
            PNL_Pause.Enabled = true;
            PNL_Help.Visible = false;
            TMR_Tempo.Start();
            TmrAnimation.Start();
        }

        #endregion //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Foco no form
        private void FrmJogo_Click(object sender, EventArgs e)
        {
            focoNoForm();
        }
        public void focoNoForm()
        {
            this.Focus();
        }
        #endregion

        #region TIMER PARA TESTES
        private void TmrDebug_Tick(object sender, EventArgs e)
        {
            Console.WriteLine();
        }
        #endregion
    }
}
