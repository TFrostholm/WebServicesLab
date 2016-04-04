using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelMVVM.Annotations;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class HotelViewModel:INotifyPropertyChanged
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}