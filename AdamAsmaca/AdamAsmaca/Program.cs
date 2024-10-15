using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Rastgele seçilmesi için kelimelerden oluşan bir dizi oluşturur
        String[] kelimeler = { "izmir", "ankara", "istanbul", "aydın","elazığ","mardin","rize","van","tunceli"};

        // Kelimelerin rastgele seçilmesi için Random sınıfı kullanılır
        Random rastgele = new Random();
        String secilenKelime = kelimeler[rastgele.Next(kelimeler.Length)];

        // Tahmin edilen kelimenin doğru harflerini saklamak için bir karakter dizisi oluşturur
        char[] tahminEdilen = new String('_', secilenKelime.Length).ToCharArray();

        // Yanlış tahmin edilen harfleri saklamak için bir liste oluşturur
        List<char> yanlisTahminler = new List<char>();

        // Oyuncunun kalan tahmin haklarını belirler
        int kalanHak = 6;

        // Oyuna başlama mesajı
        Console.WriteLine("Adam Asmaca Oyununa Hoşgeldiniz!");

        // Oyun döngüsü başlar, kalan hak sıfır olana dek döner
        while (kalanHak > 0)
        {
            // Kullanıcıya mecvut tahmin edilen kelimeyi ve diğer bilgileri gösterir
            Console.WriteLine("\nKelime: " + new String(tahminEdilen));
            Console.WriteLine("Yanlış Tahminler: " + String.Join(", ", yanlisTahminler));
            Console.WriteLine("Kalan Hak: " + kalanHak);
            Console.WriteLine("Bir harf tahmin edin: ");

            // Kulanıcıdan bir harf girişi alır
            char tahmin;

            try
            {
                // Kullanıcıdan alınan harfi küçük harfe çevirip tahmin değişkenine atar
                tahmin = char.Parse(Console.ReadLine().ToLower());
            }
            catch
            {
                // Geçersiz giriş durumunda kullanıcıyı uyarır
                Console.WriteLine("Geçersiz giriş, lütfen geçerli bir harf girin.");
                continue;
            }

            // Girilen harf kelimede geçiyorsa
            if (secilenKelime.Contains(tahmin))
            {
                // Doğru harfi tahmin edilen kelimeye ekler 
                for(int i=0; i< secilenKelime.Length; i++)
                {
                    if(secilenKelime[i]== tahmin)
                    {
                        tahminEdilen[i] = tahmin;
                    }
                }

                // Eğer tüm harfler doğru tahmin edilmişse, oyunu kazandık mesajı verir
                if(new string(tahminEdilen)== secilenKelime)
                {
                    Console.WriteLine("\nTebrikler kelimeyi doğru tahmin ettiniz: "+ secilenKelime);
                    break;
                }
            }

            else
            {
                // Yanlış tahmin edilen harfi listeye ekler ve kalan hakları azaltır
                if (!yanlisTahminler.Contains(tahmin))
                    {

                    yanlisTahminler.Add(tahmin);

                    kalanHak--;
                }
                else
                {
                    // Aynı harfi yanlış tahmin ettiyse kullanıcıyı bilgilendirir
                    Console.WriteLine("Bu harfi zaten yanlış tahmin ettiniz!");
                }
            }
        }

        if (kalanHak == 0) // Kalan hak sıfıra ulaşınca oyunun kaybedildiğini bildirir
        {
            Console.WriteLine("\nÜzgünüm kaybettiniz. Doğru kelime: " + secilenKelime);
        }

        // Oyunun bittiği mesajını verir
        Console.WriteLine("\nOyun bitti. Çıkamk için bir tuşa basın.");
        Console.ReadKey();
    }
}
