﻿using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using AxWMPLib;

namespace Jogo_Matamática_3_ano
{
    public class Utilits
    {
        // Variáveis da funções de perguntas
        public int randomPergunta;
        char PerguntaLetra;
        // Variáveis da função ganharFase()
        public int ControleAnimacaoAux, animcaoWin = 1, andarQtdPx = 3;
        public int animationSpeed;
        public int animationPlayer;
        public int countAnimation;
        public Label[] labels;
        public TextBox[] texts;

        #region Recebendo todas as classes estanciadas do design
        Timer TmrMainGameManager;
        PictureBox PbxPersonagem;
        PictureBox PBX_Sair;
        PictureBox PBX_Jogar;
        Panel PNL_Fases;
        Panel panel4;
        Panel panel3;
        Panel panel5;
        Panel panel6;
        Panel panel2;
        Panel panel1;
        PictureBox PbxColision;
        PictureBox pictureBox1;
        PictureBox pictureBox2;
        PictureBox pictureBox3;
        PictureBox pictureBox4;
        PictureBox pictureBox5;
        PictureBox pictureBox6;
        PictureBox pictureBox7;
        PictureBox pictureBox8;
        PictureBox pictureBox9;
        PictureBox pictureBox10;
        PictureBox pictureBox11;
        PictureBox pictureBox12;
        PictureBox pictureBox13;
        PictureBox pictureBox14;
        PictureBox pictureBox15;
        PictureBox pictureBox16;
        PictureBox pictureBox17;
        PictureBox pictureBox18;
        PictureBox pictureBox19;
        PictureBox pictureBox20;
        PictureBox pictureBox21;
        PictureBox pictureBox22;
        PictureBox pictureBox23;
        PictureBox pictureBox24;
        PictureBox pictureBox25;
        PictureBox pictureBox26;
        PictureBox pictureBox27;
        PictureBox pictureBox28;
        PictureBox pictureBox29;
        PictureBox pictureBox30;
        PictureBox pictureBox31;
        PictureBox pictureBox32;
        PictureBox pictureBox33;
        PictureBox pictureBox34;
        PictureBox pictureBox35;
        PictureBox pictureBox36;
        PictureBox pictureBox37;
        PictureBox pictureBox38;
        PictureBox pictureBox39;
        PictureBox pictureBox40;
        PictureBox pictureBox41;
        PictureBox pictureBox42;
        PictureBox pictureBox43;
        PictureBox pictureBox44;
        PictureBox pictureBox45;
        PictureBox pictureBox46;
        PictureBox pictureBox47;
        PictureBox pictureBox48;
        PictureBox pictureBox49;
        PictureBox pictureBox50;
        PictureBox pictureBox51;
        PictureBox pictureBox52;
        PictureBox pictureBox53;
        Timer TMR_Tempo;
        Label LBL_Tempo;
        Timer TmrAnimation;
        PictureBox PBX_Ambiente1;
        PictureBox PBX_Ambiente2;
        PictureBox PBX_Ambiente3;
        PictureBox PBX_Ambiente4;
        PictureBox PBX_Ambiente5;
        PictureBox PBX_Ambiente6;
        PictureBox PBX_Ambiente7;
        PictureBox PBX_Vitamina1;
        PictureBox PBX_Vitamina2;
        PictureBox PBX_Vitamina3;
        PictureBox PBX_Vitamina4;
        PictureBox PBX_Vitamina5;
        PictureBox PBX_Vitamina6;
        PictureBox PBX_Vitamina7;
        PictureBox PbxCerca;
        Panel PnlPerguntas;
        PictureBox PbxBtnCerto;
        PictureBox PbxBtn2;
        PictureBox PbxBtn4;
        PictureBox PbxBtn3;
        PictureBox PbxBtn1;
        Label Lbl_de_Ajuda;
        Timer TmrPergunta;
        PictureBox PbxCristal1;
        PictureBox PbxCristal2;
        PictureBox PbxCristal3;
        PictureBox PbxContVitaminas;
        PictureBox PbxContCristais;
        Label LblContVitaminas;
        Label LblContCristais;
        Label LblScore;
        PictureBox PBX_Help;
        Label LBL_txtHelp;
        Label LBL_txtHelp2;
        PictureBox pictureBox58;
        PictureBox pictureBox60;
        PictureBox PBX_Vitoria;
        PictureBox PbxVinheta1;
        PictureBox PbxVinheta2;
        PictureBox pictureBox61;
        PictureBox PBX_Placar;
        Sons sons;
        
        public Utilits
            (
            Timer TmrMainGameManager,
            PictureBox PbxPersonagem,
            PictureBox PBX_Sair,
            PictureBox PBX_Jogar,
            Panel PNL_Fases,
            Panel panel4,
            Panel panel3,
            Panel panel5,
            Panel panel6,
            Panel panel2,
            Panel panel1,
            PictureBox PbxColision,
            PictureBox pictureBox1,
            PictureBox pictureBox2,
            PictureBox pictureBox3,
            PictureBox pictureBox4,
            PictureBox pictureBox5,
            PictureBox pictureBox6,
            PictureBox pictureBox7,
            PictureBox pictureBox8,
            PictureBox pictureBox9,
            PictureBox pictureBox10,
            PictureBox pictureBox11,
            PictureBox pictureBox12,
            PictureBox pictureBox13,
            PictureBox pictureBox14,
            PictureBox pictureBox15,
            PictureBox pictureBox16,
            PictureBox pictureBox17,
            PictureBox pictureBox18,
            PictureBox pictureBox19,
            PictureBox pictureBox20,
            PictureBox pictureBox21,
            PictureBox pictureBox22,
            PictureBox pictureBox23,
            PictureBox pictureBox24,
            PictureBox pictureBox25,
            PictureBox pictureBox26,
            PictureBox pictureBox27,
            PictureBox pictureBox28,
            PictureBox pictureBox29,
            PictureBox pictureBox30,
            PictureBox pictureBox31,
            PictureBox pictureBox32,
            PictureBox pictureBox33,
            PictureBox pictureBox34,
            PictureBox pictureBox35,
            PictureBox pictureBox36,
            PictureBox pictureBox37,
            PictureBox pictureBox38,
            PictureBox pictureBox39,
            PictureBox pictureBox40,
            PictureBox pictureBox41,
            PictureBox pictureBox42,
            PictureBox pictureBox43,
            PictureBox pictureBox44,
            PictureBox pictureBox45,
            PictureBox pictureBox46,
            PictureBox pictureBox47,
            PictureBox pictureBox48,
            PictureBox pictureBox49,
            PictureBox pictureBox50,
            PictureBox pictureBox51,
            PictureBox pictureBox52,
            PictureBox pictureBox53,
            Timer TMR_Tempo,
            Label LBL_Tempo,
            Timer TmrAnimation,
            PictureBox PBX_Ambiente1,
            PictureBox PBX_Ambiente2,
            PictureBox PBX_Ambiente3,
            PictureBox PBX_Ambiente4,
            PictureBox PBX_Ambiente5,
            PictureBox PBX_Ambiente6,
            PictureBox PBX_Ambiente7,
            PictureBox PBX_Vitamina1,
            PictureBox PBX_Vitamina2,
            PictureBox PBX_Vitamina3,
            PictureBox PBX_Vitamina4,
            PictureBox PBX_Vitamina5,
            PictureBox PBX_Vitamina6,
            PictureBox PBX_Vitamina7,
            PictureBox PbxCerca,
            Panel PnlPerguntas,
            TextBox TxtResposta,
            Label LblResposta,
            PictureBox PbxBtnCerto,
            PictureBox PbxBtn2,
            PictureBox PbxBtn4,
            PictureBox PbxBtn3,
            PictureBox PbxBtn1,
            Label Lbl_de_Ajuda,
            Timer TmrPergunta,
            Label LblResposta2,
            TextBox TxtResposta2,
            Label LblResposta3,
            TextBox TxtResposta3,
            PictureBox PbxCristal1,
            PictureBox PbxCristal2,
            PictureBox PbxCristal3,
            PictureBox PbxContVitaminas,
            PictureBox PbxContCristais,
            Label LblContVitaminas,
            Label LblContCristais,
            Label LblScore,
            PictureBox PBX_Help,
            Label LBL_txtHelp,
            Label LBL_txtHelp2,
            PictureBox pictureBox58,
            PictureBox pictureBox60,
            PictureBox PBX_Vitoria,
            TextBox TxtResposta4,
            Label LblResposta4,
            PictureBox PbxVinheta1,
            PictureBox PbxVinheta2,
            PictureBox pictureBox61,
            PictureBox PBX_Placar,
            Sons sons
            )
        {
            labels = new Label[4];
            texts = new TextBox[4];
            this.TmrMainGameManager = TmrMainGameManager;
            this.PbxPersonagem = PbxPersonagem;
            this.PBX_Sair = PBX_Sair;
            this.PBX_Jogar = PBX_Jogar;
            this.PNL_Fases = PNL_Fases;
            this.panel4 = panel4;
            this.panel3 = panel3;
            this.panel5 = panel5;
            this.panel6 = panel6;
            this.panel2 = panel2;
            this.panel1 = panel1;
            this.PbxColision = PbxColision;
            this.pictureBox1 = pictureBox1;
            this.pictureBox2 = pictureBox2;
            this.pictureBox3 = pictureBox3;
            this.pictureBox4 = pictureBox4;
            this.pictureBox5 = pictureBox5;
            this.pictureBox6 = pictureBox6;
            this.pictureBox7 = pictureBox7;
            this.pictureBox8 = pictureBox8;
            this.pictureBox9 = pictureBox9;
            this.pictureBox10 = pictureBox10;
            this.pictureBox11 = pictureBox11;
            this.pictureBox12 = pictureBox12;
            this.pictureBox13 = pictureBox13;
            this.pictureBox14 = pictureBox14;
            this.pictureBox15 = pictureBox15;
            this.pictureBox16 = pictureBox16;
            this.pictureBox17 = pictureBox17;
            this.pictureBox18 = pictureBox18;
            this.pictureBox19 = pictureBox19;
            this.pictureBox20 = pictureBox20;
            this.pictureBox21 = pictureBox21;
            this.pictureBox22 = pictureBox22;
            this.pictureBox23 = pictureBox23;
            this.pictureBox24 = pictureBox24;
            this.pictureBox25 = pictureBox25;
            this.pictureBox26 = pictureBox26;
            this.pictureBox27 = pictureBox27;
            this.pictureBox28 = pictureBox28;
            this.pictureBox29 = pictureBox29;
            this.pictureBox30 = pictureBox30;
            this.pictureBox31 = pictureBox31;
            this.pictureBox32 = pictureBox32;
            this.pictureBox33 = pictureBox33;
            this.pictureBox34 = pictureBox34;
            this.pictureBox35 = pictureBox35;
            this.pictureBox36 = pictureBox36;
            this.pictureBox37 = pictureBox37;
            this.pictureBox38 = pictureBox38;
            this.pictureBox39 = pictureBox39;
            this.pictureBox40 = pictureBox40;
            this.pictureBox41 = pictureBox41;
            this.pictureBox42 = pictureBox42;
            this.pictureBox43 = pictureBox43;
            this.pictureBox44 = pictureBox44;
            this.pictureBox45 = pictureBox45;
            this.pictureBox46 = pictureBox46;
            this.pictureBox47 = pictureBox47;
            this.pictureBox48 = pictureBox48;
            this.pictureBox49 = pictureBox49;
            this.pictureBox50 = pictureBox50;
            this.pictureBox51 = pictureBox51;
            this.pictureBox52 = pictureBox52;
            this.pictureBox53 = pictureBox53;
            this.TMR_Tempo = TMR_Tempo;
            this.LBL_Tempo = LBL_Tempo;
            this.TmrAnimation = TmrAnimation;
            this.PBX_Ambiente1 = PBX_Ambiente1;
            this.PBX_Ambiente2 = PBX_Ambiente2;
            this.PBX_Ambiente3 = PBX_Ambiente3;
            this.PBX_Ambiente4 = PBX_Ambiente4;
            this.PBX_Ambiente5 = PBX_Ambiente5;
            this.PBX_Ambiente6 = PBX_Ambiente6;
            this.PBX_Ambiente7 = PBX_Ambiente7;
            this.PBX_Vitamina1 = PBX_Vitamina1;
            this.PBX_Vitamina2 = PBX_Vitamina2;
            this.PBX_Vitamina3 = PBX_Vitamina3;
            this.PBX_Vitamina4 = PBX_Vitamina4;
            this.PBX_Vitamina5 = PBX_Vitamina5;
            this.PBX_Vitamina6 = PBX_Vitamina6;
            this.PBX_Vitamina7 = PBX_Vitamina7;
            this.PbxCerca = PbxCerca;
            this.PnlPerguntas = PnlPerguntas;
            texts[0] = TxtResposta;
            labels[0] = LblResposta;
            this.PbxBtnCerto = PbxBtnCerto;
            this.PbxBtn2 = PbxBtn2;
            this.PbxBtn4 = PbxBtn4;
            this.PbxBtn3 = PbxBtn3;
            this.PbxBtn1 = PbxBtn1;
            this.Lbl_de_Ajuda = Lbl_de_Ajuda;
            this.TmrPergunta = TmrPergunta;
            labels[1] = LblResposta2;
            texts[1] = TxtResposta2;
            labels[2] = LblResposta3;
            texts[2] = TxtResposta3;
            this.PbxCristal1 = PbxCristal1;
            this.PbxCristal2 = PbxCristal2;
            this.PbxCristal3 = PbxCristal3;
            this.PbxContVitaminas = PbxContVitaminas;
            this.PbxContCristais = PbxContCristais;
            this.LblContVitaminas = LblContVitaminas;
            this.LblContCristais = LblContCristais;
            this.LblScore = LblScore;
            this.PBX_Help = PBX_Help;
            this.LBL_txtHelp = LBL_txtHelp;
            this.LBL_txtHelp2 = LBL_txtHelp2;
            this.pictureBox58 = pictureBox58;
            this.pictureBox60 = pictureBox60;
            this.PBX_Vitoria = PBX_Vitoria;
            labels[3] = LblResposta4;
            texts[3] = TxtResposta4;
            this.PbxVinheta1 = PbxVinheta1;
            this.PbxVinheta2 = PbxVinheta2;
            this.pictureBox61 = pictureBox61;
            this.PBX_Placar = PBX_Placar;
            this.sons = sons;
        }
        #endregion

        //RESETAR AMBIENTE TORNÁ-LO INVISÍVEL
        public void resetAmbiente()
        {
            PBX_Ambiente1.Hide();
            PBX_Ambiente2.Hide();
            PBX_Ambiente3.Hide();
            PBX_Ambiente4.Hide();
            PBX_Ambiente5.Hide();
            PBX_Ambiente6.Hide();
            PBX_Ambiente7.Hide();
        }

        //SETAR TRANSPARENCIA ITENS
        public void itensTrans()
        {
            PbxCristal1.BackColor = Color.Transparent;
            PbxCristal2.BackColor = Color.Transparent;
            PbxCristal3.BackColor = Color.Transparent;
            PBX_Vitoria.BackColor = Color.Transparent;
        }

        //SETAR O LAYOUT DOS BOTÕES DE ACORDO COM A PERGUNTA
        public void setarBtnPergunta(int fase)
        {
            int SizeX = 127,
                SizeY = 70;

            PbxBtn1.Enabled = true;
            PbxBtn2.Enabled = true;
            PbxBtn3.Enabled = true;
            PbxBtn4.Enabled = true;
            PbxBtnCerto.Enabled = true;

            PbxBtn1.Show();
            PbxBtn2.Show();
            PbxBtn3.Show();
            PbxBtn4.Show();
            PbxBtnCerto.Show();

            PbxBtn1.Size = new Size(SizeX, SizeY);
            PbxBtn2.Size = new Size(SizeX, SizeY);
            PbxBtn3.Size = new Size(SizeX, SizeY);
            PbxBtn4.Size = new Size(SizeX, SizeY);
            PbxBtnCerto.Size = new Size(SizeX, SizeY);

            if (fase == 1)
            {
                #region randomPergunta == 1
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(681, 104);
                    PbxBtn2.Location = new Point(835, 104);
                    PbxBtn3.Location = new Point(981, 104);
                    PbxBtnCerto.Location = new Point(533, 104);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                {
                    SizeX = 389;
                    SizeY = 53;

                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Size = new Size(SizeX, SizeY);
                    PbxBtn2.Size = new Size(SizeX, SizeY);
                    PbxBtn3.Size = new Size(SizeX, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn1.Location = new Point(208, 61);
                    PbxBtn2.Location = new Point(208, 117);
                    PbxBtn3.Location = new Point(615, 117);
                    PbxBtnCerto.Location = new Point(615, 61);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                {
                    setImgBtn(5, fase);

                    PbxBtn1.Location = new Point(833, 28);
                    PbxBtn2.Location = new Point(1057, 111);
                    PbxBtn3.Location = new Point(752, 111);
                    PbxBtn4.Location = new Point(905, 111);
                    PbxBtnCerto.Location = new Point(978, 28);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                {
                    SizeX = 148;
                    SizeY = 77;

                    PbxBtn2.Enabled = false;
                    PbxBtn3.Enabled = false;
                    PbxBtn4.Enabled = false;

                    PbxBtn2.Hide();
                    PbxBtn3.Hide();
                    PbxBtn4.Hide();

                    setImgBtn(2, fase);

                    PbxBtn1.Size = new Size(SizeX, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn1.Location = new Point(823, 56);
                    PbxBtnCerto.Location = new Point(1023, 56);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(766, 98);
                    PbxBtn2.Location = new Point(620, 98);
                    PbxBtn3.Location = new Point(335, 98);
                    PbxBtnCerto.Location = new Point(479, 98);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(792, 97);
                    PbxBtn2.Location = new Point(649, 97);
                    PbxBtn3.Location = new Point(361, 97);
                    PbxBtnCerto.Location = new Point(508, 97);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                {
                    SizeX = 58;
                    SizeY = 58;

                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Size = new Size(SizeX + 54, SizeY);
                    PbxBtn2.Size = new Size(SizeX, SizeY);
                    PbxBtn3.Size = new Size(SizeX + 9, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn1.Location = new Point(1053, 78);
                    PbxBtn2.Location = new Point(946, 78);
                    PbxBtn3.Location = new Point(813, 78);
                    PbxBtnCerto.Location = new Point(689, 78);
                }
                #endregion
                #region randomPergunta == 2
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(90, 105);
                    PbxBtn2.Location = new Point(385, 105);
                    PbxBtn3.Location = new Point(240, 105);
                    PbxBtnCerto.Location = new Point(532, 105);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(335, 106);
                    PbxBtn2.Location = new Point(621, 106);
                    PbxBtn3.Location = new Point(766, 106);
                    PbxBtnCerto.Location = new Point(479, 106);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(277, 108);
                    PbxBtn2.Location = new Point(560, 108);
                    PbxBtn3.Location = new Point(129, 108);
                    PbxBtnCerto.Location = new Point(416, 108);
                }
                #endregion
                #region randomPergunta == 3
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                {
                    setImgBtn(5, fase);

                    PbxBtn1.Location = new Point(904, 26);
                    PbxBtn2.Location = new Point(1050, 111);
                    PbxBtn3.Location = new Point(904, 111);
                    PbxBtn4.Location = new Point(764, 111);
                    PbxBtnCerto.Location = new Point(1050, 26);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(916, 23);
                    PbxBtn2.Location = new Point(1062, 108);
                    PbxBtn3.Location = new Point(1062, 23);
                    PbxBtnCerto.Location = new Point(916, 108);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                {
                    setImgBtn(5, fase);

                    PbxBtn1.Location = new Point(916, 23);
                    PbxBtn2.Location = new Point(1062, 108);
                    PbxBtn3.Location = new Point(1062, 23);
                    PbxBtn4.Location = new Point(776, 109);
                    PbxBtnCerto.Location = new Point(916, 108);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(362, 101);
                    PbxBtn2.Location = new Point(508, 101);
                    PbxBtn3.Location = new Point(792, 101);
                    PbxBtnCerto.Location = new Point(649, 101);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'f')
                {
                    SizeX = 389;
                    SizeY = 53;

                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Size = new Size(SizeX, SizeY);
                    PbxBtn2.Size = new Size(SizeX, SizeY);
                    PbxBtn3.Size = new Size(SizeX, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn1.Location = new Point(208, 61);
                    PbxBtn2.Location = new Point(208, 117);
                    PbxBtn3.Location = new Point(615, 61);
                    PbxBtnCerto.Location = new Point(615, 117);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'g')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(651, 87);
                    PbxBtn2.Location = new Point(794, 86);
                    PbxBtn3.Location = new Point(510, 86);
                    PbxBtnCerto.Location = new Point(364, 86);
                }
                #endregion
            }
            else if (fase == 2)
            {
                #region randomPergunta == 1
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(388, 110);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 110);
                    PbxBtn3.Location = new Point(PbxBtn2.Location.X + (SizeX + 20), 110);
                    PbxBtnCerto.Location = new Point(PbxBtn3.Location.X + (SizeX + 20), 110);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtnCerto.Location = new Point(922, 21);
                    PbxBtn2.Location = new Point(PbxBtnCerto.Location.X + (SizeX + 20), 21);
                    PbxBtn1.Location = new Point(922, PbxBtnCerto.Location.Y + (SizeY + 20));
                    PbxBtn3.Location = new Point(PbxBtnCerto.Location.X + (SizeX + 20), PbxBtnCerto.Location.Y + (SizeY + 20));
                }
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                    setarTxtPergunta(fase);
                #endregion
                #region randomPergunta == 2
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(388, 110);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 110);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 110);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 110);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(388, 110);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 110);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 110);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 110);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn2.Location = new Point(922, 21); 
                    PbxBtnCerto.Location = new Point(PbxBtn2.Location.X + (SizeX + 20), 21);
                    PbxBtn1.Location = new Point(922, PbxBtn2.Location.Y + (SizeY + 20));
                    PbxBtn3.Location = new Point(PbxBtn2.Location.X + (SizeX + 20), PbxBtn2.Location.Y + (SizeY + 20));
                }
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    PbxBtn3.Enabled = false;
                    PbxBtn3.Hide();
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(3, fase);

                    PbxBtn2.Location = new Point(766, 110);
                    PbxBtnCerto.Location = new Point(PbxBtn2.Location.X + (SizeX + 20), 110);
                    PbxBtn1.Location = new Point(PbxBtnCerto.Location.X + (SizeX + 20), 110);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                    setarTxtPergunta(fase);
                #endregion
                #region randomPergunta == 3
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                {
                    SizeX = 60;
                    SizeY = 64;

                    PbxBtn1.Size = new Size(SizeX, SizeY);

                    SizeX = 75;
                    SizeY = 86;

                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn2.Enabled = false;
                    PbxBtn2.Hide();
                    PbxBtn3.Enabled = false;
                    PbxBtn3.Hide();
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    PbxBtn1.Image = null;
                    PbxBtnCerto.Image = null;

                    PbxBtn1.BackColor = Color.Transparent;
                    PbxBtnCerto.BackColor = Color.Transparent;

                    PbxBtn1.Location = new Point(1111, 118);
                    PbxBtnCerto.Location = new Point(959, 94);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(388, 105);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 105);
                    PbxBtn3.Location = new Point(PbxBtn2.Location.X + (SizeX + 20), 105);
                    PbxBtnCerto.Location = new Point(PbxBtn3.Location.X + (SizeX + 20), 105);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(388, 110);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 110);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 110);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 110);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(661, 105);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 105);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 105);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 105);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'f')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(661, 105);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 105);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 105);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 105);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'g')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Hide();

                    setImgBtn(4, fase);

                    PbxBtn1.Location = new Point(661, 105);
                    PbxBtn2.Location = new Point(PbxBtn1.Location.X + (2 * SizeX + 2 * 20), 105);
                    PbxBtn3.Location = new Point(PbxBtn1.Location.X + (SizeX + 20), 105);
                    PbxBtnCerto.Location = new Point(PbxBtn1.Location.X + (3 * SizeX + 3 * 20), 105);
                }
                #endregion
            }
            else if (fase == 3)
            {
                #region randomPergunta == 1
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                    setarTxtPergunta(fase);
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                    setarTxtPergunta(fase);
                #endregion
                #region randomPergunta == 2
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                    setarTxtPergunta(fase);
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                    setarTxtPergunta(fase);
                #endregion
                #region randomPergunta == 3
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'f')
                    setarTxtPergunta(fase);
                if (randomPergunta == 3 && PerguntaLetra == 'g')
                    setarTxtPergunta(fase);
                #endregion
            }
        }

        private void setImgBtn(int qtdBtns, int fase)
        {
            if (qtdBtns == 2)
            {
                PbxBtn1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 1 + ".png");
                PbxBtnCerto.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_Certo.png");
            }
            if (qtdBtns == 3)
            {
                PbxBtn1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 1 + ".png");
                PbxBtn2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 2 + ".png");
                PbxBtnCerto.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_Certo.png");
            }
            if (qtdBtns == 4)
            {
                PbxBtn1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 1 + ".png");
                PbxBtn2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 2 + ".png");
                PbxBtn3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 3 + ".png");
                PbxBtnCerto.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_Certo.png");
            }
            if (qtdBtns == 5)
            {
                PbxBtn1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 1 + ".png");
                PbxBtn2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 2 + ".png");
                PbxBtn3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 3 + ".png");
                PbxBtn4.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_" + 4 + ".png");
                PbxBtnCerto.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\Btns\\" + randomPergunta + PerguntaLetra + "_Certo.png");
            }
        }

        private void setLabelText(Label exNomeLbl, TextBox exNomeTxt)
        {
            foreach (Label x in labels)
            {
                if (x == exNomeLbl)
                    break;
                x.Enabled = true;
                x.Show();
                x.Text = "Clique aqui";
                x.Font = new Font("Snap ITC", 12);
                x.Size = new Size(86, 46);
            }

            foreach (TextBox x in texts)
            {
                if (x == exNomeTxt)
                    break;
                x.MaxLength = 3;
                x.Show();
                x.Enabled = true;
            }
        }
        private void setLabelText()
        {
            foreach (Label x in labels)
            {
                x.Enabled = true;
                x.Show();
                x.Text = "Clique aqui";
                x.Font = new Font("Snap ITC", 12);
                x.Size = new Size(86, 46);
            }

            foreach (TextBox x in texts)
            {
                x.MaxLength = 3;
                x.Text = "";
                x.Enabled = true;
                x.Show();
            }
        }

        //SETAR O LAYOUT DOS TEXTOS DE ACORDO COM A PERGUNTA
        public void setarTxtPergunta(int fase)
        {
            PbxBtn1.Enabled = false;
            PbxBtn2.Enabled = false;
            PbxBtn3.Enabled = false;
            PbxBtn4.Enabled = false;
            PbxBtnCerto.Enabled = false;

            PbxBtn1.Hide();
            PbxBtn2.Hide();
            PbxBtn3.Hide();
            PbxBtn4.Hide();
            PbxBtnCerto.Hide();

            //Setar como default
            labels[0].Size = new Size(75, 46);
            labels[0].Font = new Font("Snap ITC", 12);
            labels[0].Text = "Clique aqui";
            labels[0].Show();
            texts[0].Show();
            labels[0].Enabled = true;
            texts[0].MaxLength = 2;
            texts[0].Enabled = true;

            if (fase == 1)
            {
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    Lbl_de_Ajuda.Location = new Point(529, 27);
                    labels[0].Location = new Point(392, 76);
                    labels[1].Location = new Point(529, 77);
                    labels[2].Location = new Point(667, 77);

                    Lbl_de_Ajuda.Size = new Size(192, 44);

                    Lbl_de_Ajuda.Show();

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    labels[0].Location = new Point(327, 57);
                    labels[1].Location = new Point(732, 56);
                    labels[2].Location = new Point(1134, 56);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                    labels[0].Location = new Point(518, 32);
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    labels[0].Location = new Point(382, 85);
                    labels[1].Location = new Point(531, 85);
                    labels[2].Location = new Point(684, 85);
                    labels[3].Location = new Point(829, 86);

                    setLabelText();
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                    labels[0].Location = new Point(1101, 103);
            }
            else if (fase == 2)
            {
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                {
                    labels[0].Location = new Point(327, 57);
                    labels[1].Location = new Point(732, 57);
                    labels[2].Location = new Point(1134, 57);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                {
                    labels[0].Location = new Point(327 - 284, 57);
                    labels[1].Location = new Point(732 - 284, 57);
                    labels[2].Location = new Point(1134 - 284, 57);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                {
                    labels[0].Location = new Point(327 - 284, 57);
                    labels[1].Location = new Point(732 - 284, 57);
                    labels[2].Location = new Point(1134 - 284, 57);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                    labels[0].Location = new Point(737, 106);
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                    labels[0].Location = new Point(594, 109);
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                    labels[0].Location = new Point(500, 107);
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                    labels[0].Location = new Point(1010, 81);
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                {
                    labels[0].Location = new Point(843, 118);
                    labels[1].Location = new Point(1096, 38);

                    setLabelText(labels[2], texts[2]);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    labels[0].Location = new Point(350, 77);
                    labels[0].Size = new Size(564, 46);
                    texts[0].MaxLength = 27;
                }
            }
            else if (fase == 3)
            {
                #region randomPergunta == 1
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                    labels[0].Location = new Point(595, 75);
                if (randomPergunta == 1 && PerguntaLetra == 'b')
                {
                    labels[0].Location = new Point(365, 115);
                    labels[0].Size = new Size(571, 46);
                    texts[0].MaxLength = 27;
                }
                if (randomPergunta == 1 && PerguntaLetra == 'c')
                {
                    labels[0].Location = new Point(761, 54);
                    labels[1].Location = new Point(767, 123);

                    setLabelText(labels[2], texts[2]);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'd')
                    labels[0].Location = new Point(790, 75);
                    labels[0].Size = new Size(124, 46);
                    texts[0].MaxLength = 4;
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                {
                    labels[0].Location = new Point(398, 86);
                    labels[1].Location = new Point(567, 86);
                    labels[2].Location = new Point(741, 86);
                    labels[3].Location = new Point(908, 86);

                    setLabelText();
                }
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                {
                    labels[0].Location = new Point(354, 82);
                    labels[1].Location = new Point(726, 83);
                    labels[2].Location = new Point(1070, 82);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'g')
                    labels[0].Location = new Point(607, 94);
                #endregion
                #region randomPergunta == 2
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                    labels[0].Location = new Point(595, 75);
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    labels[0].Location = new Point(365, 115);
                    labels[0].Size = new Size(571, 46);
                    texts[0].MaxLength = 27;
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    labels[0].Location = new Point(761, 54);
                    labels[1].Location = new Point(767, 123);

                    setLabelText(labels[2], texts[2]);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                {
                    labels[0].Location = new Point(790, 75);
                    labels[0].Size = new Size(124, 46);
                    texts[0].MaxLength = 4;
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    labels[0].Location = new Point(398, 86);
                    labels[1].Location = new Point(567, 86);
                    labels[2].Location = new Point(741, 86);
                    labels[3].Location = new Point(908, 86);

                    setLabelText();
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    labels[0].Location = new Point(354, 88);
                    labels[1].Location = new Point(726, 88);
                    labels[2].Location = new Point(1070, 88);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                    labels[0].Location = new Point(607, 94);
                #endregion
                #region randomPergunta == 3
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                {
                    labels[0].Location = new Point(546, 86);
                    labels[1].Location = new Point(714, 86);
                    labels[2].Location = new Point(889, 86);
                    labels[3].Location = new Point(1057, 86);

                    setLabelText();
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    labels[0].Location = new Point(365, 115);
                    labels[0].Size = new Size(571, 46);
                    texts[0].MaxLength = 27;
                }
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                {
                    labels[0].Location = new Point(761, 54);
                    labels[1].Location = new Point(767, 123);

                    setLabelText(labels[2], texts[2]);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    labels[0].Location = new Point(790, 75);
                    labels[0].Size = new Size(124, 46);
                    texts[0].MaxLength = 4;
                }
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                {
                    labels[0].Location = new Point(398, 86);
                    labels[1].Location = new Point(567, 86);
                    labels[2].Location = new Point(741, 86);
                    labels[3].Location = new Point(908, 86);

                    setLabelText();
                }
                if (randomPergunta == 3 && PerguntaLetra == 'f')
                {
                    labels[0].Location = new Point(371, 84);
                    labels[1].Location = new Point(745, 84);
                    labels[2].Location = new Point(1089, 84);

                    setLabelText(labels[3], texts[3]);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'g')
                    labels[0].Location = new Point(607, 94);
                #endregion
            }

        }

        //RESETAR O LAYOUT DAS PERGUNTAS
        public int resetarObjetosPergunta(int contVitaminas)
        {
            PbxBtn1.Location = new Point(10, 10);
            PbxBtn2.Location = new Point(10, 10);
            PbxBtn3.Location = new Point(10, 10);
            PbxBtn4.Location = new Point(10, 10);
            PbxBtnCerto.Location = new Point(10, 10);

            PbxBtn1.Size = new Size(10, 10);
            PbxBtn2.Size = new Size(10, 10);
            PbxBtn3.Size = new Size(10, 10);
            PbxBtn4.Size = new Size(10, 10);
            PbxBtnCerto.Size = new Size(10, 10);

            PbxBtn1.BackColor = Color.Transparent;
            PbxBtn2.BackColor = Color.Transparent;
            PbxBtn3.BackColor = Color.Transparent;
            PbxBtn4.BackColor = Color.Transparent;
            PbxBtnCerto.BackColor = Color.Transparent;

            PbxBtn1.Hide();
            PbxBtn2.Hide();
            PbxBtn3.Hide();
            PbxBtn4.Hide();
            PbxBtnCerto.Hide();
            Lbl_de_Ajuda.Hide();

            Lbl_de_Ajuda.Enabled = false;

            foreach (TextBox x in texts)
            {
                x.Location = new Point(-10, -10);
                x.Size = new Size(3, 42);
                x.Hide();
                x.Enabled = false;
                x.Clear();
                x.MaxLength = 27;
            }
            foreach (Label x in labels)
            {
                x.Location = new Point(10, 10);
                x.Size = new Size(10, 10);
                x.Hide();
                x.Enabled = false;
                x.Text = "Clique aqui e responda";
                x.Font = new Font("Snap ITC", 24);
                x.ForeColor = Color.White;
            }

            //Abrir o portão da fase
            if (contVitaminas == 7)
            {
                return 800;
            }

            return 0;
        }

        //ENTRAR PERGUNTA
        public char perguntasEntrada(int fase, int contVitaminas)
        {
            TMR_Tempo.Stop();
            TmrMainGameManager.Stop();

            //Exibir para o player (Placar)
            LblContVitaminas.Text = contVitaminas + "/7";

            //Aleatorizar as perguntas
            Random randNum = new Random();
            randomPergunta = randNum.Next(1, 4);

            //Perguntas fase 1 e verificar se está correta
            if (fase == 1)
            {
                SetarImgPergunta();
            }
            else if (fase == 2)
            {
                SetarImgPergunta();
            }
            else if (fase == 3)
            {
                SetarImgPergunta();
            }

            //FUNÇÃO AUXILIAR DO perguntasEntrada
            void SetarImgPergunta()
            {
                if (contVitaminas == 1)
                {
                    PerguntaLetra = 'a';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 2)
                {
                    PerguntaLetra = 'b';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 3)
                {
                    PerguntaLetra = 'c';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 4)
                {
                    PerguntaLetra = 'd';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 5)
                {
                    PerguntaLetra = 'e';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 6)
                {
                    PerguntaLetra = 'f';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
                else if (contVitaminas == 7)
                {
                    PerguntaLetra = 'g';
                    PnlPerguntas.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\perguntas\\mapa_" + fase + "\\pergunta_" + randomPergunta + PerguntaLetra + ".png");
                }
            }
            return PerguntaLetra;
        }

        //PERGAR O NUMERO QUE FOI GERADO ALEATÓRIO
        public int getRandom()
        {
            return randomPergunta;
        }

        //FECHAR A PERGUNTA
        public int rodarSaidaPerguntas()
        {
            TmrMainGameManager.Start();
            TMR_Tempo.Start();
            return 1000;
        }

        //SETAR AS VITAMINAS
        public void setarVitaminas(int fase, int tamX, int tamY, string img)
        {
            //SETAR TRANSPARENCIA
            PBX_Vitamina1.BackColor = Color.Transparent;
            PBX_Vitamina2.BackColor = Color.Transparent;
            PBX_Vitamina3.BackColor = Color.Transparent;
            PBX_Vitamina4.BackColor = Color.Transparent;
            PBX_Vitamina5.BackColor = Color.Transparent;
            PBX_Vitamina6.BackColor = Color.Transparent;
            PBX_Vitamina7.BackColor = Color.Transparent;

            //SETAR DESENHO
            PBX_Vitamina1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina4.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina5.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina6.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Vitamina7.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);

            //SETAR O TAMANHO
            PBX_Vitamina1.Size = new Size(tamX, tamY);
            PBX_Vitamina2.Size = new Size(tamX, tamY);
            PBX_Vitamina3.Size = new Size(tamX, tamY);
            PBX_Vitamina4.Size = new Size(tamX, tamY);
            PBX_Vitamina5.Size = new Size(tamX, tamY);
            PBX_Vitamina6.Size = new Size(tamX, tamY);
            PBX_Vitamina7.Size = new Size(tamX, tamY);

            //SETAR A POSIÇÃO
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
            if (fase == 3)
            {
                PBX_Vitamina1.Location = new Point(521, 354);
                PBX_Vitamina2.Location = new Point(811, 231);
                PBX_Vitamina3.Location = new Point(229, 561);
                PBX_Vitamina4.Location = new Point(882, 626);
                PBX_Vitamina5.Location = new Point(1097, 561);
                PBX_Vitamina6.Location = new Point(373, 285);
                PBX_Vitamina7.Location = new Point(84, 354);
                PBX_Vitoria.Location = new Point(1169, 675);
            }
        }

        //SETAR AMBIENTE
        public void setAmbiente(int fase, int tamX, int tamY, string img)
        {
            //SETAR TRANSPARENCIA
            PBX_Ambiente1.BackColor = Color.Transparent;
            PBX_Ambiente2.BackColor = Color.Transparent;
            PBX_Ambiente3.BackColor = Color.Transparent;
            PBX_Ambiente4.BackColor = Color.Transparent;
            PBX_Ambiente5.BackColor = Color.Transparent;
            PBX_Ambiente6.BackColor = Color.Transparent;
            PBX_Ambiente7.BackColor = Color.Transparent;

            //SETAR DESENHO
            PBX_Ambiente1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente4.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente5.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente6.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PBX_Ambiente7.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);

            //SETAR O TAMANHO
            PBX_Ambiente1.Size = new Size(tamX, tamY);
            PBX_Ambiente2.Size = new Size(tamX, tamY);
            PBX_Ambiente3.Size = new Size(tamX, tamY);
            PBX_Ambiente4.Size = new Size(tamX, tamY);
            PBX_Ambiente5.Size = new Size(tamX, tamY);
            PBX_Ambiente6.Size = new Size(tamX, tamY);
            PBX_Ambiente7.Size = new Size(tamX, tamY);

            //SETAR POSIÇÃO
            if (fase == 1)
            {
                PBX_Ambiente1.Location = new Point(282, 306);
                PBX_Ambiente2.Location = new Point(502, 272);
                PBX_Ambiente3.Location = new Point(720, 235);
                PBX_Ambiente4.Location = new Point(946, 235);
                PBX_Ambiente5.Location = new Point(367, 487);
                PBX_Ambiente6.Location = new Point(224, 642);
                PBX_Ambiente7.Location = new Point(1092, 503);
            }
            if (fase == 2)
            {
                PBX_Ambiente1.Location = new Point(118, 561);
                PBX_Ambiente2.Location = new Point(189, 201);
                PBX_Ambiente3.Location = new Point(189, 239);
                PBX_Ambiente4.Location = new Point(406, 462);
                PBX_Ambiente5.Location = new Point(714, 487);
                PBX_Ambiente6.Location = new Point(1103, 343);
                PBX_Ambiente7.Location = new Point(788, 594);
            }

            if (fase == 3)
            {
                PBX_Ambiente1.Location = new Point(137, 266);
                PBX_Ambiente2.Location = new Point(0, 0);
                PBX_Ambiente3.Location = new Point(643, 266);
                PBX_Ambiente4.Location = new Point(0, 0);
                PBX_Ambiente5.Location = new Point(1003, 622);
                PBX_Ambiente6.Location = new Point(349, 678);
                PBX_Ambiente7.Location = new Point(137, 419);
            }
        }

        //SETAR OS CRISTAIS
        public void setCrist(int fase, int tamX, int tamY, string img)
        {
            //SETAR TRANSPARENCIA
            PbxCristal1.BackColor = Color.Transparent;
            PbxCristal2.BackColor = Color.Transparent;
            PbxCristal3.BackColor = Color.Transparent;

            //SETAR DESENHO
            PbxCristal1.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PbxCristal2.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);
            PbxCristal3.Image = Image.FromFile(Directory.GetCurrentDirectory() + img);

            //SETAR O TAMANHO
            PbxCristal1.Size = new Size(tamX, tamY);
            PbxCristal2.Size = new Size(tamX, tamY);
            PbxCristal3.Size = new Size(tamX, tamY);

            //SETAR POSIÇÃO
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
            if (fase == 3)
            {
                PbxCristal1.Location = new Point(476, 188);
                PbxCristal2.Location = new Point(669, 288);
                PbxCristal3.Location = new Point(376, 695);
            }
        }

        //ADICIONAR TEMPO A FASE
        public int addTempo(int tempo, int tempSeg)
        {
            tempSeg = tempSeg + tempo;
            if (tempo > 0)
            {
                LBL_Tempo.ForeColor = Color.GreenYellow;
                LBL_Tempo.Text += " +" + tempo;
            }
            else
            {
                LBL_Tempo.ForeColor = Color.IndianRed;
                LBL_Tempo.Text += " " + tempo;
            }
            return tempSeg;
        }

        //ADICIONAR PONTOS
        public int addScorePonto(int pontos, int Score)
        {
            if (Score > 0)
            {
                Score += pontos;
            }
            else if (Score <= 0)
            {
                Score = 0;
            }

            if (pontos > 0)
            {
                LblScore.ForeColor = Color.GreenYellow;
                LblScore.Text += " +" + pontos;
            }
            else
            {
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
            return Score;

        }

        //FUNÇÃO DE ALTERAR IMG DO HELP
        public void helpImg(int mapa, int help)
        {
            if (help == 1 && mapa == 1)
            {
                helpLBL(189, 281);
                LBL_txtHelp.Text = "Você deve pegar todas as vitaminas";
                LBL_txtHelp2.Text = "para passar de fase!";
            }
            else if (help == 2 && mapa == 1)
            {
                helpLBL(189, 265);
                LBL_txtHelp.Text = "Responda corretamente as perguntas";
                LBL_txtHelp2.Text = "e ganhe pontos e tempo!";
            }
            else if (help == 3 && mapa == 1)
            {
                helpLBL(189, 220);
                LBL_txtHelp.Text = "Os cristais te dão bonus incriveis,";
                LBL_txtHelp2.Text = "pegue-os e ganhe mais pontos!";
            }
            else if (help == 4 && mapa == 1)
            {
                helpLBL(135, 200);
                LBL_txtHelp.Text = "Cuidado com seu tempo, não deixe ele acabar,";
                LBL_txtHelp2.Text = "você não vai querer perder tudo!";
            }
            PBX_Help.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\help\\mapa_" + mapa + "\\infoHelp_" + help + ".png");
        }

        //FUNÇÃO QUE ALTERA A POSIÇÃO DA LBL HELP
        public void helpLBL(int posX1, int posX2)
        {
            LBL_txtHelp.Location = new Point(posX1, 348);
            LBL_txtHelp2.Location = new Point(posX2, 378);
        }

        //SETAR O PLACAR
        public void setPlacar(int fase)
        {
            LblScore.Text = "0";

            //Setar o texto da fase
            LblContVitaminas.Text = "0/7";
            LblContCristais.Text = "x";

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
            if (fase == 3)
            {
                //Setar a imagen certa
                PbxContVitaminas.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\cereja_animada.gif");
                PbxContCristais.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\itens\\cristal_animado.gif");
            }

        }

        //VINHETA
        public int vinheta()
        {
            int TAMANHO_X = 1300;
            int TAMANHO_Y = 1000;
            PbxVinheta1.Size = new Size(TAMANHO_X, TAMANHO_Y);
            PbxVinheta1.Location = new Point(0, 0);
            PbxVinheta2.Size = new Size(TAMANHO_X, TAMANHO_Y);
            PbxVinheta2.Location = new Point(TAMANHO_X, 0);
            PbxVinheta2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\Vinheta\\TELA_PRETA.png");
            return 1100;
        }

        //REMOVER PAINEIS DO MENU FASE E REORGANIZAR DENOVO
        public void removePnlsFases_4_5_6()
        {
            panel4.Hide();
            panel4.Enabled = false;
            panel5.Hide();
            panel5.Enabled = false;
            panel6.Hide();
            panel6.Enabled = false;

            panel1.Location = new Point(panel1.Location.X, 280);
            panel2.Location = new Point(panel2.Location.X, 280);
            panel3.Location = new Point(panel3.Location.X, 280);
        }

        #region ANIMAÇÕES

        //ANIMAÇÃO DO PERSONAGEM GANHANDO A FASE
        public int ganharFase(int ControleAnimacao, string escolhaPerson, string objPerson)
        {
            //Olha pro player 
            if (ControleAnimacao == 1)
            {
                sons.setMusicStop();
            }
            if (ControleAnimacao > 0 && ControleAnimacao < 250)
            {
                ControleAnimacao++;
                if (ControleAnimacao == 50 || ControleAnimacao == 100 || ControleAnimacao == 150)
                {
                    ControleAnimacao++;
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_" + animcaoWin + ".png");
                }
                if (ControleAnimacao == 200)
                {
                    animcaoWin = 1;
                }
            }
            //Andar para baixo
            if (ControleAnimacao > 220 && ControleAnimacao < 250 && ControleAnimacao%3 == 0)
            {
                animationSpeed = countAnimation / 4;
                animationPlayer = (animationSpeed % 3) + 1;
                countAnimation += 1;
                PbxPersonagem.Location = new Point(PbxPersonagem.Location.X, PbxPersonagem.Location.Y + andarQtdPx);
                PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_" + animationPlayer + ".png");
            }
            //Dá uns pulo
            if (ControleAnimacao == 250)
                sons.setEfeito("win");
            if (ControleAnimacao > 250 && ControleAnimacao < 520) //700 para colocar todos os 5 pulos;
            {
                ControleAnimacaoAux++;
                if (ControleAnimacao == 252)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_pulo_2.png");
                }
                if ((ControleAnimacao > 250 && ControleAnimacao < 295) || (ControleAnimacao > 340 && ControleAnimacao < 385) || (ControleAnimacao > 430 && ControleAnimacao < 475)/* Tirar alguns pulos || (ControleAnimacao > 520 && ControleAnimacao < 565) || (ControleAnimacao > 610 && ControleAnimacao < 655)*/)
                {
                    if (ControleAnimacao % 2 == 0)
                    {
                        PbxPersonagem.Location = new Point(PbxPersonagem.Location.X, PbxPersonagem.Location.Y - 1);
                    }
                }
                else if ((ControleAnimacao > 295 && ControleAnimacao < 340) || (ControleAnimacao > 385 && ControleAnimacao < 430) || (ControleAnimacao > 475 && ControleAnimacao < 520)/* Tirar alguns pulos || (ControleAnimacao > 565 && ControleAnimacao < 610) || (ControleAnimacao > 655 && ControleAnimacao < 700)*/)
                {
                    if (ControleAnimacao % 2 == 0)
                    {
                        PbxPersonagem.Location = new Point(PbxPersonagem.Location.X, PbxPersonagem.Location.Y + 1);
                    }
                }
                if (ControleAnimacaoAux % 40 == 0)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_pulo_" + animcaoWin + ".png");
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
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_1.png");
                }
                PbxPersonagem.Location = new Point(PbxPersonagem.Location.X + 3, PbxPersonagem.Location.Y);
                if (ControleAnimacao % 5 == 0)
                {
                    animcaoWin = (ControleAnimacao % 2) + 1;
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_" + animcaoWin + ".png");
                }
            }
            //Encerra a animação de saida do mapa
            if (ControleAnimacao == 670)
            {
                PNL_Fases.Enabled = true;
                PNL_Fases.Show();
                LBL_Tempo.Text = "";
                resetAmbiente();
                TmrAnimation.Stop();
                sons.setMusic("menu");
                return 0;
            }
            return ControleAnimacao += 1;
        }

        //ANIMAÇÃO DO PERSONAGEM ENTRANDO NA FASE
        public int entrandoFase(int ControleAnimacao, string escolhaPerson, string objPerson, int fase)
        {
            //Entra no mapa 1
            if (fase == 1)
            {
                if (ControleAnimacao == 701)
                {
                    TmrMainGameManager.Stop();
                    PbxPersonagem.Location = new Point(-104, 136);
                    PbxColision.Location = new Point(59, 169);
                }
                if (ControleAnimacao > 701 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(PbxPersonagem.Location.X + 3, PbxPersonagem.Location.Y);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                    return 0;
                }
            }
            //Entra no mapa 2
            if (fase == 2)
            {
                if (ControleAnimacao == 701)
                {
                    TmrMainGameManager.Stop();
                    PbxColision.Location = new Point(25, 713);
                    PbxPersonagem.Location = new Point(17 - 150, 680);
                }
                if (ControleAnimacao > 701 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(PbxPersonagem.Location.X + 3, PbxPersonagem.Location.Y);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                    return 0;
                }
            }

            //Entra no mapa 3
            if (fase == 3)
            {
                if (ControleAnimacao == 701)
                {
                    TmrMainGameManager.Stop();
                    PbxColision.Location = new Point(41, 709);
                    PbxPersonagem.Location = new Point(30 - 150, 676);
                }
                if (ControleAnimacao > 701 && ControleAnimacao < 752)
                {
                    PbxPersonagem.Location = new Point(PbxPersonagem.Location.X + 3, PbxPersonagem.Location.Y);
                    if (ControleAnimacao % 5 == 0)
                    {
                        animcaoWin = (ControleAnimacao % 2) + 1;
                        PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_" + animcaoWin + ".png");
                    }
                }
                if (ControleAnimacao == 752)
                {
                    PbxPersonagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_1.png");
                    TmrAnimation.Stop();
                    TmrMainGameManager.Start();
                    return 0;
                }
            }
            return ControleAnimacao += 1;
        }

        //ANIMAÇÃO DO PORTÃO ABRINDO
        public int doorOpen(int ControleAnimacao)
        {
            //Animação do portão
            if (ControleAnimacao > 800 && ControleAnimacao < 835)
            {
                PbxCerca.Location = new Point(PbxCerca.Location.X + 1, PbxCerca.Location.Y);
            }
            if (ControleAnimacao == 836)
            {
                TmrAnimation.Stop();
                return 0;
            }
            return ControleAnimacao += 1;
        }

        //ANIMAÇÃO DA PERGUNTA APARECENDO
        public int aparecendoPergunta(int ControleAnimacao)
        {
            if (ControleAnimacao == 901)
            {
                PnlPerguntas.Location = new Point(10, 960);
                PnlPerguntas.Show();
            }
            if (ControleAnimacao > 900 && ControleAnimacao < 968)
            {
                PnlPerguntas.Location = new Point(PnlPerguntas.Location.X, PnlPerguntas.Location.Y - 3);
            }
            if (ControleAnimacao == 970)
            {
                TmrAnimation.Stop();
                return 0;
            }
            return ControleAnimacao += 1;
        }

        //ANIMAÇÃO DA PERGUNTA DESAPARECENDO
        public int aparecendoPergunta(int ControleAnimacao, int contVitaminas)
        {
            if (ControleAnimacao == 1000)
            {
                TmrPergunta.Stop();
            }
            if (ControleAnimacao > 1000 && ControleAnimacao < 1068)
            {
                PnlPerguntas.Location = new Point(PnlPerguntas.Location.X, PnlPerguntas.Location.Y + 3);
            }
            if (ControleAnimacao == 1068)
            {
                PnlPerguntas.Hide();
                if (resetarObjetosPergunta(contVitaminas) == 800)
                    return 800;
                TmrAnimation.Stop();
                return 0;
            }
            return ControleAnimacao += 1;
        }

        //ANIMAÇÃO DA VINHETA
        public int vinheta(int ControleAnimacao)
        {
            if (ControleAnimacao > 1101 && ControleAnimacao < 1202)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
                ControleAnimacao += 2;
            }
            if (ControleAnimacao > 1302 && ControleAnimacao < 1403)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
                ControleAnimacao += 2;
            }
            if (ControleAnimacao == 1404)
            {
                PbxVinheta2.Location = new Point(1300, 0);
                PbxVinheta2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\Vinheta\\Logo_PathMath.png");
            }
            if (ControleAnimacao > 1404 && ControleAnimacao < 1505)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
            }
            if (ControleAnimacao == 1506)
            {
                PbxVinheta1.Hide();
            }

            if (ControleAnimacao > 1606 && ControleAnimacao < 1707)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
            }
            if (ControleAnimacao == 1708)
            {
                PBX_Jogar.Enabled = true;
                PBX_Sair.Enabled = true;
                PBX_Placar.Enabled = true;
                PbxVinheta1.Size = new Size(1, 1);
                PbxVinheta2.Size = new Size(1, 1);
                PbxVinheta2.Hide();
                TmrAnimation.Stop();
                sons.setMusic("menu");
                return 0;
            }
            return ControleAnimacao += 1;
        }

        #endregion

        //RESETAR FASE
        public Tuple<int, int, int, int, int, int, int> resetFaseInts(int fase)
        {
            PbxColision.Location = new Point(0, 0);
            if (fase == 1)
            {
                //Resetar o placar
                setPlacar(fase);

                //Resetar animação do personagem entrando no
                TmrAnimation.Start();

                //Reset Musica
                sons.setMusic("floresta_1");

                //Retornar reset de valores
                return new Tuple<int, int, int, int, int, int, int>(2, 1, 6, 700, 0, 0, -1);
            }
            if (fase == 2)
            {
                //Resetar o placar
                setPlacar(fase);

                //Resetar animação do personagem entrando no
                TmrAnimation.Start();

                //Resetar placar
                LblContVitaminas.Text = "0/7";
                LblContCristais.Text = "x";

                //Resetar Score
                LblScore.Text = "0";

                //Reset Musica
                sons.setMusic("caverna");

                //Retornar reset de valores
                return new Tuple<int, int, int, int, int, int, int>(2, 16, 6, 700, 0, 0, -1);
            }
            if (fase == 3)
            {
                //Resetar o placar
                setPlacar(fase);

                //Resetar animação do personagem entrando no
                TmrAnimation.Start();

                //Resetar placar
                LblContVitaminas.Text = "0/7";
                LblContCristais.Text = "x";

                //Resetar Score
                LblScore.Text = "0";

                //Reset Musica
                sons.setMusic("gelo");

                //Retornar reset de valores
                return new Tuple<int, int, int, int, int, int, int>(2, 16, 6, 700, 0, 0, -1);
            }
            return new Tuple<int, int, int, int, int, int, int>(0, 0, 0, 0, 0, 0, 0);
        }

        //CARREGAR AS PAREDES
        public void loadWalls(int fase)
        {
            if (fase == 1)
            {
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
            }
            if (fase == 2)
            {
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
            }
            if (fase == 3)
            {
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
                pictureBox61.Location = new Point(-11, 688); pictureBox61.Size = new Size(31, 44);
            }
        }
    }

    public class EfeitoBtnMouseCima
    {
        private PictureBox PBX_Jogar, PbxCarregar, PBX_Placar, PBX_Sair, PBX_SimInicio, PBX_NaoInicio, BTN_SimInfo, BTN_NaoInfo, PBX_Continuar, PBX_Inicio, PBX_Reiniciar, PBX_Salvar, PBX_SairPause, PbxCreditos, PbxSalvarMenu,
            PbxSomEnable, PbxSomEnablePause, PbxEfeitoEnable, PbxEfeitoEnablePause;
        private int Width = 220, Height = 120;

        public EfeitoBtnMouseCima(PictureBox PBX_Jogar, PictureBox PbxCarregar, PictureBox PBX_Placar, PictureBox PBX_Sair, PictureBox PBX_SimInicio,
                                  PictureBox PBX_NaoInicio, PictureBox BTN_SimInfo,PictureBox BTN_NaoInfo, PictureBox PBX_Continuar, PictureBox PBX_Inicio,
                                  PictureBox PBX_Reiniciar, PictureBox PBX_Salvar, PictureBox PBX_SairPause, PictureBox PbxCreditos, PictureBox PbxSalvarMenu,
                                  PictureBox PbxSomEnable, PictureBox PbxSomEnablePause, PictureBox PbxEfeitoEnable, PictureBox PbxEfeitoEnablePause)
        {
            this.PBX_Jogar = PBX_Jogar;
            this.PbxCarregar = PbxCarregar;
            this.PBX_Placar = PBX_Placar;
            this.PBX_Sair = PBX_Sair;
            this.PBX_SimInicio = PBX_SimInicio;
            this.PBX_NaoInicio = PBX_NaoInicio;
            this.BTN_SimInfo = BTN_SimInfo;
            this.BTN_NaoInfo = BTN_NaoInfo;
            this.PBX_Continuar = PBX_Continuar;
            this.PBX_Inicio = PBX_Inicio;
            this.PBX_Reiniciar = PBX_Reiniciar;
            this.PBX_Salvar = PBX_Salvar;
            this.PBX_SairPause = PBX_SairPause;
            this.PbxCreditos = PbxCreditos;
            this.PbxSalvarMenu = PbxSalvarMenu;
            this.PbxSomEnable = PbxSomEnable;
            this.PbxSomEnablePause = PbxSomEnablePause;
            this.PbxEfeitoEnable = PbxEfeitoEnable;
            this.PbxEfeitoEnablePause = PbxEfeitoEnablePause;
        }
        public void efeitoBtn(int s, string type) {
            if (s == PBX_Jogar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Jogar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Jogar, Width, Height);
                }
            }
            else if (s == PbxCarregar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxCarregar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxCarregar, Width, Height);
                }
            }
            else if (s == PBX_Placar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Placar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Placar, Width, Height);
                }
            }
            else if (s == PBX_Sair.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Sair, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Sair, Width, Height);
                }
            }
            else if (s == PBX_SimInicio.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_SimInicio, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_SimInicio, Width, Height);
                }
            }
            else if (s == PBX_NaoInicio.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_NaoInicio, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_NaoInicio, Width, Height);
                }
            }
            else if (s == BTN_SimInfo.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.BTN_SimInfo, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.BTN_SimInfo, Width, Height);
                }
            }
            else if (s == BTN_NaoInfo.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.BTN_NaoInfo, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.BTN_NaoInfo, Width, Height);
                }
            }
            else if (s == PBX_Continuar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Continuar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Continuar, Width, Height);
                }
            }
            else if (s == PBX_Inicio.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Inicio, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Inicio, Width, Height);
                }
            }
            else if (s == PBX_Reiniciar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Reiniciar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Reiniciar, Width, Height);
                }
            }
            else if (s == PBX_Salvar.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_Salvar, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_Salvar, Width, Height);
                }
            }
            else if (s == PBX_SairPause.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PBX_SairPause, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PBX_SairPause, Width, Height);
                }
            }
            else if (s == PbxCreditos.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxCreditos, 199, 62, 20, 20, 10, 10);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxCreditos, 199, 62, 20, 20, 10, 10);
                }
            }
            else if (s == PbxSalvarMenu.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxSalvarMenu, Width, Height);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxSalvarMenu, Width, Height);
                }
            }
            else if (s == PbxSomEnable.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxSomEnable, 60, 40, 10, 10, 5, 5);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxSomEnable, 60, 40, 10, 10, 5, 5);
                }
            }
            else if (s == PbxSomEnablePause.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxSomEnablePause, 60, 40, 10, 10, 5, 5);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxSomEnablePause, 60, 40, 10, 10, 5, 5);
                }
            }
            else if (s == PbxEfeitoEnable.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxEfeitoEnable, 60, 40, 10, 10, 5, 5);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxEfeitoEnable, 60, 40, 10, 10, 5, 5);
                }
            }
            else if (s == PbxEfeitoEnablePause.GetHashCode())
            {
                if (type == "Hover")
                {
                    efeitoBtnHover(this.PbxEfeitoEnablePause, 60, 40, 10, 10, 5, 5);
                }
                else if (type == "Leave")
                {
                    efeitoBtnLeave(this.PbxEfeitoEnablePause, 60, 40, 10, 10, 5, 5);
                }
            }
        }
        private void efeitoBtnHover(PictureBox j, int Width, int Height)
        {
            int saveW = j.Size.Width;
            int saveH = j.Size.Height;
            int saveX = j.Location.X;
            int saveY = j.Location.Y;
            j.Size = new Size(j.Size.Width + 30, j.Size.Height + 30);
            j.Location = new Point(j.Location.X - 15, j.Location.Y - 15);
            if (j.Size.Width < Width || j.Size.Height < Height)
            {
                j.Size = new Size(saveW, saveH);
                j.Location = new Point(saveX, saveY);
            }
        }
        private void efeitoBtnLeave(PictureBox j, int Width, int Height)
        {
            int saveW = j.Size.Width;
            int saveH = j.Size.Height;
            int saveX = j.Location.X;
            int saveY = j.Location.Y;
            j.Size = new Size(j.Size.Width - 30, j.Size.Height - 30);
            j.Location = new Point(j.Location.X + 15, j.Location.Y + 15);
            if (j.Size.Width < Width || j.Size.Height < Height)
            {
                j.Size = new Size(saveW, saveH);
                j.Location = new Point(saveX, saveY);
            }
        }
        private void efeitoBtnHover(PictureBox j, int Width, int Height, byte WidthSize, byte HeightSize, byte X, byte Y)
        {
            int saveW = j.Size.Width;
            int saveH = j.Size.Height;
            int saveX = j.Location.X;
            int saveY = j.Location.Y;
            j.Size = new Size(j.Size.Width + WidthSize, j.Size.Height + HeightSize);
            j.Location = new Point(j.Location.X - X, j.Location.Y - Y);
            if (j.Size.Width < Width || j.Size.Height < Height)
            {
                j.Size = new Size(saveW, saveH);
                j.Location = new Point(saveX, saveY);
            }
        }
        private void efeitoBtnLeave(PictureBox j, int Width, int Height, byte WidthSize, byte HeightSize, byte X, byte Y)
        {
            int saveW = j.Size.Width;
            int saveH = j.Size.Height;
            int saveX = j.Location.X;
            int saveY = j.Location.Y;
            j.Size = new Size(j.Size.Width - WidthSize, j.Size.Height - HeightSize);
            j.Location = new Point(j.Location.X + X, j.Location.Y + Y);
            if (j.Size.Width < Width || j.Size.Height < Height)
            {
                j.Size = new Size(saveW, saveH);
                j.Location = new Point(saveX, saveY);
            }
        }
    }

    public class Sons
    {
        private SoundPlayer efeito;
        private AxWindowsMediaPlayer MpSons;
        private PictureBox PbxSomEnable;
        public Sons(AxWindowsMediaPlayer MpSons, PictureBox PbxSomEnable)
        {
            this.MpSons = MpSons;
            this.PbxSomEnable = PbxSomEnable;
            efeito = new SoundPlayer();
        }
        //SETAR A MUSICA
        public void setMusic(string music)
        {
            MpSons.URL = @Directory.GetCurrentDirectory() + "\\Sons\\" + music + ".wav";
            MpSons.Ctlcontrols.play();
        }
        public void setMusicStop()
        {
            MpSons.Ctlcontrols.stop();
        }
        public void setEfeito(string efeitoNome)
        {
            switch (PbxSomEnable.Tag) {
                case "Ativo":
                    efeito.Stop();
                    efeito.SoundLocation = @Directory.GetCurrentDirectory() + "\\Sons\\" + efeitoNome + ".wav";
                    efeito.Play();
                    break;
            }
        }
    }

    public static class FontHandling
    {
        public static bool IsFontInstalled(string fontName)
        {
            using (var testFont = new System.Drawing.Font(fontName, 8))
                return 0 == string.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static void InstallFont(string fontSourcePath)
        {
            var shellAppType = Type.GetTypeFromProgID("Shell.Application");
            var shell = Activator.CreateInstance(shellAppType);
            var fontFolder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { Environment.GetFolderPath(Environment.SpecialFolder.Fonts) });
            if (File.Exists(fontSourcePath))
                fontFolder.CopyHere(fontSourcePath);
        }
    }
}