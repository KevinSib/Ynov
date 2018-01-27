using System;
namespace YnovShop.Business.Exceptions
{
    public class NoDescriptionProvidedException : Exception
    {
        public override string Message => "No description provided !";
    }
}
