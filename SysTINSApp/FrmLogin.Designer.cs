namespace SysTINSApp
{
    partial class FrmLogin
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
            btnEntrar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textSenha = new TextBox();
            lblMensagem = new Label();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(138, 173);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(77, 37);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "&Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(266, 173);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(79, 37);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 73);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 114);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(349, 23);
            textBox1.TabIndex = 4;
            // 
            // textSenha
            // 
            textSenha.Location = new Point(80, 111);
            textSenha.Name = "textSenha";
            textSenha.Size = new Size(349, 23);
            textSenha.TabIndex = 5;
            textSenha.UseSystemPasswordChar = true;
            // 
            // lblMensagem
            // 
            lblMensagem.AutoSize = true;
            lblMensagem.BackColor = Color.Transparent;
            lblMensagem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensagem.ForeColor = Color.IndianRed;
            lblMensagem.Location = new Point(21, 156);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(0, 21);
            lblMensagem.TabIndex = 6;
            // 
            // FrmLogin
            // 
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnCancelar;
            ClientSize = new Size(475, 309);
            ControlBox = false;
            Controls.Add(lblMensagem);
            Controls.Add(textSenha);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnEntrar);
            Name = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textSenha;
        private Label lblMensagem;
    }
}