using System;


namespace VG2
{
    public interface ICommonTimeHandler
    {
        public abstract DateTime LastHandledTime { get; set; }

        public abstract void HandlePassedCommonTime(TimeSpan time);

    }

    public interface IOfflineTimeHandler
    {
        public abstract DateTime LastHandledTime { get; set; }

        public abstract void HandlePassedOfflineTime(TimeSpan time);
    }

    public interface IOnlineTimeHandler
    {
        public abstract void HandlePassedOnlineTime(TimeSpan time);
    }
}






