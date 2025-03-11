
using System.Xml.Linq;

public interface Ödeme
{
    public void ÖdemeSüreci(decimal amount);
}
public class Ürün
{
    public string ürünAdi { get; set; }
    public decimal ürünFiyati { get; set; }
    public int ürünStoku { get; set; }
    public Ürün(string ürünAdi, decimal ürünFiyati, int ürünStoku)
    {
        this.ürünAdi = ürünAdi;
        this.ürünFiyati = ürünFiyati;
        this.ürünStoku = ürünStoku;
    }
    public void EkranaYazdir()
    {
        Console.WriteLine($"{ürünAdi} - {ürünFiyati} - {ürünStoku} ");
    }
    public bool StokAzalt(int miktar)
    {
        if (ürünStoku >= miktar)
        {
            ürünStoku -= miktar;
            Console.WriteLine($"{ürünAdi} - Stok güncellenmiştir. Yeni stok: {ürünStoku} adet.");
            return true;
        }
        else
        {
            Console.WriteLine("Yeterli stok yok.");
            return false;
        }
    }
}
public abstract class Kullanıcı
{
    public string mailAdress { get; set; }
    public string isim { get; set; }
    public Kullanıcı(string isim, string email)
    {
       this.isim = isim;
        mailAdress = email;
    }

    public abstract void KullanıcıBilgileriYaz();

}
public class Müşteri : Kullanıcı
{
    public Müşteri(string isim, string email) : base(isim, email) { }
    public override void KullanıcıBilgileriYaz()
    {
        Console.WriteLine($"Müşteri: {isim}, Email: {mailAdress}");
    }

}
public class Satici : Kullanıcı
{
    public Satici(string isim, string email) : base(isim, email) { }

    public override void KullanıcıBilgileriYaz()
    {
        Console.WriteLine($"Satıcı: {isim}, Email: {mailAdress}");
    }

    public void AddProduct(List<Ürün> ürünler, string ürünAdi, decimal ürünFiyati, int ürünStoku)
    {
        ürünler.Add(new Ürün(ürünAdi, ürünFiyati, ürünStoku));
    }
}

public class Sepet
{
    private List<Ürün> _ürünler;
    public Sepet()
    {
        _ürünler = new List<Ürün>();
    }
    public void ürünEkle(Ürün ürün,int miktar)
    {
        for (int i = 0; i < miktar; i++)
        {
            _ürünler.Add(ürün);
        }
    }
    public void ürünCıkar(Ürün ürün)
    {
        _ürünler.Remove(ürün);
    }
    public decimal ToplamTutarHesapla()
    {
        decimal toplam = 0;
        foreach (var ürün in _ürünler)
        {
            toplam += ürün.ürünFiyati;
        }
        return toplam;
    }
    public void SepetiGöster()
    {
        Console.WriteLine("Sepetiniz:");
        foreach (var product in _ürünler)
        {
            Console.WriteLine($"{product.ürünAdi} - {product.ürünFiyati} TL");
        }
        Console.WriteLine($"Toplam: {ToplamTutarHesapla()} TL");
    }
}
public class Sipariş
{
    public Kullanıcı Kullanıcı { get; set; }
    public List<Ürün> Ürünler { get; set; }
    public decimal ToplamTutar { get; set; }

    public Sipariş(Kullanıcı Kullanıcı, List<Ürün> Ürünler)
    {
        this.Kullanıcı = Kullanıcı;
        this.Ürünler = Ürünler;
        this.ToplamTutar = Ürünler.Sum(u => u.ürünFiyati);  // Toplam tutarı ürünlerin fiyatlarını toplayarak hesaplıyoruz.
    }

    public void SiparişGöster()
    {
        Console.WriteLine($"Sipariş Bilgileri - {Kullanıcı.isim} - {ToplamTutar} TL");
        foreach (var ürün in Ürünler)
        {
            Console.WriteLine($"{ürün.ürünAdi} - {ürün.ürünFiyati} TL");
        }
    }
}

public class KrediKartıÖdemesi : Ödeme
{
    public void ÖdemeSüreci(decimal amount)
    {
        Console.WriteLine($"Kredi kartı ile {amount} ödeme yapıldı ");
    }

}
public class Havale : Ödeme
{
    public void ÖdemeSüreci(decimal amount)
    {
        Console.WriteLine($"Havale ile {amount} TL ödeme yapıldı.");
    }
}
class Program
{
    public static void Main(String[] args)
    {
        List<Kullanıcı> kuallanıcılar = new List<Kullanıcı>();
        List<Ürün> products = new List<Ürün>();
        Sepet sepet = new Sepet();
        Satici satici = null;


        bool exit = false;
        while (!exit)
        {
            // Kullanıcıya seçenekler sunma
            Console.Clear();
            Console.WriteLine("******** E-Ticaret Sistemi ********");
            Console.WriteLine("1. Satıcı Girişi");
            Console.WriteLine("2. Müşteri Girişi");
            Console.WriteLine("3. Sepeti Görüntüle");
            Console.WriteLine("4. Ürün Ekle");
            Console.WriteLine("5. Siparişi Tamamla");
            Console.WriteLine("6. Çıkış");
            Console.Write("Yapmak istediğiniz işlemi seçin (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Satıcı olarak giriş yapma
                    Console.Clear();
                    Console.WriteLine("Satıcı olarak giriş yapın.");
                    Console.Write("Adınızı girin: ");
                    string Saticiİsmi = Console.ReadLine();
                    Console.Write("E-posta adresinizi girin: ");
                    string SaticiEmaili = Console.ReadLine();

                    // Satıcıyı listeye ekle
                    satici = kuallanıcılar.OfType<Satici>().FirstOrDefault(s => s.mailAdress == SaticiEmaili);
                    if (satici == null)
                    {
                        // Yeni satıcı oluşturma
                        satici = new Satici(Saticiİsmi, SaticiEmaili);
                        kuallanıcılar.Add(satici);
                        Console.WriteLine("Yeni satıcı kaydedildi.");
                    }
                    satici.KullanıcıBilgileriYaz();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Müşteri olarak giriş yapın.");
                    Console.Write("Adınızı girin: ");
                    string müşteriİsmi = Console.ReadLine();
                    Console.Write("E-posta adresinizi girin: ");
                    string müşteriEmaili = Console.ReadLine();

                    Müşteri müşteri = kuallanıcılar.OfType<Müşteri>().FirstOrDefault(c => c.mailAdress == müşteriEmaili);
                    if (müşteri == null)
                    {
                        müşteri = new Müşteri(müşteriİsmi, müşteriEmaili);
                        kuallanıcılar.Add(müşteri);
                        Console.WriteLine("Yeni müşteri kaydedildi.");
                    }
                    müşteri.KullanıcıBilgileriYaz();

                    Console.WriteLine("\nSatıcının eklediği ürünler:");
                    foreach (var ürün in products)
                    {
                        ürün.EkranaYazdir();
                    }

                    Console.WriteLine("\nSepete ürün eklemek için ürün adını girin (Çıkmak için 'q' tuşuna basın):");
                    string ürünAdiSecim = Console.ReadLine();

                    while (ürünAdiSecim != "q")
                    {
                        var secilenÜrün = products.FirstOrDefault(p => p.ürünAdi.ToLower() == ürünAdiSecim.ToLower());
                        if (secilenÜrün != null)
                        {
                            Console.Write("Kaç adet almak istersiniz? ");
                            int alinanMiktar = int.Parse(Console.ReadLine());

                            // Stok miktarına göre ürün ekleme
                            if (secilenÜrün.StokAzalt(alinanMiktar))
                            {
                                sepet.ürünEkle(secilenÜrün, alinanMiktar);
                                Console.WriteLine($"{alinanMiktar} adet {secilenÜrün.ürünAdi} sepete eklendi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ürün bulunamadı. Lütfen tekrar deneyin.");
                        }
                        Console.WriteLine("\nSepete ürün eklemek için ürün adını girin (Çıkmak için 'q' tuşuna basın):");
                        ürünAdiSecim = Console.ReadLine();
                    }
                    break;

                case "3":
                    // Sepeti görüntüle
                    Console.Clear();
                    sepet.SepetiGöster();
                    break;

                case "4":
                    // Satıcı ürün ekle
                    Console.Clear();
                    Console.Write("Ürün adı: ");
                    string ürünAdi = Console.ReadLine();
                    Console.Write("Ürün fiyatı: ");
                    decimal ürünFiyati = decimal.Parse(Console.ReadLine());
                    Console.Write("Ürün stok miktarı: ");
                    int ürünStok = int.Parse(Console.ReadLine());
                    Ürün yeniÜrün = new Ürün(ürünAdi, ürünFiyati, ürünStok);

                    satici.AddProduct(products, ürünAdi, ürünFiyati, ürünStok);
                    break;

                case "5":
                    // Sipariş tamamlama
                    Console.Clear();
                    if (sepet.ToplamTutarHesapla() > 0)
                    {
                        Console.WriteLine("Ödeme yöntemi seçin:");
                        Console.WriteLine("1. Kredi Kartı");
                        Console.WriteLine("2. Havale");
                        string paymentChoice = Console.ReadLine();
                        Ödeme ödeme;

                        if (paymentChoice == "1")
                        {
                            ödeme = new KrediKartıÖdemesi();
                        }
                        else
                        {
                            ödeme = new Havale();
                        }

                        ödeme.ÖdemeSüreci(sepet.ToplamTutarHesapla());
                        Console.WriteLine("Siparişiniz başarıyla tamamlandı.");
                    }
                    else
                    {
                        Console.WriteLine("Sepetiniz boş! Lütfen ürün ekleyin.");
                    }
                    break;

                case "6":
                    // Çıkış
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}

