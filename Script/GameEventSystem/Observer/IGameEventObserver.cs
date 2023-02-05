using System.Collections.Generic;
using Script.GameEventSystem.Subject;
using UnityEngine;

namespace Script.GameEventSystem.Observer
{
    public abstract class IGameEventObserver
    {
        public abstract void SetSubject(IGameEventSubject gameEventSubject);
        public abstract void Update();
    }
}