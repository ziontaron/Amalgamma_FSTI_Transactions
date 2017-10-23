namespace Amalgamma_FSTI_Transactions
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HangFS = new System.Windows.Forms.CheckBox();
            this.Procced = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FSTI_Trans = new System.Windows.Forms.Button();
            this.FSTI_CloseClient = new System.Windows.Forms.Button();
            this.FSTI_Login = new System.Windows.Forms.Button();
            this.FSTI_Ini = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Server_Stop = new System.Windows.Forms.Button();
            this.Server_Start = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textConfig = new System.Windows.Forms.TextBox();
            this.CFG_File = new System.Windows.Forms.Label();
            this.FS_Pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FS_User = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HangFS);
            this.tabPage1.Controls.Add(this.Procced);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.FSTI_Trans);
            this.tabPage1.Controls.Add(this.FSTI_CloseClient);
            this.tabPage1.Controls.Add(this.FSTI_Login);
            this.tabPage1.Controls.Add(this.FSTI_Ini);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Server_Stop);
            this.tabPage1.Controls.Add(this.Server_Start);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textConfig);
            this.tabPage1.Controls.Add(this.CFG_File);
            this.tabPage1.Controls.Add(this.FS_Pass);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.FS_User);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HangFS
            // 
            this.HangFS.AutoSize = true;
            this.HangFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HangFS.Location = new System.Drawing.Point(21, 158);
            this.HangFS.Name = "HangFS";
            this.HangFS.Size = new System.Drawing.Size(178, 17);
            this.HangFS.TabIndex = 30;
            this.HangFS.Text = "STAY CONNECTED TO FS";
            this.HangFS.UseVisualStyleBackColor = true;
            // 
            // Procced
            // 
            this.Procced.AutoSize = true;
            this.Procced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Procced.Location = new System.Drawing.Point(112, 314);
            this.Procced.Name = "Procced";
            this.Procced.Size = new System.Drawing.Size(0, 16);
            this.Procced.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "FSTI Transactions";
            // 
            // FSTI_Trans
            // 
            this.FSTI_Trans.Enabled = false;
            this.FSTI_Trans.Location = new System.Drawing.Point(21, 311);
            this.FSTI_Trans.Name = "FSTI_Trans";
            this.FSTI_Trans.Size = new System.Drawing.Size(75, 23);
            this.FSTI_Trans.TabIndex = 27;
            this.FSTI_Trans.Text = "Proceed";
            this.FSTI_Trans.UseVisualStyleBackColor = true;
            // 
            // FSTI_CloseClient
            // 
            this.FSTI_CloseClient.Enabled = false;
            this.FSTI_CloseClient.Location = new System.Drawing.Point(183, 181);
            this.FSTI_CloseClient.Name = "FSTI_CloseClient";
            this.FSTI_CloseClient.Size = new System.Drawing.Size(75, 23);
            this.FSTI_CloseClient.TabIndex = 26;
            this.FSTI_CloseClient.Text = "Close Client";
            this.FSTI_CloseClient.UseVisualStyleBackColor = true;
            this.FSTI_CloseClient.Visible = false;
            // 
            // FSTI_Login
            // 
            this.FSTI_Login.Enabled = false;
            this.FSTI_Login.Location = new System.Drawing.Point(102, 181);
            this.FSTI_Login.Name = "FSTI_Login";
            this.FSTI_Login.Size = new System.Drawing.Size(75, 23);
            this.FSTI_Login.TabIndex = 25;
            this.FSTI_Login.Text = "Login";
            this.FSTI_Login.UseVisualStyleBackColor = true;
            this.FSTI_Login.Visible = false;
            // 
            // FSTI_Ini
            // 
            this.FSTI_Ini.Enabled = false;
            this.FSTI_Ini.Location = new System.Drawing.Point(21, 181);
            this.FSTI_Ini.Name = "FSTI_Ini";
            this.FSTI_Ini.Size = new System.Drawing.Size(75, 23);
            this.FSTI_Ini.TabIndex = 24;
            this.FSTI_Ini.Text = "Initialize";
            this.FSTI_Ini.UseVisualStyleBackColor = true;
            this.FSTI_Ini.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "FSTI Client Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Server Status";
            // 
            // Server_Stop
            // 
            this.Server_Stop.Enabled = false;
            this.Server_Stop.Location = new System.Drawing.Point(102, 241);
            this.Server_Stop.Name = "Server_Stop";
            this.Server_Stop.Size = new System.Drawing.Size(75, 23);
            this.Server_Stop.TabIndex = 21;
            this.Server_Stop.Text = "Stop";
            this.Server_Stop.UseVisualStyleBackColor = true;
            // 
            // Server_Start
            // 
            this.Server_Start.Location = new System.Drawing.Point(21, 241);
            this.Server_Start.Name = "Server_Start";
            this.Server_Start.Size = new System.Drawing.Size(75, 23);
            this.Server_Start.TabIndex = 20;
            this.Server_Start.Text = "Start";
            this.Server_Start.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(556, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textConfig
            // 
            this.textConfig.Enabled = false;
            this.textConfig.Location = new System.Drawing.Point(86, 100);
            this.textConfig.Name = "textConfig";
            this.textConfig.Size = new System.Drawing.Size(464, 20);
            this.textConfig.TabIndex = 18;
            this.textConfig.Text = "m:\\mfgsys\\fs.cfg";
            // 
            // CFG_File
            // 
            this.CFG_File.AutoSize = true;
            this.CFG_File.Location = new System.Drawing.Point(18, 103);
            this.CFG_File.Name = "CFG_File";
            this.CFG_File.Size = new System.Drawing.Size(66, 13);
            this.CFG_File.TabIndex = 17;
            this.CFG_File.Text = "FS CFG File:";
            // 
            // FS_Pass
            // 
            this.FS_Pass.Location = new System.Drawing.Point(86, 74);
            this.FS_Pass.Name = "FS_Pass";
            this.FS_Pass.Size = new System.Drawing.Size(100, 20);
            this.FS_Pass.TabIndex = 16;
            this.FS_Pass.Text = "fstiapp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // FS_User
            // 
            this.FS_User.Location = new System.Drawing.Point(86, 48);
            this.FS_User.Name = "FS_User";
            this.FS_User.Size = new System.Drawing.Size(100, 20);
            this.FS_User.TabIndex = 14;
            this.FS_User.Text = "IMPT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Forth Shift Configuration";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(678, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pending Transactions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(672, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(678, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(672, 342);
            this.listBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 378);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Amalgamma FSTI Processor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textConfig;
        private System.Windows.Forms.Label CFG_File;
        private System.Windows.Forms.TextBox FS_Pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FS_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox HangFS;
        private System.Windows.Forms.Label Procced;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button FSTI_Trans;
        private System.Windows.Forms.Button FSTI_CloseClient;
        private System.Windows.Forms.Button FSTI_Login;
        private System.Windows.Forms.Button FSTI_Ini;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Server_Stop;
        private System.Windows.Forms.Button Server_Start;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

