﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TrendyolApp.Models;

namespace TrendyolApp.Data
{
    public static class CartData
    {
        public static ObservableCollection<CartModel> Products { get { return products; } }
        public static ObservableCollection<CartModel> products;

        public static ObservableCollection<CartModel> CreateCart()
        {
            if (products == null)
            {
                products = new ObservableCollection<CartModel>();
            }
            return Products;
        }

        public static void AddProduct(ProductModel product)
        {
            var data = Products.Where(c => c.Product.ProductId == product.ProductId).SingleOrDefault();
            var count = 0;
            if (AlreadyExists(data))
            {
                count = 1 + data.Count;
                Products.Remove(data);
                Products.Add(new CartModel()
                {
                    Product = product,
                    Count = count
                });
                count = 0;
                return;
            }
            Products.Add(new CartModel()
            {
                Product = product
            });

        }
        public static bool AlreadyExists(CartModel cartModel)
        {

            return cartModel != null ? true : false;
        }
        public static bool IsNotEmpty()
        {
            return Products.Count != 0 ? true : false;
        }
        public static void RemoveProduct(ProductModel product)
        {
            var count = 0;
            var data = Products.Where(p => p.Product.ProductId == product.ProductId).SingleOrDefault();
            if (data.Count == 1)
            {
                Products.Remove(data);
                return;
            }
            else
            {
                count = data.Count - 1;
                Products.Remove(data);
                Products.Add(new CartModel()
                {
                    Product = product,
                    Count = count
                });
            }


        }


    }

}
