using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Model
{
    public class CarItem : INotifyPropertyChanged
    {
        string id, resim, marka,model,yil, renk;
        decimal fiyat;


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
                NotifyPropertyChanged();
            }
        }
        public string Model
        {
            get => model;
            set
            {
                model = value;
                NotifyPropertyChanged();
            }
        }
        public string Yil
        {
            get => yil;
            set
            {
                yil = value;
                NotifyPropertyChanged();
            }
        }
        public string Renk
        {
            get => renk;
            set
            {
                renk = value;
                NotifyPropertyChanged();
            }
        }
        public decimal Fiyat
        {
            get => fiyat;
            set
            {
                fiyat = value;
                NotifyPropertyChanged();
            }
        }

        public string Resim
        {
            get
            {
                if (string.IsNullOrEmpty(resim))
                    return "car.png";
                return resim;
            }
            set
            {
                resim = value;
                NotifyPropertyChanged();
            }
        }


        public override string ToString()
        {
            return $"{Marka} {Model} ({Yil}) {Renk} - {Fiyat:C2}";
        }

        public CarItem() { }

        public CarItem(string id, string marka, string model, string yıl, string renk, string resim = null, decimal fiyat = 0)
        {
            ID = id;
            Marka = marka;
            Model = model;
            Yil = yıl;
            Renk = renk;
            Resim = resim;
            Fiyat = fiyat;
        }
    }
}
