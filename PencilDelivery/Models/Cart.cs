namespace PencilDelivery.Models
{
    public class Cart
    {
        private List<Product> _products = new();

        public int Count => _products.Count;

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public decimal TotalPrice()
        {
            return _products.Sum(product => product.PricePerUnit);
        }

        public void Clear()
        {
            _products.Clear();
        }
    }
}
