using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ZnamenitostToCreate
    {
         [Required]
          public string Name { get; set; }

          [Required]
          public string Description { get; set; }
         
          public string PictureUrl { get; set; }

          [Required]
          public int VeomaznamenitoId { get; set; }

          [Required]
          public int NezaobilaznoId { get; set; }

    }
}