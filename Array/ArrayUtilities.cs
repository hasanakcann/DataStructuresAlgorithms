namespace Array;

using System;
using System.Collections.Generic;

public class ArrayUtilities
{
    // 1. Çözüm: Tekrar eden bir sayı olup olmadığını kontrol eden HashSet yöntemi
    // Bu metot, dizideki her elemanı bir HashSet'e ekler. Eğer aynı eleman ikinci kez eklenirse, 
    // bu durumda true döndürür, yani bir tekrar olduğunu belirtir.
    public static bool ContainsDuplicateUsingHashSet(int[] numbers)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>(); // Benzersiz sayıları tutacak HashSet
        foreach (int number in numbers)
        {
            if (!uniqueNumbers.Add(number))  // Eğer aynı sayıyı eklemeye çalışıyorsak, false döner
            {
                return true; // Aynı eleman ikinci kez bulunduğunda true döndür
            }
        }
        return false; // Eğer tüm elemanlar benzersizse false döndür
    }

    // 2. Çözüm: Dizi uzunluğu ile benzersiz elemanların uzunluğunu karşılaştırarak kontrol etme
    // Bu metot, dizinin uzunluğu ile benzersiz eleman sayısının uzunluğunu karşılaştırır.
    // Eğer sayılar aynı değilse, o zaman tekrar eden elemanlar vardır.
    public static bool ContainsDuplicateByComparingLength(int[] numbers)
    {
        return numbers.Length != new HashSet<int>(numbers).Count; // HashSet'e dönüştürüp uzunluğu karşılaştırıyoruz
    }

    // Tek bir benzersiz sayıyı bulan XOR yöntemi (Single Number)
    // Bu metot, dizide yalnızca bir kez bulunan benzersiz sayıyı XOR operatörü ile bulur.
    public static int FindUniqueNumber(int[] numbers)
    {
        int uniqueNumber = 0;  // Benzersiz sayıyı tutacak değişken
        foreach (int number in numbers)
        {
            uniqueNumber ^= number; // XOR işlemi ile tekrar edenleri sıfırlıyoruz
        }
        return uniqueNumber;  // Sonuç olarak benzersiz sayı döndürülür
    }

    // Çözüm 1: HashMap (Dictionary) kullanarak majority element bulma
    // Bu metot, bir dizide majority (çoğunluk) elemanını bulmak için HashMap (Dictionary) kullanır.
    // Majority elemanı, dizide çoğunluğu sağlayan yani ⌊n / 2⌋'den fazla tekrar eden elemandır.
    public static int FindMajorityElementUsingHashMap(int[] numbers)
    {
        Dictionary<int, int> elementCounts = new Dictionary<int, int>(); // Her elemanın sayısını tutacak Dictionary
        int majorityElement = 0;  // Majority elemanının başlangıç değeri
        int highestCount = 0;     // En fazla tekrar eden sayının sayısını tutar.

        // Listeyi gezerek her elemanın kaç kez tekrar ettiğini hesaplıyoruz
        foreach (int number in numbers)
        {
            // Elemanın sayısını güncelle (Yoksa 0'dan başlatıyoruz)
            elementCounts[number] = 1 + elementCounts.GetValueOrDefault(number, 0);

            // Eğer şu anda bu elemanın sayısı en yüksek sayıyı geçtiyse, onu majority element olarak kabul et
            if (elementCounts[number] > highestCount)
            {
                majorityElement = number;  // Majority element olarak bu sayıyı seçiyoruz
            }

            // highestCount değerini güncelliyoruz, böylece en fazla tekrar eden sayıyı bulabiliriz
            highestCount = Math.Max(highestCount, elementCounts[number]);
        }

        return majorityElement;  // Sonuç olarak en fazla tekrar eden sayıyı döndürüyoruz
    }

    // Çözüm 2: Boyer-Moore Majority Voting Algorithm kullanarak majority element bulma
    // Bu metot, Boyer-Moore Majority Voting algoritmasını kullanarak majority (çoğunluk) elemanını bulur.
    // Bu algoritma, mevcut adayın oyu ile sıfırlanmasını sağlar.
    public static int FindMajorityElementUsingBoyerMoore(int[] numbers)
    {
        int currentCandidate = 0;  // Majority element adayı (başlangıçta sıfır)
        int voteCount = 0;         // Adayın sayısal değeri (frekansı)

        // Listeyi gezerek Boyer-Moore algoritmasını uyguluyoruz
        foreach (int number in numbers)
        {
            // Eğer voteCount sıfırsa, yeni bir majority element adayı seçiyoruz
            if (voteCount == 0)
            {
                currentCandidate = number;  // Aday olarak bu sayıyı belirliyoruz
            }

            // Eğer şu anda karşılaştığımız sayı, mevcut adayla eşleşirse, sayacı artırıyoruz
            if (number == currentCandidate)
            {
                voteCount++;  // Adayla eşleştiği için sayacı artırıyoruz
            }
            else
            {
                voteCount--;  // Adayla eşleşmeyen bir sayı bulduğumuzda sayacı azaltıyoruz
            }
        }

        return currentCandidate;  // Sonuç olarak majority element olarak kabul edilen aday döndürülür
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

        // **Majority Element Testleri**
        int[] testArrayForMajority1 = { 3, 2, 3 };
        int[] testArrayForMajority2 = { 2, 2, 1, 1, 1, 2, 2 };
        int[] testArrayForMajority3 = { 2, 1, 3, 2, 3, 1, 5, 1, 6, 4, 1, 4, 1, 1, 1, 1, 5 };

        Console.WriteLine("\nMajority Element Test Sonuçları:");
        Console.WriteLine($"Majority Element (HashMap Yöntemi) -> testArrayForMajority1: {FindMajorityElementUsingHashMap(testArrayForMajority1)}");
        Console.WriteLine($"Majority Element (HashMap Yöntemi) -> testArrayForMajority2: {FindMajorityElementUsingHashMap(testArrayForMajority2)}");
        Console.WriteLine($"Majority Element (HashMap Yöntemi) -> testArrayForMajority3: {FindMajorityElementUsingHashMap(testArrayForMajority3)}");

        Console.WriteLine("\nBoyer-Moore Algorithm Test Sonuçları:");
        Console.WriteLine($"Majority Element (Boyer-Moore Yöntemi) -> testArrayForMajority1: {FindMajorityElementUsingBoyerMoore(testArrayForMajority1)}");
        Console.WriteLine($"Majority Element (Boyer-Moore Yöntemi) -> testArrayForMajority2: {FindMajorityElementUsingBoyerMoore(testArrayForMajority2)}");
        Console.WriteLine($"Majority Element (Boyer-Moore Yöntemi) -> testArrayForMajority3: {FindMajorityElementUsingBoyerMoore(testArrayForMajority3)}");
    }
}
