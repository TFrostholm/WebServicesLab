namespace HotelMVVM.Model
{
    public class Room
    {
        public double? Price { get; set; }

        public string Types { get; set; }

        public int Hotel_No { get; set; }

        public int Room_No { get; set; }

        public Room(double? price, string types, int hotel_No, int room_No)
        {
            Price = price;
            Types = types;
            Hotel_No = hotel_No;
            Room_No = room_No;
        }

        public Room()
        {
            
        }
        public override string ToString()
        {
            return string.Format("Hotelno: {0}\n Room Number: {1}\n Type: {2} Price: {3}", Hotel_No, Room_No, Types, Price);
        }
    }
}