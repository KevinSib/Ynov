using System;
namespace YnovShop.Business.Exceptions
{
    public class StockIsEqualOrLessThanZeroException : Exception
    {
        public override string Message => "Stock is equal or less than zero";
    }
}
