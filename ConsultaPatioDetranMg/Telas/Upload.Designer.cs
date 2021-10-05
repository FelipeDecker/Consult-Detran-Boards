
namespace ConsultaPatioDetranMg.Telas
{
    partial class Upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Upload));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PathArquivo = new System.Windows.Forms.TextBox();
            this.BtnUploadPlanilha = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.BtnGerarPlanilha = new System.Windows.Forms.Button();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Planilhas = new System.Windows.Forms.ComboBox();
            this.ColunaPlaca = new System.Windows.Forms.TextBox();
            this.LinhaInicial = new System.Windows.Forms.TextBox();
            this.BtnPararRobo = new System.Windows.Forms.Button();
            this.QuantidadeRegistros = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(970, 600);
            this.dataGridView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arquivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total registros: ";
            // 
            // PathArquivo
            // 
            this.PathArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathArquivo.Location = new System.Drawing.Point(32, 39);
            this.PathArquivo.Name = "PathArquivo";
            this.PathArquivo.Size = new System.Drawing.Size(396, 24);
            this.PathArquivo.TabIndex = 3;
            // 
            // BtnUploadPlanilha
            // 
            this.BtnUploadPlanilha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUploadPlanilha.Image = ((System.Drawing.Image)(resources.GetObject("BtnUploadPlanilha.Image")));
            this.BtnUploadPlanilha.Location = new System.Drawing.Point(426, 38);
            this.BtnUploadPlanilha.Name = "BtnUploadPlanilha";
            this.BtnUploadPlanilha.Size = new System.Drawing.Size(40, 26);
            this.BtnUploadPlanilha.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BtnUploadPlanilha, "Selecionar Planilha");
            this.BtnUploadPlanilha.UseVisualStyleBackColor = true;
            this.BtnUploadPlanilha.Click += new System.EventHandler(this.BtnUploadPlanilha_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("BtnLimpar.Image")));
            this.BtnLimpar.Location = new System.Drawing.Point(916, 24);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(40, 40);
            this.BtnLimpar.TabIndex = 5;
            this.toolTip1.SetToolTip(this.BtnLimpar, "Limpar Campos");
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // BtnGerarPlanilha
            // 
            this.BtnGerarPlanilha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGerarPlanilha.Image = ((System.Drawing.Image)(resources.GetObject("BtnGerarPlanilha.Image")));
            this.BtnGerarPlanilha.Location = new System.Drawing.Point(962, 24);
            this.BtnGerarPlanilha.Name = "BtnGerarPlanilha";
            this.BtnGerarPlanilha.Size = new System.Drawing.Size(40, 40);
            this.BtnGerarPlanilha.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BtnGerarPlanilha, "Gerar Planilha");
            this.BtnGerarPlanilha.UseVisualStyleBackColor = true;
            this.BtnGerarPlanilha.Click += new System.EventHandler(this.BtnGerarPlanilha_Click);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciar.Image = ((System.Drawing.Image)(resources.GetObject("BtnIniciar.Image")));
            this.BtnIniciar.Location = new System.Drawing.Point(824, 24);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(40, 40);
            this.BtnIniciar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BtnIniciar, "Iniciar Execução");
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Planilha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(599, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Coluna Placa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(693, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Linha Inicial";
            // 
            // Planilhas
            // 
            this.Planilhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Planilhas.FormattingEnabled = true;
            this.Planilhas.Location = new System.Drawing.Point(475, 39);
            this.Planilhas.Name = "Planilhas";
            this.Planilhas.Size = new System.Drawing.Size(121, 24);
            this.Planilhas.TabIndex = 11;
            // 
            // ColunaPlaca
            // 
            this.ColunaPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColunaPlaca.Location = new System.Drawing.Point(602, 39);
            this.ColunaPlaca.Name = "ColunaPlaca";
            this.ColunaPlaca.Size = new System.Drawing.Size(85, 24);
            this.ColunaPlaca.TabIndex = 12;
            // 
            // LinhaInicial
            // 
            this.LinhaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinhaInicial.Location = new System.Drawing.Point(696, 39);
            this.LinhaInicial.Name = "LinhaInicial";
            this.LinhaInicial.Size = new System.Drawing.Size(74, 24);
            this.LinhaInicial.TabIndex = 13;
            // 
            // BtnPararRobo
            // 
            this.BtnPararRobo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPararRobo.Image = ((System.Drawing.Image)(resources.GetObject("BtnPararRobo.Image")));
            this.BtnPararRobo.Location = new System.Drawing.Point(870, 24);
            this.BtnPararRobo.Name = "BtnPararRobo";
            this.BtnPararRobo.Size = new System.Drawing.Size(40, 40);
            this.BtnPararRobo.TabIndex = 14;
            this.toolTip1.SetToolTip(this.BtnPararRobo, "Parar Execução");
            this.BtnPararRobo.UseVisualStyleBackColor = true;
            this.BtnPararRobo.Click += new System.EventHandler(this.BtnPararRobo_Click);
            // 
            // QuantidadeRegistros
            // 
            this.QuantidadeRegistros.AutoSize = true;
            this.QuantidadeRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantidadeRegistros.Location = new System.Drawing.Point(123, 66);
            this.QuantidadeRegistros.Name = "QuantidadeRegistros";
            this.QuantidadeRegistros.Size = new System.Drawing.Size(15, 16);
            this.QuantidadeRegistros.TabIndex = 15;
            this.QuantidadeRegistros.Text = "0";
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 726);
            this.Controls.Add(this.QuantidadeRegistros);
            this.Controls.Add(this.BtnPararRobo);
            this.Controls.Add(this.LinhaInicial);
            this.Controls.Add(this.ColunaPlaca);
            this.Controls.Add(this.Planilhas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.BtnGerarPlanilha);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.BtnUploadPlanilha);
            this.Controls.Add(this.PathArquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Upload";
            this.Text = "Consulta Pátio Detran MG";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathArquivo;
        private System.Windows.Forms.Button BtnUploadPlanilha;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Planilhas;
        private System.Windows.Forms.TextBox ColunaPlaca;
        private System.Windows.Forms.TextBox LinhaInicial;
        private System.Windows.Forms.Button BtnPararRobo;
        private System.Windows.Forms.Label QuantidadeRegistros;
        public System.Windows.Forms.Button BtnGerarPlanilha;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}