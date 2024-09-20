using Welcome.ViewModel;

namespace AdminRegisterApp;

public partial class WelcomePage : ContentPage
{
    public WelcomePage(UserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}