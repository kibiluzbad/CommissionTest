using System;
using System.Linq;
using TesteLevelUp.Ui.Infra;
using TesteLevelUp.Ui.Queries;

namespace TesteLevelUp.Ui.Commands
{
   public class CommissionCalculation : ICommand<decimal>
   {
      private readonly int _orderId;
      private readonly IGetOrderById _getOrderById;
      private const decimal ComissionRate = 0.02M;

      public CommissionCalculation(int orderId, IGetOrderById getOrderById)
      {
         _orderId = orderId;
         _getOrderById = getOrderById;
      }

      public decimal Execute()
      {
         _getOrderById.OrderId = _orderId;
         
         var order = _getOrderById.Execute();

         if (null == order) throw new InvalidOperationException(string.Format("Can't find order #{0}", _orderId));

         return ComissionRate * order.Total;

      }
   }
}