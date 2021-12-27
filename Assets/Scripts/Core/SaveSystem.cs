using UnityEngine;



namespace OG.Core
{
    public static class SaveSystem
    {
        // private const string coinSave = "coins";

        private const string levelSave = "level";
        private const string difficulty = "difficulty";
        private const string answerCount = "answerCount";

        //public static void SaveCoins(int coinAmount) => PlayerPrefs.SetInt(coinSave, coinAmount);
        //public static int GetCoins() => PlayerPrefs.GetInt(coinSave);

        public static int Level
        {
            get => PlayerPrefs.GetInt(levelSave);

            set => PlayerPrefs.SetInt(levelSave, value);
        }

        public static int AnswerCount
        {
            get => PlayerPrefs.GetInt(answerCount);

            set => PlayerPrefs.SetInt(answerCount, value);
        }

        public static float DifficultyAverage
        {
            get => PlayerPrefs.GetFloat(difficulty, 1f);

            set => PlayerPrefs.SetFloat(difficulty, value);
        }
    }
}