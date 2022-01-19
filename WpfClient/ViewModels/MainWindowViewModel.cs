using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerBackend.Models;
using WpfClient.Proxies;

namespace WpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Person> People { get; set; }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>();
            Task.Run(() => StartUpAsync()).Wait();
        }

        private async Task StartUpAsync ()
        {
            var proxy = new PersonProxy();
            var people = await proxy.GetAllAsync();
            people.ToList().ForEach(p => People.Add(p));
        }
    }
}
