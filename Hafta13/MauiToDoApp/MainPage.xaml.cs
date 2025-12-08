using MauiToDoApp.Model;

using System.Collections.ObjectModel;

namespace MauiToDoApp
{
    public partial class MainPage : ContentPage
    {

        ObservableCollection<ToDoItem> toDoItems = new ObservableCollection<ToDoItem>()
        {
            new ToDoItem() { Title="Alışveriş", Description="Marketten ekmek, süt, yumurta al.",
                Date = DateTime.Now, IsCompleted=false,
                PhotoUrl = "https://www.bartinmarketim.com/wp-content/uploads/revslider/slider-1/slider-1_slide1-copyright2.jpg" },
        };

        public MainPage()
        {
            InitializeComponent();
            lstTodo.ItemsSource = toDoItems;
        }

        private void ToolbarAddTodoItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddToDoPage(new ToDoItem()));
        }
    }
}
