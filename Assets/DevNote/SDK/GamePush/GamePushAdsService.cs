using System;
using GamePush;
using UnityEngine;


namespace DevNote.Services.GamePush
{
    public class GamePushAdsService : MonoBehaviour, IAds
    {
        public event IAds.AdShownEvent onInterstitialShown;
        public event IAds.AdShownEvent onRewardedShown;


        bool ISelectableService.Available => GamePushEnvironmentService.ServicesIsAvailable;


        bool IProjectInitializable.Initialized => GP_Init.isReady;
        void IProjectInitializable.Initialize() { }

        
        void IAds.ShowInterstitial(AdKey adKey, Action onShown, Action onError)
        {
            if (GP_Ads.IsFullscreenAvailable())
            {
                GP_Ads.ShowFullscreen(
                    onFullscreenStart: () => TimeMode.SetActive(TimeMode.Mode.Stop, true),
                    onFullscreenClose: (success) =>
                    {
                        TimeMode.SetActive(TimeMode.Mode.Stop, false);

                        if (success) onShown?.Invoke();
                        else onError?.Invoke();

                        onInterstitialShown?.Invoke(adKey, success);
                    });
            }
            else
            {
                onError?.Invoke();
                onInterstitialShown?.Invoke(adKey, false);
            }
        }

        void IAds.ShowRewarded(AdKey adKey, Action onRewarded, Action onError)
        {
            if (GP_Ads.IsRewardedAvailable())
            {
                bool rewarded = false;

                GP_Ads.ShowRewarded(adKey.ToString(),
                    onRewardedStart: () => TimeMode.SetActive(TimeMode.Mode.Stop, true),
                    onRewardedReward: (key) => rewarded = true,
                    onRewardedClose: (success) =>
                    {
                        TimeMode.SetActive(TimeMode.Mode.Stop, false);

                        bool successRewarded = success && rewarded;

                        if (successRewarded) onRewarded?.Invoke();
                        else onError?.Invoke();

                        onRewardedShown?.Invoke(adKey, successRewarded);
                    });
            }
            else
            {
                onError?.Invoke();
                onRewardedShown?.Invoke(adKey, false);
            }
        }

        void IAds.SetBanner(bool active)
        {
            if (active) GP_Ads.ShowSticky();
            else GP_Ads.CloseSticky();
        }


    }
}


