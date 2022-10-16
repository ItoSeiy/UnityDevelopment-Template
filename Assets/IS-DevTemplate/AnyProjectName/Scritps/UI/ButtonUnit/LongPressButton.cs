using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx.Triggers;

namespace ISDevTemplate.UI
{
    public class LongPressButton : NormalButton, ILongPressButtonHandler
    {
        public IObservable<Unit> OnButtonLongPressObservable => _onButtonLongPressSubject;

        public IObservable<Unit> OnButtonNormalTapObservable => _onButtonNormalTapSubject;

        private Subject<Unit> _onButtonLongPressSubject = new Subject<Unit>();

        private Subject<Unit> _onButtonNormalTapSubject = new Subject<Unit>();

        [SerializeField]
        [Header("長押しと検出するまでに必要な時間")]
        private float _longPressTime = 0.8f;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private bool _isButtonDown;

        private bool _isButtonIn;

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            OnButtonDownObservable.Subscribe(OnButtonDown);

            OnButtonClickObservable.Subscribe(OnButtonClick);

            OnPointerEnterAsObservable.Subscribe(OnButtonEnter);

            OnPointerExitAsObservable.Subscribe(OnButtonExit);

            OnButtonLongPressObservable.Subscribe(x => OnButtonUp(null));
        }

        private void OnButtonEnter(PointerEventData pointerEventData)
        {
            _isButtonIn = true;
        }

        private async void OnButtonExit(PointerEventData pointerEventData)
        {
            await UniTask.NextFrame();
            _isButtonIn = false;
        }

        private void OnButtonClick(PointerEventData pointerEventData)
        {
            _tokenSource.Cancel();
        }

        private async void OnButtonDown(PointerEventData pointerEventData)
        {
            _isButtonDown = true;

            if (_tokenSource.IsCancellationRequested) _tokenSource = new CancellationTokenSource();
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_longPressTime), cancellationToken: _tokenSource.Token);
            }
            catch (OperationCanceledException) 
            {
                _isButtonDown = false;
            }

            if (_isButtonIn)
            {
                if (_isButtonDown) _onButtonLongPressSubject.OnNext(Unit.Default);
                else _onButtonNormalTapSubject.OnNext(Unit.Default);
            }
        }
    }
}
