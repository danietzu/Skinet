using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(
            ProductSpecificationParameters parameters) : base(p =>
                (string.IsNullOrEmpty(parameters.Search) || p.Name.ToLower().Contains(parameters.Search)) &&
                (!parameters.BrandId.HasValue || p.ProductBrandId == parameters.BrandId) &&
                (!parameters.TypeId.HasValue || p.ProductTypeId == parameters.TypeId)
            )
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
            AddOrderBy(p => p.Name);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1),
                        parameters.PageSize);

            if (!string.IsNullOrEmpty(parameters.Sort))
            {
                switch (parameters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        //public ProductsWithTypesAndBrandsSpecification(Expression<Func<Product, bool>> criteria)
        //    : base(criteria) { }

        public ProductsWithTypesAndBrandsSpecification(int id)
            : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}