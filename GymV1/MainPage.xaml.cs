using Azure;
using GymV1.BLL.BL;
using GymV1.Components.Pages;
using GymV1.Share.Model;
using System.Diagnostics;
using System.Security.Cryptography;

namespace GymV1
{
    public partial class MainPage : ContentPage
    {
        private Label _label;

        public MainPage()
        {
            InitializeComponent();

            _label = new Label { Text = "Loading categoria..." };

            Content = new StackLayout
            {
                Children =
            {
                _label
            }
            };

            _ = LoadCategoriaAsync();
        }

        private async Task LoadCategoriaAsync()
        {
            blCategoria bl = new blCategoria();
            try
            {
                var mod = await bl.getModel();

                _label.Text = $"categoria: {mod[5].categoria}";
            }
            catch (Exception ex)
            {
                _label.Text = $"Error: {ex.Message}";
            }
        }
    }

}
