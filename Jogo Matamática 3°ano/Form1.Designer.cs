namespace Jogo_Matamática_3_ano
{
    partial class FrmJogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJogo));
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.PBX_Sair = new System.Windows.Forms.PictureBox();
            this.PBX_Opcoes = new System.Windows.Forms.PictureBox();
            this.PBX_Jogar = new System.Windows.Forms.PictureBox();
            this.TmrAndar = new System.Windows.Forms.Timer(this.components);
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblY = new System.Windows.Forms.Label();
            this.PbxPersonagem = new System.Windows.Forms.PictureBox();
            this.PNL_Fases = new System.Windows.Forms.Panel();
            this.PBX_Fase1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PBX_Fase2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PBX_Fase3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PBX_Fase6 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PBX_Fase5 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.PBX_Fase4 = new System.Windows.Forms.PictureBox();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Sair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Opcoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Jogar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).BeginInit();
            this.PNL_Fases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase6)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase5)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase4)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMenu
            // 
            this.PnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnlMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlMenu.BackgroundImage")));
            this.PnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlMenu.Controls.Add(this.PBX_Sair);
            this.PnlMenu.Controls.Add(this.PBX_Opcoes);
            this.PnlMenu.Controls.Add(this.PBX_Jogar);
            this.PnlMenu.Location = new System.Drawing.Point(708, 217);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(850, 800);
            this.PnlMenu.TabIndex = 1;
            // 
            // PBX_Sair
            // 
            this.PBX_Sair.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Sair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBX_Sair.BackgroundImage")));
            this.PBX_Sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBX_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Sair.Location = new System.Drawing.Point(307, 562);
            this.PBX_Sair.Name = "PBX_Sair";
            this.PBX_Sair.Size = new System.Drawing.Size(220, 120);
            this.PBX_Sair.TabIndex = 2;
            this.PBX_Sair.TabStop = false;
            this.PBX_Sair.MouseLeave += new System.EventHandler(this.PBX_Sair_MouseLeave);
            this.PBX_Sair.MouseHover += new System.EventHandler(this.PBX_Sair_MouseHover);
            // 
            // PBX_Opcoes
            // 
            this.PBX_Opcoes.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Opcoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBX_Opcoes.BackgroundImage")));
            this.PBX_Opcoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBX_Opcoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Opcoes.Location = new System.Drawing.Point(307, 400);
            this.PBX_Opcoes.Name = "PBX_Opcoes";
            this.PBX_Opcoes.Size = new System.Drawing.Size(220, 120);
            this.PBX_Opcoes.TabIndex = 1;
            this.PBX_Opcoes.TabStop = false;
            this.PBX_Opcoes.MouseLeave += new System.EventHandler(this.PBX_Opcoes_MouseLeave);
            this.PBX_Opcoes.MouseHover += new System.EventHandler(this.PBX_Opcoes_MouseHover);
            // 
            // PBX_Jogar
            // 
            this.PBX_Jogar.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Jogar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBX_Jogar.BackgroundImage")));
            this.PBX_Jogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBX_Jogar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Jogar.Location = new System.Drawing.Point(307, 235);
            this.PBX_Jogar.Name = "PBX_Jogar";
            this.PBX_Jogar.Size = new System.Drawing.Size(220, 120);
            this.PBX_Jogar.TabIndex = 0;
            this.PBX_Jogar.TabStop = false;
            this.PBX_Jogar.Click += new System.EventHandler(this.PBX_Jogar_Click);
            this.PBX_Jogar.MouseLeave += new System.EventHandler(this.PBX_Jogar_MouseLeave);
            this.PBX_Jogar.MouseHover += new System.EventHandler(this.PBX_Jogar_MouseHover);
            // 
            // TmrAndar
            // 
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(24, 344);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(55, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "Posição X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(35, 177);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(55, 13);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Posição Y";
            // 
            // LblX
            // 
            this.LblX.AutoSize = true;
            this.LblX.Location = new System.Drawing.Point(75, 148);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(14, 13);
            this.LblX.TabIndex = 4;
            this.LblX.Text = "X";
            // 
            // LblY
            // 
            this.LblY.AutoSize = true;
            this.LblY.Location = new System.Drawing.Point(75, 177);
            this.LblY.Name = "LblY";
            this.LblY.Size = new System.Drawing.Size(14, 13);
            this.LblY.TabIndex = 4;
            this.LblY.Text = "Y";
            // 
            // PbxPersonagem
            // 
            this.PbxPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.PbxPersonagem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxPersonagem.BackgroundImage")));
            this.PbxPersonagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxPersonagem.Location = new System.Drawing.Point(38, 91);
            this.PbxPersonagem.Name = "PbxPersonagem";
            this.PbxPersonagem.Size = new System.Drawing.Size(32, 33);
            this.PbxPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxPersonagem.TabIndex = 3;
            this.PbxPersonagem.TabStop = false;
            // 
            // PNL_Fases
            // 
            this.PNL_Fases.BackColor = System.Drawing.Color.LightBlue;
            this.PNL_Fases.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PNL_Fases.BackgroundImage")));
            this.PNL_Fases.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PNL_Fases.Controls.Add(this.panel4);
            this.PNL_Fases.Controls.Add(this.panel3);
            this.PNL_Fases.Controls.Add(this.panel5);
            this.PNL_Fases.Controls.Add(this.panel6);
            this.PNL_Fases.Controls.Add(this.panel2);
            this.PNL_Fases.Controls.Add(this.panel1);
            this.PNL_Fases.Location = new System.Drawing.Point(2, 2);
            this.PNL_Fases.Name = "PNL_Fases";
            this.PNL_Fases.Size = new System.Drawing.Size(850, 800);
            this.PNL_Fases.TabIndex = 3;
            // 
            // PBX_Fase1
            // 
            this.PBX_Fase1.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase1.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase1.Image")));
            this.PBX_Fase1.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase1.Name = "PBX_Fase1";
            this.PBX_Fase1.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase1.TabIndex = 0;
            this.PBX_Fase1.TabStop = false;
            this.PBX_Fase1.MouseLeave += new System.EventHandler(this.PBX_Fase1_MouseLeave);
            this.PBX_Fase1.MouseHover += new System.EventHandler(this.PBX_Fase1_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel1.Controls.Add(this.PBX_Fase1);
            this.panel1.Location = new System.Drawing.Point(14, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 196);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel2.Controls.Add(this.PBX_Fase2);
            this.panel2.Location = new System.Drawing.Point(291, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 196);
            this.panel2.TabIndex = 7;
            // 
            // PBX_Fase2
            // 
            this.PBX_Fase2.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase2.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase2.Image")));
            this.PBX_Fase2.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase2.Name = "PBX_Fase2";
            this.PBX_Fase2.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase2.TabIndex = 0;
            this.PBX_Fase2.TabStop = false;
            this.PBX_Fase2.MouseLeave += new System.EventHandler(this.PBX_Fase2_MouseLeave);
            this.PBX_Fase2.MouseHover += new System.EventHandler(this.PBX_Fase2_MouseHover);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel3.Controls.Add(this.PBX_Fase3);
            this.panel3.Location = new System.Drawing.Point(560, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 196);
            this.panel3.TabIndex = 7;
            // 
            // PBX_Fase3
            // 
            this.PBX_Fase3.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase3.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase3.Image")));
            this.PBX_Fase3.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase3.Name = "PBX_Fase3";
            this.PBX_Fase3.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase3.TabIndex = 0;
            this.PBX_Fase3.TabStop = false;
            this.PBX_Fase3.MouseLeave += new System.EventHandler(this.PBX_Fase3_MouseLeave);
            this.PBX_Fase3.MouseHover += new System.EventHandler(this.PBX_Fase3_MouseHover);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel4.Controls.Add(this.PBX_Fase6);
            this.panel4.Location = new System.Drawing.Point(560, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 196);
            this.panel4.TabIndex = 10;
            // 
            // PBX_Fase6
            // 
            this.PBX_Fase6.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase6.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase6.Image")));
            this.PBX_Fase6.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase6.Name = "PBX_Fase6";
            this.PBX_Fase6.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase6.TabIndex = 0;
            this.PBX_Fase6.TabStop = false;
            this.PBX_Fase6.MouseLeave += new System.EventHandler(this.PBX_Fase6_MouseLeave);
            this.PBX_Fase6.MouseHover += new System.EventHandler(this.PBX_Fase6_MouseHover);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel5.Controls.Add(this.PBX_Fase5);
            this.panel5.Location = new System.Drawing.Point(291, 451);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 196);
            this.panel5.TabIndex = 9;
            // 
            // PBX_Fase5
            // 
            this.PBX_Fase5.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase5.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase5.Image")));
            this.PBX_Fase5.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase5.Name = "PBX_Fase5";
            this.PBX_Fase5.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase5.TabIndex = 0;
            this.PBX_Fase5.TabStop = false;
            this.PBX_Fase5.MouseLeave += new System.EventHandler(this.PBX_Fase5_MouseLeave);
            this.PBX_Fase5.MouseHover += new System.EventHandler(this.PBX_Fase5_MouseHover);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel6.Controls.Add(this.PBX_Fase4);
            this.panel6.Location = new System.Drawing.Point(14, 451);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(256, 196);
            this.panel6.TabIndex = 8;
            // 
            // PBX_Fase4
            // 
            this.PBX_Fase4.BackColor = System.Drawing.Color.Transparent;
            this.PBX_Fase4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBX_Fase4.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Fase4.Image")));
            this.PBX_Fase4.Location = new System.Drawing.Point(14, 14);
            this.PBX_Fase4.Name = "PBX_Fase4";
            this.PBX_Fase4.Size = new System.Drawing.Size(228, 170);
            this.PBX_Fase4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBX_Fase4.TabIndex = 0;
            this.PBX_Fase4.TabStop = false;
            this.PBX_Fase4.MouseLeave += new System.EventHandler(this.PBX_Fase4_MouseLeave);
            this.PBX_Fase4.MouseHover += new System.EventHandler(this.PBX_Fase4_MouseHover);
            // 
            // FrmJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 761);
            this.Controls.Add(this.PNL_Fases);
            this.Controls.Add(this.PnlMenu);
            this.Controls.Add(this.LblY);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.PbxPersonagem);
            this.DoubleBuffered = true;
            this.Name = "FrmJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Matemática 3°ano";
            this.Load += new System.EventHandler(this.FrmJogo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmJogo_KeyPress);
            this.PnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Sair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Opcoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Jogar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).EndInit();
            this.PNL_Fases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase6)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase5)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Fase4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TmrAndar;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label LblX;
        private System.Windows.Forms.Label LblY;
        private System.Windows.Forms.PictureBox PbxPersonagem;
        private System.Windows.Forms.PictureBox PBX_Sair;
        private System.Windows.Forms.PictureBox PBX_Opcoes;
        private System.Windows.Forms.PictureBox PBX_Jogar;
        private System.Windows.Forms.Panel PNL_Fases;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox PBX_Fase6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox PBX_Fase3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox PBX_Fase5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox PBX_Fase4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PBX_Fase2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PBX_Fase1;
    }
}

