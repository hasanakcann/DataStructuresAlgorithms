namespace Array;

public class ArrayUtilities
{
    // 1.Çözüm: Tekrar eden bir sayı olup olmadığını kontrol eden HashSet yöntemi
    public static bool ContainsDuplicateUsingHashSet(int[] numbers)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        foreach (int number in numbers)
        {
            if (!uniqueNumbers.Add(number))
            {
                return true; // Aynı eleman ikinci kez bulunduğunda true döndür
            }
        }
        return false;
    }

    // 2.Çözüm: Dizi uzunluğu ile benzersiz elemanların uzunluğunu karşılaştırarak kontrol etme
    public static bool ContainsDuplicateByComparingLength(int[] numbers)
    {
        return numbers.Length != new HashSet<int>(numbers).Count;
    }

    // Tek bir benzersiz sayıyı bulan XOR yöntemi (Single Number)
    public static int FindUniqueNumber(int[] numbers)
    {
        int uniqueNumber = 0;
        foreach (int number in numbers)
        {
            uniqueNumber ^= number; // XOR işlemi ile tekrar edenleri sıfırlıyoruz.
        }
        return uniqueNumber;
    }

    public static void Main()
    {
        // **ContainsDuplicate Testleri**
        int[] testArrayWithDuplicate = { 1, 2, 3, 1 };
        int[] testArrayWithoutDuplicate = { 1, 2, 3, 4 };
        int[] testArrayMultipleDuplicates = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };

        Console.WriteLine("ContainsDuplicate Test Sonuçları:");
        Console.WriteLine($"HashSet Yöntemi -> testArrayWithDuplicate: {ContainsDuplicateUsingHashSet(testArrayWithDuplicate)}");
        Console.WriteLine($"HashSet Yöntemi -> testArrayWithoutDuplicate: {ContainsDuplicateUsingHashSet(testArrayWithoutDuplicate)}");
        Console.WriteLine($"HashSet Yöntemi -> testArrayMultipleDuplicates: {ContainsDuplicateUsingHashSet(testArrayMultipleDuplicates)}");

        Console.WriteLine();
        Console.WriteLine($"Uzunluk Karşılaştırma Yöntemi -> testArrayWithDuplicate: {ContainsDuplicateByComparingLength(testArrayWithDuplicate)}");
        Console.WriteLine($"Uzunluk Karşılaştırma Yöntemi -> testArrayWithoutDuplicate: {ContainsDuplicateByComparingLength(testArrayWithoutDuplicate)}");
        Console.WriteLine($"Uzunluk Karşılaştırma Yöntemi -> testArrayMultipleDuplicates: {ContainsDuplicateByComparingLength(testArrayMultipleDuplicates)}");

        Console.WriteLine("\n--------------------------------------\n");

        // **FindUniqueNumber Testleri**
        int[] testArray1 = { 2, 2, 1 };
        int[] testArray2 = { 4, 1, 2, 1, 2 };
        int[] testArray3 = { 1 };

        Console.WriteLine("FindUniqueNumber Test Sonuçları:");
        Console.WriteLine($"Dizi: [2, 2, 1] -> Benzersiz Sayı: {FindUniqueNumber(testArray1)}");
        Console.WriteLine($"Dizi: [4, 1, 2, 1, 2] -> Benzersiz Sayı: {FindUniqueNumber(testArray2)}");
        Console.WriteLine($"Dizi: [1] -> Benzersiz Sayı: {FindUniqueNumber(testArray3)}");
    }
}
