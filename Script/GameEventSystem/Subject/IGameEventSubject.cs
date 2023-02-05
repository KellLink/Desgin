using System.Collections.Generic;
using Script.GameEventSystem.Observer;
using UnityEngine;

namespace Script.GameEventSystem.Subject
{
    public abstract class IGameEventSubject
    {
        private List<IGameEventObserver> _observers = new List<IGameEventObserver>();

        public void RegisterObserver(IGameEventObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IGameEventObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify()
        {
            foreach (IGameEventObserver observer in _observers)
            {
                observer.Update();
            }
        }
    }
}