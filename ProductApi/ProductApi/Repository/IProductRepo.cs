namespace ProductApi.Repository
{
    public interface IProductRepo<T>
    {
        T AddProduct(T product);
        T RemoveProduct(int? id);
        T UpdateProduct(T product);
        T GetProductById(int? id);
        List<T> GetAllProduct();
    }
}
