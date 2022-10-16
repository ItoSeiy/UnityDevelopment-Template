using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using ISDevTemplate.Extensions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace ISDevTemplate.UI
{
    public class NormalButton : MonoBehaviour, INormalButtonHandler
    {
        public IObservable<PointerEventData> OnButtonDownObservable => _colliderImage.OnPointerDownAsObservable().Where(_ => IsEnable);

        public IObservable<PointerEventData> OnButtonClickObservable => _colliderImage.OnPointerClickAsObservable().Where(_ => IsEnable);

        public IObservable<PointerEventData> OnPointerEnterAsObservable => _colliderImage.OnPointerEnterAsObservable().Where(_ => IsEnable);

        public IObservable<PointerEventData> OnPointerExitAsObservable => _colliderImage.OnPointerExitAsObservable().Where(_ => IsEnable);

        public bool IsEnable { get; private set; } = true;

        protected Image ColliderImage => _colliderImage;

        [SerializeField]
        private Image _disableImage;

        [SerializeField] 
        private Image _downImage;

        [SerializeField]
        private Image _colliderImage;

        [SerializeField]
        [Header("アニメーションをするRectTransform")]
        private RectTransform _renderContents;

        [SerializeField]
        private float _normalScale = 1f;

        [SerializeField]
        private float _downScale = 0.95f;

        [SerializeField]
        private float _downImageAlpha = 0.15f;

        [SerializeField]
        private float _duration = 0.1f;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private float _animationProgress;

        private bool _isAnimaitonPlaying = false;

        private void Start()
        {
            SubscribeEvents();
        }

        public async void SetEnable(bool isEnable)
        {
            IsEnable = isEnable;

            if (_isAnimaitonPlaying)
            {
                _tokenSource.Cancel();
                await UniTask.WaitUntil(() => !_isAnimaitonPlaying);
                _tokenSource = new CancellationTokenSource();

                if (_renderContents != null)
                    _renderContents.SetLocalScale(1);
            }

            if(_disableImage != null)
                _disableImage.gameObject.SetActive(!isEnable);
        }

        protected virtual void SubscribeEvents()
        {
            OnButtonDownObservable.Subscribe(OnButtonDown);

            _colliderImage.OnPointerUpAsObservable().Subscribe(OnButtonUp);
        }
    
        private async void OnButtonDown(PointerEventData pointerEventData)
        {
            if (_isAnimaitonPlaying)
            {
                _tokenSource.Cancel();
                await UniTask.WaitUntil(() => !_isAnimaitonPlaying);
                _tokenSource = new CancellationTokenSource();
            }

            _isAnimaitonPlaying = true;

            await DOTween.To(() => _animationProgress, x =>
            {
                _animationProgress = x;

                if (_renderContents != null) 
                    _renderContents.SetLocalScale(_normalScale - _animationProgress * (_normalScale - _downScale));

                if (_downImage != null) 
                    _downImage.color = new Color(0, 0, 0, _animationProgress * _downImageAlpha);

            },
            1, //End Value
            _duration * (1 - _animationProgress))
                .SetEase(Ease.OutCubic)
                .WithCancellation(_tokenSource.Token);

            _isAnimaitonPlaying = false;
        }

        protected async void OnButtonUp(PointerEventData pointerEventData)
        {
            if (_isAnimaitonPlaying)
            {
                _tokenSource.Cancel();
                await UniTask.WaitUntil(() => !_isAnimaitonPlaying);
                _tokenSource = new CancellationTokenSource();
            }

            _isAnimaitonPlaying = true;

            await DOTween.To(() => _animationProgress, x =>
            {
                _animationProgress = x;

                if (_renderContents != null) 
                    _renderContents.SetLocalScale(_normalScale - _animationProgress * (_normalScale - _downScale));

                if (_downImage != null) 
                    _downImage.color = new Color(0, 0, 0, _animationProgress * _downImageAlpha);
            },
            0, // End Value
            _duration * _animationProgress)
                .SetEase(Ease.OutCubic)
                .WithCancellation(_tokenSource.Token);

            _isAnimaitonPlaying = false;
        }
    }
}
