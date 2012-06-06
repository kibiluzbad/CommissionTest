namespace TesteLevelUp.Ui.Infra
{
   public interface ICommand<out TResult>
   {
      TResult Execute();
   }
}