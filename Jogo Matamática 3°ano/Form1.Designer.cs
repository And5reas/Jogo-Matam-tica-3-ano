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
            this.TmrMainGameManager = new System.Windows.Forms.Timer(this.components);
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblY = new System.Windows.Forms.Label();
            this.PbxPersonagem = new System.Windows.Forms.PictureBox();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Sair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Opcoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Jogar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).BeginInit();
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
            this.PnlMenu.Location = new System.Drawing.Point(485, 344);
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
            this.PBX_Sair.Location = new System.Drawing.Point(307, 538);
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
            this.PBX_Opcoes.Location = new System.Drawing.Point(307, 393);
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
            this.PBX_Jogar.Location = new System.Drawing.Point(307, 249);
            this.PBX_Jogar.Name = "PBX_Jogar";
            this.PBX_Jogar.Size = new System.Drawing.Size(220, 120);
            this.PBX_Jogar.TabIndex = 0;
            this.PBX_Jogar.TabStop = false;
            this.PBX_Jogar.Click += new System.EventHandler(this.PBX_Jogar_Click);
            this.PBX_Jogar.MouseLeave += new System.EventHandler(this.PBX_Jogar_MouseLeave);
            this.PBX_Jogar.MouseHover += new System.EventHandler(this.PBX_Jogar_MouseHover);
            // 
            // TmrMainGameManager
            // 
            this.TmrMainGameManager.Enabled = true;
            this.TmrMainGameManager.Tick += new System.EventHandler(this.TmrMainGameManager_Tick);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.Color.GreenYellow;
            this.labelX.Location = new System.Drawing.Point(35, 47);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(55, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "Posição X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.Color.GreenYellow;
            this.labelY.Location = new System.Drawing.Point(35, 23);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(55, 13);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Posição Y";
            // 
            // LblX
            // 
            this.LblX.AutoSize = true;
            this.LblX.BackColor = System.Drawing.Color.GreenYellow;
            this.LblX.Location = new System.Drawing.Point(96, 47);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(14, 13);
            this.LblX.TabIndex = 4;
            this.LblX.Text = "X";
            // 
            // LblY
            // 
            this.LblY.AutoSize = true;
            this.LblY.BackColor = System.Drawing.Color.GreenYellow;
            this.LblY.Location = new System.Drawing.Point(96, 23);
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
            this.PbxPersonagem.Location = new System.Drawing.Point(46, 106);
            this.PbxPersonagem.Name = "PbxPersonagem";
            this.PbxPersonagem.Size = new System.Drawing.Size(32, 33);
            this.PbxPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxPersonagem.TabIndex = 3;
            this.PbxPersonagem.TabStop = false;
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmJogo_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmJogo_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmJogo_KeyUp);
            this.PnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Sair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Opcoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Jogar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TmrMainGameManager;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label LblX;
        private System.Windows.Forms.Label LblY;
        private System.Windows.Forms.PictureBox PbxPersonagem;
        private System.Windows.Forms.PictureBox PBX_Sair;
        private System.Windows.Forms.PictureBox PBX_Opcoes;
        private System.Windows.Forms.PictureBox PBX_Jogar;
    }
}

