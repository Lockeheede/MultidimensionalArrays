using System;
//New note, you would need to add a reference to the following namespace
using System.Drawing;
using System.Drawing.Imaging;
//In order to reference it, use the solution explorer and go to the references section and add the reference
//For this one, rgtclk the reference and add a reference. It will be in assembly secion. Just click the check 
//box that comes up when you hover over the reference. This namespace will not work without the reference. 


class EntryPoint
{
    static void Main()
    {
        //Images are made up on the display
        //The measure is Height X Width
        //In Pixels; like for instance 1920X1080
        //There would be 1920 columns and 1080 rows
        //With each row having a range of 0-255


        //Colors make them 2D Arrays, a range of 
        //0-255 from black to white
        //When you use RGB, however, it becomes a 3D Array
        //3X1920X1080. The 3 is each sheet of the three colors
        //With a range of 0-255 within each cell



        byte[,,] colors = new byte[3, 1080, 1920];
        Random rng = new Random();

        for (int color = 0; color < colors.GetLength(0); color++)
        {
            for (int row = 0; row < colors.GetLength(1); row++)
            {
                for (int col = 0; col < colors.GetLength(2); col++)
                {
                    colors[color, row, col] = (byte)rng.Next(0, 255);
                    //type casted into byte, because the random.Next is int. Remember to (data type) to type cast easily.

                }

            }
            //Since you are using the drawing namespace you can use the following data type
            Bitmap bitmapImage = new Bitmap(colors.GetLength(2), colors.GetLength(1), PixelFormat.Format24bppRgb);
            //Note: Press ctrl+shift+space to scroll through all the overloads available. For instance, this has 11.
            //Click in the parenthesis and press those keys to scroll through them.

            bitmapImage.SetPixel(0, 0, Color.FromArgb(colors[0, 0, 0], colors[1, 0, 0], colors[2, 0, 0]));

            for (int row = 0; row < bitmapImage.Height; row++)
            {
                for (int col = 0; col < bitmapImage.Width; col++)
                {
                    bitmapImage.SetPixel(col, row, Color.FromArgb(colors[0, row, col], colors[1, row, col], colors[2, row, col]));
                }
            }
            //This save operations creates a png file in your debug folder. Open the project in the explorer view and open your bin>debug folder to find it
            //This also saves all the images (colors) that you made in this particular project
            bitmapImage.Save("test.png");

            Bitmap readImage = new Bitmap(Image.FromFile("test.png"));

            Color[,] readColors = new Color[readImage.Height, readImage.Width];

            for (int row = 0; row < readColors.GetLength(0); row++)
            {
                for (int col = 0; col < readColors.GetLength(1); col++)
                {
                    readColors[row, col] = readImage.GetPixel(col, row);
                }
            }
            

            bool equal = true;



            for (int row = 0; row < readColors.GetLength(0); row++)
            {
                for (int col = 0; col < readColors.GetLength(1); col++)
                {
                    if ((readColors[row, col].R != colors[0, row, col]) ||
                        (readColors[row, col].G != colors[1, row, col]) ||
                        (readColors[row, col].B != colors[2, row, col]))
                    {
                        Console.WriteLine($"Difference found in pixel row = {row}, column = {col}");
                        equal = false;
                        break;
                    }
                }
            }

            Console.WriteLine($"Is the image the same as the original array: {equal}");



        }
    }
}

