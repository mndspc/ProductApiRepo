using ProductApi.Models;

namespace ProductApi.Repository
{
    public class ProductService : IProductRepo<Product>
    {
        static List<Product> products = new List<Product>
        {
            new Product { ProductId=1001,ProductName="Toothpaste",ProductCategory="FMCG"},
            new Product { ProductId=1002,ProductName="Shampoo",ProductCategory="FMCG"},
            new Product { ProductId=1003,ProductName="Mobile Phone",ProductCategory="Gadgets"},
            new Product { ProductId=1004,ProductName="Headphone",ProductCategory="Gadgets"}
        };
        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public List<Product> GetAllProduct()
        {
           return products;
        }

        public Product GetProductById(int? id)
        {
            var productById= products.FirstOrDefault(p => p.ProductId == id);
            return productById;
        }

        public Product RemoveProduct(int? id)
        {
            var productById = products.FirstOrDefault(p => p.ProductId == id);
            if (productById != null)
            {
                products.Remove(productById);

            }
            return productById; 
        }

        public Product UpdateProduct(Product newProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductId == newProduct.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = newProduct.ProductName;
                existingProduct.ProductCategory = newProduct.ProductCategory;
                
            }
            return newProduct;
        }
    }
}
