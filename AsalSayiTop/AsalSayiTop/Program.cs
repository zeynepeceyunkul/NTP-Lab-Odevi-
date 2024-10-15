using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsalSayiTop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan bir sayı girmesini ister
            Console.WriteLine("Bir sayı giriniz.");
            int N = int.Parse(Console.ReadLine()); // Girilen değer

            int toplam = 0; // Toplam değerini tutacak değişken

            // 2'den N'ye kadar olan sayıları kontrol eder
            for(int i=2; i<=N; i++)
            {
                // Eğer sayı asalsa toplam değişkenine ekler
                if (Asal(i))
                {
                    toplam += i;
                }
            }

            // Sonucu ekrana yazdırır
            Console.WriteLine( N + " sayısına kadar olan asal sayıların Toplamı: "+ toplam);
            Console.ReadKey();
        }

        // Sayının asal olup olmadığını kontrol eden metot 
        static bool Asal(int sayi)
        {
            if (sayi < 2) // 2'den küçük  sayılar asal değildir
                return false;

            for(int i=2; i<= Math.Sqrt(sayi); i++) // 2'den başlayıp kareköküne kadar bölünüp bölünemediğinin kortolünü yapar
            {
                if (sayi % i == 0) // Eğer sayı herhangi bir sayıya tam bölünüyorsa asal değildir
                    return false;
            }
            return true; // asaldır
        }
    }
}
