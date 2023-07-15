using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? LicenseKey { get; set; }
    }
}