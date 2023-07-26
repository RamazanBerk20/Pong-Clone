using TMPro;
using UnityEngine;

public class VsyncOption : MonoBehaviour
{
    public TextMeshProUGUI vsyncText;

    void Update()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncText.text = "Vsync: Off";
        }
        else
        {
            vsyncText.text = "Vsync: On";
        }
    }

    public void enableVsync()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
