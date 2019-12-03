using System;
using System.Collections.Generic;
    class EntryPoint
    {
        static void Main()
        {
        ///Multidimensional Arrays work in a way that puts data into rows and columns.
        ///Thank of the practice: where an hour, day, month, and year creates
        ///A four dimensional array of 24X31X12X3 if there are three years between
        ///2019, 2020, 2021
        ///To create a multi-D array, just put a comma in the bracket

        /*int[,] temperatures =
            {
            { 60, 69, 72, 73, 74, 75, 76, 80, 99, 100 },
            { 60, 69, 72, 73, 74, 75, 76, 80, 99, 100 }
            };//2D array.

        ///This is not practical. So you can use for loops to populate with randomly generated numbers

        int[,] temperatures2 = new int[31, 24];

        temperatures2[4, 10] = 30;
        Console.WriteLine(temperatures2[4, 10]);

        ///Create a 4D array with temperature properities for 3 years. Random but in a specific range based
        ///on season. 
        */

        bool isWinter = false;
        bool isSpring = false;
        bool isFall = false;
        bool isSummer = false;

        bool is2019 = false;
        bool is2020 = false;
        bool is2021 = false;

        bool isJan = false; bool isFeb = false; bool isMar = false; bool isApr = false;
        bool isMay = false; bool isJune = false; bool isJuly = false; bool isAug = false;
        bool isSep = false; bool isOct = false; bool isNov = false; bool isDec = false;

        int[,,,] temperaturesForTheYears = new int[3, 12, 31, 24];
        int count = 1;

        Random rng = new Random();

        //Definitely need to read about nested loops again...
        for (int year = 0; year < temperaturesForTheYears.GetLength(0); year++)
        {
            //i = years
            for (int month = 0; month < temperaturesForTheYears.GetLength(1); month++)
            {
                //j = month
                for (int day = 0; day < temperaturesForTheYears.GetLength(2); day++)
                {
                    //k = days
                    for (int hour = 0; hour < temperaturesForTheYears.GetLength(3); hour++)
                    {
                        //n = hours
                        if (year == 1) is2019 = true;
                        else if (year == 2) is2020 = true;
                        else if (year == 3) is2021 = true;

                        if (month >= 0 && month <= 2)
                        {
                            temperaturesForTheYears[year, month, day, hour] = rng.Next(40, 60);                           
                        }
                        else if (month >= 3 && month <= 5)
                        {
                            temperaturesForTheYears[year, month, day, hour] = rng.Next(60, 80);

                        }
                        else if (month >= 6 && month <= 8)
                        {
                            temperaturesForTheYears[year, month, day, hour] = rng.Next(80, 100);

                        }
                        else if (month >= 9 && month <= 11)
                        {
                            temperaturesForTheYears[year, month, day, hour] = rng.Next(40, 60);

                        }

                     //   Console.WriteLine(temperaturesForTheYears[i, j, k, n]);
                        count++;
                    }
                }

            }
        }
    }
}

