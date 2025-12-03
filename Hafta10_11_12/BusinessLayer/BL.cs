using EntityLayer;

using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public static class BL
    {
        public static ObservableCollection<Kisi> Kisiler;

        public static bool Yukle(string filter, out string message)
        {
            var liste = DataLayer.DL.KisileriYukle(filter="", out message);
            if (liste != null)
                Kisiler = new ObservableCollection<Kisi>(liste);

                return liste != null;
        }

        public static bool Ekle(Kisi k, out string mesaj)
        {
            int sonuc = DataLayer.DL.KisiEkle(k, out mesaj);
            if (sonuc > 0)
            {
                Kisiler.Add(k);
            }
            return sonuc > 0;
        }

        public static bool Guncelle(Kisi k, out string mesaj)
        {
            int sonuc = DataLayer.DL.KisiDuzenle(k, out mesaj);
            if(sonuc > 0)
            {
                var eskiKisi = Kisiler.FirstOrDefault(x => x.Id == k.Id);
                if(eskiKisi != null)
                {
                    int index = Kisiler.IndexOf(eskiKisi);
                    Kisiler[index] = k;
                }
            }
            return sonuc > 0;
        }

        public static bool Sil(string id, out string mesaj)
        {
            int sonuc = DataLayer.DL.KisiSil(id, out mesaj);
            if(sonuc > 0)
            {
                var silinecekKisi = Kisiler.FirstOrDefault(x => x.Id == id);
                if(silinecekKisi != null)
                {
                    Kisiler.Remove(silinecekKisi);
                }
            }
            return sonuc > 0;
        }
    }
}
