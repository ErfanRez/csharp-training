using System;

namespace DI.Services
{
    public class ScopeNumberService: IScopeNumberService
    {
        private int _nunmber;
        public ScopeNumberService()
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