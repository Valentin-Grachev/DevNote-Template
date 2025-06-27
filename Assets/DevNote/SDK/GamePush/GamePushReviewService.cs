using GamePush;
using UnityEngine;


namespace DevNote.Services.GamePush
{
    public class GamePushReviewService : MonoBehaviour, IReview
    {
        bool ISelectableService.Available => GamePushEnvironmentService.ServicesIsAvailable;

        bool IProjectInitializable.Initialized => GP_Init.isReady;

        void IProjectInitializable.Initialize() { }

        void IReview.Request() => GP_App.ReviewRequest();

    }
}




