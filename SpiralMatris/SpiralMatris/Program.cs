using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matrisin boyutunu giriniz: "); 
            int N = int.Parse(Console.ReadLine());

            int[,] matris = new int[N,N]; // N*N boyutundaki matrisi oluşturur.

            int sayi = 1; // Matrisin başlayacağı sayı
            int left = 0, right = N - 1;
            int top = 0, bottom = N - 1;

            while(sayi<= N * N)
            {
                for(int i= top; i<= bottom; i++) // Üst satırda sola doğru git
                {
                    matris[left, i] = sayi;
                    sayi++;
                }
                left++; // Üst satır tamamlandı, bir alt satıra geç 

                for (int i = left; i <= right; i++) // Sağ sütunda aşağı doğru git
                {
                    matris[i, bottom] = sayi;
                    sayi++;
                }
                bottom--; // Sağ sütun tamamlandı, bir önceki sütuna geç

                for(int i=bottom; i >= top; i--) // Alt satırda sağa doğru git
                {
                    matris[right, i] = sayi;
                    sayi++;
                }
                right--; // Alt satır tamamlandı, bir üst satıra geç

                for (int i = right; i >= left; i--) // Sol sütunda yukarı doğru git
                {
                    matris[i, top] = sayi;
                    sayi++;
                }
                top++; // Sol sütun tamamlandı, bir sonraki sütuna geç

            }
            // Matrisi konsola yazdır
            for(int i=0; i < N; i++)
            {
                for(int j=0; j < N; j ++)
                {
                    Console.Write(matris[i, j].ToString().PadLeft(4));

                }
                Console.WriteLine();
                Console.ReadKey();
            }





        }
    }
}
