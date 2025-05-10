using System;
using UnityEngine;

namespace DevNote
{
    public class TestAdsService : MonoBehaviour, IAds, ISelectableService
    {
        bool ISelectableService.Available => true;

        void IAds.SetBanner(bool active) {}

        void IAds.ShowInterstitial(AdKey adKey, Action onShown, Action onError) => onShown?.Invoke();

        void IAds.ShowRewarded(AdKey adKey, Action onRewarded, Action onError) => onRewarded?.Invoke();
    }
}

