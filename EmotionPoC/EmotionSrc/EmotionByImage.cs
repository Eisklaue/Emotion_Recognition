using System;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace EmotionPoC.EmotionSrc
{
    class EmotionByImage
    {
        public class EmotionResultDisplay
        {
            public string EmotionString
            {
                get;
                set;
            }
            public float Score
            {
                get;
                set;
            }

            public int OriginalIndex
            {
                get;
                set;
            }
        }

        public EmotionResultDisplay[] result;

        private string imageFilePath;

        private async Task<Emotion[]> UploadAndDetectEmotions(string imageFilePath)
        {
            string subscriptionKey = ConfigurationSettings.AppSettings["SubscriptionKey"];
            Console.WriteLine("EmotionServiceClient is created");

            // -----------------------------------------------------------------------
            // KEY SAMPLE CODE STARTS HERE
            // -----------------------------------------------------------------------

            //
            // Create Project Oxford Emotion API Service client
            //
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
            // -----------------------------------------------------------------------
            // KEY SAMPLE CODE ENDS HERE
            // -----------------------------------------------------------------------

        }

        public async Task LoadImage(string _imageFilePath)
        {
            imageFilePath = _imageFilePath;
            Console.WriteLine("Detecting...");
            Emotion[] emotionResult = await UploadAndDetectEmotions(imageFilePath);
            Console.WriteLine("Detection Done");

            result = ListEmotionResult(emotionResult);
            
        }

        private EmotionResultDisplay[] ListEmotionResult(Emotion[] emotionResult)
        {
            if(emotionResult != null)
            {
                EmotionResultDisplay[] resultDisplay = new EmotionResultDisplay[8];
                
                for (int i = 0; i < emotionResult.Length; i++)
                {
                    Emotion emotion = emotionResult[i];
                    resultDisplay[0] = new EmotionResultDisplay { EmotionString = "Anger", Score = emotion.Scores.Anger };
                    resultDisplay[1] = new EmotionResultDisplay { EmotionString = "Contempt", Score = emotion.Scores.Contempt };
                    resultDisplay[2] = new EmotionResultDisplay { EmotionString = "Disgust", Score = emotion.Scores.Disgust };
                    resultDisplay[3] = new EmotionResultDisplay { EmotionString = "Fear", Score = emotion.Scores.Fear };
                    resultDisplay[4] = new EmotionResultDisplay { EmotionString = "Happiness", Score = emotion.Scores.Happiness };
                    resultDisplay[5] = new EmotionResultDisplay { EmotionString = "Neutral", Score = emotion.Scores.Neutral };
                    resultDisplay[6] = new EmotionResultDisplay { EmotionString = "Sadness", Score = emotion.Scores.Sadness };
                    resultDisplay[7] = new EmotionResultDisplay { EmotionString = "Surprise", Score = emotion.Scores.Surprise };
                }

                return resultDisplay;
            }

            return null;           
        }


    }
}
