using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class veomaznameniteinezaobilazneSpecifications : BaseSpecification<Znamenitost>
    {
        public veomaznameniteinezaobilazneSpecifications()
        {
            AddInclude(x => x.Veomaznamenito);
            AddInclude(x => x.Nezaobilazno);
        }

        public veomaznameniteinezaobilazneSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Veomaznamenito);
            AddInclude(x => x.Nezaobilazno);
        }
    }
}