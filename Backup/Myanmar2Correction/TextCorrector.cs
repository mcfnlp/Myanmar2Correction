using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Myanmar2Correction
{
    class TextCorrector
    {
        public static void Correct(string desFile)
        {
            //StringBuilder strbil = new StringBuilder();
            //unistr = correct.Cottection(strbil).ToString();
            string desText = Corrector.Correction1(readTxtFile(desFile));
            //string desText=readTxtFile(desFile);
            //StringBuilder strbil=new StringBuilder();
            //strbil.Append(desText);
            //Corrector2 correct = new Corrector2();
            // desText = correct.Cottection(strbil).ToString();
            //desText = Corrector.Correction1(desText);
            writeTxtFile(desText, desFile);
            openTxtFile(desFile);
        }

        private static void openTxtFile(string fileName)
        {
            System.Diagnostics.Process openingTxtFile = new System.Diagnostics.Process();
            openingTxtFile.StartInfo.FileName = fileName;
            openingTxtFile.Start();
        }

        private static void writeTxtFile(string st_corr, string st_File)
        {
            StreamWriter sw = new StreamWriter(st_File);
            sw.WriteLine(st_corr);
            sw.Close();
        }
         public static string readTxtFile(string fileName)
        {            
            StreamReader sr = new StreamReader(fileName);
            string s = sr.ReadToEnd();
            sr.Close();
            return s;
        }
    }
}
