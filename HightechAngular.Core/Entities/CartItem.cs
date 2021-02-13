using System.ComponentModel.DataAnnotations;
using Force.Ddd;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HightechAngular.Orders.Entities
{
    // JSON Serialization prevents encapsulation :(
    public class CartItem
    {
        public CartItem(Product product, int count = 1)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            CategoryName = product.Category.Name;
            Price = product.GetDiscountedPrice();
            Count = count;
        }

        [JsonConstructor]
        private CartItem(int productId, string productName, string categoryName, double price, int count)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryName = categoryName;
            Price = price;
            Count = count;
        }

        [Display(Name = "Product Id")]
        public int ProductId { get; protected set; }

        [Display(Name = "Name")]
        public string ProductName { get; protected set; }

        [Display(Name = "Category")]
        public string CategoryName { get; protected set; }

        [Display(Name = "Price")]
        public double Price { get; protected set; }

        [Display(Name = "Count")]
        public int Count { get; protected set; }

        public void DecrementCount(int count = 1)
        {
            Count -= count;
        }
        public void IncreaseCount(int count = 1)
        {
            Count += count;
        }
        public override string ToString() => $"{ProductName}: ${Price}";
    }
}