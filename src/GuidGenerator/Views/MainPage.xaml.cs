using Windows.UI.Xaml;
using GuidGenerator.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GuidGenerator.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
