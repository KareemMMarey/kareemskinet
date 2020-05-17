using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecefication : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecefication(ProuctSpecParams prouctParams)
        :base(x=> 
        (string.IsNullOrEmpty(prouctParams.Search) || x.Name.Contains(prouctParams.Search))&&
        (!prouctParams.BrandId.HasValue || x.ProductBrandId==prouctParams.BrandId)&&
        (!prouctParams.TypeId.HasValue || x.ProductTypeId==prouctParams.TypeId))
        {
        }
    }
}