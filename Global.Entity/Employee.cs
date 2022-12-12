
namespace Global.Entity
{
    public class Employee
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Designation { get; set; }
        public List<Empdata>? empdata { get; set; }
        public Empdata? emphead { get; set; }
        
    }

    public class Empdata
    {
        public string? Name { get; set; }
    }
}