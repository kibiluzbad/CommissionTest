using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteLevelUp.Ui.Domain
{
   public class Order
   {
      public int Id { get; set; }
      public string Owner { get; set; }
      public DateTime CreatedAt { get; set; }
      [PetaPoco.Ignore]
      public IEnumerable<OrderItem> OrderItens { get; set; }

      [PetaPoco.Ignore]
      public decimal Total
      {
         get { return null != OrderItens ? OrderItens.Sum(c => c.Value) : 0; }
      }
   }

   public class OrderItem
   {
      public int Id { get; set; }
      public decimal Value { get; set; }
   }
}