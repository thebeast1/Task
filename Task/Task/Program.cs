using System;
using System.Collections.Generic;

namespace Task
{
    class Program
    {
        static void merge(List<int> data, int left, int mid, int right)
        {
            int i, j, k;
            int [] temp  = new int[right - left + 1];
            i = left;
            k = 0;
            j = mid + 1;

            // Merge the two parts into temp[].
            while (i <= mid && j <= right)
            {
                if (data[i] < data[j])
                {
                    temp[k] = data[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = data[j];
                    k++;
                    j++;
                }
            }

            // Insert all the remaining values from i to mid into temp[].
            while (i <= mid)
            {
                temp[k] = data[i];
                k++;
                i++;
            }

            // Insert all the remaining values from j to high into temp[].
            while (j <= right)
            {
                temp[k] = data[j];
                k++;
                j++;
            }


            // Assign sorted data stored in temp[] to a[].
            for (i = left; i <= right; i++)
            {
                data[i] = temp[i - left];
            }


        }
        static void mergeSort(List<int> data, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                mergeSort(data, left, mid);
                mergeSort(data, mid + 1, right);

                merge(data, left, mid, right);
            }
        }

        static int binarySearch(List<int> data, int left, int right, int x)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;

                if (data[mid] == x)
                    return mid;

                if (data[mid] > x)
                    return binarySearch(data, left, mid - 1, x);

                return binarySearch(data, mid + 1, right, x);
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Peace be upon You !");
            int option = 0; bool cont= true; List<int> data = new List<int>();

            while (cont)
            {
                Console.WriteLine("*Enter:\n\t1-to add New Element. ");
                Console.WriteLine("\t2-to remove Element. ");
                Console.WriteLine("\t3-to show all Elements. ");
                Console.WriteLine("\t4-to use merge Sort. ");
                Console.WriteLine("\t5-to use Binary search. ");
                Console.WriteLine("\t0-to exit.");
                option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        {
                            Console.Write("-Enter The value of the new item: ");
                            option = Convert.ToInt32(Console.ReadLine());
                            data.Add(option);
                        }
                        break;
                    case 2:
                        {
                            Console.Write("-Enter The index of the item: ");
                            option = Convert.ToInt32(Console.ReadLine());
                            data.RemoveAt(option);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("-The Data: ");
                            foreach (int i in data)
                                Console.Write(" " + i);
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        {
                            mergeSort(data, 0, data.Count-1);
                        }
                        break;
                    case 5:
                        {
                            Console.Write("-Enter the item that you want to find: ");
                            option = Convert.ToInt32(Console.ReadLine());
                            option= binarySearch(data,0,data.Count-1,option);
                            if (option == -1) Console.WriteLine("Not Found");
                            else Console.WriteLine("The index is:" + option);
                        }
                        break;
                    case 0:
                        {
                            cont = false;    
                        }
                        break;
                }
            }
        }
    }
}
