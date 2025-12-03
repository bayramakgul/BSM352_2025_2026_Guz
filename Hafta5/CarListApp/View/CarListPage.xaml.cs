using CarListApp.Model;
using CarListApp.ViewModel;

using System.Threading.Tasks;

namespace CarListApp.View
{
    public partial class CarListPage : ContentPage
    {
        public CarListPage()
        {
            InitializeComponent();

        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            lstArabalar.ItemsSource = CarMarket.Cars;
        }

        private void btnArabaEkle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CarDetailsPage(null));
        }

        private void btnArabaDuzenle_Clicked(object sender, EventArgs e)
        {
            CarItem car = (CarItem)lstArabalar.SelectedItem;
            if (car != null)
                Navigation.PushModalAsync(new CarDetailsPage(car));
        }

        private async void btnArabaSil_Clicked(object sender, EventArgs e)
        {
            CarItem car = (CarItem)lstArabalar.SelectedItem;
            if(car!=null)
            {
                var res = await DisplayAlert("Silmeyi Onayla",
                    $"{car.ToString()} \nListeden silinsin mi?",
                    "Evet", "Hayır");

                if (res)
                {
                    CarMarket.Cars.Remove(car);
                    lstArabalar.SelectedItem = null;
                }

            }
        }

    }
}
