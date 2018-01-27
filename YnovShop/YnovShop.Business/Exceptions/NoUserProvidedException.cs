using System;
namespace YnovShop.Business.Exceptions
{
    public class NoUserProvidedException : Exception
    {
        public override string Message => "No user provided !";
    }
}
