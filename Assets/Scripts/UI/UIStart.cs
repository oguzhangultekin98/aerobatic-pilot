using UnityEngine;
using OG.Core;
//using GameAnalyticsSDK;

namespace OG.UI
{
    public class UIStart : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI levelText;

        private void Awake()
        {
            Time.timeScale = 0;
        }

        private void Start()
        {
            levelText.text = "LEVEL " + (SaveSystem.Level + 1);
        }

        public void ActivateCounter()
        {
           // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, SaveSystem.Level.ToString());
            GameStateHandler.GameState = GameStateHandler.State.InLoop;
            Destroy(gameObject);
            Time.timeScale = 1;
        }
    }
}