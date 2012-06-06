using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using TesteLevelUp.Ui.Queries;

namespace TesteLevelUp.IntegrationTests
{
   [TestFixture]
   public class GetOrderByIdTests 
   {
      [Test]
      public void Can_get_orders_from_database()
      {
         IGetOrderById query = new GetOrderById();
         query.OrderId = 1;
         var order = query.Execute();

         Assert.That(order, Is.Not.Null);
      }
   }
}
