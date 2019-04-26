using Prism.Commands;
using Prism.Events;

namespace ACCharging.Shell.ViewModels
{
    public class SentMessageWindowViewModel : BaseWindowViewModel
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private IEventAggregator _ea;

        public DelegateCommand SendMessageCommand { get; set; }

        public SentMessageWindowViewModel(IEventAggregator ea)
        {
            _ea = ea;

            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
