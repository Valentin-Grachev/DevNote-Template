using System;

namespace DevNote
{
    public interface IAds
    {
        public void ShowRewarded(AdKey adKey, Action onRewarded = null, Action onError = null);
        public void ShowInterstitial(AdKey adKey, Action onShown = null, Action onError = null);
        public void SetBanner(bool active);

    }

}
