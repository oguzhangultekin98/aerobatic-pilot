using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OG.Utility 
{ 
    public class CanvasScalerHelper : MonoBehaviour
    {
        private void Start()
        {
            CanvasScaler c = GetComponent<CanvasScaler>();
            if (c)
            {
                float ratio = (float)Screen.width / Screen.height;

                if (ratio <= .55f)
                    c.matchWidthOrHeight = 0;
                else
                    c.matchWidthOrHeight = .7f;
            }
        }
    }
}
