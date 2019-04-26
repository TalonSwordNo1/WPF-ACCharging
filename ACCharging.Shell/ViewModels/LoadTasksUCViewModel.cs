using ACCharging.Core.Services;
using ACCharging.Shell.Views;
using Prism.Commands;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class LoadTasksUCViewModel: BaseDialogViewModel
    {
        private ObservableCollection<string> _messageList;
        public ObservableCollection<string> MessageList
        {
            get => _messageList;
            set => SetProperty(ref _messageList, value);
        }

        private IEventAggregator _ea;

        [Dependency]
        public TestService TestService { get; set; }
        
        public DelegateCommand LoadTaskCommand { get; set; }

        public LoadTasksUCViewModel(IEventAggregator ea)
        {
            _ea = ea;
            MessageList = new ObservableCollection<string>();

            LoadTaskCommand = new DelegateCommand(LoadTask);

            // receive messages
            _ea.GetEvent<MessageSentEvent>().Subscribe(ReceiveMessages);
        }

        public override void InitViewModel()
        {
            base.InitViewModel();

            var allTestReporters = TestService.GetAllTestReporters();
        }

        private void ReceiveMessages(string msg)
        {
            MessageList.Add(msg);
        }

        private void LoadTask()
        {
            SentMessageWindow sentMsgWin = new SentMessageWindow();
            sentMsgWin.ShowDialog();
        }
    }
}
