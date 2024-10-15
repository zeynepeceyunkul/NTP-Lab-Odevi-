using System;

namespace IkiMatrisinCarpimi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matris1 = { {1, 2, 3}, // İlk matrisi tanımla
                               {4, 5, 6},
                               {7, 8, 9} };

            int[,] matris2 = { {1, 2, 3}, // İkinci matrisi tanımla
                               {4, 5, 6},
                               {7, 8, 9} };

            // Sonuç için boş matris oluştur
            int n = 3; // Matris boyutu
            int[,] sonuc = new int[n, n];

            // Matris çarpımı
            for (int i = 0; i < n; i++) // matris1'in satırları üzerinde dön
            {
                for (int j = 0; j < n; j++) // matris2'nin sütunları üzerinde dön
                {
                    sonuc[i, j] = 0;
                    for (int k = 0; k < n; k++) // İç çarpım işlemi için döngü
                    {
                        sonuc[i, j] += matris1[i, k] * matris2[k, j];
                    }
                }
            }

            // Sonuç matrisi yazdırma
            Console.WriteLine("Sonuç matrisi: ");
            for (int i = 0; i < n; i++) // Sonuç satırları üzerinde dön
            {
                for (int j = 0; j < n; j++) // Sonuç sütunları üzerinde dön
                {
                    Console.Write(sonuc[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
