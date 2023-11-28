namespace Server.Services
{
    public interface IPlayerService
    {
        void DoSomething();
    }

    public class PlayerService : IPlayerService
    {
        public void DoSomething()
        {
            Console.WriteLine("Hes");
        }
    }

    public class MockPlayerService : IPlayerService
    {
        public void DoSomething()
        {
            Console.WriteLine("Hes Mock");
        }
    }
}
