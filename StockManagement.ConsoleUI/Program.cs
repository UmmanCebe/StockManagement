// ürünler ve kategoriler listesi oluşturunuz.
// Tüm ürünleri listeleyen kodu yazınız
// Tüm kategorileri listeleyen kodu yazınız.
// Kullanıcıdan kategori verilerini alan ve listyi ekran çıktısı olarak yazan kodu yazınız.
// Ürünlerin fiyat toplamını gösteren kodu yazınız.
// Kullanıcıdan iki değer alalım bunlar max ve min değerler olsun. Bu aralıkta ne kadar stok verisi varsa ekrana yazsın.
// Ürünler listesinde bir isim parametresi alarak ürün isimlerinden uyuşanları listeleyelim.
// ProductDetail(ProductName, ProductPrice,ProductStock,CategoryName) kullanarak ürün detaylarının listesini ekrana yazınız.


using StockManagement.ConsoleUI;

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
AddProductAndGetAll();


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

void AddProductAndGetAll()
{
    Ayrac("Ürün Ekle ve Listele");
    Console.WriteLine("Lütfen Ürün id sini Giriniz");
    int id = Convert.ToInt32(Console.ReadLine());

    bool isUnique = true;

    foreach (Product product in products)
    {
        if (product.Id == id)
        {
            isUnique = false;
            break;
        }
    }

    if (!isUnique)
    {
        Console.WriteLine($"İd alanı benzersiz olmalı: {id}");
        return;
    }

    Console.WriteLine("Lütfen Ürün Adını Giriniz");
    string name = Console.ReadLine();

    Console.WriteLine("Lütfen Ürün Değerini Giriniz");
    double price = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen Ürün Stok Adedini Giriniz");
    int stock = Convert.ToInt32(Console.ReadLine());

    Product createdProduct = new Product(id, name, price, stock);

    products.Add(createdProduct);

    foreach (Product product in products)
    {
        Console.WriteLine(product);
    }
}