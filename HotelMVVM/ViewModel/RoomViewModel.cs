using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RoomViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
        }

        private Room _newRoom;

        public Room NewRoom
        {
            get { return _newRoom; }
            set { _newRoom = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]     string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}