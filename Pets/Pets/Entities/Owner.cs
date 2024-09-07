namespace Pets.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public List<Pet> Pets { get; set; } = [];
    }
}
