namespace HotelMVVM.Model
{
    public class Hotel
    {
        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return string.Format("Hotelno {0} Name {1} Address {2}", Hotel_No, Name, Address);
        }
    }
}