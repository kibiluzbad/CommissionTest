using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using TesteLevelUp.Ui.Commands;
using TesteLevelUp.Ui.Domain;
using TesteLevelUp.Ui.Infra;
using TesteLevelUp.Ui.Queries;

namespace TesteLevelUp.Tests
{
   [TestFixture]
   public class CommissionCalculationTests
   {
      [Test]
      public void Should_return_commission_equals_2_given_order_id_with_total_equals_100()
      {
         const int orderId = 1;
         var fakeDataStore = new Mock<IGetOrderById>();

         fakeDataStore
            .Setup(c => c.Execute())
            .Returns(new Order
                              {
                                 Id = 1,
                                 OrderItens = new[] { new OrderItem{Id=1, Value = 100} }
                              });

         ICommand<decimal> commissionCalculation = new CommissionCalculation(orderId, fakeDataStore.Object);

         var commission = commissionCalculation.Execute();

         Assert.That(commission, Is.EqualTo(2));
      }

      [Test]
      public void Should_return_error_with_there_is_no_order_with_the_suplied_id()
      {
         const int orderId = 1;
         var fakeDataStore = new Mock<IGetOrderById>();

         ICommand<decimal> commissionCalculation = new CommissionCalculation(orderId, fakeDataStore.Object);
         
         Assert
            .That(() => commissionCalculation.Execute(),
                  Throws.Exception
                     .InstanceOf<InvalidOperationException>());
      }

      [Test]
      public void Should_return_commission_value_equals_0_for_order_with_no_itens()
      {
         const int orderId = 1;
         var fakeDataStore = new Mock<IGetOrderById>();

         fakeDataStore
            .Setup(c => c.Execute())
            .Returns(new Order
            {
               Id = 1
            });

         ICommand<decimal> commissionCalculation = new CommissionCalculation(orderId, fakeDataStore.Object);

         var commission = commissionCalculation.Execute();

         Assert.That(commission, Is.EqualTo(0));
      }
   }
}
