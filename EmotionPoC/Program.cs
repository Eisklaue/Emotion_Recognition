using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EmotionPoC.EmotionSrc;
using EmotionLib;
using static EmotionPoC.EmotionSrc.EmotionByImage;

namespace EmotionPoC
{

    class Program
    {
        static void Main(string[] args)
        {

            string filepath = @"C:\Users\fritz\OneDrive\Pictures\Camera Roll\20160711_095031454_iOS.jpg";
            string subscriptionKey = ConfigurationSettings.AppSettings["SubscriptionKey"];

            EmotionLib.EmotionByImage emotionByImage = new EmotionLib.EmotionByImage(subscriptionKey, filepath);
            /*
            EmotionByImage image = new EmotionByImage();
            var task = image.LoadImage(filepath);
            task.Wait();

            EmotionResultDisplay[] result = image.result;
            Console.ReadKey();
            for (int i = 0; i < image.result.Length; i++)
            {
                Console.WriteLine(image.result[i].EmotionString + ": " + image.result[i].Score);
            }
            */
            Console.WriteLine("Finished");
        }
    }
}
