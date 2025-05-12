using System;
using UnityEngine;

namespace DevNote
{
    public class TestAdsService : MonoBehaviour, IAds
    {
        bool ISelectableService.Available => true;

        bool IInitializable.Initialized => true;

        void IInitializable.Initialize() { }

        void IAds.SetBanner(bool active) {}

        void IAds.ShowInterstitial(AdKey adKey, Action onShown, Action onError) => onShown?.Invoke();

        void IAds.ShowRewarded(AdKey adKey, Action onRewarded, Action onError) => onRewarded?.Invoke();
    }
}

