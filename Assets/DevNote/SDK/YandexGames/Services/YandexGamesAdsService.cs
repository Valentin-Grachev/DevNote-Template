using System;
using Cysharp.Threading.Tasks;
using DevNote.YandexGamesSDK;
using UnityEngine;


namespace DevNote.Services.YandexGames
{
    public class YandexGamesAdsService : MonoBehaviour, IAds
    {
        private bool _initialized = false;

        public event IAds.AdShownEvent onInterstitialShown;
        public event IAds.AdShownEvent onRewardedShown;

        bool ISelectableService.Available => YG_Sdk.ServicesIsSupported;

        bool IInitializable.Initialized => _initialized;

        async void IInitializable.Initialize()
        {
            await UniTask.WaitUntil(() => YG_Sdk.available);
            _initialized = true;
        }


        void IAds.ShowRewarded(AdKey adKey, Action onRewarded, Action onError)
        {
            bool rewarded = false;
            bool error = false;

            YG_Ads.ShowRewarded((action) =>
            {
                switch (action)
                {
                    case YG_Ads.RewardedAction.Opened:
                        TimeMode.SetActive(TimeMode.Mode.Stop, true);
                        break;

                    case YG_Ads.RewardedAction.Failed:
                        error = true;
                        break;

                    case YG_Ads.RewardedAction.Rewarded:
                        rewarded = true;
                        break;

                    case YG_Ads.RewardedAction.Closed:
                        TimeMode.SetActive(TimeMode.Mode.Stop, false);

                        if (!error && rewarded)
                        {
                            onRewarded?.Invoke();
                            onRewardedShown?.Invoke(success: true);
                        }
                        else
                        {
                            onError?.Invoke();
                            onRewardedShown?.Invoke(false);
                        }

                        break;
                }

            });
        }

        void IAds.ShowInterstitial(AdKey adKey, Action onShown, Action onError)
        {
            bool interstitialWasShown = false;
            TimeMode.SetActive(TimeMode.Mode.Stop, true);

            YG_Ads.ShowInterstitial((action) =>
            {
                switch (action)
                {
                    case YG_Ads.InterstitialAction.Opened:
                        interstitialWasShown = true;
                        break;

                    case YG_Ads.InterstitialAction.Closed:
                        TimeMode.SetActive(TimeMode.Mode.Stop, false);
                        onInterstitialShown?.Invoke(success: interstitialWasShown);

                        if (interstitialWasShown) onShown?.Invoke();
                        else onError?.Invoke();
                        break;
                }

            });
        }

        void IAds.SetBanner(bool active)
        {
            if (active) YG_Ads.ShowBanner();
            else YG_Ads.HideBanner();
        }

        
    }
}



