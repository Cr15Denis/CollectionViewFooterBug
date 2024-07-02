using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewFooterBug
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; }
        public ICommand DeleteCommand { get; set; }

        private string _total;
        public string Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>
        {
            new Item { Name = "Item 1", Description = "Description 1" },
            new Item { Name = "Item 2", Description = "Description 2" },
            new Item { Name = "Item 3", Description = "Description 3" },
            new Item { Name = "Item 4", Description = "Description 4" },
            new Item { Name = "Item 5", Description = "Description 5" },
            // Add more items as needed
        };

            DeleteCommand = new Command<string>(DeleteItem);
            UpdateTotal();
        }

        private void DeleteItem(string itemName)
        {
            var item = Items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                Items.Remove(item);
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            Total = $"Total Items: {Items.Count}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Item
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
