using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDB
{
    class Program
    {
        string upit;
        static void Main(string[] args)
        {
            DataPath dp = new DataPath();
            

            dp.Sign();
            Console.WriteLine("Press enter to continue");
            Console.Read();
        }
       
       
        //vraca putanju od svih koja je odsjecena i zapisuje u txt datoteku
   
       
    }
}

