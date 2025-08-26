namespace RSA
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
            this.textBox_key_n = new System.Windows.Forms.TextBox();
            this.textBox_key_d = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_text_input = new System.Windows.Forms.TextBox();
            this.textBox_text_output = new System.Windows.Forms.TextBox();
            this.button_text_encrypt = new System.Windows.Forms.Button();
            this.button_text_decrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_keys_generate = new System.Windows.Forms.Button();
            this.button_keys_change = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_key_e = new System.Windows.Forms.TextBox();
            this.button_keys_check = new System.Windows.Forms.Button();
            this.button_generatedKeysInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_key_n
            // 
            this.textBox_key_n.Location = new System.Drawing.Point(82, 61);
            this.textBox_key_n.Name = "textBox_key_n";
            this.textBox_key_n.Size = new System.Drawing.Size(364, 22);
            this.textBox_key_n.TabIndex = 0;
            // 
            // textBox_key_d
            // 
            this.textBox_key_d.Location = new System.Drawing.Point(82, 117);
            this.textBox_key_d.Name = "textBox_key_d";
            this.textBox_key_d.Size = new System.Drawing.Size(364, 22);
            this.textBox_key_d.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "N:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "D:";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(728, 442);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_text_input
            // 
            this.textBox_text_input.Location = new System.Drawing.Point(53, 206);
            this.textBox_text_input.Multiline = true;
            this.textBox_text_input.Name = "textBox_text_input";
            this.textBox_text_input.Size = new System.Drawing.Size(278, 180);
            this.textBox_text_input.TabIndex = 6;
            // 
            // textBox_text_output
            // 
            this.textBox_text_output.Location = new System.Drawing.Point(488, 206);
            this.textBox_text_output.Multiline = true;
            this.textBox_text_output.Name = "textBox_text_output";
            this.textBox_text_output.Size = new System.Drawing.Size(278, 180);
            this.textBox_text_output.TabIndex = 7;
            // 
            // button_text_encrypt
            // 
            this.button_text_encrypt.Location = new System.Drawing.Point(357, 254);
            this.button_text_encrypt.Name = "button_text_encrypt";
            this.button_text_encrypt.Size = new System.Drawing.Size(98, 35);
            this.button_text_encrypt.TabIndex = 8;
            this.button_text_encrypt.Text = "Encrypt";
            this.button_text_encrypt.UseVisualStyleBackColor = true;
            this.button_text_encrypt.Click += new System.EventHandler(this.button_text_encrypt_Click);
            // 
            // button_text_decrypt
            // 
            this.button_text_decrypt.Location = new System.Drawing.Point(357, 295);
            this.button_text_decrypt.Name = "button_text_decrypt";
            this.button_text_decrypt.Size = new System.Drawing.Size(98, 35);
            this.button_text_decrypt.TabIndex = 10;
            this.button_text_decrypt.Text = "Decrypt";
            this.button_text_decrypt.UseVisualStyleBackColor = true;
            this.button_text_decrypt.Click += new System.EventHandler(this.button_text_decrypt_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Input text:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(488, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output text:";
            // 
            // button_keys_generate
            // 
            this.button_keys_generate.Location = new System.Drawing.Point(481, 57);
            this.button_keys_generate.Name = "button_keys_generate";
            this.button_keys_generate.Size = new System.Drawing.Size(128, 26);
            this.button_keys_generate.TabIndex = 13;
            this.button_keys_generate.Text = "Generate keys";
            this.button_keys_generate.UseVisualStyleBackColor = true;
            this.button_keys_generate.Click += new System.EventHandler(this.button_keys_generate_Click);
            // 
            // button_keys_change
            // 
            this.button_keys_change.Location = new System.Drawing.Point(481, 111);
            this.button_keys_change.Name = "button_keys_change";
            this.button_keys_change.Size = new System.Drawing.Size(128, 28);
            this.button_keys_change.TabIndex = 14;
            this.button_keys_change.Text = "Change keys";
            this.button_keys_change.UseVisualStyleBackColor = true;
            this.button_keys_change.Click += new System.EventHandler(this.button_keys_change_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(53, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "E:";
            // 
            // textBox_key_e
            // 
            this.textBox_key_e.Location = new System.Drawing.Point(82, 89);
            this.textBox_key_e.Name = "textBox_key_e";
            this.textBox_key_e.Size = new System.Drawing.Size(364, 22);
            this.textBox_key_e.TabIndex = 16;
            // 
            // button_keys_check
            // 
            this.button_keys_check.Location = new System.Drawing.Point(481, 84);
            this.button_keys_check.Name = "button_keys_check";
            this.button_keys_check.Size = new System.Drawing.Size(128, 27);
            this.button_keys_check.TabIndex = 18;
            this.button_keys_check.Text = "Check keys";
            this.button_keys_check.UseVisualStyleBackColor = true;
            this.button_keys_check.Click += new System.EventHandler(this.button_keys_check_Click);
            // 
            // button_generatedKeysInfo
            // 
            this.button_generatedKeysInfo.Location = new System.Drawing.Point(615, 57);
            this.button_generatedKeysInfo.Name = "button_generatedKeysInfo";
            this.button_generatedKeysInfo.Size = new System.Drawing.Size(188, 26);
            this.button_generatedKeysInfo.TabIndex = 19;
            this.button_generatedKeysInfo.Text = "Generated keys info";
            this.button_generatedKeysInfo.UseVisualStyleBackColor = true;
            this.button_generatedKeysInfo.Click += new System.EventHandler(this.button_generatedKeysInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 489);
            this.Controls.Add(this.button_generatedKeysInfo);
            this.Controls.Add(this.button_keys_check);
            this.Controls.Add(this.textBox_key_e);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_keys_change);
            this.Controls.Add(this.button_keys_generate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_text_decrypt);
            this.Controls.Add(this.button_text_encrypt);
            this.Controls.Add(this.textBox_text_output);
            this.Controls.Add(this.textBox_text_input);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_key_d);
            this.Controls.Add(this.textBox_key_n);
            this.Name = "Form1";
            this.Text = "RSA";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button_generatedKeysInfo;

        private System.Windows.Forms.Button button_keys_check;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_key_e;

        private System.Windows.Forms.Button button_text_encrypt;
        private System.Windows.Forms.Button button_text_decrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_keys_generate;
        private System.Windows.Forms.Button button_keys_change;

        private System.Windows.Forms.TextBox textBox_text_output;

        private System.Windows.Forms.TextBox textBox_text_input;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_exit;

        private System.Windows.Forms.TextBox textBox_key_n;
        private System.Windows.Forms.TextBox textBox_key_d;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}