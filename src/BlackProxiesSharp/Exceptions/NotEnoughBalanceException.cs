using System;

namespace BlackProxiesSharp.Exceptions
{
    public class NotEnoughBalanceException : Exception
    {
        public NotEnoughBalanceException() : base("Not enough balance to purchase this plan, please make a deposit.")
        {
        }
    }
}
