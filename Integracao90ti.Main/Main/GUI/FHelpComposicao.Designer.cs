namespace Integracao90ti.Main.GUI
{
    partial class FHelpComposicao
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
            this.btnAplicar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvComposicao = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvItemPlanilha = new System.Windows.Forms.DataGridView();
            this.Selecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdItemPlanilha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComposicao)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPlanilha)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAplicar.Location = new System.Drawing.Point(296, 299);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 24);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.dgvComposicao);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 178);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Composição";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(597, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(585, 20);
            this.textBox1.TabIndex = 5;
            // 
            // dgvComposicao
            // 
            this.dgvComposicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComposicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descricao,
            this.Unidade,
            this.Preco,
            this.Id});
            this.dgvComposicao.Location = new System.Drawing.Point(6, 49);
            this.dgvComposicao.MultiSelect = false;
            this.dgvComposicao.Name = "dgvComposicao";
            this.dgvComposicao.RowHeadersVisible = false;
            this.dgvComposicao.Size = new System.Drawing.Size(666, 124);
            this.dgvComposicao.TabIndex = 4;
            this.dgvComposicao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComposicao_CellClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código da Composição";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 140;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 300;
            // 
            // Unidade
            // 
            this.Unidade.DataPropertyName = "Unidade";
            this.Unidade.HeaderText = "Unidade";
            this.Unidade.Name = "Unidade";
            // 
            // Preco
            // 
            this.Preco.DataPropertyName = "Preco";
            this.Preco.HeaderText = "Preço Unitário";
            this.Preco.Name = "Preco";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvItemPlanilha);
            this.groupBox2.Location = new System.Drawing.Point(5, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 111);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item Planilha";
            // 
            // dgvItemPlanilha
            // 
            this.dgvItemPlanilha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemPlanilha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selecionar,
            this.IdItemPlanilha,
            this.CodigoItem,
            this.DescricaoItem});
            this.dgvItemPlanilha.Location = new System.Drawing.Point(6, 19);
            this.dgvItemPlanilha.Name = "dgvItemPlanilha";
            this.dgvItemPlanilha.RowHeadersVisible = false;
            this.dgvItemPlanilha.Size = new System.Drawing.Size(666, 85);
            this.dgvItemPlanilha.TabIndex = 2;
            // 
            // Selecionar
            // 
            this.Selecionar.HeaderText = "Selecionar";
            this.Selecionar.Name = "Selecionar";
            this.Selecionar.Width = 60;
            // 
            // IdItemPlanilha
            // 
            this.IdItemPlanilha.DataPropertyName = "IdItemPlanilha";
            this.IdItemPlanilha.HeaderText = "IdItemPlanilha";
            this.IdItemPlanilha.Name = "IdItemPlanilha";
            this.IdItemPlanilha.Visible = false;
            // 
            // CodigoItem
            // 
            this.CodigoItem.DataPropertyName = "Codigo";
            this.CodigoItem.HeaderText = "Código do Item";
            this.CodigoItem.Name = "CodigoItem";
            this.CodigoItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CodigoItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoItem.Width = 140;
            // 
            // DescricaoItem
            // 
            this.DescricaoItem.DataPropertyName = "Descricao";
            this.DescricaoItem.HeaderText = "Descrição do Item";
            this.DescricaoItem.Name = "DescricaoItem";
            this.DescricaoItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DescricaoItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DescricaoItem.Width = 440;
            // 
            // FHelpComposicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 331);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAplicar);
            this.Name = "FHelpComposicao";
            this.Text = "FHelpComposicao";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComposicao)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPlanilha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvComposicao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvItemPlanilha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdItemPlanilha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoItem;
    }
}