using System.ComponentModel.DataAnnotations;

namespace Plantopia.WebApi.Domains.Model.Plant
{
    public class PlantType
    {
        [Key]
        public int PlantTypeId { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }
    }
}