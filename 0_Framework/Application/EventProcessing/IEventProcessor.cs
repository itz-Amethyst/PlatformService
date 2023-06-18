namespace _0_Framework.Application.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
