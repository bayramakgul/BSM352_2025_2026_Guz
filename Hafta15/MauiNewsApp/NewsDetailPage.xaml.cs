using MauiNewsApp.Model;

namespace MauiNewsApp;

public partial class NewsDetailPage : ContentPage
{
	Item News;
	public NewsDetailPage(Item news)
	{
		InitializeComponent();
		newsDetail.Source = news.link;
		this.Title = news.title;
		this.News = news;
    }

    private void ShareNews(object sender, EventArgs e)
    {
		Share.Default.RequestAsync(new ShareTextRequest
		{
			Uri = News.link,
			Text = News.title
		});
    }
}