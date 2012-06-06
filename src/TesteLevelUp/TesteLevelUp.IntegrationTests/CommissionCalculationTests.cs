using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TesteLevelUp.Ui.Commands;
using TesteLevelUp.Ui.Infra;
using TesteLevelUp.Ui.Queries;

namespace TesteLevelUp.IntegrationTests
{
   [TestFixture]
   public class CommissionCalculationTests
   {
      public void Can_calculate_commission_for_orderid_1()
      {
         ICommand<decimal> commissionCalculation = new CommissionCalculation(1, new GetOrderById());
         var commission = commissionCalculation.Execute();

         Assert.That(commission, Is.EqualTo(2));

      }
   }
}
