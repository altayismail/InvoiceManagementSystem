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
-Daire, fatura, aidat ve kullanıcı bilgilerinin excel çıkıtısını sistemden alabilir.

2-Kullanıcı
-Kendisine atanan fatura ve aidat bilgilerini görür ve bu faturaları her hangi bir bilgiye göre filtereleyerek görür.
-Kredi kartı ile ödeme yapabilir.
-Yöneticiye mesaj gönderebilir.
-Daire/Konut bilgilerinde, Hangi blokda, Durumu (Dolu-boş), Tipi (2+1 vb.), Bulunduğu kat, Daire numarası, Daire sahibi veya kiracı,
-Kullanıcı bilgilerinde; Ad-soyad, TCNo, E-Mail, Telefon No, Araç bilgisi(varsa plaka no).

3-Arayüz dışında kullanıcıların kredi kartı ile ödeme yapabilmesi için ayrı bir servis bulunmaktadır. Bu servisde sistemde ki her bir kullanıcı için banka bilgileri(bakiye, kredi kartı no vb.) kontrol edilerek ödeme yapılması sağlanır.

## Teknolojiler
- ASP.NET 5 MVC -> ASP.NET 6 MVC (Target Framework Update)
- .NET 5 -> .NET 6 (Target Framework Update) - Kredi Kartı Ödeme Servisi için
- Uygulama ve Ödeme Servisi için veri tabanı => MS SQL Server
