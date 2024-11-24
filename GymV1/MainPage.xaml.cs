using GymV1.BLL.BL;
using GymV1.Components.Pages;
using GymV1.Share.Model;
using System.Security.Cryptography;

namespace GymV1
{
    public partial class MainPage : ContentPage
    {
        cCategoria cat;
        public MainPage()
        {
            getmethodAsync();
            InitializeComponent();
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = $"Categoria l"}
                }
            };
        }

        public async void getmethodAsync()
        {
            blCategoria bl = new blCategoria();
            cat = await bl.getModel();
        }
    }
}
