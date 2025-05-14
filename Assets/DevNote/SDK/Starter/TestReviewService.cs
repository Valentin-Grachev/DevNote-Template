using UnityEngine;

namespace DevNote.Services.Starter
{
    public class TestReviewService : MonoBehaviour, IReview
    {
        bool ISelectableService.Available => true;

        bool IInitializable.Initialized => true;

        void IInitializable.Initialize() { }

        void IReview.Request() => Debug.Log($"{Const.LOG_PREFIX} Test review shown");
    }
}

