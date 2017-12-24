using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filenames = new string[2] { @"ARTICLES.TXT", @"USERS.TXT" };

            KMeans km = new KMeans();

            int nItemsCount = km.LoadItemsFromFile(filenames[0]);
            int nUsersCount = km.LoadUsersFromFile(filenames[1]);

            int nInitialUsers = 0;
            int nItemsPerCluster = 0, nItemsPerClusterMax = 0;
            if (nItemsCount > 0 && nUsersCount > 0)
            {
                do
                {
                    nItemsPerClusterMax = nItemsCount / nUsersCount;
                    Console.Write("Enter the number of articles per user [2-{0}]: ", nItemsPerClusterMax);
                    nItemsPerCluster = int.Parse(Console.ReadLine());
                } while (nItemsPerCluster < 2 || nItemsPerCluster > nItemsPerClusterMax);

                do
                {
                    Console.Write("\nEnter the number of users (initial centroids) [1-{0}]: ", nUsersCount);
                    nInitialUsers = int.Parse(Console.ReadLine());
                } while (nInitialUsers < 1 || nInitialUsers > nUsersCount);
            }

            km.Compute(nInitialUsers, nItemsPerCluster);

            Console.Read();
        }
    }
}
