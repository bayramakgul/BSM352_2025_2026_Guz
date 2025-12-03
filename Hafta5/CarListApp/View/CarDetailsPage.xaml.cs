using CarListApp.Model;
using CarListApp.ViewModel;

namespace CarListApp.View
{
    public partial class CarDetailsPage : ContentPage
    {
        public CarItem Car { get; set; }
        bool Duzenle = false;

        public CarDetailsPage(CarItem car)
        {
            InitializeComponent();
            Duzenle = car != null;

            if(car == null)
                car = new CarItem();

            Car = car;
            BindingContext = car;
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty( Car.Marka)
                || string.IsNullOrEmpty(Car.Model)
                || string.IsNullOrEmpty(Car.Yil)
                || string.IsNullOrEmpty(Car.Renk)
                || Car.Fiyat == 0 )
            {
                DisplayAlert("Eksik Bilgi","Lütfen Eksik Bilgileri Doldurun", "OK");
                return;
            }

            if (!Duzenle)
            {
                if (Car != null)
                    CarMarket.Cars.Add(Car);
            }

            Navigation.PopModalAsync();
        }


        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Car = null;
            Navigation.PopModalAsync();
        }
    }
}
