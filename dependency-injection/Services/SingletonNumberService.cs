using System;

namespace DI.Services
{
    public class SingletonNumberService: ISingletonNumberService
    {
        private int _nunmber;
        public SingletonNumberService()
        {
            var random = new Random();
            _nunmber = random.Next(0, 999999999);
        }
        public int GetNumber()
        {
            return _nunmber;
        }
    }
}