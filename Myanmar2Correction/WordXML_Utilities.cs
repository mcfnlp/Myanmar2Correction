using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using System.Text;

namespace Myanmar2Correction
{
   class WordXML_Utilities
    {
        Object missing = System.Reflection.Missing.Value;

        public String ConvertToXML(string filename)
        {
            Word.Application wordApp = new Word.Application();

            // For reasons of performace and to avoid the user
            // messing things up :
            wordApp.Visible = false;
            wordApp.ScreenUpdating = true;

            // Word needs a lot of parameters that are optional in VB
            // but need to be passed in C#
            Object xmlFormat = Word.WdSaveFormat.wdFormatXML;
            Object f = filename;
            //string tem = System.IO.Directory.GetCurrentDirectory();
            string tem = filename.Substring(0, filename.LastIndexOf('\\'));
            Object savename = tem + "\\TempXml.xml";
            Word.Document doc = wordApp.Documents.Add(ref f, ref missing, ref missing, ref  missing);

            // Here comes the actual saving part
            doc.SaveAs(ref savename, ref xmlFormat, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, 
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            doc.Close(ref missing, ref missing, ref missing);

            return savename.ToString();
        }

        public void SaveToDoc(string xmlInput, string docOutput)
        {
            Word.Application wordApp = new Word.Application();

            // For reasons of performace and to avoid the user
            // messing things up :
            wordApp.Visible = false;
            wordApp.ScreenUpdating = true;

            // Word needs a lot of parameters that are optional in VB
            // but need to be passed in C#
            Object docFormat = Word.WdSaveFormat.wdFormatDocumentDefault;//edit in Ms2007
            Object f = xmlInput;
            Object savename = docOutput;
            Word.Document doc = wordApp.Documents.Add(ref f, ref missing, ref missing, ref  missing);
            doc.Content.Font.Name = "Myanmar3";
            // Here comes the actual saving part
            doc.SaveAs(
            ref savename,
            ref docFormat,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing,
            ref missing);

            doc.Close(ref missing, ref missing, ref missing);
        }

    }
}

