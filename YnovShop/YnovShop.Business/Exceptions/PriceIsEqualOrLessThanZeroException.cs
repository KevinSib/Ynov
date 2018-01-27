using System;
namespace YnovShop.Business.Exceptions
{
    public class PriceIsEqualOrLessThanZeroException : Exception
    {
        public override string Message => "Price is equal or less than zero. Must be higher !";
    }
}
