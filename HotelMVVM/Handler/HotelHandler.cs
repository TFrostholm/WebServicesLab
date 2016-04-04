using HotelMVVM.ViewModel;

namespace HotelMVVM.Handler
{
    public class HotelHandler
    {
        public HotelViewModel HotelViewModel { get; set; }

        public HotelHandler(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;
        }

        public void CreateHotel()
        {
            HotelViewModel.HotelCatalogSingleton.Add(HotelViewModel.NewHotel.Hotel_No, HotelViewModel.NewHotel.Name, HotelViewModel.NewHotel.HotelAddress);
        }
    }
}