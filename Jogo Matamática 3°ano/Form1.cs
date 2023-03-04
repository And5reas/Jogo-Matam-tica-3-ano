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

        //Colocar som no jogo
        public SoundPlayer SomTema;
        Save salvar;
        Utilits utilits;

        string escolhaPerson, objPerson;

        //A letra da pergunta
        char PerguntaLetra;

        //TEMPO DE JOGO
        int tempSeg, tempMin;

        //MENU
        int ativouMenu = 0, infoMenu, helpIndex = 1;

        //Alocar a fase que o player está 1, 2 ,3, 4...
        int fase,

            //Swiths do debugMode
            DebugSwith, DebugSwithBust, DebugParedeSwith,

            //Variáveis de posição do player
            andarQtdPx = 6,
            posXPlayer, posYPlayer, posXColision, posYColision, posX2Player, posY2Player,
            animationPlayer, countAnimation, animationSpeed,

            //Variáveis que controla as animações
            ControleAnimacao = 0,

            //Variáveis de Vitaminas, Cristais e aleatorizar as perguntas
            contVitaminas = 0, contCristais = 0, contVitaTotal = 0, contCrisTotal = 0, randomPergunta = 0,

            //Controla o TmrPergunta
            tempPergunta = 0,

            //Score do player
            Score = 0, CristalBuffTime = 0;

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
                this.Focus();
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = true;
                this.Focus();
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                this.Focus();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                this.Focus();
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
                contVitaTotal++;
                PerguntaLetra = utilits.perguntasEntrada(fase, contVitaminas, contVitaTotal);
                randomPergunta = utilits.getRandom();
                ControleAnimacao = 900;
                TmrAnimation.Start();
                TmrPergunta.Start();
            }

            //Pular o tempo da pergunta
            if (e.KeyChar.ToString().ToLower() == "o" && DebugSwithB == true && PnlPerguntas.Visible == true)
            {
                ControleAnimacao = utilits.rodarSaidaPerguntas();
                TmrAnimation.Start();
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
        }
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
                PnlMenu,
                label1,
                TmrMainGameManager,
                labelX,
                labelY,
                LblX,
                LblY,
                PbxPersonagem,
                PBX_Sair,
                PBX_Opcoes,
                PBX_Jogar,
                PNL_Fases,
                panel4,
                PBX_Fase6,
                panel3,
                PBX_Fase3,
                panel5,
                PBX_Fase5,
                panel6,
                PBX_Fase4,
                panel2,
                PBX_Fase2,
                panel1,
                PBX_Fase1,
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
                TmrColisao,
                PNL_Pause,
                PBX_SairPause,
                PBX_Inicio,
                PBX_Continuar,
                panel7,
                PNL_InfoPause,
                PNL_Info,
                BTN_NaoInfo,
                BTN_SimInfo,
                PBX_Info,
                PNL_SairInicio,
                pictureBox55,
                PBX_NaoInicio,
                PBX_SimInicio,
                TMR_Tempo,
                LBL_Tempo,
                pictureBox56,
                PNL_SemTempo,
                BTN_NaoTempo,
                BTN_SimTempo,
                label3,
                LBL_SemTempo,
                TMR_SemTempo,
                PNL_SemTempo2,
                label5,
                BTN_NaoTempo2,
                BTN_SimTempo2,
                label2,
                LBL_SemTempo2,
                PBX_Reiniciar,
                LblBust,
                TmrAnimation,
                PBX_Ambiente1,
                PBX_Ambiente2,
                PBX_Ambiente3,
                PBX_Ambiente4,
                PBX_Ambiente5,
                PBX_Ambiente6,
                PBX_Ambiente7,
                TMR_PulaPula,
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
                PrbTempPerg,
                Lbl_de_Ajuda,
                TmrPergunta,
                LblResposta2,
                TxtResposta2,
                LblResposta3,
                TxtResposta3,
                LblWallStatus,
                PbxCristal1,
                PbxCristal2,
                PbxCristal3,
                PbxContVitaminas,
                PbxContCristais,
                LblContVitaminas,
                LblContCristais,
                LblScore,
                PNL_MostrarFases,
                PBX_Escolha2,
                LBL_Person,
                PBX_Escolha1,
                PBX_VoltarFase,
                PNL_InfoFase,
                pictureBox54,
                PNL_Help,
                PBX_Help,
                PBX_bntVaiHelp,
                PBX_btnVoltaHelp,
                LBL_txtHelp,
                LBL_HelpSair,
                LBL_txtHelp2,
                pictureBox57,
                PBX_VitaAtual,
                LBL_VitaTotal,
                LBL_CrisTotal,
                LBL_ScoreTotal,
                pictureBox59,
                LBL_Nome2,
                LBL_Nome1,
                pictureBox58,
                pictureBox60,
                PBX_AmbVilao,
                PBX_Vitoria,
                LblResposta4,
                TxtResposta4,
                PbxVinheta1,
                PbxVinheta2,
                PBX_Salvar,
                SomTema
                );
            #endregion

            //Ocultar qualquer pbx do form
            //ocultarTodasPbx();

            //"Remover" os paineis 4 5 e 6
            utilits.removePnlsFases_4_5_6();

            //Manter a musica em loop
            SomTema.PlayLooping();

            //Desabilitar btn menu
            PBX_Jogar.Enabled = false;
            PBX_Sair.Enabled = false;
            PBX_Opcoes.Enabled = false;

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
            //PBX_Fase2.Enabled = false;
            //PBX_Fase3.Enabled = false;
            //PBX_Fase4.Enabled = false;
            //PBX_Fase5.Enabled = false;
            //PBX_Fase6.Enabled = false;

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

            //Painel perguntas
            PnlPerguntas.Location = new Point(9, 960);
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

            //Mostrar a "vinheta"
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
                            contVitaTotal++;
                            PerguntaLetra = utilits.perguntasEntrada(fase, contVitaminas, contVitaTotal);
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
                            contCrisTotal++;

                            //Exibir para o player (Placar)
                            LblContCristais.Text = "x" + contCristais;
                            LBL_CrisTotal.Text = contCrisTotal + "/18";
                            if (contCristais != 3)
                            CristalBuffTime = 6;
                            if (contCristais == 3)
                            {
                                Score = Score + 100;
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
                            TmrMainGameManager.Stop();
                            TMR_Tempo.Stop();
                            utilits.animcaoWin = 1;
                            PBX_Fase2.Enabled = true;
                            PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                            PBX_Vitoria.Visible = false;
                            utilits.setMusicStop(SomTema);
                            objPerson = "Tocha";
                            ControleAnimacao = 1;
                            TmrAnimation.Start();
                        }
                        if (PbxColision.Bounds.IntersectsWith(h.Bounds) && fase == 2)
                        {
                            TmrMainGameManager.Stop();
                            TMR_Tempo.Stop();
                            utilits.animcaoWin = 1;
                            PBX_Fase3.Enabled = true;
                            PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_3.png");
                            PBX_Vitoria.Visible = false;
                            objPerson = "Flores";
                            ControleAnimacao = 1;
                            TmrAnimation.Start();
                        }
                    }
                }
            }

            //Para o Score e o tempo quando pegar todos os "itens"
            if (contCristais == 3 && contVitaminas == 7)
            {
                LBL_ScoreTotal.Text = Score.ToString();
                TMR_Tempo.Stop();
                contVitaminas = 0;
                contCristais = 0;
            }
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

        //ENTRAR E SAIR BTN VOLTAR INICIO SETA
        private void PBX_VoltarInicio_MouseHover(object sender, EventArgs e)
        {

        }

        private void PBX_VoltarInicio_MouseLeave(object sender, EventArgs e)
        {

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
            tempMin = 1;
            tempSeg = 0;
            LBL_Tempo.Text = "1:00";

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PBX_btnVoltaHelp.Visible = false;
            PNL_Help.Visible = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_1.png");
            PBX_Vitoria.Image = Image.FromFile(Directory.GetCurrentDirectory() + diretorioObjeto);

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
            pictureBox24.Location = new Point(960, 278); pictureBox24.Size = new Size(173, 22);
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

            //Setar a música da fase
            utilits.setMusic("floresta_1");
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
            tempMin = 1;
            tempSeg = 15;

            //Start da fase
            TMR_Tempo.Start();

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_2.png");
            PBX_Vitoria.Image = Image.FromFile(Directory.GetCurrentDirectory() + diretorioObjeto);

            //Setar a cerca da fase
            PbxCerca.Location = new Point(1191, 650);
            PbxCerca.Visible = true;

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(25, 713);
            PbxPersonagem.Location = new Point(-133, 680);
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

            #region Load Wall fase 2

            //Colocando as paredes em seus lugares
            pictureBox1.Location = new Point(88, 179); pictureBox1.Size = new Size(38, 327);
            pictureBox2.Location = new Point(159, 179); pictureBox2.Size = new Size(39, 274);
            pictureBox3.Location = new Point(204, 179); pictureBox3.Size = new Size(351, 25);
            pictureBox4.Location = new Point(231, 210); pictureBox4.Size = new Size(40, 491);
            pictureBox5.Location = new Point(132, 477); pictureBox5.Size = new Size(93, 29);
            pictureBox6.Location = new Point(447, 210); pictureBox6.Size = new Size(37, 220);
            pictureBox7.Location = new Point(303, 232); pictureBox7.Size = new Size(138, 25);
            pictureBox8.Location = new Point(303, 263); pictureBox8.Size = new Size(37, 117);
            pictureBox9.Location = new Point(346, 355); pictureBox9.Size = new Size(64, 27);

            pictureBox10.Location = new Point(374, 282); pictureBox10.Size = new Size(67, 25);
            pictureBox11.Location = new Point(374, 313); pictureBox11.Size = new Size(36, 21);
            pictureBox12.Location = new Point(88, 532); pictureBox12.Size = new Size(38, 191);
            pictureBox13.Location = new Point(132, 532); pictureBox13.Size = new Size(66, 25);
            pictureBox14.Location = new Point(159, 563); pictureBox14.Size = new Size(39, 91);
            pictureBox15.Location = new Point(132, 678); pictureBox15.Size = new Size(66, 45);
            pictureBox16.Location = new Point(303, 406); pictureBox16.Size = new Size(37, 319);
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

            pictureBox40.Location = new Point(1034, 427); pictureBox40.Size = new Size(28, 26);
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

            //Setar a música da fase
            utilits.setMusic("caverna");
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Start fase 3 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Fase3_Click(object sender, EventArgs e)
        {
            //Fase atual
            fase = 3;

            //TEMPO DE FASE
            tempMin = 1;
            tempSeg = 15;

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(36, 717);
            PbxPersonagem.Location = new Point(-125, 684);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_1.png");

            //Start da fase
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            ControleAnimacao = 700;
            TmrAnimation.Start();

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_3.png");

            #region Load Wall fase 3

            //Colocando as paredes em seus lugares
            pictureBox1.Location = new Point(94, 167); pictureBox1.Size = new Size(871, 25);
            pictureBox2.Location = new Point(323, 195); pictureBox2.Size = new Size(36, 49);
            pictureBox3.Location = new Point(94, 220); pictureBox3.Size = new Size(223, 24);
            pictureBox4.Location = new Point(94, 250); pictureBox4.Size = new Size(36, 462);
            pictureBox5.Location = new Point(136, 272); pictureBox5.Size = new Size(146, 24);
            pictureBox6.Location = new Point(398, 147); pictureBox6.Size = new Size(37, 14);
            pictureBox7.Location = new Point(12, 109); pictureBox7.Size = new Size(1264, 32);
            pictureBox8.Location = new Point(24, 147); pictureBox8.Size = new Size(35, 546);
            pictureBox9.Location = new Point(-2, 670); pictureBox9.Size = new Size(20, 99);

            pictureBox10.Location = new Point(24, 737); pictureBox10.Size = new Size(1248, 27);
            pictureBox11.Location = new Point(1227, 205); pictureBox11.Size = new Size(45, 526);
            pictureBox12.Location = new Point(1278, 128); pictureBox12.Size = new Size(12, 89);
            pictureBox13.Location = new Point(323, 272); pictureBox13.Size = new Size(36, 389);
            pictureBox14.Location = new Point(171, 637); pictureBox14.Size = new Size(146, 24);
            pictureBox15.Location = new Point(171, 324); pictureBox15.Size = new Size(146, 24);
            pictureBox16.Location = new Point(136, 376); pictureBox16.Size = new Size(146, 24);
            pictureBox17.Location = new Point(171, 428); pictureBox17.Size = new Size(146, 25);
            pictureBox18.Location = new Point(136, 480); pictureBox18.Size = new Size(146, 24);
            pictureBox19.Location = new Point(171, 532); pictureBox19.Size = new Size(146, 25);

            pictureBox20.Location = new Point(136, 584); pictureBox20.Size = new Size(146, 25);
            pictureBox21.Location = new Point(136, 690); pictureBox21.Size = new Size(223, 22);
            pictureBox22.Location = new Point(399, 220); pictureBox22.Size = new Size(37, 511);
            pictureBox23.Location = new Point(365, 272); pictureBox23.Size = new Size(28, 24);
            pictureBox24.Location = new Point(929, 354); pictureBox24.Size = new Size(36, 358);
            pictureBox25.Location = new Point(929, 324); pictureBox25.Size = new Size(147, 24);
            pictureBox26.Location = new Point(1082, 302); pictureBox26.Size = new Size(34, 46);
            pictureBox27.Location = new Point(854, 220); pictureBox27.Size = new Size(35, 511);
            pictureBox28.Location = new Point(971, 272); pictureBox28.Size = new Size(145, 24);
            pictureBox29.Location = new Point(929, 195); pictureBox29.Size = new Size(36, 101);

            pictureBox30.Location = new Point(1005, 220); pictureBox30.Size = new Size(145, 24);
            pictureBox31.Location = new Point(1005, 167); pictureBox31.Size = new Size(145, 25);
            pictureBox32.Location = new Point(1156, 147); pictureBox32.Size = new Size(36, 565);
            pictureBox33.Location = new Point(701, 640); pictureBox33.Size = new Size(36, 19);
            pictureBox34.Location = new Point(777, 195); pictureBox34.Size = new Size(36, 387);
            pictureBox35.Location = new Point(549, 663); pictureBox35.Size = new Size(264, 24);
            pictureBox36.Location = new Point(625, 558); pictureBox36.Size = new Size(146, 24);
            pictureBox37.Location = new Point(590, 611); pictureBox37.Size = new Size(223, 25);
            pictureBox38.Location = new Point(474, 272); pictureBox38.Size = new Size(297, 24);
            pictureBox39.Location = new Point(701, 324); pictureBox39.Size = new Size(36, 180);

            pictureBox40.Location = new Point(590, 508); pictureBox40.Size = new Size(148, 25);
            pictureBox41.Location = new Point(625, 302); pictureBox41.Size = new Size(35, 177);
            pictureBox42.Location = new Point(474, 302); pictureBox42.Size = new Size(35, 410);
            pictureBox43.Location = new Point(549, 324); pictureBox43.Size = new Size(35, 312);
            pictureBox44.Location = new Point(1082, 458); pictureBox44.Size = new Size(34, 254);
            pictureBox45.Location = new Point(1005, 376); pictureBox45.Size = new Size(145, 24);
            pictureBox46.Location = new Point(442, 220); pictureBox46.Size = new Size(296, 24);
            pictureBox47.Location = new Point(971, 427); pictureBox47.Size = new Size(145, 25);
            pictureBox48.Location = new Point(1006, 480); pictureBox48.Size = new Size(35, 253);
            pictureBox49.Location = new Point(777, 692); pictureBox49.Size = new Size(36, 41);
            #endregion
            //Setar a música da fase

            utilits.setMusic("caverna"); // ainda não tem musiquinha :(
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Start fase 5 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void PBX_Fase5_Click(object sender, EventArgs e)
        {
            //Diretório das imagens que estamos usando para a fase
            string diretorioVit = "\\img\\itens\\cereja_animada.gif",
                   diretorioCristal = "\\img\\itens\\cristal_animado.gif",
                   diretorioAmbiente = "\\img\\ambiente\\mapa_5\\arvoreNeve.png";

            //Fase atual
            fase = 5;

            //TEMPO DE FASE
            tempMin = 1;
            tempSeg = 15;

            //Setar a posição inicial da colisão e personagem e imagen
            PbxColision.Location = new Point(39, 711);
            PbxPersonagem.Location = new Point(-125, 684);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_1.png");

            //Start da fase
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            ControleAnimacao = 700;
            TmrAnimation.Start(); 

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;
            PBX_AmbVilao.Visible = true;

            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_5.png");

            //SETAR TRANSPARENCIA ITENS
            utilits.itensTrans();

            //SETAR IMAGEM DOS ITENS
            utilits.setarVitaminas(fase, 28, 33, diretorioVit);
            utilits.setCrist(fase, 22, 26, diretorioCristal);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR AMBIENTE
            utilits.setAmbiente(fase, 66, 55, diretorioAmbiente);

            #region Load Wall fase 5

            pictureBox1.Location = new Point(161, 673); pictureBox1.Size = new Size(22, 31);
            pictureBox2.Location = new Point(188, 439); pictureBox2.Size = new Size(34, 19);
            pictureBox3.Location = new Point(189, 254); pictureBox3.Size = new Size(33, 39);
            pictureBox4.Location = new Point(259, 337); pictureBox4.Size = new Size(37, 16);
            pictureBox5.Location = new Point(329, 176); pictureBox5.Size = new Size(38, 14);
            pictureBox6.Location = new Point(329, 286); pictureBox6.Size = new Size(38, 14);
            pictureBox7.Location = new Point(329, 622); pictureBox7.Size = new Size(38, 96);
            pictureBox8.Location = new Point(163, 464); pictureBox8.Size = new Size(60, 26);
            pictureBox9.Location = new Point(549, 196); pictureBox9.Size = new Size(42, 454);
            pictureBox10.Location = new Point(1051, 250); pictureBox10.Size = new Size(40, 416);

            pictureBox11.Location = new Point(625, 252); pictureBox11.Size = new Size(39, 414);
            pictureBox12.Location = new Point(25, 724); pictureBox12.Size = new Size(1222, 30);
            pictureBox13.Location = new Point(838, 233); pictureBox13.Size = new Size(37, 417);
            pictureBox14.Location = new Point(188, 406); pictureBox14.Size = new Size(107, 27);
            pictureBox15.Location = new Point(259, 306); pictureBox15.Size = new Size(108, 25);
            pictureBox16.Location = new Point(163, 299); pictureBox16.Size = new Size(59, 32);
            pictureBox17.Location = new Point(189, 568); pictureBox17.Size = new Size(34, 137);
            pictureBox18.Location = new Point(597, 196); pictureBox18.Size = new Size(522, 31);
            pictureBox19.Location = new Point(476, 672); pictureBox19.Size = new Size(611, 31);
            pictureBox20.Location = new Point(476, 254); pictureBox20.Size = new Size(39, 412);

            pictureBox21.Location = new Point(259, 568); pictureBox21.Size = new Size(34, 150);
            pictureBox22.Location = new Point(329, 251); pictureBox22.Size = new Size(139, 29);
            pictureBox23.Location = new Point(119, 393); pictureBox23.Size = new Size(38, 97);
            pictureBox24.Location = new Point(329, 359); pictureBox24.Size = new Size(38, 126);
            pictureBox25.Location = new Point(1211, 177); pictureBox25.Size = new Size(47, 220);
            pictureBox26.Location = new Point(906, 250); pictureBox26.Size = new Size(138, 30);
            pictureBox27.Location = new Point(694, 513); pictureBox27.Size = new Size(138, 29);
            pictureBox28.Location = new Point(881, 304); pictureBox28.Size = new Size(137, 31);
            pictureBox29.Location = new Point(767, 303); pictureBox29.Size = new Size(37, 48);
            pictureBox30.Location = new Point(737, 357); pictureBox30.Size = new Size(67, 28);

            pictureBox31.Location = new Point(695, 286); pictureBox31.Size = new Size(36, 98);
            pictureBox32.Location = new Point(908, 357); pictureBox32.Size = new Size(137, 28);
            pictureBox33.Location = new Point(670, 566); pictureBox33.Size = new Size(136, 30);
            pictureBox34.Location = new Point(910, 464); pictureBox34.Size = new Size(37, 202);
            pictureBox35.Location = new Point(670, 464); pictureBox35.Size = new Size(138, 29);
            pictureBox36.Location = new Point(117, 234); pictureBox36.Size = new Size(41, 97);
            pictureBox37.Location = new Point(120, 359); pictureBox37.Size = new Size(176, 28);
            pictureBox38.Location = new Point(670, 252); pictureBox38.Size = new Size(137, 28);
            pictureBox39.Location = new Point(118, 552); pictureBox39.Size = new Size(37, 151);
            pictureBox40.Location = new Point(118, 517); pictureBox40.Size = new Size(276, 29);

            pictureBox41.Location = new Point(80, 124); pictureBox41.Size = new Size(1178, 47);
            pictureBox42.Location = new Point(696, 408); pictureBox42.Size = new Size(322, 31);
            pictureBox43.Location = new Point(983, 464); pictureBox43.Size = new Size(35, 205);
            pictureBox44.Location = new Point(1125, 197); pictureBox44.Size = new Size(44, 521);
            pictureBox45.Location = new Point(299, 568); pictureBox45.Size = new Size(71, 32);
            pictureBox46.Location = new Point(256, 459); pictureBox46.Size = new Size(67, 26);
            pictureBox47.Location = new Point(400, 306); pictureBox47.Size = new Size(38, 412);
            pictureBox48.Location = new Point(228, 254); pictureBox48.Size = new Size(66, 27);
            pictureBox49.Location = new Point(115, 196); pictureBox49.Size = new Size(252, 32);
            pictureBox50.Location = new Point(25, 124); pictureBox50.Size = new Size(49, 577);

            pictureBox51.Location = new Point(256, 439); pictureBox51.Size = new Size(40, 14);
            pictureBox52.Location = new Point(400, 176); pictureBox52.Size = new Size(40, 69);
            pictureBox53.Location = new Point(694, 619); pictureBox53.Size = new Size(138, 28);
            pictureBox58.Location = new Point(1243, 382); pictureBox58.Size = new Size(47, 35);
            pictureBox60.Location = new Point(1211, 428); pictureBox60.Size = new Size(47, 258);
            #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Setar a música da fase
            utilits.setMusic("gelo");
        }
        #endregion

        #region Abertura de jogo/Funções Iniciais //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void PBX_Jogar_Click(object sender, EventArgs e)
        {
            PNL_Fases.Visible = true;
            PnlMenu.Visible = false;
            PNL_MostrarFases.Location = new Point(150, 51);
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
        }

        private void PBX_NaoInicio_Click(object sender, EventArgs e)
        {
            PNL_SairInicio.Visible = false;
        }

        private void PbxPersonagem_Click(object sender, EventArgs e)
        {

        }

        private void FrmJogo_FormClosing(object sender, FormClosingEventArgs e)
        {

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
                ReiniciarJogo();
                ativouMenu = 0;
                TmrMainGameManager.Start();
                TMR_Tempo.Start();
                PNL_Info.Visible = false;
                PNL_Pause.Visible = false;
            }
            //VOLTAR PARA O MENU FASES
            if (infoMenu == 3)
            {
                ReiniciarJogo();
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
                LBL_ScoreTotal.Text = Score.ToString();
                utilits.LBLScore(570, 550, 545);
                andarQtdPx = 6;
            }
            else
            {
                utilits.LBLScore(530, 520, 490);
                if (contCristais == 1)
                {
                    Score = Score + 3;
                    LblScore.ForeColor = Color.Yellow;
                    LblScore.Text = Score + "+" + (contCristais + 3);
                    andarQtdPx = 8;
                }
                else if (contCristais == 2)
                {
                    Score = Score + 7;
                    LblScore.ForeColor = Color.Orange;
                    LblScore.Text = Score + "+" + (contCristais + 6);
                    andarQtdPx = 8;
                }
                LBL_ScoreTotal.Text = Score.ToString();
                CristalBuffTime--;
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
            ReiniciarJogo();
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

        #region REINICIAR JOGO //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ReiniciarJogo()
        {
            //FASE 1
            if (fase == 1)
            {
                tempMin = 1;
                tempSeg = 0;

                //Resetar a velocidade que o player anda
                andarQtdPx = 6;

                //Resetar animação do personagem entrando no
                ControleAnimacao = 700;
                TmrAnimation.Start();

                //Resetar placar
                LblContVitaminas.Text = "0/7";
                LblContCristais.Text = "x";
                contCristais = 0;
                contVitaminas = 0;

                //Resetar visibilidade dos itens
                mostrarTodasPbx();

                //Resetar Score
                Score = 0;
                LblScore.Text = "0";
            }
            //FASE 2
            if (fase == 2)
            {
                tempMin = 1;
                tempSeg = 15;
                PbxColision.Location = new Point(25, 713);
                PbxPersonagem.Location = new Point(17, 680);
            }
            //FASE 3
            if (fase == 3)
            {
                tempMin = 1;
                tempSeg = 15;
                PbxColision.Location = new Point(36, 717);
                PbxPersonagem.Location = new Point(25, 684);
            }
        }

        public void mostrarTodasPbx()
        {
            foreach (Control j in this.Controls)
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
            foreach (Control j in this.Controls)
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
            ControleAnimacao = utilits.rodarSaidaPerguntas();
            TmrAnimation.Start();
        }

        private void PbxBtn1_Click(object sender, EventArgs e)
        {
            tempSeg = utilits.addTempo(-5, tempSeg);
            Score = utilits.addScorePonto(-20, Score);
            ControleAnimacao = utilits.rodarSaidaPerguntas();
            TmrAnimation.Start();
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
                ControleAnimacao = utilits.rodarSaidaPerguntas();
                TmrAnimation.Start();
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
                        ControleAnimacao = utilits.rodarSaidaPerguntas();
                        TmrAnimation.Start();
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
                    if (num1 == 7 * 4 && num2 == 6 * 3 && num3 == 7 * 8)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        ControleAnimacao = utilits.rodarSaidaPerguntas();
                        TmrAnimation.Start();
                    }
                    if (num1 >= (7 * 4) - 10 && num1 <= (7 * 4) + 10 && num1 != 7 * 4)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= (6 * 3) - 10 && num2 <= (6 * 3) + 10 && num2 != 6 * 3)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= (7 * 8) - 10 && num3 <= (7 * 8) + 10 && num3 != 7 * 8)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num1 == 7 * 4)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 6 * 3)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 7 * 8)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < (7 * 4) - 10 && num1 > (7 * 4) + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < (6 * 3) - 10 && num2 > (6 * 3) + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < (7 * 8) - 10 && num3 > (7 * 8) + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
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
                        ControleAnimacao = utilits.rodarSaidaPerguntas();
                        TmrAnimation.Start();
                    }
                    if (num1 >= 0 && num1 <= 20 && num1 != 10)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num1 < 0 && num1 > 20)
                    {
                        LblResposta.ForeColor = Color.White;
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
                    if (num1 == 64 / 2 && num2 == 448 / 4 && num3 == 93 / 3 && num4 == 535 / 5)
                    {
                        tempSeg = utilits.addTempo(10, tempSeg);
                        Score = utilits.addScorePonto(20, Score);
                        ControleAnimacao = utilits.rodarSaidaPerguntas();
                        TmrAnimation.Start();
                    }
                    if (num1 >= (64 / 2) - 10 && num1 <= (64 / 2) + 10 && num1 != 64 / 2)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= (448 / 4) - 10 && num2 <= (448 / 4) + 10 && num2 != 448 / 4)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= (93 / 3) - 10 && num3 <= (93 / 3) + 10 && num3 != 93 / 3)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num4 >= (535 / 5) - 10 && num4 <= (535 / 5) + 10 && num4 != 535 / 5)
                    {
                        LblResposta4.ForeColor = Color.Yellow;
                    }
                    if (num1 == 64 / 2)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 448 / 4)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 93 / 3)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 535 / 5)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < (64 / 2) - 10 && num1 > (64 / 2) + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < (448 / 4) - 10 && num2 > (448 / 4) + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < (93 / 3) - 10 && num3 > (93 / 3) + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                    if (num3 < (535 / 5) - 10 && num3 > (535 / 5) + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
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
                        ControleAnimacao = utilits.rodarSaidaPerguntas();
                        TmrAnimation.Start();
                    }
                    if (num1 >= 23 && num1 <= 43 && num1 != 33)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num1 < 23 && num1 > 43)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                }
            }
            if (fase == 3) //Resposta de texto da fase 3
            {

            }
            if (fase == 4) //Resposta de texto da fase 4
            {

            }
            if (fase == 5) //Resposta de texto da fase 5
            {

            }
            if (fase == 6) //Resposta de texto da fase 6
            {

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
            {
                 utilits.helpImg(fase, helpIndex);
            }
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

        #region TIMER PARA TESTES
        private void TmrDebug_Tick(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
