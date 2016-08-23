using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace Myanmar2Correction
{
    class WordCorrector
    {
        //public static void Correct(String wordFilePath, String saveFilePath)
        //{
        //    WordXML_Utilities uti = new WordXML_Utilities();
        //    Logging.logger += "Converting XML   :" + "\n";
        //    String xmlFile = uti.ConvertToXML(wordFilePath);

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(xmlFile);

        //    XmlElement root = doc.DocumentElement;
        //    XmlNodeList nodes = doc.GetElementsByTagName("w:t");
        //    XmlNode LastNode;
        //    XmlNode newnodetext;

        //    foreach (XmlNode node in nodes)
        //    {
        //        //XmlNode FirstNode = node.FirstChild;
        //        LastNode = node.LastChild;
        //        newnodetext = node.LastChild;
        //        string t2 = LastNode.InnerText;
        //        t2 = Corrector.Correction1(t2);
        //        newnodetext.InnerText = t2;
        //        try
        //        {
        //            root.ReplaceChild(newnodetext, LastNode);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("This is testing    .");
        //        }
        //    }


        //    string tem = saveFilePath.Substring(0, saveFilePath.LastIndexOf('\\'));
        //    string savename = tem + "\\finishxml.xml";
        //    doc.Save(savename);
        //    uti.SaveToDoc(savename, saveFilePath);
        //    string temp = saveFilePath.Substring(0, saveFilePath.LastIndexOf('\\')) + "\\TempXml.xml";
        //    string finish = saveFilePath.Substring(0, saveFilePath.LastIndexOf('\\')) + "\\finishxml.xml";
        //    File.Delete(temp);
        //    File.Delete(finish);
        //}
        public static void Correct(Word.Application wordapp, String saveFilePath)
        {
            string srcTxt = wordapp.ActiveDocument.Content.Text;
            string uniTxt = Corrector.Correction1(srcTxt);//take care
            wordapp.ActiveDocument.Content.Text = uniTxt;
            Object w = saveFilePath;
            Object missing = System.Reflection.Missing.Value;
            wordapp.ActiveDocument.Save();
            wordapp.Documents.Save(ref missing, ref missing);
            wordapp.Quit(ref missing, ref missing, ref missing);

        }

    }
}
          
       
