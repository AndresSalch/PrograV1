using Azure;
using GymV1.BLL.BL;

namespace GymV1
{
    public partial class MainPage : ContentPage
    {
        private Label _label;
        private Label _label0;

        public MainPage()
        {
            InitializeComponent();

            _label0 = new Label { Text = "TEST ENV\n" };

            _label = new Label { Text = "Cargando categoria..." };

            Content = new StackLayout
            {
                Children =
            {
                _label0,
                _label
            }
            };

            _ = LoadModelAsync();
        }

        private async Task LoadModelAsync()
        {
            blCliente bl = new blCliente();
            try
            {
                var mod = await bl.getModel();

                _label.Text = $"Nombre: {mod[1].nombre}";
            }
            catch (Exception ex)
            {
                _label.Text = $"Error: {ex.Message}";
            }
        }
    }

}
