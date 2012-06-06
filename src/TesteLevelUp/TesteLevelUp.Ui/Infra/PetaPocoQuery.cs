using System.Data.SqlServerCe;
using PetaPoco;
using TesteLevelUp.Ui.Commands;

namespace TesteLevelUp.Ui.Infra
{
   public abstract class PetaPocoQuery<TEnt> : IQuery<TEnt>
   {
      private readonly Database _db;

      protected PetaPocoQuery(Database db = null)
      {
         _db = db ?? new Database(new SqlCeConnection(DatabaseHelper.GetDataBaseFile()));
      }

      public TEnt Execute()
      {
         try
         {
            _db.Connection.Open();
            return Execute(_db);
         }
         finally
         {
            _db.Connection.Close();
         }

      }

      protected abstract TEnt Execute(Database db);
   }
}