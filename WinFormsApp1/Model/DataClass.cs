using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class DataClass
    {
   
        public int id { get; set; }
       
        public string? data { get; set; }
        public string flag { get; set; }

        public static implicit operator DataGridViewRow(DataClass v)
        {
            throw new NotImplementedException();
        }
    }
}
