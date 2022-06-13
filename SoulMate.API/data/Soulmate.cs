using System.ComponentModel.DataAnnotations.Schema;

namespace SoulMate.API.data
{
    public class Soulmate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}