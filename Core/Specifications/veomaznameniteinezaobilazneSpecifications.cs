using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class veomaznameniteinezaobilazneSpecifications : BaseSpecification<Znamenitost>
    {
        public veomaznameniteinezaobilazneSpecifications(ZnamenitostSpecParams znamenitostSpecParams)
           : base(x => 
                (string.IsNullOrEmpty(znamenitostSpecParams.Search) || x.Naziv.ToLower().Contains(znamenitostSpecParams.Search)) &&
                (!znamenitostSpecParams.VeomaznamenitoId.HasValue || x.VeomaznamenitoId == znamenitostSpecParams.VeomaznamenitoId) &&
                (!znamenitostSpecParams.NezaobilaznoId.HasValue || x.NezaobilaznoId == znamenitostSpecParams.NezaobilaznoId)
           )
        {
            AddInclude(x => x.Veomaznamenito);
            AddInclude(x => x.Nezaobilazno);
            AddOrderBy(x => x.Naziv);
            ApplyPaging(znamenitostSpecParams.PageSize * (znamenitostSpecParams.PageIndex -1), znamenitostSpecParams.PageSize);

            if(!string.IsNullOrEmpty(znamenitostSpecParams.Sort))
            {     
            AddOrderBy(p => p.Naziv);        
            }
        }

        public veomaznameniteinezaobilazneSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Veomaznamenito);
            AddInclude(x => x.Nezaobilazno);
        }
    }
}