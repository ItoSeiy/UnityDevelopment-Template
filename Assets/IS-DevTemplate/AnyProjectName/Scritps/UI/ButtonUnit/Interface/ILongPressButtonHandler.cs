using System;
using UniRx;

namespace ISDevTemplate.UI
{
    public interface ILongPressButtonHandler : INormalButtonHandler
    {
        public IObservable<Unit> OnButtonLongPressObservable { get; }
        public IObservable<Unit> OnButtonNormalTapObservable { get; }
    }
}