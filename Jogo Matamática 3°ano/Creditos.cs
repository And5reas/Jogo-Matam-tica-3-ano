using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmCreditos : Form
    {
        public static Point point;

        public FrmCreditos()
        {
            InitializeComponent();
            Console.WriteLine();
            this.Location = point;
            PbxCretitos.Location = new Point(0, 500);
            BackColor = Color.FromArgb(76, 57, 42);
            TmrRolar.Start();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TmrRolar_Tick(object sender, EventArgs e)
        {
            if (PbxCretitos.Location.Y == -3290)
            {
                Thread.Sleep(3000);
                Close();
            }
            if (PbxCretitos.Location.Y == 500)
            {
                Thread.Sleep(1500);
            }
            PbxCretitos.Location = new Point(0, PbxCretitos.Location.Y - 5);
        }

        private void FrmCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 || e.KeyChar.ToString().ToLower() == "q")
            {
                Close();
            }
        }

        private void PbxCretitos_MouseDown(object sender, MouseEventArgs e)
        {
            TmrRolar.Stop();
        }

        private void PbxCretitos_MouseUp(object sender, MouseEventArgs e)
        {
            TmrRolar.Start();
        }
    }
}
