# StoreCrudMVC - .NET Core 8 CRUD Uygulaması

Bu proje, .NET Core 8 ve MVC kullanılarak geliştirilmiş basit bir CRUD (Create, Read, Update, Delete) uygulamasıdır. Kullanıcıların ürün ekleyebileceği, güncelleyebileceği, silebileceği ve listeleyebileceği bir yönetim paneli içerir.

## Özellikler
- Ürün ekleme, düzenleme ve silme işlemleri
- Resim yükleme desteği
- Kategori seçimi için dropdown menü
- Kullanıcı dostu bir arayüz

---

## Proje Kurulumu
### 1. Bağımlılıkları Yükleme
Projeyi çalıştırmak için aşağıdaki bağımlılıkları yükleyin:
```sh
 dotnet restore
```

### 2. Veritabanı Yapılandırması
Bu projede **Entity Framework Core** kullanılmıştır. Migration işlemlerini tamamlamak için aşağıdaki komutları çalıştırabilirsiniz:
```sh
 dotnet ef migrations add InitialCreate
 dotnet ef database update
```

### 3. Uygulamayı Çalıştırma
Uygulamayı başlatmak için aşağıdaki komutu kullanabilirsiniz:
```sh
 dotnet run
```
Uygulama varsayılan olarak `https://localhost:5001` adresinde çalışacaktır.

---

## Kullanılan Teknolojiler
- **.NET Core 8** (Backend)
- **Entity Framework Core** (ORM)
- **Bootstrap** (Frontend)
- **SQLite / MSSQL** (Veritabanı)

---

## Proje Yapısı
```
StoreCrudMVC
│   Program.cs
│   appsettings.json
│
├───Controllers
│       ProductsController.cs
│
├───Models
│       Product.cs
│       ProductDto.cs
│
├───Services
│       ApplicationDbContext.cs
│
├───Views
│   ├───Products
│   │       Index.cshtml
│   │       Create.cshtml
│   │       Edit.cshtml
│
└───wwwroot
        (Resim dosyaları burada tutulur)
```

---

## Controller Açıklaması
**`ProductsController.cs`**: CRUD işlemlerini yöneten ana controller.

### Metotlar:
1. `Index()` - Tüm ürünleri listeleme
2. `Create()` - Yeni ürün ekleme (GET & POST)
3. `Edit(int id)` - Ürünü düzenleme (GET & POST)
4. `Delete(int id)` - Ürünü silme

**Resim Kaydetme:**
- Resimler `wwwroot/products/` klasörüne kaydedilir.
- Yeni eklenen her resim için benzersiz bir dosya adı oluşturulur.
- Düzenleme sırasında eski resim silinir, yeni resim eklenir.

---

## View Açıklamaları
### `Create.cshtml` (Yeni Ürün Ekleme)
- Ürün adı, marka, kategori, fiyat ve açıklama alanlarını içerir.
- Kullanıcının resim yüklemesine izin verir.

### `Edit.cshtml` (Ürün Düzenleme)
- Mevcut ürün bilgileri formda görüntülenir.
- Eğer resim değiştirilirse, eski resim sistemden silinir ve yenisi yüklenir.

---

## Veritabanı Modeli
### `Product.cs`
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Brand { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Price { get; set; }
    public string Description { get; set; } = "";
    public string ImageFileName { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
```
### `ProductDto.cs`
```csharp
public class ProductDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = "";
    [Required, MaxLength(100)]
    public string Brand { get; set; } = "";
    [Required, MaxLength(100)]
    public string Category { get; set; } = "";
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Description { get; set; } = "";
    public IFormFile? ImageFile { get; set; }
}
```

---

## Hata Yönetimi
- Eğer bir ürün resmi yüklenmezse `ModelState.AddModelError` ile hata gösterilir.
- Formlar doğrulama hataları için `asp-validation-for` kullanır.

---

## Geliştirme ve Katkıda Bulunma
Eğer projeye katkıda bulunmak istiyorsanız:
1. Bu repoyu fork'layın.
2. Yeni bir branch oluşturun.
3. Geliştirmelerinizi yapın ve commit'leyin.
4. Bir pull request açın.

---

## Lisans
Bu proje açık kaynak olup MIT lisansı ile dağıtılmaktadır.

---

Bu proje hakkında sorularınız veya önerileriniz varsa, benimle iletişime geçebilirsiniz. 🚀

