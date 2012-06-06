namespace TesteLevelUp.Ui.Commands
{
   public interface IQuery<TResult>
   {
      TResult Execute();
   }
}