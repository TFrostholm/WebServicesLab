using HotelMVVM.Model;
using HotelMVVM.Persistency;
using HotelMVVM.ViewModel;

namespace HotelMVVM.Handler
{
    public class RoomHandler
    {
        public RoomViewModel RoomViewModel { get; set; }

        public RoomHandler(RoomViewModel roomViewModel)
        {
            RoomViewModel = roomViewModel;
        }

        public void CreateRoom()
        {
            Room room = new Room();
            room.Hotel_No = RoomViewModel.NewRoom.Hotel_No;
            room.Room_No = RoomViewModel.NewRoom.Room_No;
            room.Types = RoomViewModel.NewRoom.Types;
            room.Price = RoomViewModel.NewRoom.Price;

            //Todo insert code here to SaveHotel()

            var rooms = new PersistenceFacade().GetRooms();

            RoomViewModel.HotelCatalogSingleton.Rooms.Clear();
            foreach (var room1 in rooms)
            {
                RoomViewModel.HotelCatalogSingleton.Rooms.Add(room1);
            }

            RoomViewModel.NewRoom.Hotel_No = 0;
            RoomViewModel.NewRoom.Room_No = 0;
            RoomViewModel.NewRoom.Types = "";
            RoomViewModel.NewRoom.Price = 0;
        }
    }
}