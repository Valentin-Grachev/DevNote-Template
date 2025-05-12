using System;

namespace DevNote
{
    public interface ISave : IInitializable, ISelectableService
    {
        public void SaveLocal(Action onSuccess = null, Action onError = null);
        public void SaveCloud(Action onSuccess = null, Action onError = null);
        public void DeleteSaves(Action onSuccess = null, Action onError = null);

    }

}

