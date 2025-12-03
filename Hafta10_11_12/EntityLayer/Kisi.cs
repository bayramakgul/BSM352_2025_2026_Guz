using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace EntityLayer
{
    public class Kisi : INotifyPropertyChanged
    {
        string id, ad, soyad, email, tel, resim;

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                    id = Guid.NewGuid().ToString();
                // örnek: "C9C40BA1-A5D1-4D11-BC40-32AE8AF2F339"

                return id;
            }
            set => id = value;
        }
        public string Ad
        {
            get => ad;
            set
            {
                ad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AdSoyad));
            }
        }
        public string Soyad { get => soyad;
            set
            {
                soyad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AdSoyad));
            }
        }

        public string AdSoyad => $"{Ad} {Soyad}";

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();

            }
        }
        public string Telefon { get => tel;
            set{tel = value;
                OnPropertyChanged();
            }}

        [JsonIgnore]
        public string Resim
        {
            get => resim;
            set
            {
                resim = value;
                OnPropertyChanged();
            }
        }

        public string ResimData
        {
            get
            {
                return string.IsNullOrEmpty(Resim) ?
                    null :
                    Convert.ToBase64String(File.ReadAllBytes(Resim));
            }
            set
            {
                if(value == null)
                {
                    Resim = null;
                    return;
                }

                byte[] bytes = Convert.FromBase64String(value);
                File.WriteAllBytes($"kisi_{Id}.jpg", bytes);
                Resim = $"kisi_{Id}.jpg";
            }
        }
    }
}
