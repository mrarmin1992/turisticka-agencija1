using Core.Entities;

namespace Core.Specifications
{
    public class ZnamenitostiwithFiltersForCountSpecifications : BaseSpecification<Znamenitost>
    {
        public ZnamenitostiwithFiltersForCountSpecifications(ZnamenitostSpecParams znamenitostSpecParams) 
        : base(x => 
        (string.IsNullOrEmpty(znamenitostSpecParams.Search) || x.Naziv.ToLower().Contains(znamenitostSpecParams.Search)) &&
                (!znamenitostSpecParams.VeomaznamenitoId.HasValue || x.VeomaznamenitoId == znamenitostSpecParams.VeomaznamenitoId) &&
                (!znamenitostSpecParams.NezaobilaznoId.HasValue || x.NezaobilaznoId == znamenitostSpecParams.NezaobilaznoId)
           )
        {

        }
    }
}