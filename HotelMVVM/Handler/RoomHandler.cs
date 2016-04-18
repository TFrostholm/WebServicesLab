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
            
        }
    }
}