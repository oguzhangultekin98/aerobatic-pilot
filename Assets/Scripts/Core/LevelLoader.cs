using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// using GameAnalyticsSDK;
// using Facebook.Unity;

namespace OG.Core
{
    public class LevelLoader : MonoBehaviour
    {
        private static LevelLoader _instance;
        public static int ActiveSceneBuildIndex => SceneManager.GetActiveScene().buildIndex;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);
            // initFB();
            // GameAnalytics.Initialize();
            //To Do: Create a script that responsible for that.
            if (ActiveSceneBuildIndex == 0)
                LoadLevel(SaveSystem.Level % 3 + 1);
        }

        // public void initFB()
        // {
        //     if (FB.IsInitialized)
        //     {
        //         FB.ActivateApp();
        //     }
        //     else
        //     {
        //         //Handle FB.Init
        //         FB.Init(() =>
        //         {
        //             FB.ActivateApp();
        //         });
        //     }
        // }
        public static void LoadLevel(int index)
        {
            GC.Collect();
            SceneManager.LoadScene(index);
        }

        public static void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}