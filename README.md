# StoreFlow
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


![Kayıt 2026-02-08 233937](https://github.com/user-attachments/assets/bb4c106a-2dd9-4014-90ae-bee4e43c6d8e)


Bu proje eğitim amaçlı geliştirilmiştir.
