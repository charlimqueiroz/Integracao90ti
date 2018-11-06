namespace Integracao90ti.Main.GUI
{
    partial class FAssociacao
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBaseDados = new System.Windows.Forms.ComboBox();
            this.cbProjeto = new System.Windows.Forms.ComboBox();
            this.cbPlanilha = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAssociarComposicao = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Associar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdComposicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdItemPlanilha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvFamilias = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociarComposicao)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(791, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salvar Associação";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(920, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Exportar Quantitativos";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbBaseDados);
            this.groupBox1.Controls.Add(this.cbProjeto);
            this.groupBox1.Controls.Add(this.cbPlanilha);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1043, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(695, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Planilha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Projeto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Base de Dados";
            // 
            // cbBaseDados
            // 
            this.cbBaseDados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaseDados.FormattingEnabled = true;
            this.cbBaseDados.Location = new System.Drawing.Point(6, 41);
            this.cbBaseDados.Name = "cbBaseDados";
            this.cbBaseDados.Size = new System.Drawing.Size(339, 21);
            this.cbBaseDados.TabIndex = 7;
            this.cbBaseDados.SelectedIndexChanged += new System.EventHandler(this.cbBaseDados_SelectedIndexChanged);
            // 
            // cbProjeto
            // 
            this.cbProjeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjeto.FormattingEnabled = true;
            this.cbProjeto.Location = new System.Drawing.Point(351, 41);
            this.cbProjeto.Name = "cbProjeto";
            this.cbProjeto.Size = new System.Drawing.Size(339, 21);
            this.cbProjeto.TabIndex = 6;
            this.cbProjeto.SelectedIndexChanged += new System.EventHandler(this.cbProjeto_SelectedIndexChanged);
            // 
            // cbPlanilha
            // 
            this.cbPlanilha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlanilha.FormattingEnabled = true;
            this.cbPlanilha.Location = new System.Drawing.Point(698, 41);
            this.cbPlanilha.Name = "cbPlanilha";
            this.cbPlanilha.Size = new System.Drawing.Size(339, 21);
            this.cbPlanilha.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dgvAssociarComposicao);
            this.groupBox2.Controls.Add(this.tvFamilias);
            this.groupBox2.Location = new System.Drawing.Point(4, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1043, 362);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Associação Revit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pesquisar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(962, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(739, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Família e Tipo";
            // 
            // dgvAssociarComposicao
            // 
            this.dgvAssociarComposicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssociarComposicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.CodigoCPU,
            this.DescricaoCPU,
            this.CodigoItem,
            this.Quantidade,
            this.Associar,
            this.IdComposicao,
            this.IdItemPlanilha});
            this.dgvAssociarComposicao.Location = new System.Drawing.Point(217, 58);
            this.dgvAssociarComposicao.MultiSelect = false;
            this.dgvAssociarComposicao.Name = "dgvAssociarComposicao";
            this.dgvAssociarComposicao.RowHeadersVisible = false;
            this.dgvAssociarComposicao.Size = new System.Drawing.Size(820, 298);
            this.dgvAssociarComposicao.TabIndex = 11;
            this.dgvAssociarComposicao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 215;
            // 
            // CodigoCPU
            // 
            this.CodigoCPU.DataPropertyName = "CodigoCPU";
            this.CodigoCPU.HeaderText = "Código CPU no Orçamento";
            this.CodigoCPU.Name = "CodigoCPU";
            // 
            // DescricaoCPU
            // 
            this.DescricaoCPU.DataPropertyName = "DescricaoCPU";
            this.DescricaoCPU.HeaderText = "Descrição CPU";
            this.DescricaoCPU.Name = "DescricaoCPU";
            this.DescricaoCPU.Width = 225;
            // 
            // CodigoItem
            // 
            this.CodigoItem.DataPropertyName = "CodigoItem";
            this.CodigoItem.HeaderText = "Código Item Planilha";
            this.CodigoItem.Name = "CodigoItem";
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // Associar
            // 
            this.Associar.HeaderText = "Associar";
            this.Associar.Name = "Associar";
            this.Associar.Text = "...";
            this.Associar.ToolTipText = "...";
            this.Associar.Width = 50;
            // 
            // IdComposicao
            // 
            this.IdComposicao.DataPropertyName = "IdComposicao";
            this.IdComposicao.HeaderText = "IdComposicao";
            this.IdComposicao.Name = "IdComposicao";
            this.IdComposicao.Visible = false;
            // 
            // IdItemPlanilha
            // 
            this.IdItemPlanilha.DataPropertyName = "IdItemPlanilha";
            this.IdItemPlanilha.HeaderText = "IdItemPlanilha";
            this.IdItemPlanilha.Name = "IdItemPlanilha";
            this.IdItemPlanilha.Visible = false;
            // 
            // tvFamilias
            // 
            this.tvFamilias.CheckBoxes = true;
            this.tvFamilias.Location = new System.Drawing.Point(8, 54);
            this.tvFamilias.Name = "tvFamilias";
            this.tvFamilias.Size = new System.Drawing.Size(203, 301);
            this.tvFamilias.TabIndex = 10;
            this.tvFamilias.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFamilias_NodeMouseClick);
            // 
            // FAssociacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 482);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FAssociacao";
            this.Text = "FAssociacao";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociarComposicao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBaseDados;
        private System.Windows.Forms.ComboBox cbProjeto;
        private System.Windows.Forms.ComboBox cbPlanilha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvAssociarComposicao;
        private System.Windows.Forms.TreeView tvFamilias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewButtonColumn Associar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComposicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdItemPlanilha;
    }
}