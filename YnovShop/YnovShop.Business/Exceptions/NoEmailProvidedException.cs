using System;
namespace YnovShop.Business.Exceptions
{
    public class NoEmailProvidedException : Exception
    {
        public override string Message => "No Email provided.";
    }
}
