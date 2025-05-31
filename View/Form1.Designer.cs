namespace Equipa24_FolhetosPDF
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label4 = new System.Windows.Forms.Label();
            this.txtMensagens = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtTextoComplementar = new System.Windows.Forms.TextBox();
            this.lblTexto = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.pictureBoxEquipa24 = new System.Windows.Forms.PictureBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.cboSeleciona = new System.Windows.Forms.ComboBox();
            this.btnPdfFoto = new System.Windows.Forms.Button();
            this.btnPdfImagem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEquipa24)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 549);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Mensagens:";
            // 
            // txtMensagens
            // 
            this.txtMensagens.Location = new System.Drawing.Point(39, 574);
            this.txtMensagens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMensagens.Multiline = true;
            this.txtMensagens.Name = "txtMensagens";
            this.txtMensagens.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMensagens.Size = new System.Drawing.Size(682, 92);
            this.txtMensagens.TabIndex = 45;
            this.txtMensagens.Leave += new System.EventHandler(this.txtMensagens_Leave);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(18, 535);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(688, 13);
            this.label3.TabIndex = 44;
            // 
            // btnGravar
            // 
            this.btnGravar.Enabled = false;
            this.btnGravar.Location = new System.Drawing.Point(557, 495);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(148, 35);
            this.btnGravar.TabIndex = 43;
            this.btnGravar.Text = "Gravar Ficheiro";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFoto.InitialImage")));
            this.pictureBoxFoto.Location = new System.Drawing.Point(534, 77);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(129, 145);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 42;
            this.pictureBoxFoto.TabStop = false;
            // 
            // btnPdf
            // 
            this.btnPdf.Enabled = false;
            this.btnPdf.Location = new System.Drawing.Point(212, 495);
            this.btnPdf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(68, 35);
            this.btnPdf.TabIndex = 41;
            this.btnPdf.Text = "PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Enabled = false;
            this.btnProximo.Location = new System.Drawing.Point(452, 435);
            this.btnProximo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(81, 35);
            this.btnProximo.TabIndex = 40;
            this.btnProximo.Text = "Próximo";
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(24, 435);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(86, 35);
            this.btnAnterior.TabIndex = 38;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(18, 411);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 13);
            this.label1.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "complementar";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(153, 343);
            this.txtObs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObs.Size = new System.Drawing.Size(552, 55);
            this.txtObs.TabIndex = 35;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(34, 343);
            this.lblObs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(38, 20);
            this.lblObs.TabIndex = 34;
            this.lblObs.Text = "Obs";
            // 
            // txtTextoComplementar
            // 
            this.txtTextoComplementar.Location = new System.Drawing.Point(153, 268);
            this.txtTextoComplementar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTextoComplementar.Multiline = true;
            this.txtTextoComplementar.Name = "txtTextoComplementar";
            this.txtTextoComplementar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTextoComplementar.Size = new System.Drawing.Size(552, 55);
            this.txtTextoComplementar.TabIndex = 33;
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(34, 268);
            this.lblTexto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(52, 20);
            this.lblTexto.TabIndex = 32;
            this.lblTexto.Text = "Texto ";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(153, 191);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescricao.Size = new System.Drawing.Size(325, 55);
            this.txtDescricao.TabIndex = 31;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(34, 191);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(80, 20);
            this.lblDescricao.TabIndex = 30;
            this.lblDescricao.Text = "Descrição";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(24, 495);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(81, 35);
            this.btnSair.TabIndex = 29;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(153, 145);
            this.txtProduto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(254, 26);
            this.txtProduto.TabIndex = 28;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(34, 149);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(65, 20);
            this.lblCodigo.TabIndex = 27;
            this.lblCodigo.Text = "Produto";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(153, 105);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(106, 26);
            this.txtID.TabIndex = 26;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(34, 109);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID";
            // 
            // pictureBoxEquipa24
            // 
            this.pictureBoxEquipa24.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEquipa24.Image")));
            this.pictureBoxEquipa24.Location = new System.Drawing.Point(18, 29);
            this.pictureBoxEquipa24.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxEquipa24.Name = "pictureBoxEquipa24";
            this.pictureBoxEquipa24.Size = new System.Drawing.Size(242, 54);
            this.pictureBoxEquipa24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEquipa24.TabIndex = 24;
            this.pictureBoxEquipa24.TabStop = false;
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(557, 460);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(148, 35);
            this.btnImportar.TabIndex = 47;
            this.btnImportar.Text = "Importar Ficheiro";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // cboSeleciona
            // 
            this.cboSeleciona.FormattingEnabled = true;
            this.cboSeleciona.Location = new System.Drawing.Point(120, 438);
            this.cboSeleciona.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSeleciona.Name = "cboSeleciona";
            this.cboSeleciona.Size = new System.Drawing.Size(320, 28);
            this.cboSeleciona.TabIndex = 48;
            this.cboSeleciona.Text = "Selecionar";
            this.cboSeleciona.SelectedIndexChanged += new System.EventHandler(this.cboSeleciona_SelectedIndexChanged);
            this.cboSeleciona.Leave += new System.EventHandler(this.cboSeleciona_Leave);
            // 
            // btnPdfFoto
            // 
            this.btnPdfFoto.Enabled = false;
            this.btnPdfFoto.Location = new System.Drawing.Point(288, 495);
            this.btnPdfFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPdfFoto.Name = "btnPdfFoto";
            this.btnPdfFoto.Size = new System.Drawing.Size(102, 35);
            this.btnPdfFoto.TabIndex = 50;
            this.btnPdfFoto.Text = "PDF Foto";
            this.btnPdfFoto.UseVisualStyleBackColor = true;
            this.btnPdfFoto.Click += new System.EventHandler(this.btnPdfFoto_Click);
            // 
            // btnPdfImagem
            // 
            this.btnPdfImagem.Enabled = false;
            this.btnPdfImagem.Location = new System.Drawing.Point(397, 495);
            this.btnPdfImagem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPdfImagem.Name = "btnPdfImagem";
            this.btnPdfImagem.Size = new System.Drawing.Size(136, 35);
            this.btnPdfImagem.TabIndex = 51;
            this.btnPdfImagem.Text = "PDF Imagem";
            this.btnPdfImagem.UseVisualStyleBackColor = true;
            this.btnPdfImagem.Click += new System.EventHandler(this.btnPdfImagem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 706);
            this.Controls.Add(this.btnPdfImagem);
            this.Controls.Add(this.btnPdfFoto);
            this.Controls.Add(this.cboSeleciona);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMensagens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.pictureBoxFoto);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.txtTextoComplementar);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.pictureBoxEquipa24);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Equipa24 - FolhetosPDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEquipa24)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMensagens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtTextoComplementar;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox pictureBoxEquipa24;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.ComboBox cboSeleciona;
        private System.Windows.Forms.Button btnPdfFoto;
        private System.Windows.Forms.Button btnPdfImagem;
    }
}