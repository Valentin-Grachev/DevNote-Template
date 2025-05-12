using UnityEngine;

namespace DevNote
{
    public class TestReviewService : MonoBehaviour, IReview
    {
        bool ISelectableService.Available => true;

        bool IInitializable.Initialized => true;

        void IInitializable.Initialize() { }

        void IReview.Request() => Debug.Log($"{Const.LogPrefix} Test review shown");
    }
}

