using System;

namespace CoR_Demo
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }

    abstract class AbstractHandler : IHandler
    {
        IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            return this._nextHandler?.Handle(request);
        }
    }

    class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new[]{"Nut","Banana","Cup of Coffee"})
            {
                Console.WriteLine($"Client: Who wants a {food}");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.WriteLine($"    {result}");
                }
                else
                {
                    Console.WriteLine($"    {food} was left untouched.{Environment.NewLine}");
                }
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}