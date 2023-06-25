using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventAddViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public string OrganiserId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
