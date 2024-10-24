namespace DriverService.Domain.Entities
{
    public class Driver
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LicenseNumber { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }
        public bool IsAvailable { get; private set; }
        public Vehicle ActiveVehicle { get; private set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public int DurationInSeconds { get; set; }

        public Driver(string name, string licenseNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            LicenseNumber = licenseNumber;
            Vehicles = new List<Vehicle>();
            IsAvailable = true;
        }

        public void RegisterVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void SetActiveVehicle(Vehicle vehicle)
        {
            if (Vehicles.Contains(vehicle))
            {
                ActiveVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Vehicle is not registered for this driver.");
            }
        }


        public void MarkAsBusy()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
    }
}
