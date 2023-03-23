using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_Matamática_3_ano
{
    public partial class FrmCreditos : Form
    {
        public FrmCreditos()
        {
            InitializeComponent();
            LblAndreas.Text = "Programação\nDesign de jogo\nModelagem\nDesign de nível\nDesign de interface de usuário\nAnimação\nGestão de projeto";
            LblPhilip.Text = "Programação\nDesign de jogo\nArte de conceito\nPintura\nModelagem\nDesign de interface de usuário\nAnimação";
            LblKaio.Text = "Design de som\nMúsicas";
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
