using System;
namespace YnovShop.Business.Exceptions
{
    public class NoNameProvidedException : Exception
    {
        public override string Message => "No Name provided !";  
    }
}
