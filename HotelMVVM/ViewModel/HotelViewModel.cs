using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelMVVM.Annotations;
using HotelMVVM.Handler;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class HotelViewModel:INotifyPropertyChanged
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public Handler.HotelHandler HotelHandler { get; set; }


        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            //Creates an instance of the newHotel
            _newHotel = new Hotel();

            //Creates an instance of HotelHandler
            HotelHandler = new HotelHandler(this);

        }

        private Hotel _newHotel;

        public Hotel NewHotel
        {
            get
            {
                return _newHotel;
            }
            set
            {
                _newHotel = value; OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}