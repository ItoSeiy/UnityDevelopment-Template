using System;
using ISDevTemplate.Data;
using ISDevTemplate.Scene;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace ISDevTemplate.Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        #region Properties

        public bool IsGameFinish { get; private set; } = false;

        #endregion

        #region Inspector Variables

        [SerializeField]
        private CanvasGroup _gameClearCanvas;

        [SerializeField]
        private Button _onGameClearButton;

        [SerializeField]
        private CanvasGroup _gameOverCanvas;

        [SerializeField]
        private Button _onGameOverButton;

        [SerializeField]
        private float _fadeDuration = 0.5f;

        #endregion

        #region Member Variables
        #endregion

        #region Constant
        #endregion

        #region Events

        public event Action OnGameClear;

        public event Action OnGameOver;

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            SetEvents();
        }

        #endregion

        #region Enums
        #endregion

        #region Public Methods

        /// <summary>
        /// ゲームクリア時に呼ばれる
        /// </summary>
        [ContextMenu("GameClear")]
        public void GameClear()
        {
            IsGameFinish = true;
            OnGameClear?.Invoke();

            _gameClearCanvas.Enable(_fadeDuration);

            print("GameClear");
        }

        /// <summary>
        /// ゲームオーバー時に呼ばれる
        /// </summary>
        [ContextMenu("GameOver")]
        public void GameOver()
        {
            IsGameFinish = true;
            OnGameOver?.Invoke();

            _gameOverCanvas.Enable(_fadeDuration);

            print("GameOver");
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            IsGameFinish = false;
        }

        /// <summary>
        /// デリゲートやUniRxのイベントを登録する関数
        /// </summary>
        private void SetEvents()
        {
            // シーンのロード後には毎回初期化を行う
            SceneLoder.Instance.OnLoadEnd += Init;

            // セーブデータの読み込み後の処理の登録
            SaveDataManager.Instance.OnSaveDataLoded += OnSaveDataLoded;

            // ゲームクリア後に出るNextボタンの処理の登録
            _onGameClearButton
                .OnClickAsObservable()
                .TakeUntilDestroy(this)
                .ThrottleFirst(TimeSpan.FromSeconds(_fadeDuration))
                .Subscribe(_ => OnGameClearButton());

            // ゲームオーバー後に出るTry Againボタンの処理の登録
            _onGameOverButton
                .OnClickAsObservable()
                .TakeUntilDestroy(this)
                .ThrottleFirst(TimeSpan.FromSeconds(_fadeDuration))
                .Subscribe(_ => OnGameOverButton());
        }

        /// <summary>
        /// セーブデータの初回読み込み後にシーンを遷移する
        /// </summary>
        private void OnSaveDataLoded(SaveData saveData)
        {
            SceneLoder.Instance.LoadScene(saveData.SceneName);
        }

        /// <summary>
        /// ゲームクリア後に表示されるボタンの処理
        /// </summary>
        private void OnGameClearButton()
        {
            _gameClearCanvas.Disable(_fadeDuration);
            SceneLoder.Instance.LoadScene(SaveDataManager.Instance.SaveData.SceneName);
        }

        /// <summary>
        /// ゲームオーバー後に表示されるボタンの処理
        /// </summary>
        private void OnGameOverButton()
        {
            _gameOverCanvas.Disable(_fadeDuration);
            SceneLoder.Instance.LoadScene();
        }

        #endregion
    }
}
