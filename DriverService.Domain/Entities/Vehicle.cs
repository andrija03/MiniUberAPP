namespace DriverService.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; private set; }
        public string Brand { get; private set; }   
        public string Model { get; private set; }   
        public string Color { get; private set; }  
        public int NumberOfSeats { get; private set; }  
        public bool IsAvailable { get; private set; } 

        public Vehicle(string brand, string model, string color, int numberOfSeats)
        {
            Id = Guid.NewGuid();
            Brand = brand;
            Model = model;
            Color = color;
            NumberOfSeats = numberOfSeats;
            IsAvailable = true;   
        }

        public void SetAvailability(bool availability)
        {
            IsAvailable = availability;
        }
    }
}
