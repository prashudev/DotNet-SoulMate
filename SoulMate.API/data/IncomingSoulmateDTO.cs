using System.ComponentModel.DataAnnotations;

namespace SoulMate.API.data
{
    public class IncomingSoulmateDTO
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int CountryId { get; set; }
    }
}
