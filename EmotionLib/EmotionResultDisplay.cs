using System;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionLib
{
    class EmotionResultDisplay
    {
        public string emotionString { get; set; }
        public string score { get; set; }

        public EmotionResultDisplay (Emotion[] emotionResult)
        {
            //
        }
        /*
        private EmotionResultDisplay[] ListEmotionResult(Emotion[] emotionResult)
        {
            if (emotionResult != null)
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
        */
    }
}
