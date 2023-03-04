﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public class Utilits
    {
        // Variáveis da funções de perguntas
        int randomPergunta;
        char PerguntaLetra;
        // Variáveis da função ganharFase()
        public int ControleAnimacaoAux, animcaoWin = 1, andarQtdPx = 3;
        public int animationSpeed;
        public int animationPlayer;
        public int countAnimation;


        #region Recebendo todas as classes estanciadas do design
        Panel PnlMenu;
        Label label1;
        Timer TmrMainGameManager;
        Label labelX;
        Label labelY;
        Label LblX;
        Label LblY;
        PictureBox PbxPersonagem;
        PictureBox PBX_Sair;
        PictureBox PBX_Opcoes;
        PictureBox PBX_Jogar;
        Panel PNL_Fases;
        Panel panel4;
        PictureBox PBX_Fase6;
        Panel panel3;
        PictureBox PBX_Fase3;
        Panel panel5;
        PictureBox PBX_Fase5;
        Panel panel6;
        PictureBox PBX_Fase4;
        Panel panel2;
        PictureBox PBX_Fase2;
        Panel panel1;
        PictureBox PBX_Fase1;
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
        Timer TmrColisao;
        Panel PNL_Pause;
        PictureBox PBX_SairPause;
        PictureBox PBX_Inicio;
        PictureBox PBX_Continuar;
        Panel panel7;
        Panel PNL_InfoPause;
        Panel PNL_Info;
        PictureBox BTN_NaoInfo;
        PictureBox BTN_SimInfo;
        PictureBox PBX_Info;
        Panel PNL_SairInicio;
        PictureBox pictureBox55;
        PictureBox PBX_NaoInicio;
        PictureBox PBX_SimInicio;
        Timer TMR_Tempo;
        Label LBL_Tempo;
        PictureBox pictureBox56;
        Panel PNL_SemTempo;
        PictureBox BTN_NaoTempo;
        PictureBox BTN_SimTempo;
        Label label3;
        Label LBL_SemTempo;
        Timer TMR_SemTempo;
        Panel PNL_SemTempo2;
        Label label5;
        PictureBox BTN_NaoTempo2;
        PictureBox BTN_SimTempo2;
        Label label2;
        Label LBL_SemTempo2;
        PictureBox PBX_Reiniciar;
        Label LblBust;
        Timer TmrAnimation;
        PictureBox PBX_Ambiente1;
        PictureBox PBX_Ambiente2;
        PictureBox PBX_Ambiente3;
        PictureBox PBX_Ambiente4;
        PictureBox PBX_Ambiente5;
        PictureBox PBX_Ambiente6;
        PictureBox PBX_Ambiente7;
        Timer TMR_PulaPula;
        PictureBox PBX_Vitamina1;
        PictureBox PBX_Vitamina2;
        PictureBox PBX_Vitamina3;
        PictureBox PBX_Vitamina4;
        PictureBox PBX_Vitamina5;
        PictureBox PBX_Vitamina6;
        PictureBox PBX_Vitamina7;
        PictureBox PbxCerca;
        Panel PnlPerguntas;
        TextBox TxtResposta;
        Label LblResposta;
        PictureBox PbxBtnCerto;
        PictureBox PbxBtn2;
        PictureBox PbxBtn4;
        PictureBox PbxBtn3;
        PictureBox PbxBtn1;
        ProgressBar PrbTempPerg;
        Label Lbl_de_Ajuda;
        Timer TmrPergunta;
        Label LblResposta2;
        TextBox TxtResposta2;
        Label LblResposta3;
        TextBox TxtResposta3;
        Label LblWallStatus;
        PictureBox PbxCristal1;
        PictureBox PbxCristal2;
        PictureBox PbxCristal3;
        PictureBox PbxContVitaminas;
        PictureBox PbxContCristais;
        Label LblContVitaminas;
        Label LblContCristais;
        Label LblScore;
        Panel PNL_MostrarFases;
        PictureBox PBX_Escolha2;
        Label LBL_Person;
        PictureBox PBX_Escolha1;
        PictureBox PBX_VoltarFase;
        Panel PNL_InfoFase;
        PictureBox pictureBox54;
        Panel PNL_Help;
        PictureBox PBX_Help;
        PictureBox PBX_bntVaiHelp;
        PictureBox PBX_btnVoltaHelp;
        Label LBL_txtHelp;
        Label LBL_HelpSair;
        Label LBL_txtHelp2;
        PictureBox pictureBox57;
        PictureBox PBX_VitaAtual;
        Label LBL_VitaTotal;
        Label LBL_CrisTotal;
        Label LBL_ScoreTotal;
        PictureBox pictureBox59;
        Label LBL_Nome2;
        Label LBL_Nome1;
        PictureBox pictureBox58;
        PictureBox pictureBox60;
        PictureBox PBX_AmbVilao;
        PictureBox PBX_Vitoria;
        Label LblResposta4;
        TextBox TxtResposta4;
        PictureBox PbxVinheta1;
        PictureBox PbxVinheta2;
        PictureBox PBX_Salvar;
        SoundPlayer SomTema;
        public Utilits
            (
            Panel PnlMenu,
            Label label1,
            Timer TmrMainGameManager,
            Label labelX,
            Label labelY,
            Label LblX,
            Label LblY,
            PictureBox PbxPersonagem,
            PictureBox PBX_Sair,
            PictureBox PBX_Opcoes,
            PictureBox PBX_Jogar,
            Panel PNL_Fases,
            Panel panel4,
            PictureBox PBX_Fase6,
            Panel panel3,
            PictureBox PBX_Fase3,
            Panel panel5,
            PictureBox PBX_Fase5,
            Panel panel6,
            PictureBox PBX_Fase4,
            Panel panel2,
            PictureBox PBX_Fase2,
            Panel panel1,
            PictureBox PBX_Fase1,
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
            Timer TmrColisao,
            Panel PNL_Pause,
            PictureBox PBX_SairPause,
            PictureBox PBX_Inicio,
            PictureBox PBX_Continuar,
            Panel panel7,
            Panel PNL_InfoPause,
            Panel PNL_Info,
            PictureBox BTN_NaoInfo,
            PictureBox BTN_SimInfo,
            PictureBox PBX_Info,
            Panel PNL_SairInicio,
            PictureBox pictureBox55,
            PictureBox PBX_NaoInicio,
            PictureBox PBX_SimInicio,
            Timer TMR_Tempo,
            Label LBL_Tempo,
            PictureBox pictureBox56,
            Panel PNL_SemTempo,
            PictureBox BTN_NaoTempo,
            PictureBox BTN_SimTempo,
            Label label3,
            Label LBL_SemTempo,
            Timer TMR_SemTempo,
            Panel PNL_SemTempo2,
            Label label5,
            PictureBox BTN_NaoTempo2,
            PictureBox BTN_SimTempo2,
            Label label2,
            Label LBL_SemTempo2,
            PictureBox PBX_Reiniciar,
            Label LblBust,
            Timer TmrAnimation,
            PictureBox PBX_Ambiente1,
            PictureBox PBX_Ambiente2,
            PictureBox PBX_Ambiente3,
            PictureBox PBX_Ambiente4,
            PictureBox PBX_Ambiente5,
            PictureBox PBX_Ambiente6,
            PictureBox PBX_Ambiente7,
            Timer TMR_PulaPula,
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
            ProgressBar PrbTempPerg,
            Label Lbl_de_Ajuda,
            Timer TmrPergunta,
            Label LblResposta2,
            TextBox TxtResposta2,
            Label LblResposta3,
            TextBox TxtResposta3,
            Label LblWallStatus,
            PictureBox PbxCristal1,
            PictureBox PbxCristal2,
            PictureBox PbxCristal3,
            PictureBox PbxContVitaminas,
            PictureBox PbxContCristais,
            Label LblContVitaminas,
            Label LblContCristais,
            Label LblScore,
            Panel PNL_MostrarFases,
            PictureBox PBX_Escolha2,
            Label LBL_Person,
            PictureBox PBX_Escolha1,
            PictureBox PBX_VoltarFase,
            Panel PNL_InfoFase,
            PictureBox pictureBox54,
            Panel PNL_Help,
            PictureBox PBX_Help,
            PictureBox PBX_bntVaiHelp,
            PictureBox PBX_btnVoltaHelp,
            Label LBL_txtHelp,
            Label LBL_HelpSair,
            Label LBL_txtHelp2,
            PictureBox pictureBox57,
            PictureBox PBX_VitaAtual,
            Label LBL_VitaTotal,
            Label LBL_CrisTotal,
            Label LBL_ScoreTotal,
            PictureBox pictureBox59,
            Label LBL_Nome2,
            Label LBL_Nome1,
            PictureBox pictureBox58,
            PictureBox pictureBox60,
            PictureBox PBX_AmbVilao,
            PictureBox PBX_Vitoria,
            Label LblResposta4,
            TextBox TxtResposta4,
            PictureBox PbxVinheta1,
            PictureBox PbxVinheta2,
            PictureBox PBX_Salvar,
            SoundPlayer SomTema
            )
        {
            this.PnlMenu = PnlMenu;
            this.label1 = label1;
            this.TmrMainGameManager = TmrMainGameManager;
            this.labelX = labelX;
            this.labelY = labelY;
            this.LblX = LblX;
            this.LblY = LblY;
            this.PbxPersonagem = PbxPersonagem;
            this.PBX_Sair = PBX_Sair;
            this.PBX_Opcoes = PBX_Opcoes;
            this.PBX_Jogar = PBX_Jogar;
            this.PNL_Fases = PNL_Fases;
            this.panel4 = panel4;
            this.PBX_Fase6 = PBX_Fase6;
            this.panel3 = panel3;
            this.PBX_Fase3 = PBX_Fase3;
            this.panel5 = panel5;
            this.PBX_Fase5 = PBX_Fase5;
            this.panel6 = panel6;
            this.PBX_Fase4 = PBX_Fase4;
            this.panel2 = panel2;
            this.PBX_Fase2 = PBX_Fase2;
            this.panel1 = panel1;
            this.PBX_Fase1 = PBX_Fase1;
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
            this.TmrColisao = TmrColisao;
            this.PNL_Pause = PNL_Pause;
            this.PBX_SairPause = PBX_SairPause;
            this.PBX_Inicio = PBX_Inicio;
            this.PBX_Continuar = PBX_Continuar;
            this.panel7 = panel7;
            this.PNL_InfoPause = PNL_InfoPause;
            this.PNL_Info = PNL_Info;
            this.BTN_NaoInfo = BTN_NaoInfo;
            this.BTN_SimInfo = BTN_SimInfo;
            this.PBX_Info = PBX_Info;
            this.PNL_SairInicio = PNL_SairInicio;
            this.pictureBox55 = pictureBox55;
            this.PBX_NaoInicio = PBX_NaoInicio;
            this.PBX_SimInicio = PBX_SimInicio;
            this.TMR_Tempo = TMR_Tempo;
            this.LBL_Tempo = LBL_Tempo;
            this.pictureBox56 = pictureBox56;
            this.PNL_SemTempo = PNL_SemTempo;
            this.BTN_NaoTempo = BTN_NaoTempo;
            this.BTN_SimTempo = BTN_SimTempo;
            this.label3 = label3;
            this.LBL_SemTempo = LBL_SemTempo;
            this.TMR_SemTempo = TMR_SemTempo;
            this.PNL_SemTempo2 = PNL_SemTempo2;
            this.label5 = label5;
            this.BTN_NaoTempo2 = BTN_NaoTempo2;
            this.BTN_SimTempo2 = BTN_SimTempo2;
            this.label2 = label2;
            this.LBL_SemTempo2 = LBL_SemTempo2;
            this.PBX_Reiniciar = PBX_Reiniciar;
            this.LblBust = LblBust;
            this.TmrAnimation = TmrAnimation;
            this.PBX_Ambiente1 = PBX_Ambiente1;
            this.PBX_Ambiente2 = PBX_Ambiente2;
            this.PBX_Ambiente3 = PBX_Ambiente3;
            this.PBX_Ambiente4 = PBX_Ambiente4;
            this.PBX_Ambiente5 = PBX_Ambiente5;
            this.PBX_Ambiente6 = PBX_Ambiente6;
            this.PBX_Ambiente7 = PBX_Ambiente7;
            this.TMR_PulaPula = TMR_PulaPula;
            this.PBX_Vitamina1 = PBX_Vitamina1;
            this.PBX_Vitamina2 = PBX_Vitamina2;
            this.PBX_Vitamina3 = PBX_Vitamina3;
            this.PBX_Vitamina4 = PBX_Vitamina4;
            this.PBX_Vitamina5 = PBX_Vitamina5;
            this.PBX_Vitamina6 = PBX_Vitamina6;
            this.PBX_Vitamina7 = PBX_Vitamina7;
            this.PbxCerca = PbxCerca;
            this.PnlPerguntas = PnlPerguntas;
            this.TxtResposta = TxtResposta;
            this.LblResposta = LblResposta;
            this.PbxBtnCerto = PbxBtnCerto;
            this.PbxBtn2 = PbxBtn2;
            this.PbxBtn4 = PbxBtn4;
            this.PbxBtn3 = PbxBtn3;
            this.PbxBtn1 = PbxBtn1;
            this.PrbTempPerg = PrbTempPerg;
            this.Lbl_de_Ajuda = Lbl_de_Ajuda;
            this.TmrPergunta = TmrPergunta;
            this.LblResposta2 = LblResposta2;
            this.TxtResposta2 = TxtResposta2;
            this.LblResposta3 = LblResposta3;
            this.TxtResposta3 = TxtResposta3;
            this.LblWallStatus = LblWallStatus;
            this.PbxCristal1 = PbxCristal1;
            this.PbxCristal2 = PbxCristal2;
            this.PbxCristal3 = PbxCristal3;
            this.PbxContVitaminas = PbxContVitaminas;
            this.PbxContCristais = PbxContCristais;
            this.LblContVitaminas = LblContVitaminas;
            this.LblContCristais = LblContCristais;
            this.LblScore = LblScore;
            this.PNL_MostrarFases = PNL_MostrarFases;
            this.PBX_Escolha2 = PBX_Escolha2;
            this.LBL_Person = LBL_Person;
            this.PBX_Escolha1 = PBX_Escolha1;
            this.PBX_VoltarFase = PBX_VoltarFase;
            this.PNL_InfoFase = PNL_InfoFase;
            this.pictureBox54 = pictureBox54;
            this.PNL_Help = PNL_Help;
            this.PBX_Help = PBX_Help;
            this.PBX_bntVaiHelp = PBX_bntVaiHelp;
            this.PBX_btnVoltaHelp = PBX_btnVoltaHelp;
            this.LBL_txtHelp = LBL_txtHelp;
            this.LBL_HelpSair = LBL_HelpSair;
            this.LBL_txtHelp2 = LBL_txtHelp2;
            this.pictureBox57 = pictureBox57;
            this.PBX_VitaAtual = PBX_VitaAtual;
            this.LBL_VitaTotal = LBL_VitaTotal;
            this.LBL_CrisTotal = LBL_CrisTotal;
            this.LBL_ScoreTotal = LBL_ScoreTotal;
            this.pictureBox59 = pictureBox59;
            this.LBL_Nome2 = LBL_Nome2;
            this.LBL_Nome1 = LBL_Nome1;
            this.pictureBox58 = pictureBox58;
            this.pictureBox60 = pictureBox60;
            this.PBX_AmbVilao = PBX_AmbVilao;
            this.PBX_Vitoria = PBX_Vitoria;
            this.LblResposta4 = LblResposta4;
            this.TxtResposta4 = TxtResposta4;
            this.PbxVinheta1 = PbxVinheta1;
            this.PbxVinheta2 = PbxVinheta2;
            this.PBX_Salvar = PBX_Salvar;
            this.SomTema = SomTema;
        }
        #endregion

        //RESETAR AMBIENTE TORNÁ-LO INVISÍVEL
        public void resetAmbiente()
        {
            PBX_Ambiente1.Visible = false;
            PBX_Ambiente2.Visible = false;
            PBX_Ambiente3.Visible = false;
            PBX_Ambiente4.Visible = false;
            PBX_Ambiente5.Visible = false;
            PBX_Ambiente6.Visible = false;
            PBX_Ambiente7.Visible = false;
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
        public bool setarBtnPergunta(int fase)
        {
            int SizeX = 109,
                SizeY = 56;

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

            PbxBtn1.Size = new Size(SizeX, SizeY);
            PbxBtn2.Size = new Size(SizeX, SizeY);
            PbxBtn3.Size = new Size(SizeX, SizeY);
            PbxBtn4.Size = new Size(SizeX, SizeY);
            PbxBtnCerto.Size = new Size(SizeX, SizeY);

            if (fase == 1)
            {
                if (randomPergunta == 1 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

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
                    PbxBtn4.Visible = false;

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

                    PbxBtn2.Visible = false;
                    PbxBtn3.Visible = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Size = new Size(SizeX, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX, SizeY);

                    PbxBtn1.Location = new Point(823, 56);
                    PbxBtnCerto.Location = new Point(1023, 56);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'e')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(766, 98);
                    PbxBtn2.Location = new Point(620, 98);
                    PbxBtn3.Location = new Point(335, 98);
                    PbxBtnCerto.Location = new Point(479, 98);
                }
                if (randomPergunta == 1 && PerguntaLetra == 'f')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

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
                    PbxBtn4.Visible = false;

                    PbxBtn1.Size = new Size(SizeX, SizeY);
                    PbxBtn2.Size = new Size(SizeX, SizeY);
                    PbxBtn3.Size = new Size(SizeX + 9, SizeY);
                    PbxBtnCerto.Size = new Size(SizeX + 54, SizeY);

                    PbxBtn1.Location = new Point(1053, 78);
                    PbxBtn2.Location = new Point(208, 117);
                    PbxBtn3.Location = new Point(813, 78);
                    PbxBtnCerto.Location = new Point(689, 78);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'a')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(90, 105);
                    PbxBtn2.Location = new Point(385, 105);
                    PbxBtn3.Location = new Point(240, 105);
                    PbxBtnCerto.Location = new Point(532, 105);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    return setarTxtPergunta(fase);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    return setarTxtPergunta(fase);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'd')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(335, 106);
                    PbxBtn2.Location = new Point(621, 106);
                    PbxBtn3.Location = new Point(766, 106);
                    PbxBtnCerto.Location = new Point(479, 106);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    return setarTxtPergunta(fase);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    return setarTxtPergunta(fase);
                }
                if (randomPergunta == 2 && PerguntaLetra == 'g')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(277, 108);
                    PbxBtn2.Location = new Point(560, 108);
                    PbxBtn3.Location = new Point(129, 108);
                    PbxBtnCerto.Location = new Point(416, 108);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'a')
                {
                    PbxBtn1.Location = new Point(904, 26);
                    PbxBtn2.Location = new Point(1050, 111);
                    PbxBtn3.Location = new Point(904, 111);
                    PbxBtn4.Location = new Point(764, 111);
                    PbxBtnCerto.Location = new Point(1050, 26);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'b')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(916, 23);
                    PbxBtn2.Location = new Point(1062, 108);
                    PbxBtn3.Location = new Point(1062, 23);
                    PbxBtnCerto.Location = new Point(916, 108);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'c')
                {
                    PbxBtn1.Location = new Point(916, 23);
                    PbxBtn2.Location = new Point(1062, 108);
                    PbxBtn3.Location = new Point(1062, 23);
                    PbxBtn4.Location = new Point(776, 109);
                    PbxBtnCerto.Location = new Point(916, 108);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    return setarTxtPergunta(fase);
                }
                if (randomPergunta == 3 && PerguntaLetra == 'e')
                {
                    PbxBtn4.Enabled = false;
                    PbxBtn4.Visible = false;

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
                    PbxBtn4.Visible = false;

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
                    PbxBtn4.Visible = false;

                    PbxBtn1.Location = new Point(651, 87);
                    PbxBtn2.Location = new Point(794, 86);
                    PbxBtn3.Location = new Point(510, 86);
                    PbxBtnCerto.Location = new Point(364, 86);
                }
            }
            else if (fase == 2)
            {

            }
            else if (fase == 3)
            {

            }
            return false;
        }

        //SETAR O LAYOUT DOS TEXTOS DE ACORDO COM A PERGUNTA
        public bool setarTxtPergunta(int fase)
        {
            if (fase == 1)
            {
                if (randomPergunta == 2 && PerguntaLetra == 'b')
                {
                    Lbl_de_Ajuda.Location = new Point(529, 27);
                    LblResposta.Location = new Point(375, 75);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(507, 75);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(640, 75);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    Lbl_de_Ajuda.Size = new Size(192, 44);
                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);
                    LblResposta2.Font = new Font("Snap ITC", 12);
                    LblResposta3.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";
                    LblResposta2.Text = "Clique aqui";
                    LblResposta3.Text = "Clique aqui";

                    Lbl_de_Ajuda.Visible = true;
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

                    return true;
                }
                if (randomPergunta == 2 && PerguntaLetra == 'c')
                {
                    LblResposta.Location = new Point(314, 53);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(700, 51);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(1086, 54);
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

                    return true;
                }
                if (randomPergunta == 2 && PerguntaLetra == 'e')
                {
                    LblResposta.Location = new Point(519, 33);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    LblResposta.Enabled = true;

                    TxtResposta.MaxLength = 2;

                    return true;
                }
                if (randomPergunta == 2 && PerguntaLetra == 'f')
                {
                    LblResposta.Location = new Point(382, 85);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta2.Location = new Point(531, 85);
                    TxtResposta2.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta3.Location = new Point(684, 85);
                    TxtResposta3.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);
                    LblResposta4.Location = new Point(829, 86);
                    TxtResposta4.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);
                    LblResposta2.Size = new Size(75, 46);
                    LblResposta3.Size = new Size(75, 46);
                    LblResposta4.Size = new Size(75 + 3, 46);

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

                    TxtResposta.MaxLength = 2;
                    TxtResposta2.MaxLength = 3;
                    TxtResposta3.MaxLength = 2;
                    TxtResposta4.MaxLength = 3;

                    return true;
                }
                if (randomPergunta == 3 && PerguntaLetra == 'd')
                {
                    LblResposta.Location = new Point(1055, 98);
                    TxtResposta.Location = new Point(LblResposta.Location.X + 3, LblResposta.Location.Y);

                    LblResposta.Size = new Size(75, 46);

                    LblResposta.Font = new Font("Snap ITC", 12);

                    LblResposta.Text = "Clique aqui";

                    LblResposta.Visible = true;
                    TxtResposta.Visible = true;

                    LblResposta.Enabled = true;

                    TxtResposta.MaxLength = 2;

                    return true;
                }
            }
            else if (fase == 2)
            {

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
            return false;
        }

        //RESETAR O LAYOUT DAS PERGUNTAS
        public int resetarObjetosPergunta(int contVitaminas)
        {
            //Abrir o portão da fase
            if (contVitaminas == 7)
            {
                return 800;
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

            return 1070;
        }

        //ENTRAR PERGUNTA
        public char perguntasEntrada(int fase, int contVitaminas, int contVitaTotal)
        {
            TMR_Tempo.Stop();
            TmrMainGameManager.Stop();

            //Exibir para o player (Placar)
            LblContVitaminas.Text = contVitaminas + "/7";
            LBL_VitaTotal.Text = contVitaTotal + "/48";

            //Aleatorizar as perguntas
            Random randNum = new Random();
            randomPergunta = randNum.Next(1, 4);
            randomPergunta = 2; // IRÁ SER REMOVIDO

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
            else if (fase == 4)
            {
                SetarImgPergunta();
            }
            else if (fase == 5)
            {
                SetarImgPergunta();
            }
            else if (fase == 6)
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

            if (fase == 5)
            {

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

            if (fase == 5)
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
            if (fase == 5)
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
                Score = Score + pontos;
            }
            else if (Score <= 0)
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
            return Score;

        }

        //FUNÇÃO QUE DEFINE A POSIÇÃO DA LBL SCORE
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

        //VINHETA
        public int vinheta()
        {
            int TAMANHO_X = 1300;
            int TAMANHO_Y = 1000;
            PbxVinheta1.Size = new Size(TAMANHO_X, TAMANHO_Y);
            PbxVinheta1.Location = new Point(0, 0);
            PbxVinheta2.Size = new Size(TAMANHO_X, TAMANHO_Y);
            PbxVinheta2.Location = new Point(TAMANHO_X, 0);
            PbxVinheta2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\Vinheta\\Logo_UNISANTA.png");
            return 1708;
        }

        //SETAR A MUSICA
        public void setMusic(string music)
        {
            SomTema.Stop();
            SomTema.SoundLocation = @Directory.GetCurrentDirectory() + "\\Sons\\" + music + ".wav";
            SomTema.PlayLooping();
        }
        public void setMusic(string music, string noLoop)
        {
            SomTema.Stop();
            SomTema.SoundLocation = @Directory.GetCurrentDirectory() + "\\Sons\\" + music + ".wav";
            SomTema.Play();
        }
        public void setMusicStop(SoundPlayer SomTema)
        {
            SomTema.Stop();
        }

        //REMOVER PAINEIS DO MENU FASE E REORGANIZAR DENOVO
        public void removePnlsFases_4_5_6()
        {
            panel4.Visible = false;
            panel4.Enabled = false;
            panel5.Visible = false;
            panel5.Enabled = false;
            panel6.Visible = false;
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
                setMusic("win", "Sem loop");
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
                PNL_Fases.Visible = true;
                LBL_Tempo.Text = "";
                resetAmbiente();
                TmrAnimation.Stop();
                setMusic("menu");
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
                    PbxPersonagem.Location = new Point(-104, 136);
                    PbxColision.Location = new Point(59, 169);
                    TmrMainGameManager.Stop();
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
                    PbxColision.Location = new Point(25, 713);
                    PbxPersonagem.Location = new Point(17 - 150, 680);
                    TmrMainGameManager.Stop();
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
                    PbxColision.Location = new Point(36, 717);
                    PbxPersonagem.Location = new Point(25 - 150, 684);
                    TmrMainGameManager.Stop();
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

            //Entra no mapa 5
            if (fase == 5)
            {
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
                PnlPerguntas.Visible = true;
            }
            if (ControleAnimacao > 900 && ControleAnimacao < 968)
            {
                PnlPerguntas.Location = new Point(PnlPerguntas.Location.X, PnlPerguntas.Location.Y - 3);
            }
            if (ControleAnimacao == 970)
            {
                //Esse método irá retornar se as strings só podem conter números
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
                PnlPerguntas.Visible = false;
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
            }
            if (ControleAnimacao > 1302 && ControleAnimacao < 1403)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
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
                PbxVinheta1.Visible = false;
            }

            if (ControleAnimacao > 1606 && ControleAnimacao < 1707)
            {
                PbxVinheta2.Location = new Point(PbxVinheta2.Location.X - 13, 0);
            }
            if (ControleAnimacao == 1708)
            {
                PBX_Jogar.Enabled = true;
                PBX_Sair.Enabled = true;
                PBX_Opcoes.Enabled = true;
                PbxVinheta1.Size = new Size(1, 1);
                PbxVinheta2.Size = new Size(1, 1);
                PbxVinheta2.Visible = false;
                TmrAnimation.Stop();
                return 0;
            }
            return ControleAnimacao += 1;
        }

        #endregion

        public Tuple<int, int, int, int, int, int, int> resetFaseInts(int fase)
        {
            if (fase == 1)
                return new Tuple<int, int, int, int, int, int, int>(1, 0, 6, 700, 0, 0, 0);
            if (fase == 2)
                return new Tuple<int, int, int, int, int, int, int>(1, 15, 6, 700, 0, 0, 0);
            if (fase == 3)
                return new Tuple<int, int, int, int, int, int, int>(1, 15, 6, 700, 0, 0, 0);
            return new Tuple<int, int, int, int, int, int, int>(0, 0, 0, 0, 0, 0, 0);
        }

























    }
}