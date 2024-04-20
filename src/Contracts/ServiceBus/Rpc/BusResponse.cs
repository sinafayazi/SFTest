namespace Contracts.ServiceBus.Rpc
{
    public class BusResponse
    {
        public virtual Error Error { get; set; }

        public virtual bool Success()
        {
            return Error != null;
        }
    }
}