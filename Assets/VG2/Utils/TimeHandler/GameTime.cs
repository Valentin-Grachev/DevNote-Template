using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VG2
{
    public class GameTime : ITickable
    {
        private const int HANDLE_ONLINE_TIME_EVERY_MILLISECONDS = 1000;


        private List<ICommonTimeHandler> _commonTimeHandlers = new List<ICommonTimeHandler>();
        private List<IOfflineTimeHandler> _offlineTimeHandlers = new List<IOfflineTimeHandler>();
        private List<IOnlineTimeHandler> _onlineTimeHandlers = new List<IOnlineTimeHandler>();
        
        private float _millisecondsToOnlineTimeUpdate = HANDLE_ONLINE_TIME_EVERY_MILLISECONDS;


        public void AddCommonTimeHandler(ICommonTimeHandler commonTimeHandler)
        {

            TimeSpan passedTime = DateTime.Now - commonTimeHandler.LastHandledTime;
            commonTimeHandler.HandlePassedCommonTime(passedTime);
            commonTimeHandler.LastHandledTime = DateTime.Now;
            _commonTimeHandlers.Add(commonTimeHandler);
        }

        public void AddOfflineTimeHandler(IOfflineTimeHandler offlineTimeHandler)
        {
            TimeSpan passedTime = DateTime.Now - offlineTimeHandler.LastHandledTime;
            offlineTimeHandler.HandlePassedOfflineTime(passedTime);
            offlineTimeHandler.LastHandledTime = DateTime.Now;
            _offlineTimeHandlers.Add(offlineTimeHandler);
        }

        public void AddOnlineTimeHandler(IOnlineTimeHandler onlineTimeHandler)
        {
            _onlineTimeHandlers.Add(onlineTimeHandler);
        }


        public void Tick()
        {
            _millisecondsToOnlineTimeUpdate -= Time.deltaTime * 1000f;
            if (_millisecondsToOnlineTimeUpdate <= 0f)
            {
                HandleOnlineTime(HANDLE_ONLINE_TIME_EVERY_MILLISECONDS);
                _millisecondsToOnlineTimeUpdate = HANDLE_ONLINE_TIME_EVERY_MILLISECONDS;
            }
        }


        private void HandleOnlineTime(int milliseconds)
        {
            TimeSpan timeSpan = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: milliseconds);

            for (int i = 0; i < _commonTimeHandlers.Count; i++)
            {
                _commonTimeHandlers[i].HandlePassedCommonTime(timeSpan);
                _commonTimeHandlers[i].LastHandledTime = DateTime.Now;
            }
                
            for (int i = 0; i < _onlineTimeHandlers.Count; i++)
                _onlineTimeHandlers[i].HandlePassedOnlineTime(timeSpan);

            for (int i = 0; i < _offlineTimeHandlers.Count; i++)
                _offlineTimeHandlers[i].LastHandledTime = DateTime.Now;

        }


    }
}

