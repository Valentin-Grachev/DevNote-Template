using System;
using UnityEngine;

namespace DevNote.Services.Starter
{
    public class TestAdsService : MonoBehaviour, IAds
    {
        public event IAds.AdShownEvent onInterstitialShown;
        public event IAds.AdShownEvent onRewardedShown;


        bool ISelectableService.Available => true;

        bool IInitializable.Initialized => true;

        

        void IInitializable.Initialize() { }

        void IAds.SetBanner(bool active) {}

        void IAds.ShowInterstitial(AdKey adKey, Action onShown, Action onError)
        {
            onShown?.Invoke();
            onInterstitialShown?.Invoke(success: true);
        }

        void IAds.ShowRewarded(AdKey adKey, Action onRewarded, Action onError)
        {
            onRewarded?.Invoke();
            onRewardedShown?.Invoke(success: true);
        }
    }
}

