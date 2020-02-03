using event_registrator.Models;
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
        public List<User> users { get; set; }
        public ExelData(string fName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(fName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read()) //Each ROW
                        {
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                //Console.WriteLine(reader.GetString(column));//Will blow up if the value is decimal etc. 
                                Console.WriteLine(reader.GetValue(column));//Get Value returns object
                            }
                        }
                    } while (reader.NextResult()); //Move to NEXT SHEET

                }
            }
        }
    }

}
