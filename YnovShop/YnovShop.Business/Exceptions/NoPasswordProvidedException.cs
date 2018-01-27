using System;
namespace YnovShop.Business.Exceptions
{
    public class NoPasswordProvidedException : Exception
    {
        public override string Message => "No Password provided";
    }
}
