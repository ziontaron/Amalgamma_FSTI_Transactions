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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Up_Since = new System.Windows.Forms.Label();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._CB_SHIP13 = new System.Windows.Forms.CheckBox();
            this._CB_DOSERIAL = new System.Windows.Forms.CheckBox();
            this._CB_SHIP06 = new System.Windows.Forms.CheckBox();
            this._CB_DOPACK = new System.Windows.Forms.CheckBox();
            this._CB_DOSHIP = new System.Windows.Forms.CheckBox();
            this._CB_PICK00 = new System.Windows.Forms.CheckBox();
            this._CB_PICK12 = new System.Windows.Forms.CheckBox();
            this._CB_MORV = new System.Windows.Forms.CheckBox();
            this._CB_MOMT06 = new System.Windows.Forms.CheckBox();
            this._CB_IMTR = new System.Windows.Forms.CheckBox();
            this._CB_MOMT00 = new System.Windows.Forms.CheckBox();
            this._CB_IMTR_NEWLOT = new System.Windows.Forms.CheckBox();
            this._CB_SHIP02 = new System.Windows.Forms.CheckBox();
            this._CB_SHIP_PICK = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._CB_PICK08 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Up_Since);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(907, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 53);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 34);
            this.button1.TabIndex = 32;
            this.button1.Text = "Clear Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Up_Since
            // 
            this.Up_Since.AutoSize = true;
            this.Up_Since.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Up_Since.Location = new System.Drawing.Point(615, 25);
            this.Up_Since.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Up_Since.Name = "Up_Since";
            this.Up_Since.Size = new System.Drawing.Size(165, 17);
            this.Up_Since.TabIndex = 31;
            this.Up_Since.Text = "Up Since: 06/03/1987";
            // 
            // HangFS
            // 
            this.HangFS.AutoSize = true;
            this.HangFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HangFS.Location = new System.Drawing.Point(28, 194);
            this.HangFS.Margin = new System.Windows.Forms.Padding(4);
            this.HangFS.Name = "HangFS";
            this.HangFS.Size = new System.Drawing.Size(221, 21);
            this.HangFS.TabIndex = 30;
            this.HangFS.Text = "STAY CONNECTED TO FS";
            this.HangFS.UseVisualStyleBackColor = true;
            // 
            // Procced
            // 
            this.Procced.AutoSize = true;
            this.Procced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Procced.Location = new System.Drawing.Point(149, 386);
            this.Procced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Procced.Name = "Procced";
            this.Procced.Size = new System.Drawing.Size(0, 20);
            this.Procced.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 342);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "FSTI Transactions";
            // 
            // FSTI_Trans
            // 
            this.FSTI_Trans.Enabled = false;
            this.FSTI_Trans.Location = new System.Drawing.Point(28, 383);
            this.FSTI_Trans.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Trans.Name = "FSTI_Trans";
            this.FSTI_Trans.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Trans.TabIndex = 27;
            this.FSTI_Trans.Text = "Proceed";
            this.FSTI_Trans.UseVisualStyleBackColor = true;
            // 
            // FSTI_CloseClient
            // 
            this.FSTI_CloseClient.Enabled = false;
            this.FSTI_CloseClient.Location = new System.Drawing.Point(244, 223);
            this.FSTI_CloseClient.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_CloseClient.Name = "FSTI_CloseClient";
            this.FSTI_CloseClient.Size = new System.Drawing.Size(100, 28);
            this.FSTI_CloseClient.TabIndex = 26;
            this.FSTI_CloseClient.Text = "Close Client";
            this.FSTI_CloseClient.UseVisualStyleBackColor = true;
            this.FSTI_CloseClient.Visible = false;
            // 
            // FSTI_Login
            // 
            this.FSTI_Login.Enabled = false;
            this.FSTI_Login.Location = new System.Drawing.Point(136, 223);
            this.FSTI_Login.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Login.Name = "FSTI_Login";
            this.FSTI_Login.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Login.TabIndex = 25;
            this.FSTI_Login.Text = "Login";
            this.FSTI_Login.UseVisualStyleBackColor = true;
            this.FSTI_Login.Visible = false;
            // 
            // FSTI_Ini
            // 
            this.FSTI_Ini.Enabled = false;
            this.FSTI_Ini.Location = new System.Drawing.Point(28, 223);
            this.FSTI_Ini.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Ini.Name = "FSTI_Ini";
            this.FSTI_Ini.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Ini.TabIndex = 24;
            this.FSTI_Ini.Text = "Initialize";
            this.FSTI_Ini.UseVisualStyleBackColor = true;
            this.FSTI_Ini.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "FSTI Client Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Server Status";
            // 
            // Server_Stop
            // 
            this.Server_Stop.Enabled = false;
            this.Server_Stop.Location = new System.Drawing.Point(136, 297);
            this.Server_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Server_Stop.Name = "Server_Stop";
            this.Server_Stop.Size = new System.Drawing.Size(100, 28);
            this.Server_Stop.TabIndex = 21;
            this.Server_Stop.Text = "Stop";
            this.Server_Stop.UseVisualStyleBackColor = true;
            // 
            // Server_Start
            // 
            this.Server_Start.Location = new System.Drawing.Point(28, 297);
            this.Server_Start.Margin = new System.Windows.Forms.Padding(4);
            this.Server_Start.Name = "Server_Start";
            this.Server_Start.Size = new System.Drawing.Size(100, 28);
            this.Server_Start.TabIndex = 20;
            this.Server_Start.Text = "Start";
            this.Server_Start.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(741, 121);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 28);
            this.button3.TabIndex = 19;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textConfig
            // 
            this.textConfig.Enabled = false;
            this.textConfig.Location = new System.Drawing.Point(115, 123);
            this.textConfig.Margin = new System.Windows.Forms.Padding(4);
            this.textConfig.Name = "textConfig";
            this.textConfig.Size = new System.Drawing.Size(617, 22);
            this.textConfig.TabIndex = 18;
            this.textConfig.Text = "m:\\mfgsys\\fs.cfg";
            // 
            // CFG_File
            // 
            this.CFG_File.AutoSize = true;
            this.CFG_File.Location = new System.Drawing.Point(24, 127);
            this.CFG_File.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CFG_File.Name = "CFG_File";
            this.CFG_File.Size = new System.Drawing.Size(87, 17);
            this.CFG_File.TabIndex = 17;
            this.CFG_File.Text = "FS CFG File:";
            // 
            // FS_Pass
            // 
            this.FS_Pass.Location = new System.Drawing.Point(115, 91);
            this.FS_Pass.Margin = new System.Windows.Forms.Padding(4);
            this.FS_Pass.Name = "FS_Pass";
            this.FS_Pass.Size = new System.Drawing.Size(132, 22);
            this.FS_Pass.TabIndex = 16;
            this.FS_Pass.Text = "fstiapp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // FS_User
            // 
            this.FS_User.Location = new System.Drawing.Point(115, 59);
            this.FS_User.Margin = new System.Windows.Forms.Padding(4);
            this.FS_User.Name = "FS_User";
            this.FS_User.Size = new System.Drawing.Size(132, 22);
            this.FS_User.TabIndex = 14;
            this.FS_User.Text = "IMPT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Forth Shift Configuration";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(907, 436);
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
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(899, 428);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(907, 436);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(899, 428);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(907, 436);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Transaction Admin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._CB_PICK08);
            this.groupBox1.Controls.Add(this._CB_SHIP13);
            this.groupBox1.Controls.Add(this._CB_DOSERIAL);
            this.groupBox1.Controls.Add(this._CB_SHIP06);
            this.groupBox1.Controls.Add(this._CB_DOPACK);
            this.groupBox1.Controls.Add(this._CB_DOSHIP);
            this.groupBox1.Controls.Add(this._CB_PICK00);
            this.groupBox1.Controls.Add(this._CB_PICK12);
            this.groupBox1.Controls.Add(this._CB_MORV);
            this.groupBox1.Controls.Add(this._CB_MOMT06);
            this.groupBox1.Controls.Add(this._CB_IMTR);
            this.groupBox1.Controls.Add(this._CB_MOMT00);
            this.groupBox1.Controls.Add(this._CB_IMTR_NEWLOT);
            this.groupBox1.Controls.Add(this._CB_SHIP02);
            this.groupBox1.Controls.Add(this._CB_SHIP_PICK);
            this.groupBox1.Location = new System.Drawing.Point(33, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(662, 383);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Avaliable Transactions ";
            // 
            // _CB_SHIP13
            // 
            this._CB_SHIP13.AutoSize = true;
            this._CB_SHIP13.Location = new System.Drawing.Point(191, 195);
            this._CB_SHIP13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_SHIP13.Name = "_CB_SHIP13";
            this._CB_SHIP13.Size = new System.Drawing.Size(77, 21);
            this._CB_SHIP13.TabIndex = 13;
            this._CB_SHIP13.Text = "SHIP13";
            this._CB_SHIP13.UseVisualStyleBackColor = true;
            // 
            // _CB_DOSERIAL
            // 
            this._CB_DOSERIAL.AutoSize = true;
            this._CB_DOSERIAL.Location = new System.Drawing.Point(191, 169);
            this._CB_DOSERIAL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_DOSERIAL.Name = "_CB_DOSERIAL";
            this._CB_DOSERIAL.Size = new System.Drawing.Size(99, 21);
            this._CB_DOSERIAL.TabIndex = 12;
            this._CB_DOSERIAL.Text = "DOSERIAL";
            this._CB_DOSERIAL.UseVisualStyleBackColor = true;
            // 
            // _CB_SHIP06
            // 
            this._CB_SHIP06.AutoSize = true;
            this._CB_SHIP06.Location = new System.Drawing.Point(191, 90);
            this._CB_SHIP06.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_SHIP06.Name = "_CB_SHIP06";
            this._CB_SHIP06.Size = new System.Drawing.Size(77, 21);
            this._CB_SHIP06.TabIndex = 11;
            this._CB_SHIP06.Text = "SHIP06";
            this._CB_SHIP06.UseVisualStyleBackColor = true;
            // 
            // _CB_DOPACK
            // 
            this._CB_DOPACK.AutoSize = true;
            this._CB_DOPACK.Location = new System.Drawing.Point(191, 142);
            this._CB_DOPACK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_DOPACK.Name = "_CB_DOPACK";
            this._CB_DOPACK.Size = new System.Drawing.Size(87, 21);
            this._CB_DOPACK.TabIndex = 10;
            this._CB_DOPACK.Text = "DOPACK";
            this._CB_DOPACK.UseVisualStyleBackColor = true;
            // 
            // _CB_DOSHIP
            // 
            this._CB_DOSHIP.AutoSize = true;
            this._CB_DOSHIP.Location = new System.Drawing.Point(191, 116);
            this._CB_DOSHIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_DOSHIP.Name = "_CB_DOSHIP";
            this._CB_DOSHIP.Size = new System.Drawing.Size(82, 21);
            this._CB_DOSHIP.TabIndex = 9;
            this._CB_DOSHIP.Text = "DOSHIP";
            this._CB_DOSHIP.UseVisualStyleBackColor = true;
            // 
            // _CB_PICK00
            // 
            this._CB_PICK00.AutoSize = true;
            this._CB_PICK00.Location = new System.Drawing.Point(24, 195);
            this._CB_PICK00.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_PICK00.Name = "_CB_PICK00";
            this._CB_PICK00.Size = new System.Drawing.Size(76, 21);
            this._CB_PICK00.TabIndex = 8;
            this._CB_PICK00.Text = "PICK00";
            this._CB_PICK00.UseVisualStyleBackColor = true;
            // 
            // _CB_PICK12
            // 
            this._CB_PICK12.AutoSize = true;
            this._CB_PICK12.Location = new System.Drawing.Point(24, 169);
            this._CB_PICK12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_PICK12.Name = "_CB_PICK12";
            this._CB_PICK12.Size = new System.Drawing.Size(76, 21);
            this._CB_PICK12.TabIndex = 7;
            this._CB_PICK12.Text = "PICK12";
            this._CB_PICK12.UseVisualStyleBackColor = true;
            // 
            // _CB_MORV
            // 
            this._CB_MORV.AutoSize = true;
            this._CB_MORV.Location = new System.Drawing.Point(24, 36);
            this._CB_MORV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_MORV.Name = "_CB_MORV";
            this._CB_MORV.Size = new System.Drawing.Size(87, 21);
            this._CB_MORV.TabIndex = 0;
            this._CB_MORV.Text = "MORV00";
            this._CB_MORV.UseVisualStyleBackColor = true;
            // 
            // _CB_MOMT06
            // 
            this._CB_MOMT06.AutoSize = true;
            this._CB_MOMT06.Location = new System.Drawing.Point(24, 143);
            this._CB_MOMT06.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_MOMT06.Name = "_CB_MOMT06";
            this._CB_MOMT06.Size = new System.Drawing.Size(88, 21);
            this._CB_MOMT06.TabIndex = 6;
            this._CB_MOMT06.Text = "MOMT06";
            this._CB_MOMT06.UseVisualStyleBackColor = true;
            // 
            // _CB_IMTR
            // 
            this._CB_IMTR.AutoSize = true;
            this._CB_IMTR.Location = new System.Drawing.Point(24, 63);
            this._CB_IMTR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_IMTR.Name = "_CB_IMTR";
            this._CB_IMTR.Size = new System.Drawing.Size(79, 21);
            this._CB_IMTR.TabIndex = 1;
            this._CB_IMTR.Text = "IMTR01";
            this._CB_IMTR.UseVisualStyleBackColor = true;
            // 
            // _CB_MOMT00
            // 
            this._CB_MOMT00.AutoSize = true;
            this._CB_MOMT00.Location = new System.Drawing.Point(24, 116);
            this._CB_MOMT00.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_MOMT00.Name = "_CB_MOMT00";
            this._CB_MOMT00.Size = new System.Drawing.Size(88, 21);
            this._CB_MOMT00.TabIndex = 5;
            this._CB_MOMT00.Text = "MOMT00";
            this._CB_MOMT00.UseVisualStyleBackColor = true;
            // 
            // _CB_IMTR_NEWLOT
            // 
            this._CB_IMTR_NEWLOT.AutoSize = true;
            this._CB_IMTR_NEWLOT.Location = new System.Drawing.Point(24, 90);
            this._CB_IMTR_NEWLOT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_IMTR_NEWLOT.Name = "_CB_IMTR_NEWLOT";
            this._CB_IMTR_NEWLOT.Size = new System.Drawing.Size(134, 21);
            this._CB_IMTR_NEWLOT.TabIndex = 2;
            this._CB_IMTR_NEWLOT.Text = "IMTR01 New Lot";
            this._CB_IMTR_NEWLOT.UseVisualStyleBackColor = true;
            // 
            // _CB_SHIP02
            // 
            this._CB_SHIP02.AutoSize = true;
            this._CB_SHIP02.Location = new System.Drawing.Point(191, 63);
            this._CB_SHIP02.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_SHIP02.Name = "_CB_SHIP02";
            this._CB_SHIP02.Size = new System.Drawing.Size(77, 21);
            this._CB_SHIP02.TabIndex = 4;
            this._CB_SHIP02.Text = "SHIP02";
            this._CB_SHIP02.UseVisualStyleBackColor = true;
            // 
            // _CB_SHIP_PICK
            // 
            this._CB_SHIP_PICK.AutoSize = true;
            this._CB_SHIP_PICK.Location = new System.Drawing.Point(191, 36);
            this._CB_SHIP_PICK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_SHIP_PICK.Name = "_CB_SHIP_PICK";
            this._CB_SHIP_PICK.Size = new System.Drawing.Size(111, 21);
            this._CB_SHIP_PICK.TabIndex = 3;
            this._CB_SHIP_PICK.Text = "SHIP PICK18";
            this._CB_SHIP_PICK.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _CB_PICK08
            // 
            this._CB_PICK08.AutoSize = true;
            this._CB_PICK08.Location = new System.Drawing.Point(24, 220);
            this._CB_PICK08.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CB_PICK08.Name = "_CB_PICK08";
            this._CB_PICK08.Size = new System.Drawing.Size(76, 21);
            this._CB_PICK08.TabIndex = 14;
            this._CB_PICK08.Text = "PICK08";
            this._CB_PICK08.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 465);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Amalgamma FSTI Processor V 3.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label Up_Since;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox _CB_SHIP02;
        private System.Windows.Forms.CheckBox _CB_SHIP_PICK;
        private System.Windows.Forms.CheckBox _CB_IMTR_NEWLOT;
        private System.Windows.Forms.CheckBox _CB_IMTR;
        private System.Windows.Forms.CheckBox _CB_MORV;
        private System.Windows.Forms.CheckBox _CB_MOMT06;
        private System.Windows.Forms.CheckBox _CB_MOMT00;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _CB_PICK12;
        private System.Windows.Forms.CheckBox _CB_PICK00;
        private System.Windows.Forms.CheckBox _CB_DOPACK;
        private System.Windows.Forms.CheckBox _CB_DOSHIP;
        private System.Windows.Forms.CheckBox _CB_SHIP06;
        private System.Windows.Forms.CheckBox _CB_SHIP13;
        private System.Windows.Forms.CheckBox _CB_DOSERIAL;
        private System.Windows.Forms.CheckBox _CB_PICK08;
    }
}

