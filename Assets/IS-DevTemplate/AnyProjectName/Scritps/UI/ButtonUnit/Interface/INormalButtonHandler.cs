using System;
using UniRx;
using UnityEngine.EventSystems;

namespace ISDevTemplate.UI
{
    public interface INormalButtonHandler
    {
        public IObservable<PointerEventData> OnButtonDownObservable { get; }
        public IObservable<PointerEventData> OnButtonClickObservable { get; }
        public bool IsEnable { get;}
    }
}