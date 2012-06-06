using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteLevelUp.Ui.Commands;
using TesteLevelUp.Ui.Domain;
using TesteLevelUp.Ui.Infra;
using TesteLevelUp.Ui.Queries;

namespace TesteLevelUp.Ui
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Digite o id do pedido:");
         var id = Console.ReadLine();
         ICommand<decimal> commissionCalculation = new CommissionCalculation(Convert.ToInt32(id), new GetOrderById());

         try
         {
            var comission = commissionCalculation.Execute();
            Console.WriteLine("Comissão é de: {0}", comission.ToString("C2"));
         }
         catch (InvalidOperationException ioex)
         {
            Console.WriteLine(ioex.Message);
         }
         Console.WriteLine("Pressione ENTER para sair...");
         Console.ReadLine();
      }
   }
}
