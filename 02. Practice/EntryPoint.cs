using System;
using System.Collections.Generic;
class EntryPoint
    {
        static void Main()
        {
        Random rng = new Random();
        int years = 3;
        int months = 12;
        int days = 31;
        int hours = 24;

        //The list represents the years, and it is no longer trying to keep track of the years through the array, but instead through the list
        List<int[,,]> temperatures = new List<int[,,]>();

        //The most outer loop is going through the years, which you can't use length on, so you must use a count
        for(int year = 0; year < years; year++)
        {
            temperatures.Add(new int[months, days, hours]);

            //The inner loops work on the array inside of the list, so temperatures[year] represents the list of int[months, days, hours]
            for (int month = 0; month < temperatures[year].GetLength(0); month++)
            {
                for (int day = 0; day < temperatures[year].GetLength(1); day++)
                {
                    for (int hour = 0; hour < temperatures[year].GetLength(2); hour++)
                    {
                        if (month >= 0 && month <= 2)
                        {
                            temperatures[year][month, day, hour] = rng.Next(-3, 50);
                        }
                        else if(month >= 3 && month <= 5)
                        {
                            temperatures[year][month, day, hour] = rng.Next(-50, 75);
                        }
                        else if (month >= 6 && month <= 8)
                        {
                            temperatures[year][month, day, hour] = rng.Next(75, 100);
                        }
                        else if (month >= 9 && month <= 11)
                        {
                            temperatures[year][month, day, hour] = rng.Next(75, 50);
                        }
                    }
                }

            }
        }


        }
    }

