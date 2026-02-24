namespace Application.DTOs
{
    public class RegionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Departament { get; set; }
    }
}
