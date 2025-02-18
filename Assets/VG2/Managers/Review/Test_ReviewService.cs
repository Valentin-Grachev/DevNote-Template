using System;
using UnityEngine;
using VG2.Internal;


namespace VG2
{
    public class Test_ReviewService : ReviewService
    {
        [SerializeField] private bool _useInBuild;


        public override bool supported => Environment.editor || _useInBuild;

        public override void Initialize() => InitCompleted();


        public override void Request(Action onOpened, Action onClosed)
        {
            Core.LogEditor("Review opened.");
            onOpened?.Invoke();

            Core.LogEditor("Review closed.");
            onClosed?.Invoke();
        }
    }
}


