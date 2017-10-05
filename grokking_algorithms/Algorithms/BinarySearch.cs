using System;
using Utilities;

namespace Algorithms
{
    public static class BinarySearch
	{
		public static int Search(int item, int[] items, int length)
		{
			int mid;
			var lowest = 0;
			var highest = length;
			do
			{
				// We're looking for 'item' in the sorted array 'item'
				// The array has a given length, "length"
				// We'll start in the middle of items
				mid = (highest + lowest) / 2;

				// We then want to see if this is the item we are looking for
				// (like opening a book right to the page we wanted on accident)
				if (item == items[mid]) 
				{
					// found
					return mid;
				}
				// Most likely we will need to check if our number is higher or lower
				if (item < items[mid])
				{
					// Item is in the lower half
					// so get rid of the top half
					highest = mid - 1;
				}
				else
				{
					// item is in the higher half
					// so get rid of the bottom half
					lowest = mid + 1;
				}
			} while (lowest <= highest);

			return -1;
		}

        public static void Test()
        {
            int item;
            int[] items;
            int length;

            Console.WriteLine("Binary Search");

            Console.WriteLine("Running Test 1");
            item = 3;
            items = new int[5] { 1, 2, 3, 4, 5 };
            length = 5;
            Console.WriteLine(item);
            Console.WriteLine(items.ToStringExtended());
            Console.WriteLine(length);
            Console.WriteLine(Search(item, items, length));

            Console.WriteLine("Running Test 2");
            item = 5;
            items = new int[5] { 1, 2, 3, 4, 5 };
            length = 5;
            Console.WriteLine(item);
            Console.WriteLine(items.ToStringExtended());
            Console.WriteLine(length);
            Console.WriteLine(Search(item, items, length));

            Console.WriteLine("Running Test 3");
            item = 0;
            items = new int[5] { 1, 2, 3, 4, 5 };
            length = 5;
            Console.WriteLine(item);
            Console.WriteLine(items.ToStringExtended());
            Console.WriteLine(length);
            Console.WriteLine(Search(item, items, length));
        }
    }
}
