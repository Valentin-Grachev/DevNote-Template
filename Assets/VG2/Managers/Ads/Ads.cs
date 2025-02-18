using System;
using UnityEngine;
using VG2.Internal;


namespace VG2
{
    public class Ads : Manager
    {
        private static Ads _instance;


        public static bool SkipAds 
        { 
            get => PlayerPrefs.GetInt(nameof(SkipAds), 0) == 1;
            set
            {
                PlayerPrefs.SetInt(nameof(SkipAds), Convert.ToInt32(value));
                GameState.adsEnabled.Value = !value;
                Saves.Save();
            }
        }

        private static AdService service => _instance.supportedService as AdService;
        protected override string managerName => "VG Ads";


        [SerializeField] private float _interstitialCooldown = 63f;

        private float _currentInterstitialCooldown = 0f;

        private static float interstitialCooldown => _instance._interstitialCooldown;


        protected override void OnInitialized()
        {
            _instance = this;
            _currentInterstitialCooldown = interstitialCooldown;
            Log(Core.Message.Initialized(managerName));
        }


        public static class Rewarded
        {
            public enum Result { Success, NotRewarded, NotAvailable }

            public delegate void OnShown(string key_ad, Result result);
            public static event OnShown onShown;
            

            public static void Show(string key_ad = "none", bool resetCooldown = false, Action<Result> onShown = null)
            {
                if (SkipAds)
                {
                    onShown?.Invoke(Result.Success);
                    return;
                }


                _instance.Log("Request rewarded ad. Ad key: " + key_ad);

                service.ShowRewarded(key_ad, (result) =>
                {
                    onShown?.Invoke(result);
                    Rewarded.onShown?.Invoke(key_ad, result);

                    if (result == Result.Success)
                    {
                        _instance.Log("On rewarded. Ad key: " + key_ad);

                        if (resetCooldown)
                            _instance._currentInterstitialCooldown = interstitialCooldown;
                    }
                    else _instance.Log("On not rewarded. Ad key: " + key_ad);
                });
            }
        }



        public static class Interstitial
        {
            public enum Result { Success, Cooldown, NoAds, NotAvailable }

            public delegate void OnShown(string key_ad, Result result);
            public static event OnShown onShown;

            public static bool now => _instance._currentInterstitialCooldown < 0f;

            public static void Show(string key_ad = "none", bool ignoreCooldown = false, Action<Result> onShown = null)
            {
                if (SkipAds)
                {
                    onShown?.Invoke(Result.Success);
                    return;
                }


                _instance.Log("Request interstitial ad. Ad key: " + key_ad);

                if (GameState.adsEnabled.Value == false)
                {
                    _instance.Log("No Ads purchased. Interstitial rejected. Ad key: " + key_ad);
                    onShown?.Invoke(Result.NoAds);
                    Interstitial.onShown?.Invoke(key_ad, Result.NoAds);
                    return;
                }

                if (!now && !ignoreCooldown)
                {
                    _instance.Log("Cooldown is not finished. Ad key: " + key_ad);
                    onShown?.Invoke(Result.Cooldown);
                    Interstitial.onShown?.Invoke(key_ad, Result.Cooldown);
                    return;
                }

                service.ShowInterstitial(key_ad, (success) =>
                {
                    Result result = success ? Result.Success : Result.NotAvailable;

                    onShown?.Invoke(result);
                    Interstitial.onShown?.Invoke(key_ad, result);

                    if (success)
                    {
                        _instance.Log("On interstitial shown. Ad key: " + key_ad);
                        _instance._currentInterstitialCooldown = interstitialCooldown;
                    }
                    else _instance.Log("On interstitial failed. Ad key: " + key_ad);
                });
                return;
            }


        }



        private void Update()
        {
            _currentInterstitialCooldown -= Time.unscaledDeltaTime;
        }



    }
}




