namespace presentacion
{
    partial class frmVerDetalle
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
            this.lblCodigoDetalle = new System.Windows.Forms.Label();
            this.lblCodVerDetalle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigoDetalle
            // 
            this.lblCodigoDetalle.AutoSize = true;
            this.lblCodigoDetalle.Location = new System.Drawing.Point(40, 24);
            this.lblCodigoDetalle.Name = "lblCodigoDetalle";
            this.lblCodigoDetalle.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoDetalle.TabIndex = 0;
            this.lblCodigoDetalle.Text = "Código:";
            // 
            // lblCodVerDetalle
            // 
            this.lblCodVerDetalle.AutoSize = true;
            this.lblCodVerDetalle.Location = new System.Drawing.Point(40, 51);
            this.lblCodVerDetalle.Name = "lblCodVerDetalle";
            this.lblCodVerDetalle.Size = new System.Drawing.Size(35, 13);
            this.lblCodVerDetalle.TabIndex = 1;
            this.lblCodVerDetalle.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // frmVerDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 250);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodVerDetalle);
            this.Controls.Add(this.lblCodigoDetalle);
            this.Name = "frmVerDetalle";
            this.Text = "frmVerDetalle";
            this.Load += new System.EventHandler(this.frmVerDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigoDetalle;
        private System.Windows.Forms.Label lblCodVerDetalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}