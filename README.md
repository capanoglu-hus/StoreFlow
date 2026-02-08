
# StoreFlow

ASP.NET Core MVC tabanlı bir mağaza yönetim uygulaması. Ürün, kategori, müşteri, sipariş ve görev yönetimi özellikleri sunar.

## Özellikler

- **Ürün Yönetimi**: Ürün ekleme, güncelleme ve listeleme
- **Kategori Yönetimi**: Ürün kategorilerinin CRUD işlemleri
- **Müşteri Yönetimi**: Müşteri kayıtları ve şehir bazlı filtreleme
- **Sipariş Yönetimi**: Sipariş oluşturma, güncelleme ve durum takibi
- **Dashboard**: İstatistikler, grafikler ve özet bilgiler
- **Mesajlar**: Mesaj listeleme ve yönetimi
- **Todo Listesi**: Görev ekleme ve takibi
- **LINQ Örnekleri**: OrderBy, GroupBy, Skip, Take, Union, Concat gibi sorgu örnekleri

## Teknolojiler

- **.NET 10.0**
- **ASP.NET Core MVC**
- **Entity Framework Core 10**
- **SQL Server**
- **Bootstrap 5**
- **jQuery**
- **Melody Admin Dashboard** şablonu

## Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server veya SQL Server Express
- Visual Studio 2022 veya VS Code (isteğe bağlı)



## Proje Yapısı

```
StoreFlow/
├── Controllers/        # MVC Controller'ları
├── Context/            # DbContext ve veritabanı bağlantısı
├── Entities/           # Veritabanı entity modelleri
├── Migrations/         # EF Core migrasyonları
├── Models/             # View modelleri
├── ViewComponents/     # Yeniden kullanılabilir view bileşenleri
├── Views/              # Razor view'ları
│   ├── Category/       # Kategori sayfaları
│   ├── Customer/       # Müşteri sayfaları
│   ├── Dashboard/      # Dashboard sayfaları
│   ├── Order/          # Sipariş sayfaları
│   ├── Product/        # Ürün sayfaları
│   ├── Message/        # Mesaj sayfaları
│   └── Todo/           # Todo sayfaları
├── wwwroot/            # Statik dosyalar (CSS, JS)
├── appsettings.json    # Uygulama ayarları
└── Program.cs          # Uygulama giriş noktası




![Kayıt 2026-02-09 001500](https://github.com/user-attachments/assets/c0527540-36a4-4afb-a4e5-45f681d41a63)


![Kayıt 2026-02-09 001629](https://github.com/user-attachments/assets/d8c4253d-2311-4d29-afd7-0a7d47316198)


![Kayıt 2026-02-09 001754](https://github.com/user-attachments/assets/116b9a94-9d1d-4a1e-a59c-1c0dbeb7359b)


![Kayıt 2026-02-09 001908](https://github.com/user-attachments/assets/3d59ed16-6f79-4b3a-a90d-e4b759292ce6)


Bu proje eğitim amaçlı geliştirilmiştir.
( https://www.udemy.com/course/entityframework-core-masterclass-70-linq-ef-core-metodu/ )
