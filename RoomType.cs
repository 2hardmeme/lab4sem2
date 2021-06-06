namespace Zoo
{
    public class RoomType
    {
        public enum Room
        {
            Cage,
            Aviary,
            Aquarium,
            Terrarium
        }
        public Room room { get; set; }
        public RoomType() { }
        public RoomType(Room room)
        {
            this.room = room;
        }
        public override string ToString()
        {
            return "RoomType: " + room.ToString();
        }
    }
}
