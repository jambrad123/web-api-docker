using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        
        public int? OwnerId { get; set; } // PascalCase
        public Owner Owner { get; set; }
    }
}
