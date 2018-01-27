using System;
namespace YnovShop.Business.Exceptions
{
    public class NoProductProvidedException : Exception
    {
        public override string Message => "No product provided !";
    }
}
