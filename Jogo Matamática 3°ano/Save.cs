using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public class Save
    {
        FrmJogo jogo;
        public Save()
        {
        }

        public void Load()
        {
            string loadSave = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Save.txt");
            if (loadSave == "2")
            {
                jogo.PBX_Fase2.Enabled = true;
                jogo.PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
            }
            else if (loadSave == "3")
            {
                jogo.PBX_Fase2.Enabled = true;
                jogo.PBX_Fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                jogo.PBX_Fase3.Enabled = true;
                jogo.PBX_Fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_3.png");
            }
        }
        public void save(int fase)
        {
            for (int i = 0; i < 2; i++)
            {
                string filePath = Directory.GetCurrentDirectory() + "\\Save.txt";
                string Save = File.ReadAllText(filePath);
                Save.Replace(Save, fase.ToString());
                File.WriteAllText(filePath, fase.ToString());
            }
        }
    }
}
