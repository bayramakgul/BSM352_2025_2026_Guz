using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmlakIlanApp.Model
{
    public class Emlak : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        string id, konum, tur, email, telefon;
        decimal fiyat;
        int imar,metrekare;

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
       // public string IlanBasligi { get; set; }
       // public string Aciklama { get; set; }
        public decimal Fiyat {
            get => fiyat;
            set
            {
                fiyat = value;
                NotifyPropertyChanged();
            }
        }
        public int MetreKare { get => metrekare;
            set
            {
                metrekare = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IlanBasligi));
                NotifyPropertyChanged(nameof(Aciklama));
            }
        }
        public string Konum { get=>konum;
            set
            {
                konum = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(Aciklama));
            }
        }

        public int ImarOrani { get => imar;
            set
            {
                imar = value;
                NotifyPropertyChanged();
            }
        }

        public string EmlakTuru
        {
            get => tur; set
            {
                tur = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IlanBasligi));
                NotifyPropertyChanged(nameof(Aciklama));
            }
        } // Örneğin: Daire, Villa, Arsa, Tarla, vb.

        public string Email {
            get { return email; }
            set{
                email = value;
                NotifyPropertyChanged();
            }
        }
        public string Telefon { 
            get => telefon;
            set{
                telefon = value;
                NotifyPropertyChanged();
            }
        }

        public string Resim => ResimLinkleri[0];

        public List<string> ResimLinkleri { get; set; } = new List<string>();

        public string Manzara { get; set; }
        public string Cephe { get; set; }

        public string IlanBasligi => $"Satlık {EmlakTuru} {MetreKare} m2";
        public string Aciklama => $"{Konum} ilinde {MetreKare} m2 {EmlakTuru.ToLower()} satılıktır.\n" +
                    $"{Manzara}\n, " +
                    $"{Cephe}.\n" +
                    $"Bu bilgiler rastgele üretilmiştir, gerçek değildir.";

    }
}
