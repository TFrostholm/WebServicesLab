using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class HotelViewModel
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;

        }
    }
}