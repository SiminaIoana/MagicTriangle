/**************************************************************************
 *                                                                        *
 *  File:        Form1.Designer.cs                                        *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Windows Forms UI for displaying triangle elements        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


namespace Proiect
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxBisectoare = new System.Windows.Forms.CheckBox();
            this.checkBoxMediane = new System.Windows.Forms.CheckBox();
            this.checkBoxInaltimi = new System.Windows.Forms.CheckBox();
            this.checkBoxCercCircumscris = new System.Windows.Forms.CheckBox();
            this.checkBoxCercInscris = new System.Windows.Forms.CheckBox();
            this.buttonRescrierePunct1 = new System.Windows.Forms.Button();
            this.buttonRescrierePunct2 = new System.Windows.Forms.Button();
            this.buttonRescrierePunct3 = new System.Windows.Forms.Button();
            this.buttonAfisareValori = new System.Windows.Forms.Button();
            this.richTextBoxCalculate = new System.Windows.Forms.RichTextBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonResetare = new System.Windows.Forms.Button();
            this.checkBoxMediatoare = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(44, 138);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1609, 604);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // checkBoxBisectoare
            // 
            this.checkBoxBisectoare.AutoSize = true;
            this.checkBoxBisectoare.Location = new System.Drawing.Point(1035, 33);
            this.checkBoxBisectoare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxBisectoare.Name = "checkBoxBisectoare";
            this.checkBoxBisectoare.Size = new System.Drawing.Size(97, 21);
            this.checkBoxBisectoare.TabIndex = 1;
            this.checkBoxBisectoare.Text = "Bisectoare";
            this.checkBoxBisectoare.UseVisualStyleBackColor = true;
            this.checkBoxBisectoare.CheckedChanged += new System.EventHandler(this.checkBoxBisectoare_CheckedChanged);
            // 
            // checkBoxMediane
            // 
            this.checkBoxMediane.AutoSize = true;
            this.checkBoxMediane.Location = new System.Drawing.Point(1035, 89);
            this.checkBoxMediane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMediane.Name = "checkBoxMediane";
            this.checkBoxMediane.Size = new System.Drawing.Size(84, 21);
            this.checkBoxMediane.TabIndex = 2;
            this.checkBoxMediane.Text = "Mediane";
            this.checkBoxMediane.UseVisualStyleBackColor = true;
            this.checkBoxMediane.CheckedChanged += new System.EventHandler(this.checkBoxMediane_CheckedChanged);
            // 
            // checkBoxInaltimi
            // 
            this.checkBoxInaltimi.AutoSize = true;
            this.checkBoxInaltimi.Location = new System.Drawing.Point(1191, 33);
            this.checkBoxInaltimi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxInaltimi.Name = "checkBoxInaltimi";
            this.checkBoxInaltimi.Size = new System.Drawing.Size(73, 21);
            this.checkBoxInaltimi.TabIndex = 3;
            this.checkBoxInaltimi.Text = "Inaltimi";
            this.checkBoxInaltimi.UseVisualStyleBackColor = true;
            this.checkBoxInaltimi.CheckedChanged += new System.EventHandler(this.checkBoxInaltimi_CheckedChanged);
            // 
            // checkBoxCercCircumscris
            // 
            this.checkBoxCercCircumscris.AutoSize = true;
            this.checkBoxCercCircumscris.Location = new System.Drawing.Point(1337, 31);
            this.checkBoxCercCircumscris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCercCircumscris.Name = "checkBoxCercCircumscris";
            this.checkBoxCercCircumscris.Size = new System.Drawing.Size(133, 21);
            this.checkBoxCercCircumscris.TabIndex = 4;
            this.checkBoxCercCircumscris.Text = "Cerc circumscris";
            this.checkBoxCercCircumscris.UseVisualStyleBackColor = true;
            this.checkBoxCercCircumscris.CheckedChanged += new System.EventHandler(this.checkBoxCercCircumscris_CheckedChanged);
            // 
            // checkBoxCercInscris
            // 
            this.checkBoxCercInscris.AutoSize = true;
            this.checkBoxCercInscris.Location = new System.Drawing.Point(1337, 89);
            this.checkBoxCercInscris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCercInscris.Name = "checkBoxCercInscris";
            this.checkBoxCercInscris.Size = new System.Drawing.Size(103, 21);
            this.checkBoxCercInscris.TabIndex = 5;
            this.checkBoxCercInscris.Text = "Cerc inscris";
            this.checkBoxCercInscris.UseVisualStyleBackColor = true;
            this.checkBoxCercInscris.CheckedChanged += new System.EventHandler(this.checkBoxCercInscris_CheckedChanged);
            // 
            // buttonRescrierePunct1
            // 
            this.buttonRescrierePunct1.Location = new System.Drawing.Point(44, 31);
            this.buttonRescrierePunct1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRescrierePunct1.Name = "buttonRescrierePunct1";
            this.buttonRescrierePunct1.Size = new System.Drawing.Size(149, 28);
            this.buttonRescrierePunct1.TabIndex = 6;
            this.buttonRescrierePunct1.Text = "Rescriere Punct1";
            this.buttonRescrierePunct1.UseVisualStyleBackColor = true;
            this.buttonRescrierePunct1.Click += new System.EventHandler(this.buttonRescrierePunct1_Click);
            // 
            // buttonRescrierePunct2
            // 
            this.buttonRescrierePunct2.Location = new System.Drawing.Point(227, 31);
            this.buttonRescrierePunct2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRescrierePunct2.Name = "buttonRescrierePunct2";
            this.buttonRescrierePunct2.Size = new System.Drawing.Size(149, 28);
            this.buttonRescrierePunct2.TabIndex = 7;
            this.buttonRescrierePunct2.Text = "Rescriere Punct 2";
            this.buttonRescrierePunct2.UseVisualStyleBackColor = true;
            this.buttonRescrierePunct2.Click += new System.EventHandler(this.buttonRescrierePunct2_Click);
            // 
            // buttonRescrierePunct3
            // 
            this.buttonRescrierePunct3.Location = new System.Drawing.Point(405, 31);
            this.buttonRescrierePunct3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRescrierePunct3.Name = "buttonRescrierePunct3";
            this.buttonRescrierePunct3.Size = new System.Drawing.Size(149, 28);
            this.buttonRescrierePunct3.TabIndex = 8;
            this.buttonRescrierePunct3.Text = "Rescriere Punct 3";
            this.buttonRescrierePunct3.UseVisualStyleBackColor = true;
            this.buttonRescrierePunct3.Click += new System.EventHandler(this.buttonRescrierePunct3_Click);
            // 
            // buttonAfisareValori
            // 
            this.buttonAfisareValori.Location = new System.Drawing.Point(405, 89);
            this.buttonAfisareValori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAfisareValori.Name = "buttonAfisareValori";
            this.buttonAfisareValori.Size = new System.Drawing.Size(149, 28);
            this.buttonAfisareValori.TabIndex = 9;
            this.buttonAfisareValori.Text = "Afisare Valori";
            this.buttonAfisareValori.UseVisualStyleBackColor = true;
            this.buttonAfisareValori.Click += new System.EventHandler(this.buttonAfisareValori_Click);
            // 
            // richTextBoxCalculate
            // 
            this.richTextBoxCalculate.Location = new System.Drawing.Point(577, 31);
            this.richTextBoxCalculate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxCalculate.Name = "richTextBoxCalculate";
            this.richTextBoxCalculate.Size = new System.Drawing.Size(363, 99);
            this.richTextBoxCalculate.TabIndex = 11;
            this.richTextBoxCalculate.Text = "";
            this.richTextBoxCalculate.TextChanged += new System.EventHandler(this.richTextBoxCalculate_TextChanged);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(1408, 768);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 28);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1553, 768);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 28);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonResetare
            // 
            this.buttonResetare.Location = new System.Drawing.Point(44, 89);
            this.buttonResetare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetare.Name = "buttonResetare";
            this.buttonResetare.Size = new System.Drawing.Size(149, 28);
            this.buttonResetare.TabIndex = 14;
            this.buttonResetare.Text = "RESETARE";
            this.buttonResetare.UseVisualStyleBackColor = true;
            this.buttonResetare.Click += new System.EventHandler(this.buttonResetare_Click);
            // 
            // checkBoxMediatoare
            // 
            this.checkBoxMediatoare.AutoSize = true;
            this.checkBoxMediatoare.Location = new System.Drawing.Point(1191, 89);
            this.checkBoxMediatoare.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMediatoare.Name = "checkBoxMediatoare";
            this.checkBoxMediatoare.Size = new System.Drawing.Size(101, 21);
            this.checkBoxMediatoare.TabIndex = 15;
            this.checkBoxMediatoare.Text = "Mediatoare";
            this.checkBoxMediatoare.UseVisualStyleBackColor = true;
            this.checkBoxMediatoare.CheckedChanged += new System.EventHandler(this.checkBoxMediatoare_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 811);
            this.Controls.Add(this.checkBoxMediatoare);
            this.Controls.Add(this.buttonResetare);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.richTextBoxCalculate);
            this.Controls.Add(this.buttonAfisareValori);
            this.Controls.Add(this.buttonRescrierePunct3);
            this.Controls.Add(this.buttonRescrierePunct2);
            this.Controls.Add(this.buttonRescrierePunct1);
            this.Controls.Add(this.checkBoxCercInscris);
            this.Controls.Add(this.checkBoxCercCircumscris);
            this.Controls.Add(this.checkBoxInaltimi);
            this.Controls.Add(this.checkBoxMediane);
            this.Controls.Add(this.checkBoxBisectoare);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxBisectoare;
        private System.Windows.Forms.CheckBox checkBoxMediane;
        private System.Windows.Forms.CheckBox checkBoxInaltimi;
        private System.Windows.Forms.CheckBox checkBoxCercCircumscris;
        private System.Windows.Forms.CheckBox checkBoxCercInscris;
        private System.Windows.Forms.Button buttonRescrierePunct1;
        private System.Windows.Forms.Button buttonRescrierePunct2;
        private System.Windows.Forms.Button buttonRescrierePunct3;
        private System.Windows.Forms.Button buttonAfisareValori;
        public System.Windows.Forms.RichTextBox richTextBoxCalculate;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonResetare;
        private System.Windows.Forms.CheckBox checkBoxMediatoare;
    }
}

