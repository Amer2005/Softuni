using Footballers.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(ValidationConstants.TeamNameMinLength)]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        [RegularExpression(@"^[a-zA-Z\d\s.-]+$")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("Nationality")]
        [MinLength(ValidationConstants.TeamNationalityMinLength)]
        [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballersIds { get; set; }
    }
}
