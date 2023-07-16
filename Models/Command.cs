using System.ComponentModel.DataAnnotations;
using CommanderGQL.Models;

namespace CommanderGQL.Models
{

    public class Command
    {

        [Key]
        public int Id { get; set; }
        public required string HowTo { get; set; }
        public required string CommandLine { get; set; }
        public required int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}