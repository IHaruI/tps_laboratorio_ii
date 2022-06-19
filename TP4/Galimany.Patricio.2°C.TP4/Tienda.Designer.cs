namespace Galimany.Patricio._2_C.TP4
{
    partial class Tienda
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
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rbSprite = new System.Windows.Forms.GroupBox();
            this.rbCocacola = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rbSprite.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(26, 131);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(107, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // rbSprite
            // 
            this.rbSprite.Controls.Add(this.radioButton2);
            this.rbSprite.Controls.Add(this.rbCocacola);
            this.rbSprite.Location = new System.Drawing.Point(62, 25);
            this.rbSprite.Name = "rbSprite";
            this.rbSprite.Size = new System.Drawing.Size(94, 100);
            this.rbSprite.TabIndex = 4;
            this.rbSprite.TabStop = false;
            this.rbSprite.Text = "Tienda";
            // 
            // rbCocacola
            // 
            this.rbCocacola.AutoSize = true;
            this.rbCocacola.Checked = true;
            this.rbCocacola.Location = new System.Drawing.Point(6, 22);
            this.rbCocacola.Name = "rbCocacola";
            this.rbCocacola.Size = new System.Drawing.Size(79, 19);
            this.rbCocacola.TabIndex = 2;
            this.rbCocacola.TabStop = true;
            this.rbCocacola.Text = "Coca Cola";
            this.rbCocacola.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 19);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Sprite";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Tienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 174);
            this.Controls.Add(this.rbSprite);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnComprar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tienda";
            this.rbSprite.ResumeLayout(false);
            this.rbSprite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox rbSprite;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rbCocacola;
    }
}