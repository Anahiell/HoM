using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //array
            int[] array = { 3, 1, 2, 2, 4, 5, 6, 4 };

            //del
            var distinctTask = Task.Run(() => array.Distinct().ToArray());

            //sort array
            var sortedTask = distinctTask.ContinueWith(previousTask =>
            {
                var distinctArray = previousTask.Result;
                Array.Sort(distinctArray);
                return distinctArray;
            });

            //search
            var binarySearchTask = sortedTask.ContinueWith(previousTask =>
            {
                var sortedArray = previousTask.Result;
                int searchValue = 4;
                return Array.BinarySearch(sortedArray, searchValue);
            });

            // await when all tasks finished
            await Task.WhenAll(distinctTask, sortedTask, binarySearchTask);


            Console.WriteLine($"Array what we have: {string.Join(", ", array)}");
            Console.WriteLine($"Array after del: {string.Join(", ", sortedTask.Result)}");
            Console.WriteLine($"Binary searching number 4: {binarySearchTask.Result}");
            Console.ReadKey();
        }
    }
}
