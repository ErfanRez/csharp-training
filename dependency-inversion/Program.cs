using System;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderService = new OrderService(new SmsService2());
            var orderService2 = new OrderService(new SmsService());

            orderService.Finally();
            orderService2.Finally();
            Console.ReadKey();
        }
    }

    public interface ISmsService
    {
        void Send(string message);
    }
    public class SmsService : ISmsService
    {
        public void Send(string message)
        {
            Console.Write($"V1 = {message}");
        }
    }
    public class SmsService2 : ISmsService
    {
        public void Send(string message)
        {
            Console.Write($"V2 = {message}");
        }
    }
    public class OrderService
    {
        private readonly ISmsService _service;

        public OrderService(ISmsService service)
        {
            _service = service;
        }
        public void Finally()
        {
            //
            _service.Send("Test");
        }
    }
}
