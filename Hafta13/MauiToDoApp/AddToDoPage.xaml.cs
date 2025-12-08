using MauiToDoApp.Model;
using MauiToDoApp.Services;

namespace MauiToDoApp;

public partial class AddToDoPage : ContentPage
{
	ToDoItem Todo;
	public AddToDoPage(ToDoItem item)
	{
		InitializeComponent();
		Todo = item;

		this.BindingContext = item;
	}

    private void AddNewTodo(object sender, EventArgs e)
    {
		FirebaseServices.AddNewTodo(Todo);
    }
}