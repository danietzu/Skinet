using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
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