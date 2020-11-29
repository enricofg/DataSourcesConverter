using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Excel_Lib
{
    public class ExcelHandler
    {
        public static string ReadFromExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();

            //open excel file
            var excelWorkbook = excelApplication.Workbooks.Open(filename);
            //excelApplication.Visible = true;
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;

            string content = excelWorksheet.Cells[1, 1].Value;
            content += (excelWorksheet.Cells[1, 2] as Excel.Range).Text;
             
            //TODO: read text content from every sheet of the workbook

            excelWorkbook.Close();
            excelApplication.Quit();

            ReleaseComObject(excelWorksheet);
            ReleaseComObject(excelWorkbook);
            ReleaseComObject(excelApplication);

            return content;
        }      

        private static void ReleaseComObject(Object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception releasing COM Object: " + ex.Message);
                throw;
            }
            finally
            {
                //Garbage Collector: indicar que há objetos para serem libertados da memória
                GC.Collect();
            }
        }
    }
}
