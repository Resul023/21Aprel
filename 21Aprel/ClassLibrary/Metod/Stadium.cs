using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibrary.Metod
{
    public class Stadium
    {
        public int Id { get; set; }
        public string _name { get; private set; }
        public decimal HourlyPrice { get; set; }
        public int Capacity { get; set; }

        public string Name 
        {
            get
            { 
                return this._name;
            }
            set 
            {
                if (value.Length<=25 && value.Length >1 && string.IsNullOrWhiteSpace(_name))
                {
                    this._name = value;
                }
            }
        }

           
    }
}
