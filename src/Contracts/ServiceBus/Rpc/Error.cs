using System;

namespace Contracts.ServiceBus.Rpc
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        
        public Error()
        {
        }

        public Error(Enum error, string message = null)
        {
            Code = Convert.ToInt32(error);
            Message = message;
        }


    }
}