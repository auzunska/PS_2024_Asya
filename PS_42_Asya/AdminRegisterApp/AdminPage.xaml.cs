namespace AdminRegisterApp;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminUserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}