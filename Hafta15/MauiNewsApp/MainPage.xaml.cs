using MauiNewsApp.Model;
using MauiNewsApp.Services;

using System.Collections.ObjectModel;

namespace MauiNewsApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            lstCategory.ItemsSource = NewsCategories;

        }

        ObservableCollection<NewsCategory> NewsCategories => new()
        {
            new NewsCategory("Manşet", url:"https://www.trthaber.com/manset_articles.rss"),
            new NewsCategory("Son Dakika", url:"https://www.trthaber.com/sondakika_articles.rss"),
            new NewsCategory("Güncem", url:"https://www.trthaber.com/gundem_articles.rss"),
            new NewsCategory("Türkiye", url:"https://www.trthaber.com/turkiye_articles.rss"),
            new NewsCategory("Dünya", url:"https://www.trthaber.com/dunya_articles.rss"),
            new NewsCategory("Ekonomi", url:"https://www.trthaber.com/ekonomi_articles.rss"),
            new NewsCategory("Spor", url:"https://www.trthaber.com/spor_articles.rss"),
            new NewsCategory("Yaşam", url:"https://www.trthaber.com/yasam_articles.rss"),
            new NewsCategory("Sağlık", url:"https://www.trthaber.com/saglik_articles.rss"),
            new NewsCategory("Kültür & Sanat", url:"https://www.trthaber.com/kultur_sanat_articles.rss"),
            new NewsCategory("Bilim & Teknoloji", url:"https://www.trthaber.com/bilim_teknoloji_articles.rss"),
            new NewsCategory("Güncel", url:"https://www.trthaber.com/guncel_articles.rss"),
            new NewsCategory("Eğitim", url:"https://www.trthaber.com/egitim_articles.rss"),
            new NewsCategory("İnfografik", url:"https://www.trthaber.com/infografik_articles.rss"),
            new NewsCategory("İnteraktif", url:"https://www.trthaber.com/interaktif_articles.rss"),
            new NewsCategory("Özel Haber", url:"https://www.trthaber.com/ozel_haber_articles.rss"),
            new NewsCategory("Dosya Haber", url:"https://www.trthaber.com/dosya_haber_articles.rss"),
        };

        private async void LoadRSSNews(object sender, EventArgs e)
        {
            var category = (sender as Button).CommandParameter as NewsCategory;
            var news = await NewsServices.GetCategoryNews(category);

            lstNews.ItemsSource = news;
        }

        private void OpenNewsDetail(object sender, SelectionChangedEventArgs e)
        {
            var news = lstNews.SelectedItem as Item;
            NewsDetailPage page = new NewsDetailPage(news);

            Navigation.PushAsync(page);
        }
    }
}
