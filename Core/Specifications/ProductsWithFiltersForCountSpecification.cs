using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(
            ProductSpecificationParameters parameters) : base(p =>
                (string.IsNullOrEmpty(parameters.Search) || p.Name.ToLower().Contains(parameters.Search)) &&
                (!parameters.BrandId.HasValue || p.ProductBrandId == parameters.BrandId) &&
                (!parameters.TypeId.HasValue || p.ProductTypeId == parameters.TypeId)
            )
        {
        }
    }
}