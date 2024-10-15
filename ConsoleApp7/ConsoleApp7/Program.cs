using System;

class Program
{
    static void Main(string[] args)
    {
        // Düğümleri temsil eden grid
        int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
        };

        // Robotların başlangıç pozisyonları
        int[,] robotPozisyonlari = {
            { 0, 0 },
            { 2, 2 },
            { 3, 3 }
        };

        // Robotların başlangıç pozisyonlarından hareket ederek kurtarılan düğüm sayısını hesaplar
        int sonuc = KurtarilanDugumSayisi(grid, robotPozisyonlari);
        Console.WriteLine($"Kurtarılan düğüm sayısı: {sonuc}"); // Sonucu ekrana yazdırır
        Console.ReadKey();
    }

    // Belirtilen robot pozisyonlarından kurtarılan düğüm sayısını hesaplayan metot 
    public static int KurtarilanDugumSayisi(int[,] grid, int[,] robotPozisyonlari)
    {
        // Grid'in satır ve sütun sayısını alır
        int satirSayisi = grid.GetLength(0);
        int sutunSayisi = grid.GetLength(1);

        // Daha önce ziyaret edilen düğümleri takip etmek için bir boolean dizisi oluşturur
        bool[,] ziyaretEdilen = new bool[satirSayisi, sutunSayisi];
        int toplamKurtarilan = 0; // Kurtarılan düğüm sayısını tutacak olan değişken

        // Her robotun pozisyonunu döngü ile kontrol eder
        for (int i = 0; i < robotPozisyonlari.GetLength(0); i++)
        {
            // Robotun mevcut satır ve sütun pozisyonunu alır
            int satir = robotPozisyonlari[i, 0];
            int sutun = robotPozisyonlari[i, 1];

            // Mevcut pozisyondan kurtarılan düğüm sayısını toplama ekler
            toplamKurtarilan += DugumleriKurtar(grid, ziyaretEdilen, satir, sutun);
        }

        // Toplam kurtarılan düğüm sayısını döndürür
        return toplamKurtarilan;
    }

    // Verilen pozisyondan itibaren kurtarılan düğüm sayısını hesaplayan yardımcı fonksiyon
    private static int DugumleriKurtar(int[,] grid, bool[,] ziyaretEdilen, int satir, int sutun)
    {
        // Pozisyonun grid sınırları içinde olup olmadığını kontrol eder
        if (satir < 0 || satir >= grid.GetLength(0) || sutun < 0 || sutun >= grid.GetLength(1))
            return 0; // Sınırların dışındaysa 0 döndürür

        // Eğer düğüm daha önce ziyaret edildiyse veya 0 (kurtarılamayan) ise
        if (ziyaretEdilen[satir, sutun] || grid[satir, sutun] == 0)
            return 0; // 0 döndürür

        // Ziyaret edilen düğümü işaretler
        ziyaretEdilen[satir, sutun] = true; // Düğümü ziyaret ettik.
        int sayac = 1; // Bu düğümü kurtardı, sayacı 1 olarak işaretler

        // Düğümün komşuları yukarı, aşağı, sol, sağ yönlerinde devam eder
        sayac += DugumleriKurtar(grid, ziyaretEdilen, satir - 1, sutun); // yukarı
        sayac += DugumleriKurtar(grid, ziyaretEdilen, satir + 1, sutun); // aşağı
        sayac += DugumleriKurtar(grid, ziyaretEdilen, satir, sutun - 1); // sol
        sayac += DugumleriKurtar(grid, ziyaretEdilen, satir, sutun + 1); // sağ

        // Toplam kurtarılan düğüm sayısını döndürür
        return sayac;
    }
}
