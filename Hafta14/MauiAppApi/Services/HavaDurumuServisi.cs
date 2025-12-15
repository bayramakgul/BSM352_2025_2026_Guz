using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppApi.Services
{
    internal static class HavaDurumuServisi
    {
        /*Kodların Kullanımı ile İlgili Genel Açıklamalar
Merkez (m=ANKARA)
Anlık durum gösterimi ve tahminler için kullanılması zorunludur. Merkez isimleri büyük harflerle ve Türkçe karakter kullanılmadan yazılmalıdır. Afyonkarahisar için AFYON değil AFYONKARAHISAR kullanılmalıdır. Kahramamaraş içinse K.MARAS kullanılmaktadır.

Merkez olarak tüm illerimizin yanında http://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx adresinde illerin altında listelenen ilçeler de kullanılabilir.

Merkez isimlerinde ç, Ç, ö, Ö, ş, Ş, ı, İ, ü, Ü, ğ, Ğ'den olaşan Türkçe harfler yerine c, C, o, O, s, S, i, I, u, U, g, G karakterlerini kullanmalısınız.

Gün (basla=1, bitir=5) (Sadece Tahmin İçin)
Tahminler için kullanılması zorunludur. 5 günlük tahmin süreci içinde istenilen günden başlanılır ve istenilen gün ile bitirilir.

Çerçeve Rengi (rC=111fff)
Kullanılması zorunlu değildir. Oluşturulacak resimde çerçeve kullanılmışsa rengini bu sorgu metnini kullanarak değiştirebilirsiniz. Renklerin hexadecimal kodlarını kullanarak (111, fedd00 gibi) istediğiniz rengi elde edebilirsiniz.

Zemin rengi (rZ=0000cc)
Kullanılması zorunlu değildir. Bu seçenekle resimlerin zemin rengini değiştirebilirsiniz. Hava durumunu simgeleyen grafiklerin zemini bu değişiklikten etkilenmez. Varsayılan değeri beyazdır (fff).

Dil Seçimi
Bazı resimler için farklı dil seçenekleri de hazırlanmıştır. Üstteki listede belirtilenlerle sınırlı kalmak koşulu ile dosya isimlerinin sonuna eklenecek -en eki ile resim oluşturulurken İngilizce metinler ve bölgesel ayarlar kullanılmaktadır.
         
         */

        public static string NormalizeCityName(string cityName)
        {
            //Anlık durum gösterimi ve tahminler için kullanılması zorunludur.
            //Merkez isimleri büyük harflerle ve Türkçe karakter kullanılmadan yazılmalıdır.
            //Afyonkarahisar için AFYON değil AFYONKARAHISAR kullanılmalıdır.
            //Kahramamaraş içinse K.MARAS kullanılmaktadır.

            //Merkez isimlerinde ç, Ç, ö, Ö, ş, Ş, ı, İ, ü, Ü, ğ, Ğ'den olaşan Türkçe harfler yerine c, C, o, O, s, S, i, I, u, U, g, G karakterlerini kullanmalısınız.

            cityName = cityName.ToUpper();

            cityName = cityName.Replace("Ç", "C");
            cityName = cityName.Replace("Ö", "O");
            cityName = cityName.Replace("Ş", "S");
            cityName = cityName.Replace("İ", "I");
            cityName = cityName.Replace("Ü", "U");
            cityName = cityName.Replace("Ğ", "G");

            cityName = cityName.Replace("ç", "C");
            cityName = cityName.Replace("ö", "O");
            cityName = cityName.Replace("ş", "S");
            cityName = cityName.Replace("ı", "I");
            cityName = cityName.Replace("ü", "U");
            cityName = cityName.Replace("ğ", "G");

            cityName = cityName.ToUpper();

            if (cityName== "KAHRAMANMARAS")
                cityName = "K.MARAS";
            else if (cityName == "AFYON")
                cityName = "AFYONKARAHISAR";

            return cityName;
        }

        public static string HavaDurumuBugun(string sehir)
        {
            var bugun_url = $"http://www.mgm.gov.tr/sunum/sondurum-show-2.aspx?m={sehir}&rC=111&rZ=fff";
            // Hava durumu verilerini yükleme işlemleri burada yapılacak
            // Bu örnekte basitçe bir URL döndürüyoruz

            return bugun_url;
        }

        public static string HavaDurumu5gun(string sehir)
        {
            var besgun_url = $"https://www.mgm.gov.tr/sunum/tahmin-show-2.aspx?m={sehir}&basla=1&bitir=5&rC=111&rZ=fff";
            // 5 günlük hava durumu verilerini yükleme işlemleri burada yapılacak
            // Bu örnekte basitçe bir URL döndürüyoruz

            return besgun_url;
        } 



    }

    public class Sehir
    {
        public string SehirAdi { get; set; }
        public string BugunUrl => HavaDurumuServisi.HavaDurumuBugun(HavaDurumuServisi.NormalizeCityName(SehirAdi));
        public string BesGunUrl => HavaDurumuServisi.HavaDurumu5gun(HavaDurumuServisi.NormalizeCityName(SehirAdi));

    }
}
