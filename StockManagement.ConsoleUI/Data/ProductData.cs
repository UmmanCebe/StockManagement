using StockManagement.ConsoleUI.Models;
using StockManagement.ConsoleUI.Models.Dtos;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
namespace StockManagement.ConsoleUI.Data;
public class ProductData
{
    private List<Product> products = new List<Product>()
    {
        new Product(1,1,"Beymen Takım Elbise",15000,250),
        new Product(2,1,"Prada Çanta",60000,10),
        new Product(3,2,"Hk Vision Drone",400000,25),
        new Product(4,2,"Dyson Süpürge",32000,200),
        new Product(5,3,"Karaca Vazo",500,1000),
        new Product(6,3,"Kütahya Porselen Ayna",1500,200),
        new Product(7,4, "Adidas Futbol Topu",5000,1254),
        new Product(8,4,"Delta Yoga Matı",2000,531)
    };

    //private List<Category> categories = new List<Category>()
    //{
    //    new Category(1,"Elbise","Elbise Açıklaması"),
    //    new Category(2,"Elektronik","Açıklama"),
    //    new Category(3,"Dekorasyon","Dekorasyon Açıklama"),
    //    new Category(4,"Spor","Spor Açıklama")
    //};

    public Product Add(Product product)
    {
        products.Add(product);
        return product;
    }

    public double TotalProductPriceSum()
    {
        double total = products.Sum(x => x.Price);
        return total;
    }

    public List<Product> GetAllPriceRange(double min, double max)
    {
        // 1. YÖNTEM
        //List<Product> filteredProducts = new List<Product>();

        //foreach (Product product in products)
        //{
        //    if (product.Price >= min && product.Price <= max)
        //    {
        //        filteredProducts.Add(product);
        //    }
        //}
        //return filteredProducts;

        // Linq
        List<Product> fileredProduct = products.Where(x => x.Price <= max && x.Price >= min).ToList();
        return fileredProduct;
    }

    public List<Product> GetAllProductNameContains(string text)
    {
        // 1. YÖNTEM
        //Console.WriteLine("Aramak İstediğiniz Ürününü Yazınız");
        //text = Console.ReadLine() ?? " ";

        //List<Product> filteredList = new List<Product>();

        //foreach (Product product in products)
        //{
        //    if (product.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        filteredList.Add(product);
        //    }
        //}
        //return filteredList;

        List<Product> filteredProduct = products.FindAll(x => x.Name.Contains(text)); // kesinlikle bir liste dönmeli
        return filteredProduct;
    }

    public Product? GetById(int id)
    {
        // 1. YÖNTEM
        //Product? product = null;
        //foreach (Product item in products)
        //{
        //    if (item.Id == id)
        //    {
        //        product = item;
        //        break;
        //    }
        //}
        //return product;

        //Linq 1. Yöntem
        Product? product = products.SingleOrDefault(x => x.Id == id);
        return product;
        // Linq 2. Yöntem
        //Product? product2 = products.Where(x=>x.Id == id).SingleOrDefault();
        //return product2;
    }

    public Product Delete(int id)
    {
        Product product = GetById(id);
        if (product != null)
        {
            products.Remove(product);
        }
        else
        {
            return null;
        }
        return product;
    }

    public List<Product> GetAll()
    {
        return products;
    }

    public List<Product> GetAllProductByStockRange(int min, int max)
    {
        List<Product> filteredProduct = products.Where(x => x.Stock >= min && x.Stock <= max).ToList();
        return filteredProduct;
    }

    public List<Product> GetAllProductsOrderByAscendingName()
    {
        List<Product> orderBy = products.OrderBy(x => x.Name).ToList();
        return orderBy;
    }
    public List<Product> GetAllProductsOrderByDescendingName()
    {
        List<Product> orderBy = products.OrderByDescending(x => x.Name).ToList();
        return orderBy;
    }

    public Product GetExpensiveProduct()
    {
        Product expensiveProduct = products.OrderBy(x => x.Price).LastOrDefault();
        return expensiveProduct;
    }

    public Product GetCheapProduct()
    {
        Product cheapProduct = products.OrderBy(x => x.Price).FirstOrDefault();
        return cheapProduct;
    }

    public List<ProductDetailDto> GetDetails(List<Category> categories) // yukarıda category listini yorum yaptığımızdan buraya parametre olarak verdik. Yukarıdaki liste açık olunca parametreye gerek yok.
    {
        var result = from p in products
                     join c in categories
                     on p.CategryId equals c.Id

                     select new ProductDetailDto(
                         Id: p.Id,
                         CategortName: c.Name,
                         Name: p.Name,
                         Price: p.Price,
                         Stock: p.Stock
                         );

        return result.ToList();
    }

    public List<ProductDetailDto> GetDetailsV2(List<Category> categories)
    {
        List<ProductDetailDto> details = products.Join(categories,
            p => p.CategryId,
            c => c.Id,
            (pr, ca) => new ProductDetailDto(
                         Id: pr.Id,
                         CategortName: ca.Name,
                         Name: pr.Name,
                         Price: pr.Price,
                         Stock: pr.Stock
            )
        ).ToList();
        return details;
    }

    public ProductDetailDto? GetDetailById(int id, List<Category> categories)
    {
        var result = from p in products
                     where p.Id == id
                     join c in categories
                     on p.CategryId equals c.Id

                     select new ProductDetailDto(
                          Id: p.Id,
                          CategortName: c.Name,
                          Name: p.Name,
                          Price: p.Price,
                          Stock: p.Stock
                         );
        return result.FirstOrDefault();
    }
}