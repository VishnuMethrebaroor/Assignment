using System.ComponentModel.DataAnnotations;

namespace First_Project.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int Speed { get; set; }

    }
}
