using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TesteLevelUp.Ui.Infra
{
   public class DatabaseHelper
   {
      public static string GetDataBaseFile()
      {
         return string.Format("DataSource=\"{0}\\TesteLevelUp\\data\\DataStore.sdf\"", GetDirectory());
      }

      public static string GetDirectory()
      {
         var assemblyPath = Assembly.GetExecutingAssembly().Location;

         return assemblyPath.Substring(0, assemblyPath.IndexOf("\\src\\") + 5);
      }
   }
}

