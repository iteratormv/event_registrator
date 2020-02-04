using event_registrator.Models;
using event_registrator.Websockets;
using ExcelDataReader;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Range = Microsoft.Office.Interop.Excel.Range;

namespace event_registrator.Data
{
    public class ExelData
    {
        public List<UserForMailing> users { get; set; }
      
        public ExelData(string fName)
        {
            users = new List<UserForMailing>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(fName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        var ufm = new UserForMailing();
                        while (reader.Read()) //Each ROW
                        {
                            string firstname = "";
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                //Console.WriteLine(reader.GetString(column));//Will blow up if the value is decimal etc. 
                                //    Console.WriteLine(reader.GetValue(column));//Get Value returns object
                                switch(column){
                                    case 0:
                                        ufm.Barcode = reader.GetValue(column).ToString();
                                        break;
                                    case 7:
                                        firstname = reader.GetValue(column).ToString();
                                        break;
                                    case 8:
                                        ufm.Name = firstname + " " + reader.GetValue(column).ToString();
                                        break;
                                    case 13:
                                        ufm.Email = reader.GetValue(column).ToString();
                                        break;
                                    case 14:
                                        ufm.ExhibitionName = reader.GetValue(column).ToString();
                                        break;
                                }
                            }
                            users.Add(ufm);
                            ufm = new UserForMailing();
                        }
                    } while (reader.NextResult()); //Move to NEXT SHEET

                }
            }
        }
    }

}
 