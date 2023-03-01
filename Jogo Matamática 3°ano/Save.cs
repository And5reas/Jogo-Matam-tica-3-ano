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
        PictureBox fase2;
        PictureBox fase3;

        public Save(PictureBox fase2, PictureBox fase3)
        {
            this.fase2 = fase2;
            this.fase3 = fase3;
        }

        public void Load()
        {
            string loadSave = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Save.txt");
            if (loadSave == "2")
            {
                fase2.Enabled = true;
                fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
            }
            else if (loadSave == "3")
            {
                fase2.Enabled = true;
                fase2.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_2.png");
                fase3.Enabled = true;
                fase3.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\img\\labirinto\\exemplos\\mapa_3.png");
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
