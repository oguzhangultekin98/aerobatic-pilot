using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using OG.Core;
namespace OG.UI
{
    public class UIEnd : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI endText;
        [SerializeField] private TextMeshProUGUI wowText;

        private bool success;

        private void Awake()
        {
            WinLoseHandler.LevelCompleted += SetTexts;
        }

        private void OnDestroy()
        {
            WinLoseHandler.LevelCompleted -= SetTexts;
        }

        public void SetTexts(bool succesfull)
        {
            success = succesfull;

            wowText.text = WowTexts(succesfull);

            if (!succesfull)
                endText.text = "TAP TO PLAY AGAIN";

            endText.gameObject.SetActive(true);
            wowText.gameObject.SetActive(true);
        }

        public void LoadLevel()
        {
            LevelLoader.LoadLevel(SaveSystem.Level % 2);
        }

        public string WowTexts(bool succesfull)
        {
            int index;

            if (succesfull)
            {
                index = Random.Range(0, 3);
                switch (index)
                {
                    case 0:
                        return "GUZEL!";
                    case 1:
                        return "IYI!";
                    default:
                        return "MUHTESEM";
                }
            }

            else
                return "BASARISIZ!";
        }
    }
}