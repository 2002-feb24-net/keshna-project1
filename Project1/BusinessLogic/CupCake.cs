

namespace BusinessLogic
{
    public class CupCake
    {
        public string Location { get; set; }

        public int LocationId { get; set; }

        public CupCake (int id, string location)
        {
            this.Location = location;
            this.LocationId = id;
        }
    }
}
