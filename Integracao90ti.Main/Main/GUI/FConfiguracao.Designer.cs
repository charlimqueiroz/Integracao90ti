namespace Integracao90ti.Main.GUI
{
    partial class FConfiguracao
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbDialeto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBaseDeDados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(456, 168);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 25);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbDialeto);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbSenha);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbUsuario);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbBaseDeDados);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tbServidor);
            this.groupBox4.Location = new System.Drawing.Point(3, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(550, 150);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conexão do Banco de dados";
            // 
            // cbDialeto
            // 
            this.cbDialeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDialeto.FormattingEnabled = true;
            this.cbDialeto.Location = new System.Drawing.Point(141, 19);
            this.cbDialeto.Name = "cbDialeto";
            this.cbDialeto.Size = new System.Drawing.Size(403, 21);
            this.cbDialeto.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Dialeto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Senha:";
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(141, 123);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(403, 20);
            this.tbSenha.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Usuário:";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(141, 97);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(403, 20);
            this.tbUsuario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Base de dados:";
            // 
            // tbBaseDeDados
            // 
            this.tbBaseDeDados.Location = new System.Drawing.Point(141, 71);
            this.tbBaseDeDados.Name = "tbBaseDeDados";
            this.tbBaseDeDados.Size = new System.Drawing.Size(403, 20);
            this.tbBaseDeDados.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servidor:";
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(141, 45);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(403, 20);
            this.tbServidor.TabIndex = 0;
            // 
            // FConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 198);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox4);
            this.Name = "FConfiguracao";
            this.Text = "FConfiguracao";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbDialeto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBaseDeDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServidor;
    }
}