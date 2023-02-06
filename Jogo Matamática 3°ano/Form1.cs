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

namespace Jogo_Matamática_3_ano
{
    public partial class FrmJogo : Form
    {
        #region Variáveis Globais //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        string escolhaPerson, objPerson;

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
            ControleAnimacao = 0, ControleAnimacaoAux, animcaoWin = 1,

            //Contador de Vitaminas e Cristais
            contVitaminas = 0, contCristais = 0, contVitaTotal = 0, contCrisTotal = 0,

            //Controla o TmrPergunta
            tempPergunta = 0,

            //Score do player
            Score = 0, CristalBuffTime = 0;

        //Controles do player
        bool goLeft, goRight, goDown, goUp,

            //Variável para ver se o debug está ativo ou não
            DebugSwithB,

            //Fazer o payer andar mais rápido e pelas paredes
            Bust, paredesStatus,

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
        }

        #region Controles //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
                    lblOutputRequest.Visible = true;
                    LblBust.Visible = true;
                    LblWallStatus.Visible = true;
                    DebugSwithB = true;
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
                    lblOutputRequest.Visible = false;
                    LblBust.Visible = false;
                    LblWallStatus.Visible = false;
                    DebugSwithB = false;
                }
            }

            //Fazer o Personagem andar mais
            if (e.KeyChar.ToString().ToLower() == "b")
            {
                if (DebugSwithBust % 2 == 0)
                {
                    DebugSwithBust++;
                    Bust = true;
                }
                else
                {
                    DebugSwithBust++;
                    Bust = false;
                }
            }

            //Fazer o Personagem andar pelas paredes
            if (e.KeyChar.ToString().ToLower() == "n")
            {
                if (DebugParedeSwith % 2 == 0)
                {
                    DebugParedeSwith++;
                    paredesStatus = true;
                }
                else
                {
                    DebugParedeSwith++;
                    paredesStatus = false;
                }
            }

            //Pause
            if (e.KeyChar == 27 && PNL_SemTempo.Visible != true && PNL_Fases.Visible != true && PnlPerguntas.Visible != true)
            {

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
            //Ocultar qualquer pbx do form
            //ocultarTodasPbx();

            //GameMenager
            TmrMainGameManager.Stop();

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
            //PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            //PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            //PBX_Fase4.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            //PBX_Fase5.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");
            //PBX_Fase6.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\utilidades\\imgInter.png");

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
            lblOutputRequest.Visible = false;
            LblBust.Visible = false;
            LblWallStatus.Visible = false;

            //Colocar contador de animações para 0
            ControleAnimacao = 0;

            //Organizer objetos do pnlPergunta
            resetarObjetosPergunta();

            //Definir o que pode digitar nos txt de pergunta
            JustNum = false;
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

            //Condição para o player ganhar
            if (posXPlayer >= 1140 && posYPlayer >= 645 && tempSeg != -1 && fase == 1)
            {
                TmrMainGameManager.Stop();
                TMR_Tempo.Stop();
                animcaoWin = 1;
                PBX_Fase2.Enabled = true;
                PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                PBX_Vitoria.Visible = false;
                objPerson = "Tocha";
                ControleAnimacao = 0;
                TmrAnimation.Start();
            }

            //Condição para ganhar/fase2
            else if (((posXPlayer > 1148 && posXPlayer < 1300) && (posYPlayer > 662 && posYPlayer < 750)) && tempSeg != -1 && fase == 2)
            {
                TmrMainGameManager.Stop();
                TMR_Tempo.Stop();
                animcaoWin = 1;
                PBX_Fase3.Enabled = true;
                PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_3.png");
                PBX_Vitoria.Visible = false;
                objPerson = "Flores";
                ControleAnimacao = 0;
                TmrAnimation.Start();
            }

            //Controles para fazer o player andar
            else if (goLeft == true)
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
                            TMR_Tempo.Stop();
                            TmrMainGameManager.Stop();

                            //Exibir para o player (Placar)
                            LblContVitaminas.Text = contVitaminas + "/7";
                            LBL_VitaTotal.Text = contVitaTotal + "/48";

                            //Perguntas fase 1 e verificar se está correta
                            if (fase == 1)
                            {
                                if (contVitaminas == 1)
                                {
                                    setarBtnPergunta4();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {
                                    setarBtnPergunta5();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
                            else if (fase == 2)
                            {
                                if (contVitaminas == 1)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {
                                    setarBtnPergunta4();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {
                                    setarTxtPergunta();
                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
                            else if (fase == 3)
                            {
                                if (contVitaminas == 1)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
                            else if (fase == 4)
                            {
                                if (contVitaminas == 1)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
                            else if (fase == 5)
                            {
                                if (contVitaminas == 1)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
                            else if (fase == 6)
                            {
                                if (contVitaminas == 1)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 2)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 3)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 4)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 5)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 6)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                                else if (contVitaminas == 7)
                                {

                                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + contVitaminas + ".png");
                                }
                            }
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
                            LblContCristais.Text ="x" + contCristais;
                            LBL_CrisTotal.Text = contCrisTotal + "/18";
                            if (contCristais == 2)
                            {
                                andarQtdPx = 8;
                            }
                            if (contCristais == 3)
                            {
                                LblScore.ForeColor = Color.OrangeRed;
                                LblScore.Text = Score + " +200";
                            }
                            CristalBuffTime = 6;
                        }
                    }
                }
            }


            //Ativar desativar o bust do modo debug
            if (DebugSwithB == true)
            {
                if (Bust == true) {
                    andarQtdPx = 50;
                    LblBust.Text = "Busted";
                }
                else 
                {
                    andarQtdPx = 6;
                    LblBust.Text = "Normal";
                }
            }

            //Ativar desativar as paredes no modo debug
            if (DebugSwithB == true)
            {
                if (paredesStatus == true)
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

            //Para o Score e o tempo quando pegar todos os "itens"
            if (contCristais == 3 && contVitaminas == 7)
            {
                Score = Score + 200;
                LblScore.ForeColor = Color.Black;
                LblScore.Text = "Score: " + Score;
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
            PbxColision.Location = new Point(59, 169);
            PbxPersonagem.Location = new Point(-104, 136);
            ControleAnimacao = 700;

            //ORGANIZAR O PLACAR DA FASE
            setPlacar();

            //SETAR TRANSPARENCIA ITENS
            ItensTrans();

            //SETAR IMAGEM DOS ITENS
            setarImagensVitaminas(diretorioVit);
            setImagendsCrital(diretorioCristal);

            //SETAR POSICAO DOS ITENS
            setPosVitaminas();
            setPosCrist();

            //SETAR TAMANHO ITENS
            setVitSize(22, 26);
            setCrisSize(22, 26);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR TRANSPARENCIA
            AmbienteTrans();

            //Setar a posiçao das imagens do ambiente
            setPosAmbiente();

            //SETAR TAMANHO DAS IMAGENS DO AMBIENTE
            setAmbSize(66, 55);

            //SETAR IMAGEM DO AMBIENTE
            setAmbImagem(diretorioAmbiente);

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
            setPlacar();

            //SETAR TRANSPARENCIA ITENS
            ItensTrans();

            //SETAR IMAGEM DOS ITENS
            setarImagensVitaminas(diretorioVit);
            setImagendsCrital(diretorioCristal);

            //SETAR POSICAO DOS ITENS -arumar
            setPosVitaminas();
            setPosCrist();

            //SETAR TAMANHO ITENS
            setVitSize(22, 26);
            setCrisSize(22, 26);

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR TRANSPARENCIA
            AmbienteTrans();

            //Setar a posiçao das imagens do ambiente - arumar
            setPosAmbiente();

            //SETAR TAMANHO DAS IMAGENS DO AMBIENTE
            setAmbSize(45, 49);

            //SETAR IMAGEM DO AMBIENTE
            setAmbImagem(diretorioAmbiente);

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
            PbxPersonagem.Location = new Point(28, 678);
            PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_1.png");

            //Start da fase
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            ControleAnimacao = 700;

            //Esconder os paineis
            PNL_Fases.Visible = false;
            PnlMenu.Visible = false;
            PNL_Pause.Enabled = true;
            PBX_AmbVilao.Visible = true;
            //Setar o mapa da fase
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\mapa_5.png");

            //SETAR TRANSPARENCIA ITENS
            ItensTrans();

            //SETAR IMAGEM DOS ITENS
            setarImagensVitaminas(diretorioVit);
            setImagendsCrital(diretorioCristal);

            /*//SETAR POSICAO DOS ITENS -arumar
            setPosVitaminas();
            setPosCrist();

            //SETAR TAMANHO ITENS
            setVitSize(28, 33);
            setCrisSize(22, 26);
            */

            //DEIXAR ITENS VISIVEIS, AMBIENTE E PERSONAGEM
            mostrarTodasPbx();

            //SETAR TRANSPARENCIA
            AmbienteTrans();

            //Setar a posiçao das imagens do ambiente - arumar
            setPosAmbiente();

            //SETAR TAMANHO DAS IMAGENS DO AMBIENTE
            setAmbSize(66, 55);

            //SETAR IMAGEM DO AMBIENTE
            setAmbImagem(diretorioAmbiente);

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
        }
        #endregion

        #region Funções e Utilidades //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //RESETAR AMBIENTE
        public void ResetAmbiente()
        {
            PBX_Ambiente1.Visible = false;
            PBX_Ambiente2.Visible = false;
            PBX_Ambiente3.Visible = false;
            PBX_Ambiente4.Visible = false;
            PBX_Ambiente5.Visible = false;
            PBX_Ambiente6.Visible = false;
            PBX_Ambiente7.Visible = false;
        }

        //Visible ambiente
        public void verAmbiente()
        {
            PBX_Ambiente1.Visible = true;
            PBX_Ambiente2.Visible = true;
            PBX_Ambiente3.Visible = true;
            PBX_Ambiente4.Visible = true;
            PBX_Ambiente5.Visible = true;
            PBX_Ambiente6.Visible = true;
            PBX_Ambiente7.Visible = true;
        }

        //SETAR TRANSPARENCIA AMBIENTE
        public void AmbienteTrans()
        {
            PBX_Ambiente1.BackColor = Color.Transparent;
            PBX_Ambiente2.BackColor = Color.Transparent;
            PBX_Ambiente3.BackColor = Color.Transparent;
            PBX_Ambiente4.BackColor = Color.Transparent;
            PBX_Ambiente5.BackColor = Color.Transparent;
            PBX_Ambiente6.BackColor = Color.Transparent;
            PBX_Ambiente7.BackColor = Color.Transparent;
        }

        //SETAR TRANSPARENCIA ITENS
        public void ItensTrans()
        {
            PBX_Vitamina1.BackColor = Color.Transparent;
            PBX_Vitamina2.BackColor = Color.Transparent;
            PBX_Vitamina3.BackColor = Color.Transparent;
            PBX_Vitamina4.BackColor = Color.Transparent;
            PBX_Vitamina5.BackColor = Color.Transparent;
            PBX_Vitamina6.BackColor = Color.Transparent;
            PBX_Vitamina7.BackColor = Color.Transparent;
            PbxCristal1.BackColor = Color.Transparent;
            PbxCristal2.BackColor = Color.Transparent;
            PbxCristal3.BackColor = Color.Transparent;
            PBX_Vitoria.BackColor = Color.Transparent;
        }

        public void ItensVisible()
        {
            PBX_Vitamina1.Visible = true;
            PBX_Vitamina2.Visible = true;
            PBX_Vitamina3.Visible = true;
            PBX_Vitamina4.Visible = true;
            PBX_Vitamina5.Visible = true;
            PBX_Vitamina6.Visible = true;
            PBX_Vitamina7.Visible = true;
            PbxCristal1.Visible = true;
            PbxCristal2.Visible = true;
            PbxCristal3.Visible = true;
            PBX_Vitoria.Visible = true;
        }

        public void IensNotVisible()
        {
            PBX_Vitamina1.Visible = false;
            PBX_Vitamina2.Visible = false;
            PBX_Vitamina3.Visible = false;
            PBX_Vitamina4.Visible = false;
            PBX_Vitamina5.Visible = false;
            PBX_Vitamina6.Visible = false;
            PBX_Vitamina7.Visible = false;
            PbxCristal1.Visible = false;
            PbxCristal2.Visible = false;
            PbxCristal3.Visible = false;
            PBX_Vitoria.Visible = false;
        }

        #region Organizar o layout das perguntas, de acordo com a pergunta | Resetar as perguntas | Rodas a saída das perguntas
        public void setarBtnPergunta4()
        {
            int sizeX = 116, sizeY = 59;

            PbxBtn1.Enabled = true;
            PbxBtn2.Enabled = true;
            PbxBtn3.Enabled = true;
            PbxBtnCerto.Enabled = true;

            PbxBtn1.Visible = true;
            PbxBtn2.Visible = true;
            PbxBtn3.Visible = true;
            PbxBtnCerto.Visible = true;

            if (fase == 1)
            {
                PbxBtn1.Location = new Point(1099, 27);
                PbxBtn2.Location = new Point(1099, 114);
                PbxBtn3.Location = new Point(948, 27);
                PbxBtn4.Location = new Point(10, 10);
                PbxBtnCerto.Location = new Point(948, 114);

                PbxBtn1.Size = new Size(sizeX, sizeY);
                PbxBtn2.Size = new Size(sizeX, sizeY);
                PbxBtn3.Size = new Size(sizeX, sizeY);
                PbxBtn4.Size = new Size(10, 10);
                PbxBtnCerto.Size = new Size(sizeX, sizeY);
            }
            if (fase == 2)
            {
                PbxBtn1.Location = new Point(360, 85);
                PbxBtn2.Location = new Point(649, 85);
                PbxBtn3.Location = new Point(792, 85);
                PbxBtn4.Location = new Point(10, 10);
                PbxBtnCerto.Location = new Point(509, 84);

                PbxBtn1.Size = new Size(sizeX, sizeY);
                PbxBtn2.Size = new Size(sizeX, sizeY);
                PbxBtn3.Size = new Size(sizeX, sizeY);
                PbxBtn4.Size = new Size(10, 10);
                PbxBtnCerto.Size = new Size(sizeX, sizeY);
            }
        }
        public void setarBtnPergunta5()
        {
            int sizeX = 116, sizeY = 59;

            PbxBtn1.Enabled = true;
            PbxBtn2.Enabled = true;
            PbxBtn3.Enabled = true;
            PbxBtn4.Enabled = true;
            PbxBtnCerto.Enabled = true;

            PbxBtn1.Visible = true;
            PbxBtn2.Visible = true;
            PbxBtn3.Visible = true;
            PbxBtn4.Visible = true;
            PbxBtnCerto.Visible = true;

            if (fase == 1)
            {
                PbxBtn1.Location = new Point(1103, 125);
                PbxBtn2.Location = new Point(951, 124);
                PbxBtn3.Location = new Point(951, 37);
                PbxBtn4.Location = new Point(805, 124);
                PbxBtnCerto.Location = new Point(1103, 36);

                PbxBtn1.Size = new Size(sizeX, sizeY);
                PbxBtn2.Size = new Size(sizeX, sizeY);
                PbxBtn3.Size = new Size(sizeX, sizeY);
                PbxBtn4.Size = new Size(sizeX, sizeY);
                PbxBtnCerto.Size = new Size(sizeX, sizeY);
            }
        }
        public void setarTxtPergunta()
        {
            if (fase == 1)
            {
                if (contVitaminas == 2)
                {
                    Lbl_de_Ajuda.Location = new Point(580, 88);
                    LblResposta.Location = new Point(581, 114);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(591, 42);

                    Lbl_de_Ajuda.Visible = true;
                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    Lbl_de_Ajuda.Enabled = true;
                    LblResposta.Enabled = true;
                }
                else if (contVitaminas == 3)
                {
                    Lbl_de_Ajuda.Location = new Point(101, 91);
                    LblResposta.Location = new Point(92, 109);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(591, 42);

                    Lbl_de_Ajuda.Visible = true;
                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    Lbl_de_Ajuda.Enabled = true;
                    LblResposta.Enabled = true;
                }
                else if (contVitaminas == 5)
                {
                    Lbl_de_Ajuda.Location = new Point(614, 29);
                    LblResposta.Location = new Point(531, 76);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(674, 76);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    Lbl_de_Ajuda.Text = "";

                    Lbl_de_Ajuda.Visible = true;
                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;

                    Lbl_de_Ajuda.Enabled = true;
                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;

                    JustNum = true;
                }
                else if (contVitaminas == 6)
                {
                    Lbl_de_Ajuda.Location = new Point(643, 95);
                    LblResposta.Location = new Point(639, 118);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(572, 46);

                    Lbl_de_Ajuda.Visible = true;
                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    Lbl_de_Ajuda.Enabled = true;
                    LblResposta.Enabled = true;
                }
                else if (contVitaminas == 7)
                {
                    Lbl_de_Ajuda.Location = new Point(485, 25);
                    LblResposta.Location = new Point(396, 77);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(532, 78);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(670, 78);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";
                    Lbl_de_Ajuda.Text = "";

                    Lbl_de_Ajuda.Visible = true;
                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;

                    Lbl_de_Ajuda.Enabled = true;
                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;
                    TxtResposta3.MaxLength = 2;

                    JustNum = true;
                }
            }
            else if (fase == 2)
            {
                if (contVitaminas == 1)
                {
                    LblResposta.Location = new Point(327, 57);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(730, 57);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(1132, 57);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(93, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;

                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;
                    TxtResposta3.MaxLength = 3;

                    JustNum = true;
                }
                else if (contVitaminas == 2)
                {
                    LblResposta.Location = new Point(327, 57);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(730, 57);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(1136, 57);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;

                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;
                    TxtResposta3.MaxLength = 2;

                    JustNum = true;
                }
                else if (contVitaminas == 3)
                {
                    LblResposta.Location = new Point(44, 57);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(446, 57);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(852, 57);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;

                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;
                    TxtResposta3.MaxLength = 2;

                    JustNum = true;
                }
                else if (contVitaminas == 4)
                {
                    LblResposta.Location = new Point(44, 57);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(446, 57);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(852, 57);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;

                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 2;
                    TxtResposta3.MaxLength = 2;

                    JustNum = true;
                }
                else if (contVitaminas == 6)
                {
                    LblResposta.Location = new Point(380, 88);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(534, 88);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(686, 88);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta4.Location = new Point(831, 88);
                    TxtResposta4.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);
                    LblResposta4.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);
                    LblResposta4.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";
                    LblResposta4.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;
                    LblResposta2.Visible = true;
                    TxtResposta2.Visible = true;
                    LblResposta3.Visible = true;
                    TxtResposta3.Visible = true;
                    LblResposta4.Visible = true;
                    TxtResposta4.Visible = true;

                    LblResposta.Enabled = true;
                    LblResposta2.Enabled = true;
                    LblResposta3.Enabled = true;
                    LblResposta4.Enabled = true;

                    TxtResposta.MaxLength = 3;
                    TxtResposta2.MaxLength = 3;
                    TxtResposta3.MaxLength = 3;
                    TxtResposta4.MaxLength = 3;

                    JustNum = true;
                }
                else if (contVitaminas == 7)
                {
                    LblResposta.Location = new Point(594, 110);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    LblResposta.Enabled = true;


                    TxtResposta.MaxLength = 2;

                    JustNum = true;
                }
            }
            else if (fase == 3)
            {

            }
            else if (fase == 4)
            {

            }
            else if (fase == 5)
            {

            }
            else if (fase == 6)
            {

            }
        }
        //Resetar o layout das perguntas
        public void resetarObjetosPergunta()
        {
            //Abrir o portão da fase
            if (contVitaminas == 7)
            {
                ControleAnimacao = 800;
                TmrAnimation.Start();
            }

            PbxBtn1.Location = new Point(10, 10);
            PbxBtn2.Location = new Point(10, 10);
            PbxBtn3.Location = new Point(10, 10);
            PbxBtn4.Location = new Point(10, 10);
            PbxBtnCerto.Location = new Point(10, 10);
            TxtResposta.Location = new Point(10, 10);
            TxtResposta2.Location = new Point(10, 10);
            TxtResposta3.Location = new Point(10, 10);
            TxtResposta4.Location = new Point(10, 10);
            LblResposta.Location = new Point(10, 10);
            LblResposta2.Location = new Point(10, 10);
            LblResposta3.Location = new Point(10, 10);
            LblResposta4.Location = new Point(10, 10);

            PbxBtn1.Size = new Size(10, 10);
            PbxBtn2.Size = new Size(10, 10);
            PbxBtn3.Size = new Size(10, 10);
            PbxBtn4.Size = new Size(10, 10);
            PbxBtnCerto.Size = new Size(10, 10);
            TxtResposta.Size = new Size(3, 42);
            LblResposta.Size = new Size(10, 10);
            TxtResposta2.Size = new Size(3, 42);
            LblResposta2.Size = new Size(10, 10);
            TxtResposta3.Size = new Size(3, 42);
            LblResposta3.Size = new Size(10, 10);
            TxtResposta4.Size = new Size(3, 42);
            LblResposta4.Size = new Size(10, 10);

            PbxBtn1.BackColor = Color.Transparent;
            PbxBtn2.BackColor = Color.Transparent;
            PbxBtn3.BackColor = Color.Transparent;
            PbxBtn4.BackColor = Color.Transparent;
            PbxBtnCerto.BackColor = Color.Transparent;

            PbxBtn1.Visible = false;
            PbxBtn2.Visible = false;
            PbxBtn3.Visible = false;
            PbxBtn4.Visible = false;
            PbxBtnCerto.Visible = false;
            TxtResposta.Visible = false;
            LblResposta.Visible = false;
            TxtResposta2.Visible = false;
            LblResposta2.Visible = false;
            TxtResposta3.Visible = false;
            LblResposta3.Visible = false;
            TxtResposta4.Visible = false;
            LblResposta4.Visible = false;
            Lbl_de_Ajuda.Visible = false;

            TxtResposta.Enabled = false;
            LblResposta.Enabled = false;
            TxtResposta2.Enabled = false;
            LblResposta2.Enabled = false;
            TxtResposta3.Enabled = false;
            LblResposta3.Enabled = false;
            TxtResposta4.Enabled = false;
            LblResposta4.Enabled = false;
            Lbl_de_Ajuda.Enabled = false;

            TxtResposta.Clear();
            TxtResposta2.Clear();
            TxtResposta3.Clear();
            TxtResposta4.Clear();
            LblResposta.Text = "Clique aqui e responda";
            LblResposta2.Text = "Clique aqui e responda";
            LblResposta3.Text = "Clique aqui e responda";
            LblResposta4.Text = "Clique aqui e responda";
            Lbl_de_Ajuda.Text = "Escreva a frase completa";

            LblResposta.Font = new Font("Snap ITC", 24);
            LblResposta2.Font = new Font("Snap ITC", 24);
            LblResposta3.Font = new Font("Snap ITC", 24);
            LblResposta4.Font = new Font("Snap ITC", 24);

            LblResposta.ForeColor = Color.White;
            LblResposta2.ForeColor = Color.White;
            LblResposta3.ForeColor = Color.White;
            LblResposta4.ForeColor = Color.White;

            TxtResposta.MaxLength = 27;
            TxtResposta2.MaxLength = 27;
            TxtResposta3.MaxLength = 27;
            TxtResposta4.MaxLength = 27;

            tempPergunta = 0;

            JustNum = false;

            this.Focus();
        }
        public void rodarSaidaPerguntas()
        {
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            ControleAnimacao = 1000;
            TmrAnimation.Start();
        }
        #endregion

        #region SETAR IMAGEM DAS VITAMINAS
        public void setarImagensVitaminas(string img)
        {
            PBX_Vitamina1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina4.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina5.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina6.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina7.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
        }
        #endregion

        #region SETAR POSICAO DAS VITAMINAS
        public void setPosVitaminas()
        {
            if (fase == 1)
            {
                PBX_Vitamina1.Location = new Point(486, 655);
                PBX_Vitamina2.Location = new Point(667, 299);
                PBX_Vitamina3.Location = new Point(228, 431);
                PBX_Vitamina4.Location = new Point(1112, 298);
                PBX_Vitamina5.Location = new Point(230, 321);
                PBX_Vitamina6.Location = new Point(965, 684);
                PBX_Vitamina7.Location = new Point(892, 409);
                PBX_Vitoria.Location = new Point(1170, 674);
            }
            if (fase == 2)
            {
                PBX_Vitamina1.Location = new Point(60, 263);
                PBX_Vitamina2.Location = new Point(1195, 212);
                PBX_Vitamina3.Location = new Point(1037, 547);
                PBX_Vitamina4.Location = new Point(879, 329);
                PBX_Vitamina5.Location = new Point(516, 683);
                PBX_Vitamina6.Location = new Point(345, 383);
                PBX_Vitamina7.Location = new Point(131, 646);
                PBX_Vitoria.Location = new Point(1192, 675); 
            }

            if(fase == 5)
            {

            }
        }
        #endregion

        #region SETAR TAMANHO VITAMINAS
        public void setVitSize(int tamX, int tamY)
        {
            PBX_Vitamina1.Size = new Size(tamX, tamY);
            PBX_Vitamina2.Size = new Size(tamX, tamY);
            PBX_Vitamina3.Size = new Size(tamX, tamY);
            PBX_Vitamina4.Size = new Size(tamX, tamY);
            PBX_Vitamina5.Size = new Size(tamX, tamY);
            PBX_Vitamina6.Size = new Size(tamX, tamY);
            PBX_Vitamina7.Size = new Size(tamX, tamY);
        }
        #endregion

        #region Setar a posiçao das imagens do ambiente
        public void setPosAmbiente()
        {
            if (fase == 1) {
                PBX_Ambiente1.Location = new Point(282, 306);
                PBX_Ambiente2.Location = new Point(502, 272);
                PBX_Ambiente3.Location = new Point(720, 235);
                PBX_Ambiente4.Location = new Point(946, 235);
                PBX_Ambiente5.Location = new Point(367, 487);
                PBX_Ambiente6.Location = new Point(224, 642);
                PBX_Ambiente7.Location = new Point(1092, 503);
            }
            if (fase == 2) {
                PBX_Ambiente1.Location = new Point(118, 561);
                PBX_Ambiente2.Location = new Point(189, 201);
                PBX_Ambiente3.Location = new Point(189, 239);
                PBX_Ambiente4.Location = new Point(406, 462);
                PBX_Ambiente5.Location = new Point(714, 487);
                PBX_Ambiente6.Location = new Point(1103, 343);
                PBX_Ambiente7.Location = new Point(788, 594);
            }

            if (fase == 5)
            {
                PBX_Ambiente1.Location = new Point(137, 266);
                PBX_Ambiente2.Location = new Point(0, 0);
                PBX_Ambiente3.Location = new Point(643, 266);
                PBX_Ambiente4.Location = new Point(0,0);
                PBX_Ambiente5.Location = new Point(1003, 622);
                PBX_Ambiente6.Location = new Point(349, 678);
                PBX_Ambiente7.Location = new Point(137, 419);
            }
        }
        #endregion

        #region SETAR TAMANHO DAS IMAGENS DO AMBIENTE
        public void setAmbSize(int tamX, int tamY)
        {
            PBX_Ambiente1.Size = new Size(tamX, tamY);
            PBX_Ambiente2.Size = new Size(tamX, tamY);
            PBX_Ambiente3.Size = new Size(tamX, tamY);
            PBX_Ambiente4.Size = new Size(tamX, tamY);
            PBX_Ambiente5.Size = new Size(tamX, tamY);
            PBX_Ambiente6.Size = new Size(tamX, tamY);
            PBX_Ambiente7.Size = new Size(tamX, tamY);
        }
        #endregion

        #region SETAR IMAGEM DO AMBIENTE
        public void setAmbImagem(string img)
        {
            PBX_Ambiente1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente4.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente5.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente6.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente7.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
        }
        #endregion

        #region SETAR POSIÇÃO DOS CRISTAIS
        public void setPosCrist()
        {
            if (fase == 1)
            {
                PbxCristal1.Location = new Point(525, 297);
                PbxCristal2.Location = new Point(676, 554);
                PbxCristal3.Location = new Point(1113, 524);
            }
            if (fase == 2)
            {
                PbxCristal1.Location = new Point(201, 443);
                PbxCristal2.Location = new Point(418, 431);
                PbxCristal3.Location = new Point(1113, 315);
            }
            if (fase == 5)
            {
                PbxCristal1.Location = new Point(476, 188);
                PbxCristal2.Location = new Point(669, 288);
                PbxCristal3.Location = new Point(376, 695);
            }
        }
        #endregion

        #region SETAR TAMANHO CRISTAIS
        public void setCrisSize(int tamX, int tamY)
        {
            PbxCristal1.Size = new Size(tamX, tamY);
            PbxCristal2.Size = new Size(tamX, tamY);
            PbxCristal3.Size = new Size(tamX, tamY);
        }
        #endregion

        #region SETAR IMAGEM DOS CRISTAIS
        public void setImagendsCrital(string img)
        {
            PbxCristal1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PbxCristal2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PbxCristal3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
        }
        #endregion

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

        public void ocultarTodasPbx()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox)
                {
                    if (j.Visible == true)
                    {
                        j.Visible = false;
                    }
                }
            }
        }
        public void AddTempo(int tempo)
        {
            tempSeg = tempSeg + tempo;
            if(tempo > 0)
            {
                LBL_Tempo.ForeColor = Color.GreenYellow;
                LBL_Tempo.Text += " +" + tempo;
            }
            else
            {
                LBL_Tempo.ForeColor = Color.IndianRed;
                LBL_Tempo.Text += " " + tempo;
            }
        }

        public void AddScorePonto(int pontos)
        {
            if (Score > 0)
            {
                Score = Score + pontos;
            }
            else if(Score <= 0)
            {
                Score = 0;
            }
           
            if (pontos > 0)
            {
                LBLScore(520, 510, 500);
                LblScore.ForeColor = Color.GreenYellow;
                LblScore.Text += " +" + pontos;
            }
            else
            {
                LBLScore(520, 510, 500);
                LblScore.ForeColor = Color.IndianRed;
                if (Score <= 0)
                {
                    LblScore.Text = "0";
                }
                else
                {
                    LblScore.Text += " " + pontos;
                }
               
            }

        }

        //função que define a posição do LBL SCORE
        public void LBLScore(int posicao1, int posicao2, int posicao3)
        {
            if (LblScore.Text.Length == 1)
            {
                LblScore.Location = new Point(posicao1, 23);
            }

            if (LblScore.Text.Length == 2)
            {
                LblScore.Location = new Point(posicao2, 23);
            }

            if (LblScore.Text.Length == 3)
            {
                LblScore.Location = new Point(posicao3, 23);
            }
        }

        //Função de Alterar IMG do HELP
        public void HelpImg(int mapa, int help)
        {
            if (help == 1 && mapa == 1)
            {
                HelpLBL(189, 281);
                LBL_txtHelp.Text = "Você deve pegar todas as vitaminas";
                LBL_txtHelp2.Text = "para passar de fase!";
            }
            else if (help == 2 && mapa == 1)
            {
                HelpLBL(189, 265);
                LBL_txtHelp.Text = "Responda corretamente as perguntas";
                LBL_txtHelp2.Text = "e ganhe pontos e tempo!";
            }
            else if (help == 3 && mapa == 1)
            {
                HelpLBL(189, 220);
                LBL_txtHelp.Text = "Os cristais te dão bonus incriveis,";
                LBL_txtHelp2.Text = "pegue-os e ganhe mais pontos!";
            }
            else if (help == 4 && mapa == 1)
            {
                HelpLBL(135, 200);
                LBL_txtHelp.Text = "Cuidado com seu tempo, não deixe ele acabar,";
                LBL_txtHelp2.Text = "você não vai querer perder tudo!";
            }
            PBX_Help.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\help\\mapa_"+mapa+ "\\infoHelp_"+help+".png");   
        }

        //funçaõ auxiliar, alterar posicao do lbl help
        public void HelpLBL(int posX1, int posX2)
        {
            LBL_txtHelp.Location = new Point(posX1, 348);
            LBL_txtHelp2.Location = new Point(posX2, 378);
        }

        #region SETAR O PLACAR
        public void setPlacar()
        {
            Score = 0;
            LblScore.Text = "0";

            //Setar o texto da fase
            LblContVitaminas.Text = "0/7";
            LblContCristais.Text = "x";

            //Setar a visibilidade do placar
            PbxContVitaminas.Visible = true;
            PbxContCristais.Visible = true;
            LblContCristais.Visible = true;
            LblContVitaminas.Visible = true;

            if (fase == 1)
            {
                //Setar a imagen certa
                PbxContVitaminas.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\maca_animada.gif");
                PbxContCristais.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\cristal_animado.gif");
            }
            if (fase == 2)
            {
                //Setar a imagen certa
                PbxContVitaminas.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\bifeCru_animado.gif");
                PbxContCristais.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\cristal_animado.gif");
            }

        }
        #endregion

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            contVitaminas++;
            lblOutputRequest.Text = contVitaminas.ToString();
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
            if (infoMenu == 3)
            {
                ativouMenu = 0;
                TmrMainGameManager.Stop();
                TMR_Tempo.Stop();
                PNL_Pause.Visible = false;
                PNL_Info.Visible = false;
                PNL_Fases.Visible = true;
                LBL_Tempo.Text = "";
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
            infoMenu = 3;
            PNL_Info.Visible = true;
            PBX_Info.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\textos\\txtInicio.png");

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
                LBLScore(570, 550, 545);
            }
            else
            {
                LBLScore(530, 520, 490);
                if (contCristais == 1)
                {
                    Score = Score + 3;
                    LblScore.ForeColor = Color.Yellow;
                    LblScore.Text = Score + "+" + (contCristais + 3);
                }
                else if (contCristais == 2)
                {
                    Score = Score + 7;
                    LblScore.ForeColor = Color.Orange;
                    LblScore.Text = Score + "+" + (contCristais + 6);
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

        #region FUNCAO REINICIAR JOGO //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ReiniciarJogo()
        {
            //FASE 1
            if (fase == 1)
            {
                tempMin = 1;
                tempSeg = 0;

                //Resetar animação do personagem entrando no mapa
                PbxColision.Location = new Point(59, 169);
                PbxPersonagem.Location = new Point(-104, 136);
                ControleAnimacao = 700;

                //Resetar placar
                LblContVitaminas.Text = "0/7";
                LblContCristais.Text = "x";
                contCristais = 0;
                contVitaminas = 0;

                //Resetar visibilidade dos itens
                mostrarTodasPbx();

                //Resetar a velocidade que o player anda
                andarQtdPx = 6;

                //Resetar Score
                Score = 0;
                LblScore.Text = "0";
                TmrAnimation.Start();
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

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Animações //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TmrAnimation_Tick(object sender, EventArgs e)
        {
            //Contador de todas as animações
            ControleAnimacao++;

            //ControleAnimacao = 0 | Animação personagem ganhando fase
            //Olha pro player 
            if (ControleAnimacao > 0 && ControleAnimacao < 250)
            {
                ControleAnimacao++;
                if (ControleAnimacao == 50 || ControleAnimacao == 100 || ControleAnimacao == 150) {
                    ControleAnimacao++;
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" +  escolhaPerson + objPerson + "\\frente\\frente_" + animcaoWin + ".png");
                }
                if (ControleAnimacao == 200)
                {
                    animcaoWin = 1;
                }
            }

            //Dá uns pulo
            if (ControleAnimacao > 250 && ControleAnimacao < 520) //700 para colocar todos os 5 pulos;
            {
                ControleAnimacaoAux++;
                if (ControleAnimacao == 252)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\"+ escolhaPerson + objPerson + "\\frente\\frente_pulo_2.png");
                }
                if ((ControleAnimacao > 250 && ControleAnimacao < 295) || (ControleAnimacao > 340 && ControleAnimacao < 385) || (ControleAnimacao > 430 && ControleAnimacao < 475)/* Tirar alguns pulos || (ControleAnimacao > 520 && ControleAnimacao < 565) || (ControleAnimacao > 610 && ControleAnimacao < 655)*/)
                {
                    if (ControleAnimacao % 2 == 0) {
                        PbxPersonagem.Location = new Point(posXPlayer, posYPlayer - 1);
                    }
                }
                else if ((ControleAnimacao > 295 && ControleAnimacao < 340) || (ControleAnimacao > 385 && ControleAnimacao < 430) || (ControleAnimacao > 475 && ControleAnimacao < 520)/* Tirar alguns pulos || (ControleAnimacao > 565 && ControleAnimacao < 610) || (ControleAnimacao > 655 && ControleAnimacao < 700)*/)
                {
                    if (ControleAnimacao % 2 == 0)
                    {
                        PbxPersonagem.Location = new Point(posXPlayer, posYPlayer + 1);
                    }
                }
                if (ControleAnimacaoAux % 40 == 0)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +  "\\frente\\frente_pulo_" + animcaoWin + ".png");
                    animcaoWin++;
                    if (animcaoWin > 2)
                    {
                        animcaoWin = 1;
                    }
                }
            }

            //Sai do mapa
            if (ControleAnimacao > 520 && ControleAnimacao < 620)
            {
                if (ControleAnimacao == 520)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_1.png");
                }
                PbxPersonagem.Location = new Point(posXPlayer + 3, posYPlayer);
                if (ControleAnimacao % 5 == 0)
                {
                    animcaoWin = (ControleAnimacao % 2) + 1;
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_" + animcaoWin + ".png");
                }
            }

            //Encerra a animação de saida do mapa
            if (ControleAnimacao == 670)
            {
                PNL_Fases.Enabled = true;
                PNL_Fases.Visible = true;
                LBL_Tempo.Text = "";
                ResetAmbiente();
                TmrAnimation.Stop();
            }

            //ControleAnimacao = 700 | Animações do personagem entrando na fase
            //Entra no mapa 1
            if (fase == 1)
            {
                if (ControleAnimacao > 700 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(posXPlayer + 3, posYPlayer);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\"+ escolhaPerson + objPerson +"\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                }
            }

            //Entra no mapa 2
            if (fase == 2)
            {
                if (ControleAnimacao > 700 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(posXPlayer + 3, posYPlayer);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                }
            }

            //Entra no mapa 3
            if (fase == 3)
            {
                if (ControleAnimacao > 700 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(posXPlayer + 3, posYPlayer);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson +"\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                }
            }

            //ControleAnimacao = 800
            //Animação do portão
            if (ControleAnimacao > 800 && ControleAnimacao < 835)
            {
                PbxCerca.Location = new Point(PbxCerca.Location.X + 1, PbxCerca.Location.Y);
            }
            if (ControleAnimacao == 836)
            {
                TmrAnimation.Stop();
            }

            //controleAnimações = 900
            //Animação da pergunta aparecendo
            if (ControleAnimacao == 901)
            {
                PnlPerguntas.Visible = true;
            }
            if (ControleAnimacao > 900 && ControleAnimacao < 968)
            {
                PnlPerguntas.Location = new Point(PnlPerguntas.Location.X, PnlPerguntas.Location.Y - 3);
            }
            if (ControleAnimacao == 970)
            {
                TmrAnimation.Stop();
            }

            //controleAnimações = 1000
            //Animação da pergunta desaparecendo
            if (ControleAnimacao == 1001)
            {
                this.Focus();
                TmrPergunta.Stop();
            }
            if (ControleAnimacao > 1000 && ControleAnimacao < 1068)
            {
                PnlPerguntas.Location = new Point(PnlPerguntas.Location.X, PnlPerguntas.Location.Y + 3);
            }
            if (ControleAnimacao == 1070)
            {
                PnlPerguntas.Visible = false;
                TmrAnimation.Stop();
                resetarObjetosPergunta();
            }

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
            AddTempo(10);
            AddScorePonto(20);
            rodarSaidaPerguntas();
        }

        private void PbxBtn1_Click(object sender, EventArgs e)
        {
            AddTempo(-5);
            AddScorePonto(-20);
            rodarSaidaPerguntas();
        }

        #endregion //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Correção de perguntas e tempo das perguntas //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void TmrPergunta_Tick(object sender, EventArgs e)
        {
            tempPergunta++;
            if (tempPergunta == PrbTempPerg.Maximum - 2)
            {
                AddTempo(-10);
                AddScorePonto(-20);
                rodarSaidaPerguntas();
            }
            if (tempPergunta >= 0 && tempPergunta <= 4000)
            {
                PrbTempPerg.Value = tempPergunta;
            }
            if (fase == 1) //Resposta de texto da fase 1
            {
                if (contVitaminas == 2) //Segunda pergunta
                {
                    if (TxtResposta.Text.ToLower() == "36 ovos" || TxtResposta.Text.ToLower() == "trinta e seis ovos" || TxtResposta.Text.ToLower() == "joaquina encontrou 36 ovos" || TxtResposta.Text.ToLower() == "ela encontrou 36 ovos")
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                }
                if (contVitaminas == 3) //Terceira pergunta
                {
                    if (TxtResposta.Text.ToLower() == "3 patos" || TxtResposta.Text.ToLower() == "três patos" || TxtResposta.Text.ToLower() == "há 3 patos")
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                }
                if (contVitaminas == 5) //Quinta pergunta
                {
                    if (TxtResposta.Text != "" && TxtResposta2.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                        resultado = 0;
                        resultado = num1 + num2;
                    }
                    if (resultado == 46)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        Lbl_de_Ajuda.Text = "Você Acertou!! ＜（＾－＾）＞";
                        rodarSaidaPerguntas();
                    }
                    else if (resultado > 40 && resultado < 52)
                    {
                        Lbl_de_Ajuda.Text = "Você está perto! :)";
                    }
                    else
                    {
                        Lbl_de_Ajuda.Text = num1.ToString() + " + " + num2.ToString() + " é igua a " + resultado + "\nVocê está longe do resultado :(";
                    }
                }
                if (contVitaminas == 6) //Sexta pergunta
                {
                    if (TxtResposta.Text.ToLower() == "12 pessoas" || TxtResposta.Text.ToLower() == "doze pessoas" || TxtResposta.Text.ToLower() == "há doze pessoas" || TxtResposta.Text.ToLower() == "há 12 pessoas")
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                }
                if (contVitaminas == 7) //Setima (Última) pergunta
                {
                    if (TxtResposta.Text != "" && TxtResposta2.Text != "" && TxtResposta3.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                        num2 = Convert.ToDouble(TxtResposta2.Text);
                        num3 = Convert.ToDouble(TxtResposta3.Text);
                        resultado = 0;
                        resultado = num1 - (num2 * num3);
                    }
                    if (resultado == -37)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        Lbl_de_Ajuda.Text = "Você Acertou!! ＜（＾－＾）＞";
                        rodarSaidaPerguntas();
                    }
                    else if (resultado > -32 && resultado < -42)
                    {
                        Lbl_de_Ajuda.Text = "Você está perto! :)";
                    }
                    else
                    {
                        Lbl_de_Ajuda.Text = num1.ToString() + " - " + num2.ToString() + " + " + num3.ToString() + " é igua a " + resultado + "\nVocê está longe do resultado :(";
                    }
                }
            }
            if (fase == 2) //Resposta de texto da fase 2
            {
                if (contVitaminas == 1)
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
                    if (num1 == 88 && num2 == 93 && num3 == 152)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                    if (num1 >= 78 && num1 <= 98 && num1 != 88)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= 83 && num2 <= 103 && num2 != 93)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= 142 && num3 <= 162 && num3 != 152)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num1 == 88)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 93)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 152)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < 78 && num1 > 98)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < 83 && num2 > 103)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < 142 && num3 > 162)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                }
                if (contVitaminas == 2)
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
                    if (num1 == 39 && num2 == 18 && num3 == 21)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                    if (num1 >= 39 - 10 && num1 <= 39 + 10 && num1 != 39)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= 18 - 10 && num2 <= 18 + 10 && num2 != 18)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= 21 - 10 && num3 <= 21 + 10 && num3 != 21)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num1 == 39)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 18)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 21)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < 39 - 10 && num1 > 39 + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < 18 - 10 && num2 > 18 + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < 21 - 10 && num3 > 21 + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                }
                if (contVitaminas == 3)
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
                    if (num1 == 72 && num2 == 95 && num3 == 93)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                    if (num1 >= 72 - 10 && num1 <= 72 + 10 && num1 != 72)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= 95 - 10 && num2 <= 95 + 10 && num2 != 95)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= 93 - 10 && num3 <= 93 + 10 && num3 != 93)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num1 == 72)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 95)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 93)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < 72 - 10 && num1 > 72 + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < 95 - 10 && num2 > 95 + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < 93 - 10 && num3 > 93 + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                }
                if (contVitaminas == 4)
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
                    if (num1 == 19 && num2 == 42 && num3 == 12)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                    if (num1 >= 19 - 10 && num1 <= 19 + 10 && num1 != 19)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= 42 - 10 && num2 <= 42 + 10 && num2 != 42)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= 12 - 10 && num3 <= 12 + 10 && num3 != 12)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num1 == 19)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 42)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 12)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < 19 - 10 && num1 > 19 + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < 42 - 10 && num2 > 42 + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < 12 - 10 && num3 > 12 + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                }
                if (contVitaminas == 6)
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
                    if (num1 == 32 && num2 == 112 && num3 == 31 && num4 == 107)
                    {
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
                    }
                    if (num1 >= 32 - 10 && num1 <= 32 + 10 && num1 != 32)
                    {
                        LblResposta.ForeColor = Color.Yellow;
                    }
                    if (num2 >= 112 - 10 && num2 <= 112 + 10 && num2 != 112)
                    {
                        LblResposta2.ForeColor = Color.Yellow;
                    }
                    if (num3 >= 31 - 10 && num3 <= 31 + 10 && num3 != 31)
                    {
                        LblResposta3.ForeColor = Color.Yellow;
                    }
                    if (num4 >= 107 - 10 && num4 <= 107 + 10 && num4 != 107)
                    {
                        LblResposta4.ForeColor = Color.Yellow;
                    }
                    if (num1 == 32)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                    }
                    if (num2 == 112)
                    {
                        LblResposta2.ForeColor = Color.GreenYellow;
                    }
                    if (num3 == 31)
                    {
                        LblResposta3.ForeColor = Color.GreenYellow;
                    }
                    if (num4 == 107)
                    {
                        LblResposta4.ForeColor = Color.GreenYellow;
                    }
                    if (num1 < 32 - 10 && num1 > 32 + 10)
                    {
                        LblResposta.ForeColor = Color.White;
                    }
                    if (num2 < 112 - 10 && num2 > 112 + 10)
                    {
                        LblResposta2.ForeColor = Color.White;
                    }
                    if (num3 < 31 - 10 && num3 > 31 + 10)
                    {
                        LblResposta3.ForeColor = Color.White;
                    }
                    if (num4 < 107 - 10 && num4 > 107 + 10)
                    {
                        LblResposta4.ForeColor = Color.White;
                    }
                }
                if (contVitaminas == 7)
                {
                    if (TxtResposta.Text != "")
                    {
                        num1 = Convert.ToDouble(TxtResposta.Text);
                    }
                    if (num1 == 7)
                    {
                        LblResposta.ForeColor = Color.GreenYellow;
                        AddTempo(10);
                        AddScorePonto(20);
                        rodarSaidaPerguntas();
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
                HelpImg(fase, helpIndex);
            }
        }
        private void PBX_btnVoltaHelp_Click(object sender, EventArgs e)
        {
            helpIndex--;
            PBX_bntVaiHelp.Visible = true;
            if (helpIndex == 1)
            {
                PBX_btnVoltaHelp.Visible = false;
                HelpImg(fase, helpIndex);
            }
            else
            {
                HelpImg(fase, helpIndex);
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
    }
}
