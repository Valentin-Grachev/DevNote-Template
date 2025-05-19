using System;

namespace DevNote
{
    public interface IAds : IInitializable, ISelectableService
    {
        public delegate void AdShownEvent(AdKey adKey, bool success);
        public event AdShownEvent onInterstitialShown;
        public event AdShownEvent onRewardedShown;


        public void ShowRewarded(AdKey adKey, Action onRewarded = null, Action onError = null);
        public void ShowInterstitial(AdKey adKey, Action onShown = null, Action onError = null);
        public void SetBanner(bool active);

    }

}
