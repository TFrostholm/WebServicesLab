using HotelMVVM.Model;
using HotelMVVM.Persistency;
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
            Hotel hotel = new Hotel();
            hotel.Hotel_No = HotelViewModel.NewHotel.Hotel_No;
            hotel.Name = HotelViewModel.NewHotel.Name;
            hotel.HotelAddress = HotelViewModel.NewHotel.HotelAddress;
            new PersistenceFacade().SaveHotel(hotel);

            var hotels = new PersistenceFacade().GetHotels();

            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var hotel1 in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);
            }

            HotelViewModel.NewHotel.Hotel_No = 0;
            HotelViewModel.NewHotel.Name = "";
            HotelViewModel.NewHotel.HotelAddress = "";
        }

        public void DeleteHotel()
        {
            new PersistenceFacade().RemoveHotel(HotelViewModel.SelectedHotel);

            var hotels = new PersistenceFacade().GetHotels();

            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var hotel1 in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);
            }
        }

        public void EditHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Hotel_No = HotelViewModel.NewHotel.Hotel_No;
            hotel.Name = HotelViewModel.NewHotel.Name;
            hotel.HotelAddress = HotelViewModel.NewHotel.HotelAddress;

            new PersistenceFacade().UpdateHotel(hotel);

            var hotels = new PersistenceFacade().GetHotels();

            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var hotel1 in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);
            }

            HotelViewModel.NewHotel.Hotel_No = 0;
            HotelViewModel.NewHotel.Name = "";
            HotelViewModel.NewHotel.HotelAddress = "";
        }
    }
}