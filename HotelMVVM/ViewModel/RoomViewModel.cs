using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HotelMVVM.Common;
using HotelMVVM.Handler;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        // reference to singleton
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }

        // Refence to RoomHandler
        public Handler.RoomHandler RoomHandler { get; set; }
            
        public RoomViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;           

            //Creates an instance of the newHotel
            _newRoom = new Room();

            // New instance of RoomHandler
            RoomHandler = new Handler.RoomHandler(this);

            // Creates instances of relayCommand
            CreateRoomCommand = new RelayCommand(RoomHandler.CreateRoom);
        }

        private Room _newRoom;
        private ICommand _createRoomCommand;

        public Room NewRoom
        {
            get { return _newRoom; }
            set { _newRoom = value; OnPropertyChanged(); }
        }

        public ICommand CreateRoomCommand
        {
            get { return _createRoomCommand; }
            set { _createRoomCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]     string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}