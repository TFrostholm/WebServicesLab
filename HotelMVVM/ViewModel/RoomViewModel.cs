using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class RoomViewModel
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public RoomViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;

        }
    }
}