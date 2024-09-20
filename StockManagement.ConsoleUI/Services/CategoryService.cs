using StockManagement.ConsoleUI.Data;
using StockManagement.ConsoleUI.Models;
namespace StockManagement.ConsoleUI.Services;

public class CategoryService
{
    CategoryData categoryData = new CategoryData();

    public void GetAll()
    {
        List<Category> categories = categoryData.GetAll();
        categories.ForEach(x => Console.WriteLine(x));
    }

    public void GetById(int id)
    {
        Category? filteredCategory = categoryData.GetById(id);
        if (filteredCategory is null)
        {
            Console.WriteLine($"Aradığınız Id ye göre kategori bulunamadı :{id}");
            return;
        }
        Console.WriteLine(filteredCategory);
    }

    public void CategoryAdd(Category category)
    {
        Category addedCategoty = categoryData.CategoryAdd(category);
        Console.WriteLine($"kategori Ekelndi: {addedCategoty}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Tüm kategoriler");
        GetAll();
    }

    public List<Category> GetAllCategories()
    {
        return categoryData.GetAll();
    }
}