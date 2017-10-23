using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Amalgamma_FSTI_Transactions
{
    public partial class Form1 : Form
    {
        #region GlobalVars

        Data_Base_MNG.SQL DBMNG = new Data_Base_MNG.SQL("192.168.0.11", "AmalgammaDB", "amalgamma", "capsonic");//el paso
        FS4Amalgamma.AmalgammaFSTI FSTI;

        #endregion
        
        public Form1()
        {
            InitializeComponent();
            FSTI = new FS4Amalgamma.AmalgammaFSTI(textConfig.Text, FS_User.Text, FS_Pass.Text);
            FSTI.AmalgammaFSTI_Initialization();
            FSTI.AmalgammaFSTI_Logon();
            timer1.Enabled = true;
        }
        
        #region Process Transactions

        private void ProcessTransaction()
        {
            string fields = "";
            string user = "";
            if (FSTI.AmalgammaFSTI_Initialization())
            {
                if (FSTI.AmalgammaFSTI_Logon())
                {
                    #region Processing
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        switch (dataGridView1.Rows[0].Cells[1].Value.ToString())
                        {
                            case "MORV":
                                {
                                    #region DoMorv
                                    fields = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                    user = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                    if (FSTI.AmalgammaFSTI_MORV00(fields, user))
                                    {
                                        listBox1.Items.Add("");
                                        listBox1.Items.Add(">>" + DateTime.Now.ToString("MM/dd/yy hh:mm") + " Transaction precessed correctly - " + FSTI.CDFResponse.ToString());
                                        string query = "UPDATE Amal_FSTI_Transactions " +
                                                       " SET TransactionProcessedYN = 1 " +
                                                       "    ,FSResponse = '" + FSTI.CDFResponse.ToString() + "'" +
                                                       "    ,FSError = 0" +
                                                       "    ,DateStampOut = GetDate()" +
                                                       " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                        DBMNG.Execute_Command(query);
                                    }
                                    else
                                    {
                                        listBox1.Items.Add("");
                                        listBox1.Items.Add(">>" + DateTime.Now.ToString("MM/dd/yy hh:mm") + " Transaction Failed - Error:" + FSTI.Trans_Error_Msg + " Fields: " + fields);
                                        listBox1.Items.AddRange(FSTI.DetailError.ToArray());
                                        string error =FSTI.Trans_Error_Msg.Replace('\'','"');
                                        string query = "UPDATE Amal_FSTI_Transactions " +
                                                       " SET TransactionProcessedYN = 1 " +
                                                       "    ,FSResponse = '" + error + "'" +
                                                       "    ,FSError = 1" +
                                                       "    ,DateStampOut = GetDate()" +
                                                       " WHERE (FSTI_Transaction_key=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ")";
                                        DBMNG.Execute_Command(query);
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
                    #endregion
                    FSTI.AmalgammaFSTI_Stop();
                }
                else
                {
                    listBox1.Items.Add("");
                    listBox1.Items.Add(">>" + DateTime.Now.ToString("MM/dd/yy hh:mm") + " Error during Logon - " + FSTI.FSTI_ErrorMsg);
                    FSTI.AmalgammaFSTI_Stop();
                }
            }
            else
            {
                listBox1.Items.Add("");
                listBox1.Items.Add(">>" + DateTime.Now.ToString("MM/dd/yy hh:mm") + " Error during Initialization - " + FSTI.FSTI_ErrorMsg);
                FSTI.AmalgammaFSTI_Stop();
            }
            //FSTI.AmalgammaFSTI_Stop();
        }

        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string query = "SELECT * FROM Amal_FSTI_Transactions WHERE (TransactionProcessedYN = 0)";
            int rows = dataGridView1.Rows.Count;
            DataTable table = DBMNG.Execute_Query(query);
            dataGridView1.DataSource = table;
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
    }
}
