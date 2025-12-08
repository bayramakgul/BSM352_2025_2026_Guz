using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MauiToDoApp.Model
{
    public class ToDoItem : INotifyPropertyChanged
    {
        string id, title, description, photourl;
        bool iscomp;
        DateTime date;

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

        public string Title { get=> title;
            set { title = value;
                OnPropertyChanged();
            } }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get => iscomp;
            set
            {
                iscomp = value;
                OnPropertyChanged();
            }
        }

        public string PhotoUrl
        {
            get => photourl;
            set
            {
                photourl = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

    }
}
