using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System;

namespace SC_RecoverImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //get image
                Bitmap img = SC_RecoverImage.Properties.Resources.secretcode; //define pixel data

                var recoveredImg = RecoverImage(img);

                //save file
                string path = System.Environment.CurrentDirectory;
                recoveredImg.Save(@path + "\\" + "recoveredImage.png");
                MessageBox.Show("Image has been recovered and saved.", "Success");
            }
            catch (Exception e)
            {
                MessageBox.Show("Problem recovering/saving image.", "Error" + e.Message);
            }
        }

        public static Image RecoverImage(Bitmap image)
        {
            Bitmap destImage;
            int x, y;

            // Loop through the images pixels and reset color.
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    Color newColor = Color.FromArgb((pixelColor.R * 10 > 255 ? 255 : pixelColor.R * 10), 0, 0);
                    image.SetPixel(x, y, newColor);
                }
            }
            destImage = image;
            return destImage;
        }

    }
}
