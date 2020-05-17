using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProuctSpecParams prouctParams)
        :base(x=> 
        (string.IsNullOrEmpty(prouctParams.Search) || x.Name.Contains(prouctParams.Search))&&
        (!prouctParams.BrandId.HasValue || x.ProductBrandId==prouctParams.BrandId)&&
        (!prouctParams.TypeId.HasValue || x.ProductTypeId==prouctParams.TypeId))
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
            ApplyPaging(prouctParams.PageSize * (prouctParams.PageIndex -1),prouctParams.PageSize);

            if(!string.IsNullOrEmpty(prouctParams.Sort)){
                switch (prouctParams.Sort)
                {
                    case "priceAsc":
                    AddOrderBy(x=>x.Price);
                    break;
                    case "priceDesc":
                    AddOrderByDecending(x=>x.Price);
                    break;
                    default:
                    AddOrderBy(x=>x.Name);
                    break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}