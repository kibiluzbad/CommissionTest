using System.Linq;
using PetaPoco;
using TesteLevelUp.Ui.Domain;
using TesteLevelUp.Ui.Infra;

namespace TesteLevelUp.Ui.Queries
{
   public class GetOrderById : PetaPocoQuery<Order>, IGetOrderById
   {
      public int OrderId { get; set; }

      public GetOrderById(Database db = null) 
         : base(db)
      {
         
      }
      
      protected override Order Execute(Database db)
      {
         var order = db.SingleOrDefault<Order>("where id = @0", OrderId);
         
         if (null == order) return order;
         
         order.OrderItens = db.Query<OrderItem>("select * from OrderItem where OrderId = @0", OrderId)
            .ToList();

         return order;
      }
   }
}