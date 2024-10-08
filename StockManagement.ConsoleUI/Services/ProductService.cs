﻿using StockManagement.ConsoleUI.Data;
using StockManagement.ConsoleUI.Models;
using StockManagement.ConsoleUI.Models.Dtos;
using StockManagement.ConsoleUI.Services;
namespace StockManagement.ConsoleUI.Service;
public class ProductService
{
    ProductData productData = new ProductData();
    CategoryService categoryService = new CategoryService();

    public void GetAll()
    {
        List<Product> products = productData.GetAll();

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
    public void GetById(int id)
    {
        Product? product = productData.GetById(id);

        if (product is null)
        {
            Console.WriteLine($"Aradığınız Id ye göre ürün bulunamadı :{id}");
            return;
        }
        Console.WriteLine(product);
    }
    public void TotalProductPriceSum()
    {
        double total = productData.TotalProductPriceSum();
        Console.WriteLine($"Ürünlerin Fiyat toplamı: {total}");
    }
    public void GetAllPriceRange(double min, double max)
    {
        List<Product> filteredData = productData.GetAllPriceRange(min, max);
        foreach (Product product in filteredData)
        {
            Console.WriteLine(product);
        }
    }
    public void GetAllProductNameContains(string text)
    {
        List<Product> filteredProduct = productData.GetAllProductNameContains(text);

        foreach (Product product in filteredProduct)
        {
            Console.WriteLine(product);
        }
    }
    public void Delete(int id)
    {
        Product product = productData.Delete(id);

        if (product is null)
        {
            Console.WriteLine($"Ürün Bulunamadı: id = {id}");
            return;
        }
        Console.WriteLine("Ürün Silindi");
        Console.WriteLine(product);
    }

    public void GetAllProductByStockRange(int min, int max)
    {
        List<Product> filteredData = productData.GetAllProductByStockRange(min, max);
        foreach (Product product in filteredData)
        {
            Console.WriteLine(product);
        }
    }

    public void GetAllProductsOrderByAscendingName()
    {
        List<Product> filtered = productData.GetAllProductsOrderByAscendingName();
        filtered.ForEach(x => Console.WriteLine(x));
    }

    public void GetAllProductsOrderByDescendingName()
    {
        List<Product> filtered = productData.GetAllProductsOrderByDescendingName();
        filtered.ForEach(x => Console.WriteLine(x));
    }

    public void GetExpensiveProduct()
    {
        Product expensiveProduct = productData.GetExpensiveProduct();
        Console.WriteLine(expensiveProduct);
    }

    public void GetCheapProduct()
    {
        Product cheapProduct = productData.GetCheapProduct();
        Console.WriteLine(cheapProduct);
    }

    public void GetDetails()
    {
        List<Category> categories = categoryService.GetAllCategories(); // Product Datada Category Listesini yorum satırı yaptık. Bu nedenle bu kısmı yazdık. Böyle daha doğru.
        List<ProductDetailDto> detailProduct = productData.GetDetails(categories);
        detailProduct.ForEach(x => Console.WriteLine(x));
    }

    public void GetDetailsV2()
    {
        List<Category> categories = categoryService.GetAllCategories();
        List<ProductDetailDto> detailProduct2 = productData.GetDetails(categories);
        detailProduct2.ForEach(x => Console.WriteLine(x));
    }

    public void GetDetailById(int id)
    {
        List<Category> categories = categoryService.GetAllCategories();
        ProductDetailDto? detail = productData.GetDetailById(id,categories);
        if(detail is null)
        {

            Console.WriteLine("Ürün Bulunamadı");
            return;
        }
        Console.WriteLine(detail);
    }
}