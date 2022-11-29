using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace SqlStudioPROD {
    public class GuiService : IGuiService {

        public AddFileModel OpenFileDialog() 
         {

            AddFileModel model = new AddFileModel();
            model.AnyErrors = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
           
            try 
                
                {
                    if (openFileDialog.ShowDialog() == true) 
                    {
                        model.FileName = openFileDialog.SafeFileName;
                        model.FilePath = openFileDialog.FileName;

                        string ext = (Path.GetExtension(openFileDialog.FileName)).ToUpper().Remove(0, 1); 
                        const string quote = "\"";

                    switch (ext) {
                            
                            case "XLSX":

                                model.FileType = FileType.XLSX;
                            model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';Extended Properties=" + quote + "Excel 12.0 Xml;HDR=[HDR];application intent=readonly;IMEX=[IMEX];" + quote;
                                model.IconPath = @"\Resources\excel.ico";
                                break;

                            case "XLS":
                                model.FileType = FileType.XLS;
                                model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';Extended Properties=" + quote + "Excel 8.0;HDR=[HDR];IMEX=[IMEX];" + quote;
                                model.IconPath = @"\Resources\excel.ico";
                                break;

                            case "XLSB":
                                model.FileType = FileType.XLSB;
                                model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';Extended Properties=" + quote + "Excel 12.0;HDR=[HDR];IMEX=[IMEX];" + quote;
                                model.IconPath = @"\Resources\excel.ico";
                                break;

                            case "XLSM":
                                model.FileType = FileType.XLSM;
                                model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';Extended Properties=" + quote + "Excel 12.0 macro;HDR=[HDR];IMEX=[IMEX];" + quote;
                                model.IconPath = @"\Resources\excel.ico";
                                break;

                            case "MDB":
                                model.FileType = FileType.MDB;
                                model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';Extended Properties=" + quote + "Excel 12.0 macro;HDR=[HDR];IMEX=[IMEX];" + quote;
                                model.IconPath = @"\Resources\access.ico";
                                break;

                            case "ACCDB":
                                model.FileType = FileType.ACCDB;
                                model.ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + model.FilePath + "';";
                                model.IconPath = @"\Resources\access.ico";
                                break;

                            default:
                                model.AnyErrors = true;
                                break;
                        }

                       }  

            } 
            
            catch (Exception) 

            {
                model.AnyErrors = true;
            }

            


            return model;
        }
    }
}
