using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel=Microsoft.Office.Interop.Excel;

namespace Myanmar2Correction
{
    class ExcelCorrector
    {
        public static void Correct(Excel.Application excelApp)
        {
            Excel.Range usedRange;
            Excel.Range currentCell;
            Excel.Workbook aWorkbook = (Excel.Workbook)excelApp.ActiveWorkbook;
            int sheetCount = aWorkbook.Sheets.Count;
            for (int sheetNo = 1; sheetNo <= sheetCount; sheetNo++)
            {
                Excel.Worksheet currentWorkSheet;
                try
                {
                    currentWorkSheet = (Excel.Worksheet)aWorkbook.Sheets[sheetNo];
                    currentWorkSheet.Activate();
                    currentWorkSheet.Application.Cells.Activate();
                    usedRange = currentWorkSheet.UsedRange;
                    int totalRows = usedRange.Rows.Count;
                    int totalColumns = usedRange.Columns.Count;

                    for (int i = 1; i <= totalRows; i++)
                    {
                        for (int j = 1; j <= totalColumns; j++)
                        {
                            currentCell = ((Excel.Range)usedRange.Cells[i, j]);
                            //UniConversion.Converter.ConvertOption option = detectFont(currentCell);
                            if (currentCell != null)
                            {
                                Object currentCellData = currentCell.Text;
                                if (currentCellData != null && ((string)currentCell.Text) != "")
                                {
                                    string srcTxt = (string)currentCell.Text;
                                    string uniTxt = Corrector.Correction1(srcTxt);    //take care........                                
                                    currentCell.Value2 = uniTxt + "";
                                    //Console.WriteLine("converting...finished" + uniTxt);
                                    //Console.WriteLine("converting...replaced");
                                }
                                //else
                                //{
                                //    currentCell.Value2 = "*";
                                //}
                            }
                        }
                        //Console.WriteLine("Row: " + i + " is finished converting!");
                    } // end of outer-for
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExcelConverter.Convert() Error :--> " + e.Message);
                    continue;
                }
                // set "Myanmar3"to default sript name
                //Console.WriteLine("Code reach end of line!");
                usedRange.Font.Name = "Myanmar3";
            }
            //activeWorkSheet.Application.Cells.Activate();
            ((Excel.Worksheet)aWorkbook.Sheets[1]).Activate();
        }
    }
}
