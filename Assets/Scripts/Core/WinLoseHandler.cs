using System;
//using GameAnalyticsSDK;


namespace OG.Core
{
    public static class WinLoseHandler
    {
        public static event Action<bool> LevelCompleted;

        public static void OnLevelEnd(bool success)
        {
            LevelCompleted?.Invoke(success);

            if (success)
            {
                SaveSystem.Level++;
                //  GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SaveSystem.Level.ToString());
            }
            else
            {
                //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, SaveSystem.Level.ToString());
            }
        }
    }
}