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
            this.label1 = new System.Windows.Forms.Label();
            this.PbxFases = new System.Windows.Forms.PictureBox();
            this.PbxPersonagem = new System.Windows.Forms.PictureBox();
            this.TmrAndar = new System.Windows.Forms.Timer(this.components);
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblY = new System.Windows.Forms.Label();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxFases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMenu
            // 
            this.PnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnlMenu.Controls.Add(this.label1);
            this.PnlMenu.Location = new System.Drawing.Point(943, 586);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(1123, 696);
            this.PnlMenu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // PbxFases
            // 
            this.PbxFases.Image = ((System.Drawing.Image)(resources.GetObject("PbxFases.Image")));
            this.PbxFases.Location = new System.Drawing.Point(179, 68);
            this.PbxFases.Name = "PbxFases";
            this.PbxFases.Size = new System.Drawing.Size(758, 550);
            this.PbxFases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbxFases.TabIndex = 2;
            this.PbxFases.TabStop = false;
            // 
            // PbxPersonagem
            // 
            this.PbxPersonagem.Location = new System.Drawing.Point(212, 86);
            this.PbxPersonagem.Name = "PbxPersonagem";
            this.PbxPersonagem.Size = new System.Drawing.Size(32, 33);
            this.PbxPersonagem.TabIndex = 3;
            this.PbxPersonagem.TabStop = false;
            // 
            // TmrAndar
            // 
            this.TmrAndar.Tick += new System.EventHandler(this.TmrAndar_Tick);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(35, 148);
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
            // FrmJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1116, 687);
            this.Controls.Add(this.LblY);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.PbxPersonagem);
            this.Controls.Add(this.PbxFases);
            this.Controls.Add(this.PnlMenu);
            this.Name = "FrmJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Matemática 3°ano";
            this.Load += new System.EventHandler(this.FrmJogo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmJogo_KeyPress);
            this.PnlMenu.ResumeLayout(false);
            this.PnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxFases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPersonagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbxFases;
        private System.Windows.Forms.PictureBox PbxPersonagem;
        private System.Windows.Forms.Timer TmrAndar;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label LblX;
        private System.Windows.Forms.Label LblY;
    }
}

