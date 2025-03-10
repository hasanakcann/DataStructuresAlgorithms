namespace BigO;

public class BigONotation
{
    /// <summary>
    /// O(n) - Doğrusal Zaman Karmaşıklığı: Tek bir döngü ile n kadar işlem yapılır.
    /// </summary>
    public static void BigON(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(i); // Her adımda bir çıktı üretir
        }
    }

    /// <summary>
    /// O(n²) - Karesel Zaman Karmaşıklığı: Çift döngü ile n*n kadar işlem yapılır.
    /// </summary>
    public static void BigON2(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"({i}, {j})"); // Her bir (i, j) kombinasyonunu yazdırır
            }
        }
    }

    /// <summary>
    /// O(n³) - Kübik Zaman Karmaşıklığı: Üçlü döngü ile n³ kadar işlem yapılır.
    /// </summary>
    public static void BigON3(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.WriteLine($"({i}, {j}, {k})"); // Her bir (i, j, k) kombinasyonunu yazdırır
                }
            }
        }
    }

    /// <summary>
    /// O(log n) - Logaritmik Zaman Karmaşıklığı: Veriyi yarıya bölerek işlem yapar (Binary Search gibi).
    /// </summary>
    public static void LogN(int n)
    {
        while (n > 1)
        {
            n = (int)Math.Floor(n / 2.0); // Sayıyı ikiye bölerek işlemi tekrar eder
            Console.WriteLine(n); // Her bir adımı yazdırır
        }
    }

    /// <summary>
    /// O(n log n) - n * log(n) Zaman Karmaşıklığı: genellikle sıralama algoritmalarında görülür.
    /// </summary>
    public static void NLogN(int n)
    {
        int limit = n; // Döngü sınırını belirler
        while (n > 1)
        {
            n = (int)Math.Floor(n / 2.0); // Sayıyı ikiye bölerek işlemi tekrar eder
            for (int i = 1; i < limit; i++)
            {
                Console.WriteLine(i); // İç döngüde her adımı yazdırır
            }
        }
    }

    /// <summary>
    /// O(n!) - Faktöriyel Zaman Karmaşıklığı: Her bir kombinasyon için işlem yapar.
    /// </summary>
    public static void NFactorial(int n)
    {
        if (n == 0)
        {
            Console.WriteLine("1"); // Temel durum
            return;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i); // Her adımı yazdırır
                NFactorial(n - 1); // Kendisini tekrar çağırarak faktöriyel hesaplar
            }
        }
    }

    /// <summary>
    /// O(n) - Faktöriyel Hesaplama: Rekürsif faktöriyel hesaplaması.
    /// </summary>
    static int counter = 0;
    public static int ActualFactorial(int n)
    {
        counter++; // Çalışma adımlarını sayar
        Console.WriteLine(counter); // Her adımı yazdırır
        if (n == 1 || n == 0)
        {
            return 1; // Temel durum
        }
        else
        {
            return n * ActualFactorial(n - 1); // Rekürsif çağrı
        }
    }

    /// <summary>
    /// O(2ⁿ) - Fibonacci Hesaplama (Rekürsif): Fibonacci serisini hesaplar.
    /// </summary>
    public static int Fibonacci(int n)
    {
        if (n == 0) return 0; // Temel durum
        if (n == 1) return 1; // Temel durum
        return Fibonacci(n - 1) + Fibonacci(n - 2); // Rekürsif Fibonacci hesaplaması
    }

    /// <summary>
    /// Programın giriş noktası - Main metodu
    /// </summary>
    public static void Main()
    {
        // Big-O analiz fonksiyonları
        Console.WriteLine("Big O(n) Çalıştırılıyor:");
        BigON(10);

        Console.WriteLine("\nBig O(n²) Çalıştırılıyor:");
        BigON2(5);

        Console.WriteLine("\nBig O(n³) Çalıştırılıyor:");
        BigON3(5);

        Console.WriteLine("\nBig O(log n) Çalıştırılıyor:");
        LogN(8);

        Console.WriteLine("\nBig O(n log n) Çalıştırılıyor:");
        NLogN(4);

        Console.WriteLine("\nBig O(n!) Çalıştırılıyor:");
        NFactorial(3);

        Console.WriteLine("\nBig O(n) Faktöriyel Hesaplama Çalıştırılıyor:");
        Console.WriteLine($"Sonuç: {ActualFactorial(8)}");

        Console.WriteLine("\nBig O(2^n) Fibonacci Hesaplama Çalıştırılıyor:");
        Console.WriteLine($"Sonuç: {Fibonacci(9)}");

        Console.WriteLine("\nDevam etmek için bir tuşa basın...");
        Console.ReadKey(); // Kullanıcıdan tuşa basmasını bekler
    }
}
