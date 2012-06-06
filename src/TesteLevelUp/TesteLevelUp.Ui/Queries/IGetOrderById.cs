using TesteLevelUp.Ui.Commands;
using TesteLevelUp.Ui.Domain;

namespace TesteLevelUp.Ui.Queries
{
   public interface IGetOrderById : IQuery<Order>
   {
      int OrderId { get; set; }
   }
}