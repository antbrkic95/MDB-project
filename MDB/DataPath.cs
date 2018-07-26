using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB
{
    public class DataPath
    {
        public string upit;
        public List<object[]> getData(string path)
        {
            List<object[]> lista = new List<object[]>();
            OleDbDataReader reader;
            string connectString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + "" + path;
            OleDbConnection cn = new OleDbConnection(connectString);
            cn.Open();
            try
            {
                upit = "select reference from data;"; 
                OleDbCommand cmd = new OleDbCommand(upit, cn);
                reader = cmd.ExecuteReader();   
                while(reader.Read())
                {
                    object[] row = new object[1];
                    reader.GetValues(row);
                    lista.Add(row);
                }
            }
            catch { }
            cn.Close();
            return lista;
        }
         
        public string[] listAllMdbFiles()
        {
            string file = "*.mdb";
            string[] filePaths = Directory.GetFileSystemEntries(@"C:\PROJEKT mdb\SKF", file, SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine(filePaths[i]);              
            }
            return filePaths;
        }
        public void Sign() {
            string[] pathsMDBFiles = listAllMdbFiles();
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\PROJEKT mdb\mdb_path\path_reference.mdb";
            OleDbConnection cn = new OleDbConnection(connection);
            cn.Open();
            for (int i = 0; i < pathsMDBFiles.Length; i++)
            {
                List<object[]> data = getData(pathsMDBFiles[i]);
                pathsMDBFiles[i] = pathsMDBFiles[i].Replace(@"C:\PROJEKT mdb\SKF\", "");
                foreach (var item in data)
                    {
                    string upit = "insert into path_reference (reference,mdb_path) values('" + item[0].ToString() + "','" + pathsMDBFiles[i] + "')";
                    //string upit = "delete * from path_reference";
                    OleDbCommand cmd = new OleDbCommand(upit, cn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                    }
            }
                cn.Close();
            }
        }
    }

