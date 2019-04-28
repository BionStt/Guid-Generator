using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace GuidGenerator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _message;
        private string _resultText;

        public string Message
        {
            get => _message;
            set { _message = value; RaisePropertyChanged(); }
        }

        public string ResultText
        {
            get => _resultText;
            set { _resultText = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandGenerateOneGuid { get; set; }

        public RelayCommand CommandGenerateTenGuids { get; set; }

        public RelayCommand CommandToUpper { get; set; }

        public RelayCommand CommandToLower { get; set; }

        public RelayCommand CommandClearList { get; set; }

        public RelayCommand CommandCopyToClipboard { get; set; }

        public MainViewModel()
        {
            CommandGenerateOneGuid = new RelayCommand(GenNewId);
            CommandGenerateTenGuids = new RelayCommand(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    GenNewId();
                }
            });

            CommandToUpper = new RelayCommand(() =>
            {
                if (!string.IsNullOrEmpty(ResultText))
                {
                    ResultText = ResultText.ToUpper();
                }
            });

            CommandToLower = new RelayCommand(() =>
            {
                if (!string.IsNullOrEmpty(ResultText))
                {
                    ResultText = ResultText.ToLower();
                }
            });

            CommandClearList = new RelayCommand(() =>
            {
                ResultText = string.Empty;
            });

            CommandCopyToClipboard = new RelayCommand(() =>
            {
                Edi.UWP.Helpers.Utils.CopyToClipBoard(ResultText);
            });
        }

        private void GenNewId()
        {
            Guid g = Guid.NewGuid();
            ResultText += g + Environment.NewLine;
        }
    }
}
