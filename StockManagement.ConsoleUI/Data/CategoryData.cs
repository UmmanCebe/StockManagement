using StockManagement.ConsoleUI.Models;
namespace StockManagement.ConsoleUI.Data;
public class CategoryData
{
    List<Category> categories = new List<Category>()
    {
        new Category(1,"Elbise","Elbise Açıklaması"),
        new Category(2,"Elektronik","Açıklama"),
        new Category(3,"Dekorasyon","Dekorasyon Açıklama"),
        new Category(4,"Spor","Spor Açıklama")
    };

    public List<Category> GetAll()
    {
        return categories;
    }

    public Category? GetById(int id)
    {
        Category? detailCategory = categories.SingleOrDefault(c => c.Id == id);
        return detailCategory;
    }

    public Category CategoryAdd(Category category)
    {
        categories.Add(category);
        return category;
    }
}