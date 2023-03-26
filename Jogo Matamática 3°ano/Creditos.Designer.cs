namespace Jogo_Matamática_3_ano
{
    partial class FrmCreditos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreditos));
            this.PbxCretitos = new System.Windows.Forms.PictureBox();
            this.TmrRolar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbxCretitos)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxCretitos
            // 
            this.PbxCretitos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxCretitos.BackgroundImage")));
            this.PbxCretitos.Location = new System.Drawing.Point(-27, 500);
            this.PbxCretitos.Name = "PbxCretitos";
            this.PbxCretitos.Size = new System.Drawing.Size(1354, 3646);
            this.PbxCretitos.TabIndex = 0;
            this.PbxCretitos.TabStop = false;
            this.PbxCretitos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbxCretitos_MouseDown);
            this.PbxCretitos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbxCretitos_MouseUp);
            // 
            // TmrRolar
            // 
            this.TmrRolar.Interval = 1;
            this.TmrRolar.Tick += new System.EventHandler(this.TmrRolar_Tick);
            // 
            // FrmCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(1300, 1000);
            this.Controls.Add(this.PbxCretitos);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreditos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Créditos";
            this.TransparencyKey = System.Drawing.Color.GreenYellow;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCreditos_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PbxCretitos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxCretitos;
        private System.Windows.Forms.Timer TmrRolar;
    }
}