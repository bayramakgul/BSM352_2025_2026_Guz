using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakIlanApp.Model
{
    public static class DataGenerator
    {
        public static List<string> Konumlar = new()
        {
           "Adana",
            "Adıyaman",
            "Afyon",
            "Ağrı",
            "Amasya",
            "Ankara",
            "Antalya",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkari",
            "Hatay",
            "Isparta",
            "Mersin İçel",
            "İstanbul",
            "İzmir",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kırklareli",
            "Kırşehir",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Kahramanmaraş",
            "Mardin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Rize",
            "Sakarya",
            "Samsun",
            "Siirt",
            "Sinop",
            "Sivas",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Şanlıurfa",
            "Uşak",
            "Van",
            "Yozgat",
            "Zonguldak",
            "Aksaray",
            "Bayburt",
            "Karaman",
            "Kırıkkale",
            "Batman",
            "Şırnak",
            "Bartın",
            "Ardahan",
            "Iğdır",
            "Yalova",
            "Karabük",
            "Kilis",
            "Osmaniye",
            "Düzce",

        };

        static List<string> EmlakTurleri = new()
        {
            "Daire", "Ofis", "Dükkan", "Villa", "Depo", "Arsa", "Tarla"
        };

        static List<string> Manzaralar = new()
        {
                        "Deniz Manzaralı",
                        "Şehir Manzaralı",
                        "Doğa Manzaralı",
                        "Dağ Manzaralı",
                        "Göl Manzaralı",
                        "Kırsal Alanda",
                        "Kıyıda",
                        "Orman Kenarında",
                        "Göl Kenarında",
                        "Şehir Merkezinde",
                        "Köy Ortasında",


        };

        static List<string> Cepheler = new()
        {
            "Kuzey Cepheli",
            "Güney Cepheli",
            "Doğu Cepheli",
            "Batı Cepheli",
            "Kuzeydoğu Cepheli",
            "Kuzeybatı Cepheli",
            "Güneydoğu Cepheli",
            "Güneybatı Cepheli",
            "Güneş Gören",
            "Yüksek Rakımlı",
        };

        static Random random = new Random();

        public static ObservableCollection<Emlak> RandomEmlakUret(int adet)
        {
            ObservableCollection<Emlak> emlaklar = new();
            for (int i= 0; i < adet; i++)
            {
                Emlak emlak = new Emlak();
                emlak.EmlakTuru = EmlakTurleri[random.Next(EmlakTurleri.Count)];
                switch (emlak.EmlakTuru)
                {
                    case "Daire":
                        emlak.MetreKare = random.Next(90, 220); break;
                    case "Ofis":
                    case "Dükkan":
                        emlak.MetreKare = random.Next(50, 300); break;
                    case "Villa":
                        emlak.MetreKare = random.Next(150, 500); break;
                        case "Depo":
                        emlak.MetreKare = random.Next(100, 400); break;
                    case "Arsa":
                        emlak.MetreKare = random.Next(200, 10000); 
                        emlak.ImarOrani = random.Next(10, 80); 
                        break;
                    case "Tarla":
                        emlak.MetreKare = random.Next(500, 20000); 
                        emlak.ImarOrani = 5;
                        break;
                }

                emlak.Konum = Konumlar[random.Next(Konumlar.Count)];
                emlak.Fiyat = emlak.MetreKare * random.Next(1000, 5000);
                emlak.Telefon = "05" + random.Next(100000000, 999999999).ToString();
                emlak.Email = "fakemail" + random.Next(1000, 9999).ToString() + "@fakemail.com";
                emlak.Manzara = $"{Manzaralar[random.Next(Manzaralar.Count)]}";
                emlak.Cephe = $"{Cepheler[random.Next(Cepheler.Count)]}";


                /*emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");
                emlak.ResimLinkleri.Add($"https://picsum.photos/seed/{random.Next(1000)}/100/100");*/

                emlak.ResimLinkleri.Add($"https://loremflickr.com/320/240/house?random={random.Next(1000)}");
                emlak.ResimLinkleri.Add($"https://loremflickr.com/320/240/house?random={random.Next(1000)}");
                emlak.ResimLinkleri.Add($"https://loremflickr.com/320/240/house?random={random.Next(1000)}");
                emlak.ResimLinkleri.Add($"https://loremflickr.com/320/240/house?random={random.Next(1000)}");
                emlak.ResimLinkleri.Add($"https://loremflickr.com/320/240/house?random={random.Next(1000)}");


                emlaklar.Add(emlak);
            }
            return emlaklar;
        }

    }
}
