using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlStudioPROD
{ 
    public class HelperService : IHelperService {
  

        public ExportDataModel ExportDataGrid(DataTable dataToExport) {

            ExportDataModel exp = new ExportDataModel();
            
            try {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = ".xlsx Files (*.xlsx)|*.xlsx"; //save only xlsx file

                //open file dialog for user
                if (saveFileDialog.ShowDialog() == true) {

                    XLWorkbook wb = new XLWorkbook();
                    wb.Worksheets.Add(dataToExport, "Export");
                    wb.SaveAs(saveFileDialog.FileName);
                    exp.Message = "File has been saved correctly";
                }
                else
                { 
                    exp.UserClickCancel = true;
                }

            } catch (Exception e) {

                exp.AnyErrors = true;
                exp.Message = e.Message;
            }

            


            return exp;

        }
    }
}
