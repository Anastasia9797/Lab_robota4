using System;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть номер студента зі списку:");
        int K = Convert.ToInt32(Console.ReadLine());
        int size = (int)(20 + 0.6 * K);

        int[] array = Array(size);
        Console.WriteLine("Початковий масив:");
        PrintArray(array);
        int[] sortArray = MergeSort(array);
        Console.WriteLine("Відсортований масив:");
        PrintArray(sortArray);

        Console.WriteLine("Введіть ключове значення:");
        int value = Convert.ToInt32(Console.ReadLine());
        int binarySearch = BinarySearch(sortArray, value);
        Console.WriteLine($"Значення {value} зустрічається в масиві {binarySearch} рази. (бінарний пошук)");
        int sequentialSearch = SequentialSearch(sortArray, value);
        Console.WriteLine($"Значення {value} зустрічається в масиві {sequentialSearch} рази. (послідовний пошук)");

        Console.ReadLine();
    }
    static int[] Array(int size)
    {
        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(10, 101);
        }
        return array;
    }
    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
    static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        int left = lowIndex;
        int right = middleIndex + 1;
        int[] tempArray = new int[highIndex - lowIndex + 1];
        int index = 0;
        while (left <= middleIndex && right <= highIndex)
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }
            index++;
        }
        for (int i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }
        for (int i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }
        for (int i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }
    static int[] MergeSort(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            int middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }
        return array;
    }
    static int[] MergeSort(int[] array)
    {
        return MergeSort(array, 0, array.Length - 1);
    }
    static int BinarySearch(int[] array, int value)
    {
        int count = 0;
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int middle = (low + high) / 2;
            if (array[middle] == value)
            {
                count++;
                int left = middle - 1;
                int right = middle + 1;

                while (left >= 0 && array[left] == value)
                {
                    count++;
                    left--;
                }
                while (right < array.Length && array[right] == value)
                {
                    count++;
                    right++;
                }
                break;
            }
            else if (array[middle] < value)
            {
                low = middle + 1;
            }
            else
            {
                high = middle - 1;
            }
        }
        return count;
    }
    static int SequentialSearch(int[] array, int value)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                count++;
            }
        }
        return count;
    }
}