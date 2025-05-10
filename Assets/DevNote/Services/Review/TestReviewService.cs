using UnityEngine;

namespace DevNote
{
    public class TestReviewService : MonoBehaviour, IReview, ISelectableService
    {
        bool ISelectableService.Available => true;

        void IReview.Request() => Debug.Log($"{Const.LogPrefix} Test review shown");
    }
}

