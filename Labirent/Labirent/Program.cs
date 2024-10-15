using System;

class Program
{
    static int N = 4; // Labirentin boyutu
    static int[,] labirent = {
        { 1, 0, 0, 0 },
        { 1, 1, 0, 1 },
        { 0, 1, 1, 1 },
        { 0, 0, 0, 1 }
    };

    static bool[,] ziyaretEdildi; // Ziyaret edilen hücreleri takip etmek için

    // Yönleri tanımlar : yukarı, aşağı, sola, sağa
    static int[,] yönler = {
        { -1, 0 }, // yukarı
        { 1, 0 },  // aşağı
        { 0, -1 }, // sola
        { 0, 1 }   // sağa
    };

    static int enKısaYol = int.MaxValue; // En kısa yol uzunluğunu tutar

    static void Main(string[] args)
    {
        ziyaretEdildi = new bool[N, N]; // Ziyaret edilen hücrelerin durumunu başlatır
        BulEnKısaYol(0, 0, 0); // Başlangıç noktasını ve adım sayısını gönderir

        if (enKısaYol == int.MaxValue)
        {
            Console.WriteLine("Yol Yok");
        }
        else
        {
            Console.WriteLine($"En Kısa Yol: {enKısaYol} adım");
            Console.ReadKey();
        }
    }

    static void BulEnKısaYol(int x, int y, int adım)
    {
        // Hedefe ulaşıldı mı?
        if (x == N - 1 && y == N - 1)
        {
            if (adım < enKısaYol)
            {
                enKısaYol = adım; // En kısa yolu güncelle
            }
            return;
        }

        // Geçerli bir hücre mi?
        if (x < 0 || x >= N || y < 0 || y >= N || labirent[x, y] == 0 || ziyaretEdildi[x, y])
        {
            return; // Geçersiz hücre, geri dön
        }

        ziyaretEdildi[x, y] = true; // Bu hücreyi ziyaret ettik

        // Tüm yönler için ilerle
        for (int i = 0; i < 4; i++)
        {
            int yeniX = x + yönler[i, 0];
            int yeniY = y + yönler[i, 1];
            BulEnKısaYol(yeniX, yeniY, adım + 1);
        }

        ziyaretEdildi[x, y] = false; // Geri döndüğümüzde hücreyi serbest bırak
    }
}
