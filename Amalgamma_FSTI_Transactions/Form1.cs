using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Amalgamma_FSTI_Transactions
{
    public partial class Form1 : Form
    {
        #region GlobalVars

        //se cambiaron las referencias de las librerias de FSTI a la version de FS 7.5

        //Amalgamma Sand Box
        //Data_Base_MNG.SQL DBMNG = new Data_Base_MNG.SQL("RSSERVER", "AmalgammaDB_SB", "amalgamma", "capsonic");//el paso

        //Amalgamma Produccion
        Data_Base_MNG.SQL DBMNG = new Data_Base_MNG.SQL("192.168.0.11", "AmalgammaDB", "amalgamma", "capsonic");//el paso
        //Data_Base_MNG.SQL DBMNG_FS = new Data_Base_MNG.SQL("192.168.0.9", "FSDBMR", "sa", "6rzq4d1");//el paso
        Data_Base_MNG.SQL DBMNG_FS = new Data_Base_MNG.SQL("192.168.0.9", "FSDBMR", "AmalAdmin", "Amalgamma16");//el paso

        FS4Amalgamma.AmalgammaFSTI FSTI;

        TOOLS.Dataloger LOGGER = new TOOLS.Dataloger("Amalgamma_FSTI", "log", "");
        
        //inifile
        TOOLS.INIFile MyINIFile = new TOOLS.INIFile("AmalgammaServer.ini");
        List<string> ActiveTransactions_list  = new List<string>();

        string ErrorDBinUse = "Data Temporarily In Use ... Please Try Again";
        string ErrorDBinUse2 = "Manufacturing Data Base In Use ... Please Try Again         ";
        string ActiveTransactions = "";
        #endregion
        
        public Form1()
        {
            InitializeComponent();

            if (!IsSingleInstance())
            {
                this.Close();
            }
            LoadInifile();
            LoadActiveTransactions();
            FSTI = new FS4Amalgamma.AmalgammaFSTI(textConfig.Text, FS_User.Text, FS_Pass.Text);
            //FSTI.AmalgammaFSTI_Initialization();
            //FSTI.AmalgammaFSTI_Logon();

            timer1.Enabled = true;

            Up_Since.Text = "Up Since: " + DateTime.Now.ToString("MM/dd/yyy hh:mm tt");
            this.Text = "Amalgamma FSTI Processor V 10.1";
            //MessageBox.Show(DateTime.Now.ToString("tt"));
            //TestFunc();
        }
        private void TestFunc()
        {
        }
        private void LoadInifile()
        {
            foreach (CheckBox Transaction in groupBox1.Controls)
            {
                Transaction.Checked = Convert.ToBoolean(MyINIFile.GetValue("ActiveTransactions", Transaction.Name.Replace("_CB_",""), ""));
            }

        }

        private void MO_SetUp_LabelUPD(string FSTI_fields)
        {
            #region UPDATE LABEL


            //MO_NO, LABEL_QTY, PART NO, BoxSerial
            //    0,         1,       2,         3
            string[] Fields_Array = FSTI_fields.Split(',');

            string MO_Ln_Q = "SELECT FS_MOLine.MOLineNumber, FS_Item.ItemNumber, FS_MOLine.MOLineKey " +
            " FROM FS_MOHeader INNER JOIN " +
            " FS_MOLine ON FS_MOHeader.MOHeaderKey = FS_MOLine.MOHeaderKey INNER JOIN " +
            " FS_Item ON FS_MOLine.ItemKey = FS_Item.ItemKey " +
            " WHERE     (FS_MOHeader.MONumber = '" + Fields_Array[0] + "') AND (FS_MOLine.MOLineStatus = '4')  " +
            " AND (FS_Item.ItemNumber = '" + Fields_Array[2] + "') " +
            " ORDER BY FS_MOLine.MOLineKey DESC";


            string _MOLn = DBMNG_FS.Execute_Scalar(MO_Ln_Q);


            if (_MOLn.Length < 3)
            {
                for (int i = _MOLn.Length; i < 3; i++)
                {
                    _MOLn = "0" + _MOLn;
                }
            }


            #region Label Update

            string Label_UPD_Q = "UPDATE Amal_Labels SET [MO_NO] = '" + Fields_Array[0] + "' ,[MO_Line] = '" + _MOLn + "' " +
                    " WHERE (serial = N'" + Fields_Array[3] + "')";

            DBMNG.Execute_Command(Label_UPD_Q);

            #endregion


            #endregion


        }
        private bool IsSingleInstance()
        {
            string proceso = "", esta = "", name = "";
            int count = 0;
            foreach (Process process in Process.GetProcesses())
            {
                name = process.ProcessName;
                proceso = process.MainWindowTitle;
                esta = this.Text;
                if (process.MainWindowTitle == this.Text)
                {
                    //MessageBox.Show(name + " " + proceso + " " + esta+" "+count.ToString());
                    count++;
                }
            }
            if (count <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region Process Transactions
        private void ProcessTransaction()
        {
            string fields = "";
            string user = "";
            string TransactionKey ="";
            try
            {
                if (FSTI.AmalgammaFSTI_Initialization())
                {
                    if (FSTI.AmalgammaFSTI_Logon())
                    {
                        #region Processing
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            LoadActiveTransactions();
                            TransactionKey = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            if (ActiveTransactions.Contains(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                            {
                                switch (dataGridView1.Rows[i].Cells[1].Value.ToString())
                                {
                                    #region MORV
                                    case "MORV":
                                        {
                                            #region Check MO Balance

                                            #region DoMorv
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();

                                            //Balance Checking
                                            string[] Fields_Array = fields.Split(',');

                                            string MO_Balance_Check_Q = "SELECT (FS_MOLine.ItemOrderedQuantity- FS_MOLine.ReceiptQuantity) as Balance FROM FS_MOLine INNER JOIN " +
                                            "FS_MOHeader ON FS_MOLine.MOHeaderKey = FS_MOHeader.MOHeaderKey " +
                                            "WHERE (FS_MOHeader.MONumber = '" + Fields_Array[0] + "') AND (FS_MOLine.MOLineNumber = '" +
                                            Fields_Array[1] + "')";

                                            int Balance = Convert.ToInt32(DBMNG_FS.Execute_Scalar(MO_Balance_Check_Q));

                                            #endregion
                                            if (Balance > 0)
                                            {
                                                #region DO FSTI
                                                if (FSTI.AmalgammaFSTI_MORV00(fields, user))
                                                {
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                                   "    ,FSError = 0" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("MORV - " + fields + " - Transaction was successfully processed.", "info");
                                                }
                                                else
                                                {
                                                    if (!FSTI.DBinUseFlag)
                                                    {
                                                        listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                        string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                        string query = "UPDATE Amal_FSTI_Transactions " +
                                                                       " SET TransactionProcessedYN = 1 " +
                                                                       "    ,FSResponse = '" + error + "'" +
                                                                       "    ,FSError = 1" +
                                                                       "    ,DateStampOut = GetDate()" +
                                                                       " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                        DBMNG.Execute_Command(query);
                                                        ProcessingLog("MORV - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                    }
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = 'The Mo Balance must be grater than " + Balance.ToString()+ "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("MORV - " + fields + " Error During Procesing Transaction - The Mo Balance must be grater than " + Balance.ToString() + ".", "error");
                                                
                                            }

                                            #endregion

                                            break;
                                        }
                                    #endregion
                                    #region IMTR
                                    case "IMTR":
                                        {
                                            #region IMTR
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();


                                            //IntemNumber,STK-BINFrom,InvCatFrom,STK-BINTo,InvCatTo,Qty,lot,lot_to
                                            //          0,          1,         2,        3,       4,  5,  6,     7
                                            string[] Fields_Array = fields.Split(',');

                                            string LOT_CHECK = Fields_Array[6];
                                            string HWS_lots = "SELECT LotNumber, Stockroom+'-'+ Bin AS STKBIN, InventoryCategory, InventoryQuantity " +
                                                                  "FROM FS_ItemInventory WHERE (LotNumber LIKE '" + LOT_CHECK + "-%')";
                                                DataTable HWS_LOTS_T = DBMNG_FS.Execute_Query(HWS_lots);

                                                if (LOT_CHECK.Contains("HWS") && !LOT_CHECK.Contains("-") && HWS_LOTS_T.Rows.Count!=0)
                                            {
                                                
                                                string IMTR_KEYS = "";
                                                for (int j = 0; j < HWS_LOTS_T.Rows.Count; j++)
                                                {
                                                    //IntemNumber,STK-BINFrom,InvCatFrom,STK-BINTo,InvCatTo,Qty,lot,lot_to
                                                    //          0,          1,         2,        3,       4,  5,  6,     7
                                                    string FIELDS = Fields_Array[0]
                                                        + "," + HWS_LOTS_T.Rows[j]["STKBIN"].ToString()
                                                        + "," + HWS_LOTS_T.Rows[j]["InventoryCategory"].ToString()
                                                        + "," + Fields_Array[3]
                                                        + "," + HWS_LOTS_T.Rows[j]["InventoryCategory"].ToString()
                                                        + "," + HWS_LOTS_T.Rows[j]["InventoryQuantity"].ToString()
                                                        + "," + HWS_LOTS_T.Rows[j]["LotNumber"].ToString();

                                                    string HWS_LOTS_IMTR = "INSERT INTO Amal_FSTI_Transactions (TransactionType, TransactionStringFields, AmalgammaUser, DateStampIn) " +
                                                        " VALUES ('IMTR' , '" + FIELDS + "', 'VBS - " + user + "', GetDate()) @@IDENTITY";
                                                    IMTR_KEYS += "|" + DBMNG.Execute_Scalar(HWS_LOTS_IMTR);
                                                }
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = 'IMTRTransacction keys: " + IMTR_KEYS + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("IMTR - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (FSTI.AmalgammaFSTI_IMTR01(fields, user))
                                                {
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                                   "    ,FSError = 0" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("IMTR - " + fields + " - Transaction was successfully processed.", "info");

                                                }
                                                else
                                                {
                                                    if (!FSTI.DBinUseFlag)
                                                    {
                                                        listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                        string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                        string query = "UPDATE Amal_FSTI_Transactions " +
                                                                       " SET TransactionProcessedYN = 1 " +
                                                                       "    ,FSResponse = '" + error + "'" +
                                                                       "    ,FSError = 1" +
                                                                       "    ,DateStampOut = GetDate()" +
                                                                       " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                        DBMNG.Execute_Command(query);
                                                        ProcessingLog("IMTR - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                    }
                                                }
                                            }
                                            #endregion
                                            break;
                                        }

                                    #endregion
                                    #region IMTR_NEWLOT
                                    case "IMTR_NEWLOT":
                                        {
                                            #region IMTR
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_IMTR01_NEWLOT(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("IMTR_NEWLOT - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("IMTR_NEWLOT - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion

                                    #region IMTR_RELABEL
                                    case "IMTR_RELABEL":
                                        {
                                            #region IMTR_RELABEL
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();

                                            
                                            //IntemNumber,STK-BINFrom,InvCatFrom,STK-BINTo,InvCatTo,Qty,lot,lot_to,Newlot
                                            //          0,          1,         2,        3,       4,  5,  6,     7,     8
                                            string[] Fields_Array = fields.Split(',');

                                            string LOT_CHECK = Fields_Array[6];

                                            string LOTINFO_Q = "SELECT FS_Item.ItemNumber, FS_ItemInventory.Stockroom +'-'+ FS_ItemInventory.Bin AS STKBIN "+
                                                        ", FS_ItemInventory.InventoryCategory, FS_ItemInventory.InventoryQuantity, FS_ItemInventory.LotNumber "+
                                                        "FROM FS_Item INNER JOIN FS_ItemInventory ON FS_Item.ItemKey = FS_ItemInventory.ItemKey "+
                                                        "WHERE (FS_ItemInventory.LotNumber = '" + LOT_CHECK + "')";

                                            DataTable LOTINFO_T = DBMNG_FS.Execute_Query(LOTINFO_Q);

                                            //string 







                                            if (FSTI.AmalgammaFSTI_IMTR01(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("IMTR_RELABEL - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("IMTR_RELABEL - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            
                                            #endregion
                                            break;
                                        }
                                    #endregion

                                    #region SHIP_PICK
                                    case "SHIP_PICK":
                                        {
                                            #region PICK
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_SHIP_PICK18(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("SHIP_PICK - " + fields + " - Transaction was successfully processed.", "info");


                                                #region FOR SHIP STAGE
                                                ///////////////////////////////////////////////
                                                try
                                                {
                                                    //CO, CO_LN, PN, STK_FROM, BIN_FROM, IC, QTY, LOT, USER
                                                    // 0,     1,  2,        3,        4,  5,   6,   7,    8

                                                    //TKP-112113-01,098,205050,NO,NORTH,O,160,05020116069614,VB - CJ
                                                    string[] Fields_Array = fields.Split(',');
                                                    string VBUser = Fields_Array[8];
                                                    string CUST_ID_Q = "SELECT FS_COHeader.CustomerID FROM FS_COHeader INNER JOIN "+
                                                            " FS_COLine ON FS_COHeader.COHeaderKey = FS_COLine.COHeaderKey "+
                                                            " WHERE (FS_COLine.COLineNumber = " + Fields_Array[1] + ") AND (FS_COHeader.CONumber = '" + Fields_Array[0] + "')";
                                                    string CUST_ID = DBMNG_FS.Execute_Scalar(CUST_ID_Q); ;

                                                    //CO, SHIP_NO, SHIP_REF, CO_LN_NO, QTY, LOT, ITEM_NO
                                                    // 0,       1,        2,        3,   4,   5,       6
                                                    string Stage_Package_Q = "INSERT INTO _CAP_VB_STAGE_SHIPPING (CO,LN,ITEM_PN,QTY,VB_USER,CUST_ID,LOT_NO,SHIP_NO) " +
                                                        "VALUES ('" + Fields_Array[0] + "','" + Fields_Array[1] + "','" + Fields_Array[2] + "'," + Fields_Array[6] +
                                                        ",'" + VBUser.Replace("VB - ", "") + "','" + CUST_ID +"','" + Fields_Array[7] + "','-')";

                                                    DBMNG_FS.Execute_Command(Stage_Package_Q);
                                                }
                                                catch { }
                                                ///////////////////////////////////////////////
                                                #endregion
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("SHIP_PICK - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region SHIP
                                    case "SHIP02":
                                        {
                                            #region SHIP02
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_SHIP02(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("SHIP02 - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("SHIP02 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region SHIP06
                                    case "SHIP06":
                                        {
                                            #region SHIP06
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_SHIP06(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("SHIP06 - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("SHIP06 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region DOSHIP
                                    case "DOSHIP":
                                        {
                                            string DoShipFields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                            string[] DoShipFields_Array = DoShipFields.Split(',');

                                            string PN_Serialized = "";

                                            string Transaction_Key = "|";

                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            //fields
                                            // CustomerID, ShipNo, ShipRef
                                            //          0,      1,       3

                                            string CUST_ID = DoShipFields_Array[0];
                                            string SHIP_NO = DoShipFields_Array[1];

                                            //DO SHIP
                                            #region DOSHIP
                                            try
                                            {
                                                //saca la informacion de enbarque del cliente
                                                string CustomerShipInfo_Q = "SELECT V_CO_DETAIL.SHIP_TO_ID, V_CO_HEADER.SHIP_VIA, V_CO_HEADER.IVC_COD, V_CO_HEADER.FRT_CHG_CD " +
                                                    " FROM (V_CO_DETAIL INNER JOIN V_CO_HEADER ON V_CO_DETAIL.COHeaderKey = V_CO_HEADER.COHeaderKey) INNER JOIN V_ITEM_INV ON V_CO_DETAIL.ItemKey = V_ITEM_INV.ItemKey " +
                                                    " WHERE ( ((V_CO_DETAIL.CUST_ID)='" + DoShipFields_Array[0] + "') AND((V_CO_DETAIL.LN_STA)='4') AND (([ISSUED_QTY]-[TOT_SHPPED])>0) AND ((V_ITEM_INV.STK_ROOM)='EL') AND ((V_ITEM_INV.BIN)='SHIP')  " +
                                                    " AND ((V_ITEM_INV.QTY_BY_LOC)>0)) GROUP BY V_CO_DETAIL.SHIP_TO_ID, V_CO_HEADER.SHIP_VIA, V_CO_HEADER.IVC_COD, V_CO_HEADER.FRT_CHG_CD";

                                                DataTable CustomerShipInfo_T = DBMNG_FS.Execute_Query(CustomerShipInfo_Q);

                                                string SHIP_TO_ID = CustomerShipInfo_T.Rows[0]["SHIP_TO_ID"].ToString();
                                                string SHIP_VIA = CustomerShipInfo_T.Rows[0]["SHIP_VIA"].ToString();
                                                string IVC_COD = CustomerShipInfo_T.Rows[0]["IVC_COD"].ToString();
                                                string FRT_CHG_CD = CustomerShipInfo_T.Rows[0]["FRT_CHG_CD"].ToString();

                                                //saca los num de parte hechos pick para el cliente
                                                string PickedItems_Q = "SELECT V_CO_DETAIL.CO_NUMBER, V_CO_DETAIL.CO_LN_NO, V_CO_DETAIL.CUST_ID, V_CO_DETAIL.SHIP_TO_ID, V_CO_DETAIL.LN_TYPE " +
                                                    " , V_CO_DETAIL.ITEM, V_CO_DETAIL.LN_STA, V_CO_DETAIL.ORDER_QTY, [ISSUED_QTY]-[TOT_SHPPED] AS OPENQTY, V_CO_HEADER.CUST_PO_NO " +
                                                    " , V_CO_DETAIL.CUST_ITEM, V_CO_DETAIL.CUST_PO_LN, V_ITEM_INV.STK_ROOM, V_ITEM_INV.BIN, V_ITEM_INV.INV_CATGRY, V_ITEM_INV.QTY_BY_LOC " +
                                                    " , V_CO_HEADER.SHIP_VIA, V_CO_HEADER.FRT_CHG_CD, V_CO_HEADER.IVC_COD, V_CO_DETAIL.ISSUED_QTY, V_ITEM_INV.IN_SHP_QTY, V_ITEM_INV.LOT " +
                                                    " FROM (V_CO_DETAIL INNER JOIN V_CO_HEADER ON V_CO_DETAIL.COHeaderKey = V_CO_HEADER.COHeaderKey) INNER JOIN V_ITEM_INV  " +
                                                    " ON V_CO_DETAIL.ItemKey = V_ITEM_INV.ItemKey " +
                                                    " WHERE (((V_CO_DETAIL.CUST_ID)='" + DoShipFields_Array[0] + "') AND ((V_CO_DETAIL.SHIP_TO_ID)='" + SHIP_TO_ID + "') AND ((V_CO_DETAIL.LN_STA)='4')  " +
                                                    " AND (([ISSUED_QTY]-[TOT_SHPPED])>0) AND ((V_ITEM_INV.STK_ROOM)='EL') AND ((V_ITEM_INV.BIN)='SHIP') AND ((V_ITEM_INV.QTY_BY_LOC)>0)  " +
                                                    " AND ((V_CO_HEADER.SHIP_VIA)='" + SHIP_VIA + "') AND ((V_CO_HEADER.FRT_CHG_CD)='" + FRT_CHG_CD + "') AND ((V_CO_HEADER.IVC_COD)='" + IVC_COD + "'))";

                                                string StagedItems_By_Packer = "SELECT Ship_Stage_Key, CO AS CO_NUMBER, LN AS CO_LN_NO, ITEM_PN AS ITEM " +
                                                                    ", QTY AS QTY_BY_LOC, LOT_NO AS LOT, SHIP_NO, VB_USER " +
                                                                    "FROM _CAP_VB_STAGE_SHIPPING WHERE (VB_USER = N'" + user.Replace("VB - ", "") + "') AND (SHIP_NO = N'-')";

                                                //DataTable PickedItems_T = DBMNG_FS.Execute_Query(PickedItems_Q);
                                                //DataTable StagedItems_By_Packer_T = DBMNG_FS.Execute_Query(StagedItems_By_Packer);

                                                DataTable PickedItems_T = DBMNG_FS.Execute_Query(StagedItems_By_Packer);
                                                for (int r = 0; r < PickedItems_T.Rows.Count; r++)
                                                {
                                                    //[r]["Ship_Stage_Key"]

                                                    try
                                                    {
                                                        string Stage_Package_Update_Q = "UPDATE _CAP_VB_STAGE_SHIPPING SET SHIP_NO = '" + DoShipFields_Array[1] + "' " +
                                                                                        "WHERE (Ship_Stage_Key = " + PickedItems_T.Rows[r]["Ship_Stage_Key"].ToString() + ")";

                                                        DBMNG_FS.Execute_Command(Stage_Package_Update_Q);
                                                    }
                                                    catch
                                                    { }

                                                }

                                                //CO, SHIP_NO, SHIP_REF, CO_LN_NO, QTY, LOT
                                                // 0,       1,        2,        3,   4,   5

                                                //hace la transaccion de SHIP02
                                                for (int j = 0; j < PickedItems_T.Rows.Count; j++)
                                                {
                                                    ///DO SHIP TRANSACTIONS
                                                    ///
                                                    string CO_LN_NO = PickedItems_T.Rows[j]["CO_LN_NO"].ToString();
                                                    if (CO_LN_NO.Length < 3)
                                                    {
                                                        if (CO_LN_NO.Length == 2)
                                                        {
                                                            CO_LN_NO = "0" + CO_LN_NO;
                                                        }
                                                        if (CO_LN_NO.Length == 1)
                                                        {
                                                            CO_LN_NO = "00" + CO_LN_NO;
                                                        }

                                                    }

                                                    fields = PickedItems_T.Rows[j]["CO_NUMBER"] + "," +
                                                        DoShipFields_Array[1] + "," +
                                                        DoShipFields_Array[2] + "," +
                                                        CO_LN_NO + "," +
                                                        PickedItems_T.Rows[j]["QTY_BY_LOC"] + "," +
                                                        PickedItems_T.Rows[j]["LOT"] + "," +
                                                        PickedItems_T.Rows[j]["ITEM"];

                                                    string Trans_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                        " [AmalgammaUser]) VALUES ('SHIP02', '" + fields + "', '" + user + "') SELECT @@IDENTITY";

                                                    Transaction_Key += "," + DBMNG.Execute_Scalar(Trans_Q);

                                                    string[] Fields_Array = fields.Split(',');


                                                    //DESCOMENTAR POR SI FALLA
                                                    //if (user.Contains("VB - "))
                                                    //{
                                                    //    //CO, SHIP_NO, SHIP_REF, CO_LN_NO, QTY, LOT, ITEM_NO
                                                    //    // 0,       1,        2,        3,   4,   5,       6
                                                    //    string Stage_Package_Q = "INSERT INTO _CAP_VB_STAGE_SHIPPING (CO,LN,ITEM_PN,QTY,VB_USER,CUST_ID,SHIP_NO) " +
                                                    //        "VALUES ('" + Fields_Array[0] + "','" + Fields_Array[3] + "','" + Fields_Array[6] + "'," + Fields_Array[4] +
                                                    //        ",'" + user.Replace("VB - ", "") + "','" + CUST_ID + "','" + Fields_Array[1] + "')";

                                                    //    DBMNG_FS.Execute_Command(Stage_Package_Q);
                                                    //    //try
                                                    //    //{
                                                    //    //    string Stage_Package_Update_Q = "UPDATE _CAP_VB_STAGE_SHIPPING_TEST SET SHIP_NO = '" + Fields_Array[1] + "' " +
                                                    //    //                                    "WHERE (Ship_Stage_Key = " + StagedItems_By_Packer_T.Rows[i][0].ToString() + ")";

                                                    //    //    DBMNG_FS.Execute_Command(Stage_Package_Update_Q);
                                                    //    //}
                                                    //    //catch
                                                    //    //{ }

                                                    //}
                                                    ///////////////////////////////////

                                                    string IsSerialized_Q = "SELECT IsSerialized FROM FS_Item WHERE (ItemNumber = '" + PickedItems_T.Rows[j]["ITEM"] + "')";

                                                    PN_Serialized = DBMNG_FS.Execute_Scalar(IsSerialized_Q);

                                                    if (PN_Serialized == "Y")
                                                    {

                                                        //CO_NO, ShipNo, CO_Ln#, SerialNo, LotNO, 
                                                        //    0,      1,      2,        3,     4,  
                                                        fields = PickedItems_T.Rows[j]["CO_NUMBER"]
                                                            + "," + DoShipFields_Array[1]
                                                            + "," + CO_LN_NO
                                                            + ",," + PickedItems_T.Rows[j]["LOT"];

                                                        string Trans_SHIP13_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                            " [AmalgammaUser]) VALUES ('DOSERIAL', '" + fields + "', '" + user + "') SELECT @@IDENTITY";

                                                        DBMNG.Execute_Scalar(Trans_SHIP13_Q);
                                                    }

                                                    ///
                                                }
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + Transaction_Key.Replace("|,", "") + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);

                                                ProcessingLog("DOSHIP - " + DoShipFields + " - Transaction was successfully processed. SHIP02 keys: " + Transaction_Key.Replace("|,", ""), "info");

                                                //DOPACK TRANSACTION
                                                //string dopack_fields = CUST_ID + "," + SHIP_NO;
                                                string dopack_fields = DoShipFields;
                                                string DOPACK_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                   " [AmalgammaUser]) VALUES ('DOPACK', '" + dopack_fields + "','" + user + "') SELECT @@IDENTITY";
                                                DBMNG.Execute_Scalar(DOPACK_Q);
                                                ////
                                            }
                                            catch (Exception ex)
                                            {
                                                ProcessingLog("DOSHIP - " + DoShipFields + " Error During Procesing Transaction - " + ex.Message, "error");
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                                " SET TransactionProcessedYN = 1 " +
                                                                "    ,FSResponse = '" + Transaction_Key.Replace("|,", "") + "- Exeption: " + ex.Message + "'" +
                                                                "    ,FSError = 0" +
                                                                "    ,DateStampOut = GetDate()" +
                                                                " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region DOPACK
                                    case "DOPACK":
                                        {
                                            //CUST_ID, SHIPNO
                                            //      0,      1
                                            string FIELDS = "";
                                            int BoxCount = 1;
                                            int PackNum=1;
                                            try
                                            {
                                                #region DOPACK
                                                string Transaction_Key = "|";
                                                fields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                                user = dataGridView1.Rows[i].Cells[3].Value.ToString();

                                                FIELDS = fields;

                                                string[] Fields_Array = fields.Split(',');

                                                string Staged_Items_Q = "SELECT    CO, LN, ITEM_PN, SUM(QTY) AS QTY, VB_USER, CUST_ID, SHIP_NO, COUNT(QTY) AS BOXES " +
                                                            " FROM _CAP_VB_STAGE_SHIPPING GROUP BY  CO, LN, ITEM_PN, VB_USER, CUST_ID, SHIP_NO "+
                                                            " HAVING (CUST_ID = N'" + Fields_Array[0] + "') AND (SHIP_NO = N'" + Fields_Array[1] + "') "+
                                                            " AND (VB_USER='" + user.Replace("VB - ", "") + "') " +
                                                            " ORDER BY ITEM_PN ";
                                                                  

                                                DataTable Sateaged_Items_T = DBMNG_FS.Execute_Query(Staged_Items_Q);

                                                for (int r = 0; r < Sateaged_Items_T.Rows.Count; r++)
                                                {

                                                    //CO_NO, ShipNo, CO_Ln#, LnItemQty, PartNo, PackType, PackWgt, PackNum
                                                    //    0,      1,      2,         3,      4,        5,       6,       7

                                                    string DoPackFields = Sateaged_Items_T.Rows[r]["CO"].ToString()
                                                        + "," + Sateaged_Items_T.Rows[r]["SHIP_NO"].ToString()
                                                        + "," + Sateaged_Items_T.Rows[r]["LN"].ToString()
                                                        + "," + Sateaged_Items_T.Rows[r]["QTY"].ToString()
                                                        + "," + Sateaged_Items_T.Rows[r]["ITEM_PN"].ToString();

                                                    //string DoPackFields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                                    string[] DoPackFields_Array = DoPackFields.Split(',');

                                                    user = dataGridView1.Rows[i].Cells[3].Value.ToString();

                                                    string ItemPkg_Info_Q = "SELECT ItemShippingWeight, PackageType, PiecesPerPackage FROM FS_Item WHERE (ItemNumber = '" + DoPackFields_Array[4] + "')";

                                                    DataTable ItemPkg_Info_T = DBMNG_FS.Execute_Query(ItemPkg_Info_Q);

                                                    string PackType = ItemPkg_Info_T.Rows[0]["PackageType"].ToString();
                                                    string PiecesPerPackage = ItemPkg_Info_T.Rows[0]["PiecesPerPackage"].ToString();

                                                    float ItemShippingWeight = float.Parse(ItemPkg_Info_T.Rows[0]["ItemShippingWeight"].ToString());

                                                    int PiecesXPackage = Convert.ToInt32(PiecesPerPackage);

                                                    float TotalQTYofBOXES = float.Parse(DoPackFields_Array[3].ToString()) / PiecesXPackage;


                                                    //float QTYofBOXES = float.Parse(DoPackFields[3].ToString()) / PiecesXPackage;

                                                    int CompleteBoxes = (int)(TotalQTYofBOXES);

                                                    float PartialBox = TotalQTYofBOXES - CompleteBoxes;

                                                    int Qty2Pack = PiecesXPackage * CompleteBoxes;

                                                    float TotalPackWgt = ItemShippingWeight * PiecesXPackage;

                                                    

                                                    #region Complete Box Packing

                                                    //CO_NO, ShipNo, CO_Ln#, LnItemQty, PartNo, PackType, PackWgt, PackNum, PackagesInSeries
                                                    //    0,      1,      2,         3,      4,        5,       6,       7,                8     

                                                    fields = DoPackFields_Array[0]
                                                        + "," + DoPackFields_Array[1]
                                                        + "," + DoPackFields_Array[2]
                                                        + "," + PiecesXPackage.ToString()
                                                        + "," + DoPackFields_Array[4]
                                                        + "," + PackType
                                                        + "," + TotalPackWgt.ToString()
                                                        //+ "," + PackNum.ToString();
                                                    //+ "," + CompleteBoxes;
                                                        +"," + PackNum.ToString()
                                                        + "," + CompleteBoxes;
                                                    ///FSTI PACK TRANSACTION 4 COMPLETE BOXES
                                                    ///
                                                    string Trans_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                        " [AmalgammaUser]) VALUES ('SHIP06', '" + fields + "', '" + user + "') SELECT @@IDENTITY";

                                                    Transaction_Key += "," + DBMNG.Execute_Scalar(Trans_Q);
                                                    PackNum = PackNum + CompleteBoxes;
                                                    ///
                                                    #endregion

                                                    #region Partial Box Packing
                                                    if (PartialBox != 0)
                                                    {
                                                        Qty2Pack = Convert.ToInt32(DoPackFields_Array[3]) - Qty2Pack;
                                                        TotalPackWgt = ItemShippingWeight * Qty2Pack;

                                                        fields = DoPackFields_Array[0]
                                                        + "," + DoPackFields_Array[1]
                                                        + "," + DoPackFields_Array[2]
                                                        + "," + Qty2Pack.ToString()
                                                        + "," + DoPackFields_Array[4]
                                                        + "," + PackType
                                                        + "," + TotalPackWgt.ToString()
                                                        + "," + PackNum.ToString()
                                                        + ",1";// +PackNum.ToString();

                                                        //DO FSTI PACK TRANSACCION FOR PARTIAL BOX

                                                        Trans_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                       " [AmalgammaUser]) VALUES ('SHIP06', '" + fields + "', '" + user + "') SELECT @@IDENTITY";

                                                        Transaction_Key += "," + DBMNG.Execute_Scalar(Trans_Q);


                                                        PackNum = PackNum + 1;
                                                    }
                                                    #endregion
                                                }

                                                #endregion
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + Transaction_Key.Replace("|,", "") + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);

                                                ProcessingLog("DOPACK - " + FIELDS + " - Transaction was successfully processed. SHIP06 keys: " + Transaction_Key.Replace("|,", ""), "info");
                                            }
                                            catch (Exception ex)
                                            {
                                                ProcessingLog("DOPACK - " + FIELDS + " Error During Procesing Transaction - " + ex.Message, "error");
                                            }
                                            break;
                                        }
                                    #endregion
                                    #region DOSERIAL
                                    case "DOSERIAL":
                                        {

                                            //CO_NO, ShipNo, CO_Ln#, SerialNo, LotNO, 
                                            //    0,      1,      2,        3,     4,  
                                            string FIELDS = "";
                                            string query = "";
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            try
                                            {
                                                string Transaction_Key = "|";
                                                fields = dataGridView1.Rows[i].Cells[2].Value.ToString();

                                                FIELDS = fields;

                                                string[] Fields_Array = fields.Split(',');

                                                #region DOSERIAL
                                                /////CODE HERE
                                                string Traveler_Attachemnt_Q = "SELECT * FROM FGPackingDetail WHERE (BoxLabel = N'" + Fields_Array[4] + "')";

                                                DataTable Traveler_Attachemnt_T = DBMNG.Execute_Query(Traveler_Attachemnt_Q);

                                                if (Traveler_Attachemnt_T.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j < Traveler_Attachemnt_T.Rows.Count; j++)
                                                    {

                                                        //CO_NO, ShipNo, CO_Ln#, SerialNo, LotNO, 
                                                        //    0,      1,      2,        3,     4,  

                                                        string Traveler_No = Traveler_Attachemnt_T.Rows[j]["TravelerNum"].ToString();
                                                        try
                                                        {
                                                            Traveler_No = Traveler_No.Remove(Traveler_No.IndexOf('='));
                                                        }
                                                        catch
                                                        {
                                                            Traveler_No = Traveler_Attachemnt_T.Rows[j]["TravelerNum"].ToString();
                                                        }
                                                        fields = Fields_Array[0]
                                                            + "," + Fields_Array[1]
                                                            + "," + Fields_Array[2]
                                                            + "," + Traveler_No
                                                            //+ "," + Traveler_Attachemnt_T.Rows[j]["TravelerNum"].ToString()
                                                            + "," + Fields_Array[4];

                                                        string Trans_Q = "INSERT INTO Amal_FSTI_Transactions ([TransactionType],[TransactionStringFields], " +
                                                                   " [AmalgammaUser]) VALUES ('SHIP13', '" + fields + "', '" + user + "') SELECT @@IDENTITY";

                                                        Transaction_Key += "," + DBMNG.Execute_Scalar(Trans_Q);
                                                    }
                                                }
                                                else
                                                {
                                                    ProcessingLog("DOSERIAL - " + FIELDS + " Error During Procesing Transaction - " + "There is no Travelers Attached to this Box Serial", "error");
                                                    query = "UPDATE Amal_FSTI_Transactions " +
                                                                  " SET TransactionProcessedYN = 1 " +
                                                                  "    ,FSResponse = 'Error During Procesing Transaction - There is no Travelers Attached to this Box Serial'" +
                                                                  "    ,FSError = 0" +
                                                                  "    ,DateStampOut = GetDate()" +
                                                                  " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    break;
                                                }

                                                    ////////
                                                #endregion


                                                    query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + Transaction_Key.Replace("|,", "") + "'" +
                                                                   "    ,FSError = 0" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);

                                                    ProcessingLog("DOSERIAL - " + FIELDS + " - Transaction was successfully processed. SHIP13 keys: " + Transaction_Key.Replace("|,", ""), "info");
                                                
                                            }
                                            catch (Exception ex)
                                            {
                                                ProcessingLog("DOSERIAL - " + FIELDS + " Error During Procesing Transaction - " + ex.Message, "error");
                                                query = "UPDATE Amal_FSTI_Transactions " +
                                                                  " SET TransactionProcessedYN = 1 " +
                                                                  "    ,FSResponse = '" + " Error During Procesing Transaction - " + ex.Message + "'" +
                                                                  "    ,FSError = 0" +
                                                                  "    ,DateStampOut = GetDate()" +
                                                                  " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                            }
                                            break;
                                        }
                                    #endregion
                                    #region SHIP13
                                    case "SHIP13":
                                        {
                                            #region SHIP13
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_SHIP13(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("SHIP13 - " + fields + " - Transaction was successfully processed.", "info");

                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("SHIP13 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion

                                    #region MOMT00
                                    case "MOMT00":
                                        {
                                            #region DoMorv
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_MOMT00(fields, user))
                                            {

                                                MO_SetUp_LabelUPD(fields);

                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("MOMT00 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("MOMT00 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region MOMT06
                                    case "MOMT06":
                                        {
                                            #region DoMorv
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_MOMT06(fields, user))
                                            {

                                                MO_SetUp_LabelUPD(fields);
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("MOMT06 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("MOMT06 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion

                                    #region PICK12
                                    case "PICK12":
                                        {
                                            #region Pick
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_PICK12(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("PICK12 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("PICK12 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region PICK00
                                    case "PICK00":
                                        {
                                            #region Pick00
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_PICK00(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("PICK00 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("PICK00 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion
                                    #region PICK08
                                    case "PICK08":
                                        { 
                                            #region Pick08
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_PICK08(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("PICK08 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("PICK08 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }
                                    #endregion

                                    case "INVA01":
                                        {
                                            #region INVA01
                                            fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                            user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            if (FSTI.AmalgammaFSTI_INVA01(fields, user))
                                            {
                                                string query = "UPDATE Amal_FSTI_Transactions " +
                                                               " SET TransactionProcessedYN = 1 " +
                                                               "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                               "    ,FSError = 0" +
                                                               "    ,DateStampOut = GetDate()" +
                                                               " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                DBMNG.Execute_Command(query);
                                                ProcessingLog("INVA01 - " + fields + " - Transaction was successfully processed.", "info");
                                            }
                                            else
                                            {
                                                if (!FSTI.DBinUseFlag)
                                                {
                                                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                                                    string query = "UPDATE Amal_FSTI_Transactions " +
                                                                   " SET TransactionProcessedYN = 1 " +
                                                                   "    ,FSResponse = '" + error + "'" +
                                                                   "    ,FSError = 1" +
                                                                   "    ,DateStampOut = GetDate()" +
                                                                   " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                                    DBMNG.Execute_Command(query);
                                                    ProcessingLog("INVA01 - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                                                }
                                            }
                                            #endregion
                                            break;
                                        }



                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                        #endregion
                        int hora = DateTime.Now.Hour;
                        string TT = DateTime.Now.ToString("tt");
                        if (hora > 9 && TT == "PM")
                        {
                            try
                            {
                                FSTI.AmalgammaFSTI_Stop();
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        //MessageBox.Show(FSTI.ErrorMsg, "Error During Login");
                        ProcessingLog("FSTI-Error During Login - " + FSTI.FSTI_ErrorMsg, "error");
                        //FSTI_Error_Flag = true;
                    }
                }
                else
                {
                    //MessageBox.Show(FSTI.ErrorMsg, "Error During FSTI Inicialitation");
                    ProcessingLog("FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg, "error");
                    //FSTI_Error_Flag = true;
                }
                //FSTI.AmalgammaFSTI_Stop();
            }
            catch(Exception ex)
            {
                if (!FSTI.DBinUseFlag)
                {
                    listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                    string error = FSTI.Trans_Error_Msg.Replace('\'', '"');
                    string query = "UPDATE Amal_FSTI_Transactions " +
                                   " SET TransactionProcessedYN = 1 " +
                                   "    ,FSResponse = '" + ex.Message + "'" +
                                   "    ,FSError = 1" +
                                   "    ,DateStampOut = GetDate()" +
                                   " WHERE (FSTI_Transaction_key=" + TransactionKey + ")";
                    DBMNG.Execute_Command(query);
                    //ProcessingLog("MORV - " + fields + " Error During Procesing Transaction - " + FSTI.Trans_Error_Msg, "error");
                    ProcessingLog("FSTI-Error Exeption - " + ex.Message, "error");
                }
                //MessageBox.Show(ex.Message, "Error FSTI Exeption");
                FSTI.AmalgammaFSTI_Stop(); 
            }
            
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string Transaction_Criteria = "|";
            foreach (CheckBox transaction in groupBox1.Controls)
            {
                if (transaction.Checked)
                {
                    Transaction_Criteria += ",'" + transaction.Name.Replace("_CB_", "") + "'";
                }
            }

            string criteria = " AND (TransactionType IN (" + Transaction_Criteria.Replace("|,","") + "))";
            string query = "SELECT * FROM Amal_FSTI_Transactions WHERE (TransactionProcessedYN = 0) " + criteria + 
                " ORDER BY FSTI_Transaction_key,DateStampIn";
            //string query = "SELECT * FROM  Amal_FSTI_Transactions WHERE (TransactionProcessedYN = 0) AND (TransactionType = N'SHIP_PICK')";
            DataTable table = DBMNG.Execute_Query(query);
            dataGridView1.DataSource = table;
            int rows = dataGridView1.Rows.Count;
            if (rows > 0)
            {
                ProcessTransaction();
            }
            timer1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FSTI.AmalgammaFSTI_Stop();
        }

        private void ProcessingLog(string Log, string type)
        {
            string DateStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            listBox1.Items.Add("");
            listBox1.Items.Add(DateStamp + " - " + Log);

            switch (type)
            {
                case "error":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Error, Log);
                        break;
                    }
                case "info":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Info, Log);
                        break;
                    }
                case "warning":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Warning, Log);
                        break;
                    }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        #region Transaction Admin
        
        private void LoadActiveTransactions()
        {
            ActiveTransactions = "";
            foreach (CheckBox Transcation in groupBox1.Controls)
            {
                if (Transcation.Checked)
                {
                    ActiveTransactions += "|" + Transcation.Name.Replace("_CB", "");
                }
            }
        }

        #endregion

    }
}
