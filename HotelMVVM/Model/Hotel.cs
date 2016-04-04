namespace HotelMVVM.Model
{
    public class Hotel
    {
        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string HotelAddress { get; set; }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Name = name;
            HotelAddress = address;
        }

        public Hotel()
        {
            
        }

        public override string ToString()
        {
            return string.Format("Hotelno: {0}\n Name: {1}\n Address: {2}", Hotel_No, Name, HotelAddress);
        }
    }
}