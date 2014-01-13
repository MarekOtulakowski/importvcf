#region UsesDirective
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading; 
#endregion

namespace MSOutlookImportVCF
{
    public partial class F_Main : Form
    {
        #region Zmienne
        string pathToVcfFolder = string.Empty;
        string pathToLog = string.Empty;
        List<string> listPathsVcfFiles;
        int countErrorCopy = 0;
        System.Windows.Forms.Timer timer;
        float percentProgress = 0;
        Thread theThread;
        bool done = false; 
        #endregion

        #region Constructors
        public F_Main()
        {
            InitializeComponent();
        } 
        #endregion

        #region WithoutOutlook
        private void B_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pathToVcfFolder = fbd.SelectedPath;
                TB_path.Text = pathToVcfFolder;
                pathToLog = pathToVcfFolder + @"\log.txt";
            }
        }

        private void B_import_Click(object sender, EventArgs e)
        {
            L_advInfo.Text = ".";
            done = false;
            PB_progress.Value = 0;
            L_stat.Text = "No action";

            //initial list
            if (listPathsVcfFiles == null)
            {
                listPathsVcfFiles = new List<string>();
            }
            else
            {
                listPathsVcfFiles.Clear();
            }

            //initial timer
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += new EventHandler(timer_Tick);
            }

            //simple validate
            if (!string.IsNullOrEmpty(TB_path.Text))
            {
                pathToVcfFolder = TB_path.Text;

                try
                {
                    Get_listOfVcfFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during get files\n" + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                L_stat.Text = "Found " + 
                              listPathsVcfFiles.Count.ToString() + 
                              " files *.vcf";

                theThread = new Thread(ImportContactsToMSOutlook);
                theThread.Start();

                timer.Start();
            }
            else
            {
                MessageBox.Show("Path to folder with VCF files is empthy!\nEnter correctly path and try again", 
                                "Information", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            PB_progress.Value = (int)percentProgress;

            if (done)
            {
                L_stat.Text = "Imported " + 
                              listPathsVcfFiles.Count + 
                              " contacts, operation is complete!" + "\n" +
                              countErrorCopy + " failed copy";
                L_advInfo.Text = "Details errors in file: " + pathToLog;
            }
        }

        private void Get_listOfVcfFiles()
        {
            DirectoryInfo rootFolder = new DirectoryInfo(pathToVcfFolder);
            FileInfo[] directoryFiles = rootFolder.GetFiles("*.vcf");

            foreach (FileInfo file in directoryFiles)
            {
                listPathsVcfFiles.Add(file.FullName.ToLower());
            }

            if (rootFolder.GetDirectories().Length > 0)
            {
                foreach (DirectoryInfo directory in rootFolder.GetDirectories())
                {
                    Get_filesFromSubfolders(directory);
                }
            }
        }

        private void Get_filesFromSubfolders(DirectoryInfo _rootFolder)
        {
            FileInfo[] plikiFolderu = _rootFolder.GetFiles("*.vcf");

            foreach (FileInfo file in plikiFolderu)
            {
                listPathsVcfFiles.Add(file.FullName.ToLower());
            }

            if (_rootFolder.GetDirectories().Length > 0)
            {
                foreach (DirectoryInfo directory in _rootFolder.GetDirectories())
                {
                    Get_filesFromSubfolders(directory);
                }
            }
        }

        private void B_abort_Click(object sender, EventArgs e)
        {
            if (theThread.IsAlive)
            {
                timer.Stop();
                theThread.Abort();
                MessageBox.Show("Abort for user wishes!",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                L_stat.Text = "Abort for user wishes";
            }
        }
        #endregion

        #region OutlookFunction
        private void ImportContactsToMSOutlook()
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.NameSpace oNS = oApp.GetNamespace("MAPI");

                Outlook.MAPIFolder oContactsFolder = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts) as Outlook.MAPIFolder;

                int i = 0;
                Outlook.ContactItem contact = null;
                foreach (string oneContact in listPathsVcfFiles)
                {
                    i++;
                    percentProgress = (float)i / listPathsVcfFiles.Count * 100;

                    try
                    {
                        contact = oApp.Session.OpenSharedItem(oneContact) as Outlook.ContactItem;
                        contact.Save();
                        contact = null;
                    }
                    catch
                    {
                        contact = null;
                        countErrorCopy++;
                        using (StreamWriter sw = File.AppendText(pathToLog))
                        {
                            sw.WriteLine(String.Format("{0}. Error imported file, path={1}",
                                countErrorCopy ,oneContact));
                            sw.Close();
                        }
                        continue;
                    }
                }

                done = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during adding new contacts to Outlook\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        } 
        #endregion
    }
}
