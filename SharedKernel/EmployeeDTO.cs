
namespace SharedKernel
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }

    public class Request
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public string Status { get; set; } // "Pending", "Accepted", "Rejected", "Completed"
        public DateTime RequestTime { get; set; }
    }

    public class Ride
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } // "In Progress", "Completed", etc.
        public Ride(Guid driverId, Guid userId)
        {
            Id = Guid.NewGuid(); 
            DriverId = driverId;
            UserId = userId;
            StartTime = DateTime.UtcNow; 
            Status = "In Progress"; 
        }
    }
    
}
