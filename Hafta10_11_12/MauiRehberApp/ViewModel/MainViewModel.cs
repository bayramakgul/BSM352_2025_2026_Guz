using EntityLayer;

using MauiRehberApp.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MauiRehberApp.ViewModel
{
    public class MainViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public ObservableCollection<Kisi> kisiler;

        public Kisi YeniKisi { get; set; } = new Kisi();

        public ObservableCollection<Kisi> Kisiler { get => kisiler;
            set
            {
                kisiler = value;
                OnPropertyChanged(nameof(Kisiler));
            }
        }

        public MainViewModel(Action<string> ShowErrorMessage)
        {
            string mesaj;
            if(!BusinessLayer.BL.Yukle("", out mesaj))
            {
                // hata mesajı göster
                ShowErrorMessage(mesaj);
                return;
            }

            Kisiler = BusinessLayer.BL.Kisiler;

        }


        internal void Filtrele(string text)
        {
            Kisiler = new ObservableCollection<Kisi>(BusinessLayer.BL.Kisiler
                .Where(x => x.Ad.Contains(text)
                         || x.Soyad.Contains(text)
                         || x.Telefon.Contains(text)));
        }
    }
    public static class Extensions
    {
        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] FromBase64(this string base64)
        {
            return Convert.FromBase64String(base64);
        }

        public static ImageSource FromBase64String(this string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            return ImageSource.FromStream(() => new System.IO.MemoryStream(imageBytes)) as ImageSource;
        }
    }
}
