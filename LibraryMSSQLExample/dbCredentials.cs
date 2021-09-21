using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMSSQLExample
{
    class dbCredentials
    {
        public static string dbMachine = "DESKTOP-6DASI9L";
        public static string dbName = "AdventureWorks2019";
        public static string dbLogin = "sa";
        public static string dbPass = "123";
        public static string ConnectionString = @"Data Source=" + dbMachine + ";Initial Catalog=" + dbName + ";User ID=" + dbLogin + ";Password=" + dbPass;
    }
}
