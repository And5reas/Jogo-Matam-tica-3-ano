using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmCreditos : Form
    {
        public static Point point;
        private int i = 0;

        public FrmCreditos()
        {
            InitializeComponent();
            Console.WriteLine();
            this.Location = point;
            PbxCretitos.Location = new Point(-27, 500);
            BackColor = Color.FromArgb(76, 57, 42);
            TmrRolar.Start();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TmrRolar_Tick(object sender, EventArgs e)
        {
            if (PbxCretitos.Location.Y == -2645)
            {
                Thread.Sleep(2000);
                Close();
            }
            i -= 5;
            PbxCretitos.Location = new Point(-27, i);
        }

        private void FrmCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 || e.KeyChar.ToString().ToLower() == "q")
            {
                Close();
            }
        }
    }
}
