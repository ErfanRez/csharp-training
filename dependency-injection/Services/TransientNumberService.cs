using System;

namespace DI.Services
{
    public class TransientNumberService: ITransientNumberService
    {
        private int _nunmber;
        public TransientNumberService()
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