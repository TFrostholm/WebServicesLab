using System.Collections.ObjectModel;
using HotelMVVM.Persistency;

namespace HotelMVVM.Model
{
    public class HotelCatalogSingleton
    {
        private static HotelCatalogSingleton instance = new HotelCatalogSingleton();



        public static HotelCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Hotel> Hotels { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        private HotelCatalogSingleton()
        {
            // Getting all hotels into the observable collection
            Hotels = new ObservableCollection<Hotel>(new PersistenceFacade().GetHotels());

            // Getting all rooms into the observable collection
            Rooms = new ObservableCollection<Room>(new PersistenceFacade().GetRooms());
        }

        public void Add(int Hotel_No, string Name, string Address)
        {
            Hotels.Add(new Hotel(Hotel_No, Name, Address));
        }
    }
}