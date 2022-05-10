# Fatura Yonetim Sistemi (In Progress)
-Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım elektrik, su ve doğalgaz faturalarının yönetimini bir sistem üzerinden yapacaksınız. İki tip kullanıcınız var.

1-Admin/Yönetici
-Daire bilgilerini girebilir.
-İkamet eden kullanıcı bilgilerini girer.
-Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek tek atama yapılabilir.
-Gelen ödeme bilgilerini görür.
-Gelen mesajları görür.
-Aylık olarak borç-alacak listesini görür.
-Kişileri listeler, düzenler, siler.
-Daire/konut bilgilerini listeler, düzenler siler.

2-Kullanıcı
-Kendisine atanan fatura ve aidat bilgilerini görür.
-Kredi kartı ile ödeme yapabilir.
-Yöneticiye mesaj gönderebilir.
-Daire/Konut bilgilerinde
-Hangi blokda
-Durumu (Dolu-boş)
-Tipi (2+1 vb.)
-Bulunduğu kat
-Daire numarası
-Daire sahibi veya kiracı
-Kullanıcı bilgilerinde
-Ad-soyad
-TCNo
-E-Mail
-T-elefon
-Araç bilgisi(varsa plaka no)

3-Arayüz dışında kullanıcıların kredi kartı ile ödeme yapabilmesi için ayrı bir servis bulunmaktadır. Bu servisde sistemde ki her bir kullanıcı için banka bilgileri(bakiye, kredi kartı no vb.) kontrol edilerek ödeme yapılması sağlanır.

## Teknolojiler
- Çok Katmanlı Mimari
- ASP.NET Core MVC
- .NET Core - Kredi Kartı Ödeme Servisi için
- Uygulama için veri tabanı => MS SQL Server
### Paketler
- FluentValidation 10.4.0
- FluentValidation.AspNetCore 10.4.0
- Microsoft.EntityFrameworkCore 5.0.15
- Microsoft.EntityFrameworkCore.Design 5.0.15
- Microsoft.EntityFrameworkCore.SqlServer 5.0.15
- Microsoft.EntityFrameworkCoreTools 5.0.15
- X.PagedList 8.1.0
- X.PageList.Mvc.Core 8.1.0
- ClosedXML 0.95.4
- AutoMapper.Extensions.Microsoft.DependencyInjection 8.1.1
