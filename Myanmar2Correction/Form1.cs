using System;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace Myanmar2Correction
{
    public partial class Form1 : Form
    {

        string srcFile;
        string desFile;
        string fileType;
        string fileName;
        bool success;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBrowse.Text = openFileDialog1.FileName;
                srcFile = txtBrowse.Text;
                fileType = srcFile.Substring(srcFile.LastIndexOf('.'));
                fileName = srcFile.Substring(0, srcFile.LastIndexOf('.'));
                desFile = fileName + "_correct" + fileType;
                if (File.Exists(desFile))
                {
                    File.Delete(desFile);
                }
                File.Copy(srcFile, desFile);
                txtSave.Text = desFile;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (srcFile != null)
            {
                string fileType = srcFile.Substring(srcFile.LastIndexOf('.'));

                switch (fileType)
                {
                    case ".xls": this.saveFileDialog1.Filter = "Micorsoft Excel 2003(*.xls)|*.xls";
                        break;
                    case ".xlsx": this.saveFileDialog1.Filter = "Micorsoft Excel 2007(*.xlsx)|*.xlsx";
                        break;
                    case ".doc": this.saveFileDialog1.Filter = "Micorsoft Word 2003(*.doc)|*.doc";
                        break;
                    case ".docx": this.saveFileDialog1.Filter = "Micorsoft Word 2007(*.docx)|*.docx";
                        break;
                    case ".txt": this.saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
                        break;
                }

                this.saveFileDialog1.FileName = desFile;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtSave.Text = saveFileDialog1.FileName;
                    desFile = txtSave.Text;
                    System.IO.File.Copy(srcFile, desFile);
                }
            }
            else
                MessageBox.Show("Please select a file that you want to correct !..");
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            picBoxLoad.Visible = true;
            lblstatus.Text = "Please wait....";
            backgroundCorrectWorker.RunWorkerAsync();
           
        }

        private static Word.Application openWord1(Object wordFilePath)
        {
            Object missing = System.Reflection.Missing.Value;
            wordApp = new Word.ApplicationClass();
            wordApp.Visible = false;
            Word.Document wordDoc = wordApp.Documents.Open(ref wordFilePath,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            return wordDoc.Application;
        }
        private static Word.Application openWord(Object wordFilePath)
        {
            Object missing = System.Reflection.Missing.Value;
            wordApp = new Word.ApplicationClass();
            wordApp.Visible = false;
            Word.Document wordDoc = wordApp.Documents.Open(ref wordFilePath,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            return wordDoc.Application;
        }

        private static  Excel.Application openExcel(string excelFilePath)
        {
            excelApp = new Excel.ApplicationClass();
            excelApp.Visible = false;
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelFilePath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);

            return excelWorkbook.Application;
        }
        private void openExcel2(string excelFilePath)
        {
            excelApp = new Excel.ApplicationClass();
            excelApp.Visible = true;
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelFilePath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private static Word.Application wordApp;
        private static Excel.Application excelApp;

        private void backgroundCorrectWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            success = false;
            if (txtBrowse.Text == "")
            {
                MessageBox.Show("Please Select a file that you want to correct ..! ");
            }
            else if (txtSave.Text == "")
            {
                MessageBox.Show("Please Make a file that you want to save ..");
            }
            else
            {
                //if (fileType.Equals(".doc") || fileType.Equals(".docx") || fileType.Equals(".xlsx") || fileType.Equals(".xlsx") || fileType.Equals(".txt"))
                try
                {
                    switch (fileType)
                    {
                        case ".txt": TextCorrector.Correct(desFile);
                            success = true;
                            break;
                        case ".xls": ExcelCorrector.Correct(openExcel(desFile));
                            excelApp.ActiveWorkbook.Save();
                            excelApp.Quit();
                            success = true;
                            openExcel2(desFile);
                            break;
                        case ".xlsx": ExcelCorrector.Correct(openExcel(desFile));
                            excelApp.ActiveWorkbook.Save();
                            excelApp.Quit();
                            success = true;
                            openExcel2(desFile);
                            break;
                        case ".doc":
                            try
                            {
                                //WordCorrector.Correct(srcFile,desFile);
                                //WordCorrector.Correct((openWord1((Object)desFile)), desFile);
                                WordCorrector.Correct(openWord1((Object)desFile), desFile);
                                openWord((Object)desFile);
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                Logging.logger += "Error End...0";
                                Logging.WriteLog();
                            }
                            break;
                        case ".docx":
                            try
                            {
                                //WordCorrector.Correct(srcFile,desFile);
                                //WordCorrector.Correct((openWord1((Object)desFile)), desFile);
                                WordCorrector.Correct(openWord1((Object)desFile), desFile);
                                openWord((Object)desFile);
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                Logging.logger += "Error End...0";
                                Logging.WriteLog();
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logging.logger += "Error End...1";
                    Logging.WriteLog();
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                }
                if (success)
                {
                    lblstatus.Text = "Successful Correction ... !";
                   
                    btnBrowse.Enabled = true;
                    
                    btnSave.Enabled = true;
                    success = !success;
                }
            }
        }

        private void backgroundCorrectWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        { txtBrowse.Text = "";
            picBoxLoad.Visible = false;
            txtSave.Text = "";
        }

      
    }
}
