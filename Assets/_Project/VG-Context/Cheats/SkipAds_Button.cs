using UnityEngine;
using VG2;

public class SkipAds_Button : ButtonHandler
{
    private int click = 8;

    protected override void OnClick()
    {
        click--;
        if (click == 0)
        {
            GameState.adsEnabled.Value = false;
            button.image.color = Color.green;
        }

    }
}
