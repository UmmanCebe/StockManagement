﻿// ürünler ve kategoriler listesi oluşturunuz.
// Tüm ürünleri listeleyen kodu yazınız
// Tüm kategorileri listeleyen kodu yazınız.
// Kullanıcıdan kategori verilerini alan ve listyi ekran çıktısı olarak yazan kodu yazınız.
// Ürünlerin fiyat toplamını gösteren kodu yazınız.
// Kullanıcıdan iki değer alalım bunlar max ve min değerler olsun. Bu aralıkta ne kadar stok verisi varsa ekrana yazsın.(price için)
// Ürünler listesinde bir isim parametresi alarak ürün isimlerinden uyuşanları listeleyelim.
// ProductDetail(ProductName, ProductPrice,ProductStock,CategoryName) kullanarak ürün detaylarının listesini ekrana yazınız.
// Ürün kaç adet isteniyorsa o kadar satılsın  eğer stokta varsa satılsın ve stok 0 olursa o ürün listeden silinsin. Eğer stok yetersiz ise alabileceği max ürün sayısı gösterilsin.
//pagination desteği getirelecek.


using StockManagement.ConsoleUI;
using System.Diagnostics;
using System.Xml.Linq;

List<Product> products = new List<Product>()
{
    new Product(1,"Beymen Ceket",15000,250),
    new Product(2,"Prada Çanta",60000,10),
    new Product(3,"HK Vision Drone",400000,25),
    new Product(4,"Dyson Süpürge",32000,200),
    new Product(5,"Karaca Vazo",500,1000),
    new Product(6,"Kütahya Porselen Ayna",1500,200),
    new Product(7,"Adidas Futbol Topu",5000,1254),
    new Product(8,"Delta Yoga Matı",2000,531)
};
List<Category> categories = new List<Category>()
{
    new Category(1,"Elbise","Elbise Açıklaması"),
    new Category(2,"Elektronik","Açıklama"),
    new Category(3,"Dekorasyon","Dekorasyon Açıklama"),
    new Category(4,"Spor","Spor Açıklama")
};


//GetAllCategories();
//GetAllProducts();
AddProduct();
//GetAllProductPriceSum();
//GetAllPriceRange(500, 15000);
//GetAllProductByPriceFiltered();
//GetAllProductNameContains();
//DeleteProduct();
//StockUpdate();


void GetAllCategories()
{
    Ayrac("Tüm Kategoriler");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }
}

void GetAllProducts()
{
    Ayrac("Tüm Ürünler");
    foreach (Product product in products)
    {
        Console.WriteLine(product);
    }
}

void Ayrac(string title)
{
    Console.WriteLine("------------------------------------------");
    Console.WriteLine(title);
    Console.WriteLine("------------------------------------------");
}

void AddProduct()
{
    Ayrac("Ürün Ekle ve Listele");

    //int id;
    //string name;
    //double price;
    //int stock;

    //GetProductAddedInput(out id, out name, out price, out stock);  // out keywordu ile metoda parametre verip verdiğimiz bu parametredeki değerleri dışarıdan okuyabiliyoruz.
    Product createdProduct = GetProductAddedInputV2();
    bool isValid = AddProductValidator(createdProduct);
    if (isValid)
    {
        products.Add(createdProduct);
        GetAllProducts();
    }
}
bool AddProductValidator(Product product)
{
    foreach (Product item in products)
    {
        if (item.Id == product.Id)
        {

            GetNotUniqueMessage("Id");
            return false;
        }

        if (item.Name == product.Name)
        {
            GetNotUniqueMessage("Name");
            return false;
        }
    }

    if (product.Stock <= 0)
    {
        Console.WriteLine("Eklemek istediğiniz Ürünün stok değeri negatif olamaz");
        return false;
    }

    if (product.Price <= 0)
    {
        Console.WriteLine("Eklemek istediğiniz Ürünün Fiyat değeri negatif olamaz");
        return false;
    }
    return true;
}
void GetNotUniqueMessage(string property)
{
    Console.WriteLine($"Eklemek istediğiniz ürünün alanı Benzersiz olmalıdır. : {property}");

}

void GetProductAddedInput(out int id, out string name, out double price, out int stock)
{
    Console.WriteLine("Lütfen Ürün id sini Giriniz");
    id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen Ürün Adını Giriniz");
    name = Console.ReadLine();

    Console.WriteLine("Lütfen Ürün Değerini Giriniz");
    price = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen Ürün Stok Adedini Giriniz");
    stock = Convert.ToInt32(Console.ReadLine());
}

Product GetProductAddedInputV2() // burada da classla yaptık.
{
    Console.WriteLine("Lütfen Ürün id sini Giriniz");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen Ürün Adını Giriniz");
    string name = Console.ReadLine();

    Console.WriteLine("Lütfen Ürün Değerini Giriniz");
    double price = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen Ürün Stok Adedini Giriniz");
    int stock = Convert.ToInt32(Console.ReadLine());

    Product product = new Product(id, name, price, stock);
    return product;
}

void GetAllProductPriceSum()
{
    Ayrac("Tüm Ürünlerin Toplam Fiyatı");
    double total = 0;

    foreach (Product product in products)
    {
        total += product.Price;
    }
    Console.WriteLine(total);
}

void GetAllPriceRange(double min, double max)
{
    Ayrac($"{min} ile {max} değer arasındaki ürünler");
    foreach (Product product in products)
    {
        if (product.Price >= min && product.Price <= max)
        {
            Console.WriteLine(product);
        }
    }
}

void GetPriceRangeData(out double min, out double max)
{
    Console.WriteLine("Lütfen Minimum değeri Giriniz");
    min = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Lütfen Minimum değeri Giriniz");
    max = Convert.ToDouble(Console.ReadLine());
}

void GetAllProductByPriceFiltered()
{
    double min;
    double max;
    GetPriceRangeData(out min, out max);
    GetAllPriceRange(min, max);
}

void GetAllProductNameContains()
{
    Ayrac("Filtrelenen Ürün İsmine Göre Gelen Ürünler");
    string text = GetProductNameData();
    foreach (Product product in products)
    {
        if (product.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine(product);
        }
    }
}

string GetProductNameData()
{
    Console.WriteLine("Aramak İstediğiniz Ürününü Yazınız");
    string text = Console.ReadLine();
    return text;
}

void DeleteProduct()
{
    Ayrac("Silme İşlemi");

    Console.WriteLine("Lütfen Ürün id Giriniz..");
    int id = Convert.ToInt32(Console.ReadLine());
    bool isPresent = true;

    foreach (Product product in products)
    {
        if (product.Id != id)
        {
            isPresent = false;
        }
        else
        {
            isPresent = true;
            products.Remove(product);
            break;
        }
    }
    if (!isPresent)
    {
        Console.WriteLine($"Aradığınız {id} id li ürün bulunamadı");
        return;
    }

    foreach (Product product in products)
    {
        Console.WriteLine(product);
    }
}

void StockUpdate()
{
    GetAllProducts();
    Ayrac("Güzellemek istediğiniz Veriyi yazınız...");

    Console.WriteLine("Lütfen id Değerini Giriniz");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen stok değerini giriniz...");
    int stock = Convert.ToInt32(Console.ReadLine());

    Product product = new Product(0, String.Empty, 0, 0); // burada boş bir nesne tanımladıkki null bir değer geldiğinde hata almayalım

    foreach (Product p in products)
    {
        if (p.Id == id)
        {
            product = p;
            break;
        }
    }

    if (stock > product.Stock)
    {
        Console.WriteLine($"Bu üründen Maximum {product.Stock} kadar alabilirsiniz");
        return;
    }

    int newStock = product.Stock - stock;
    Product updatedProduct = new Product(
          product.Id,
          product.Name,
          product.Price,
          newStock
        );

    if (updatedProduct.Stock == 0)
    {
        products.Remove(product);
        Console.WriteLine("Tüm ürünleri aldınız");
        GetAllProducts();
        return;
    }

    string productName = product.Name;
    int adetSayisi = stock;

    double totalPrice = stock * product.Price;

    Console.WriteLine($"Ürün adı: {productName}");
    Console.WriteLine($"Adet Sayısı: {adetSayisi}");
    Console.WriteLine($"Total Ücret: {totalPrice}");

    int indexProduct = products.IndexOf(product);

    products.Remove(product);
    products.Insert(indexProduct, updatedProduct);
    GetAllProducts();
}