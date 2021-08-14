using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace project5.Models
{
    
    public class Watche

    {
        [Key]
        public int ID { get; set; }
        public int VariationId { get; set; }
        public int BrandId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string WatchesBrandUrl { get; set; }
        public Variation Variations { get; set; }
        public Brand Brands { get; set; }
    }
    public class Variation
    {
        [Key]
        public int VariationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Watche> Watches { get; set; }
    }
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }

    public class BBBContext : DbContext
    {

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Watche> Watches { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Cart> Carts { get; set; }
        
    }

    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Watche Watches { get; set; }
    }
    public partial class ShoppingCart
    {
        BBBContext storedb = new BBBContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
       
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Watche watches)
        {
            
            var cartItem = storedb.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ID == watches.ID);

            if (cartItem == null)
            {
                
                cartItem = new Cart
                {
                    ID = watches.ID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storedb.Carts.Add(cartItem);
            }
            else
            {
               
                cartItem.Count++;
            }
          
            storedb.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
           
            var cartItem = storedb.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storedb.Carts.Remove(cartItem);
                }
                
                storedb.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storedb.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storedb.Carts.Remove(cartItem);
            }
           
            storedb.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return storedb.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
          
            int? count = (from cartItems in storedb.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
          
            return count ?? 0;
        }
        public decimal GetTotal()
        {
           
            decimal? total = (from cartItems in storedb.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Watches.Price).Sum();

            return total ?? decimal.Zero;
        }
       
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                   
                    Guid tempCartId = Guid.NewGuid();
                 
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
       
        public void MigrateCart(string userName)
        {
            var shoppingCart = storedb.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storedb.SaveChanges();
        }
    }
}