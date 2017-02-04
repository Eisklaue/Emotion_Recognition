using System;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.IO;
using System.Threading.Tasks;

namespace EmotionLib
{

    public class EmotionByImage
    {
        private string subscriptionKey { get; set; }
        private string imageFilePath { get; set; }
        

        public EmotionByImage(string _subscriptionKey, string _imageFilePath)
        {
            subscriptionKey = _subscriptionKey;
            imageFilePath = _imageFilePath;
        }

        public async void Start()
        {
            Emotion[] emotionResult = await UploadAndDetectEmotions(imageFilePath);

        }
        

        private async Task<Emotion[]> UploadAndDetectEmotions(string imageFilePath)
        {
            Console.WriteLine("EmotionServiceClient is created");
            
            EmotionServiceClient emotionServiceClient = new EmotionServiceClient(subscriptionKey);
            Console.WriteLine("Calling EmotionServiceClient.RecognizeAsync()...");
            try
            {
                Emotion[] emotionResult;
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    //
                    // Detect the emotions in the URL
                    //
                    emotionResult = await emotionServiceClient.RecognizeAsync(imageFileStream);
                    return emotionResult;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
