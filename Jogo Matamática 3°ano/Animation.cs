using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public class Animation
    {
        Panel PNL_Fases;
        PictureBox personagem;
        Timer animacao;
        Label LBL_Tempo;
        int animcaoWin = 1;
        int ControleAnimacao = 0;
        int ControleAnimacaoAux = 0;
        public Animation(PictureBox personagem, Timer animacao, Panel PNL_Fases, Label LBL_Tempo) 
        {
            this.personagem = personagem;
            this.animacao = animacao;
            this.PNL_Fases = PNL_Fases;
            this.LBL_Tempo = LBL_Tempo;
        }

        public bool winFasePlayer(string escolhaPerson, string objPerson, int posXPlayer, int posYPlayer)
        {
            ControleAnimacao++;
            //Olha pro player 
            if (ControleAnimacao > 0 && ControleAnimacao < 250)
            {
                ControleAnimacao++;
                if (ControleAnimacao == 50 || ControleAnimacao == 100 || ControleAnimacao == 150)
                {
                    ControleAnimacao++;
                    personagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_" + animcaoWin + ".png");
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
                    personagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_pulo_2.png");
                }
                if ((ControleAnimacao > 250 && ControleAnimacao < 295) || (ControleAnimacao > 340 && ControleAnimacao < 385) || (ControleAnimacao > 430 && ControleAnimacao < 475)/* Tirar alguns pulos || (ControleAnimacao > 520 && ControleAnimacao < 565) || (ControleAnimacao > 610 && ControleAnimacao < 655)*/)
                {
                    if (ControleAnimacao % 2 == 0)
                    {
                        personagem.Location = new Point(posXPlayer, posYPlayer - 1);
                    }
                }
                else if ((ControleAnimacao > 295 && ControleAnimacao < 340) || (ControleAnimacao > 385 && ControleAnimacao < 430) || (ControleAnimacao > 475 && ControleAnimacao < 520)/* Tirar alguns pulos || (ControleAnimacao > 565 && ControleAnimacao < 610) || (ControleAnimacao > 655 && ControleAnimacao < 700)*/)
                {
                    if (ControleAnimacao % 2 == 0)
                    {
                        personagem.Location = new Point(posXPlayer, posYPlayer + 1);
                    }
                }
                if (ControleAnimacaoAux % 40 == 0)
                {
                    personagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\frente\\frente_pulo_" + animcaoWin + ".png");
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
                    personagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_1.png");
                }
                personagem.Location = new Point(posXPlayer + 3, posYPlayer);
                if (ControleAnimacao % 5 == 0)
                {
                    animcaoWin = (ControleAnimacao % 2) + 1;
                    personagem.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\personagem\\" + escolhaPerson + objPerson + "\\direita\\direita_" + animcaoWin + ".png");
                }
            }
            //Encerra a animação de saida do mapa
            if (ControleAnimacao == 670)
            {
                PNL_Fases.Enabled = true;
                PNL_Fases.Visible = true;
                LBL_Tempo.Text = "";
                animacao.Stop();
                ControleAnimacao = 0;
                return true;
            }
            return false;
        }
    }
}