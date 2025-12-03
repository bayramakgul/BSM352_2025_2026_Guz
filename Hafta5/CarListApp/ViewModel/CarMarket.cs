using CarListApp.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModel
{
    public static class CarMarket
    {
        public static ObservableCollection<CarItem> Cars = new()
        {
            new (){Marka="Hyundai", Model="İ30", Yil="2010", Renk="Beyaz", Fiyat=500000m , Resim="https://hyundai.drive.place/images/hyundai/hyundai_i30_i-res_hatchback_5d_1.jpg"},

            new (){Marka="Opel", Model="Corsa", Yil="2019", Renk="Kırmızı", Fiyat=600000, Resim="https://drive.place/thumb/opel/opel_corsa_f_hatchback_5d_1_thumb.jpg" },

            new (){Marka="Toyota", Model="Corolla", Yil="2021", Renk="Beyaz", Fiyat=1200000}
        };
    }
}
