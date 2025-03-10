namespace Array;

public class ContainsDuplicate
{
    public static void Main()
    {
        // Örnek test senaryoları
        int[] testArrayWithDuplicate = { 1, 2, 3, 1 };  // Çıktı: true (1 tekrar ediyor)
        int[] testArrayWithoutDuplicate = { 1, 2, 3, 4 };  // Çıktı: false (Tüm elemanlar benzersiz)
        int[] testArrayMultipleDuplicates = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };  // Çıktı: true (Tekrar eden elemanlar var)

        // Çözüm 1 Sonuçları
        Console.WriteLine("Çözüm 1 Sonuçları:");
        Console.WriteLine($"testArrayWithDuplicate: {ContainsDuplicateUsingHashSet(testArrayWithDuplicate)}"); // true
        Console.WriteLine($"testArrayWithoutDuplicate: {ContainsDuplicateUsingHashSet(testArrayWithoutDuplicate)}"); // false
        Console.WriteLine($"testArrayMultipleDuplicates: {ContainsDuplicateUsingHashSet(testArrayMultipleDuplicates)}"); // true
        Console.WriteLine(); // Boşluk

        // Çözüm 2 Sonuçları
        Console.WriteLine("Çözüm 2 Sonuçları:");
        Console.WriteLine($"testArrayWithDuplicate: {ContainsDuplicateByComparingLength(testArrayWithDuplicate)}"); // true
        Console.WriteLine($"testArrayWithoutDuplicate: {ContainsDuplicateByComparingLength(testArrayWithoutDuplicate)}"); // false
        Console.WriteLine($"testArrayMultipleDuplicates: {ContainsDuplicateByComparingLength(testArrayMultipleDuplicates)}"); // true
    }

    // Çözüm 1: HashSet kullanarak çözüm
    public static bool ContainsDuplicateUsingHashSet(int[] numbers)
    {
        // Benzersiz elemanları saklamak için HashSet kullanıyoruz
        HashSet<int> uniqueNumbers = new HashSet<int>();

        // Dizideki her elemanı kontrol et
        foreach (int number in numbers)
        {
            // Eğer number zaten HashSet içinde varsa, tekrar eden bir eleman bulduk
            if (!uniqueNumbers.Add(number))
            {
                return true; // Aynı eleman ikinci kez bulunduğunda true döndür
            }
        }

        // Eğer tüm elemanlar benzersizse false döndür
        return false;
    }

    // Çözüm 2: Liste uzunluğu ile benzersiz elemanların uzunluğunu karşılaştırma
    public static bool ContainsDuplicateByComparingLength(int[] numbers)
    {
        // Liste uzunluğu ile benzersiz elemanların uzunluğunu karşılaştırıyoruz
        return numbers.Length != new HashSet<int>(numbers).Count;
    }
}
