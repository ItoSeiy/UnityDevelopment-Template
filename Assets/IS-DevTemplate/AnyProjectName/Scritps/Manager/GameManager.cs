using System;
using ISDevTemplate.Data;
using ISDevTemplate.Scene;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ISDevTemplate.Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
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

        private bool _isGameJudgePrinted = false;

        #endregion

        #region Events

        /// <summary>ゲームクリア時のイベント</summary>
        public event Action OnGameClear;

        /// <summary>ゲームクリア時に出る、「次に進むボタン」を押した時のイベント</summary>
        public event Action OnGameClearButton;

        /// <summary>ゲームオーバー時のイベント</summary>
        public event Action OnGameOver;

        /// <summary>ゲームオーバー時に出る、「リトライのボタン」を押した時のイベント</summary>
        public event Action OnGameOverButton;

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            SetEvents();
        }

        private void Start()
        {
           _ = SaveDataManager.Instance.LoadSaveData();
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
            if (_isGameJudgePrinted)
            {
                print("既にゲームがクリア又はゲームオーバーしているのでGameClear()を呼び出すのは無効です");
                return;
            }

            _isGameJudgePrinted = true;

            _ = SaveDataManager.Instance.IncrementSaveData();
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
            if (_isGameJudgePrinted)
            {
                print("既にゲームがクリア又はゲームオーバーしているのでGameClear()を呼び出すのは無効です");
                return;
            }

            _isGameJudgePrinted = true;

            OnGameOver?.Invoke();

            _gameOverCanvas.Enable(_fadeDuration);

            print("GameOver");
        }

        #endregion

        #region Private Methods

        /// デリゲートやUniRxのイベントを登録する関数
        /// </summary>
        private void SetEvents()
        {
            // シーンのロード後には毎回初期化を行う
            SceneLoder.Instance.OnLoadEnd += Init;

            // セーブデータの読み込み後の処理の登録
            SaveDataManager.Instance.OnSaveDataLoded += LoadSavedScene;

            // ゲームクリア後に出るNextボタンの処理の登録
            _onGameClearButton
                .OnClickAsObservable()
                .TakeUntilDestroy(this)
                .ThrottleFirst(TimeSpan.FromSeconds(_fadeDuration))
                .Subscribe(_ =>
                { 
                    LoadNextScene();
                    OnGameClearButton?.Invoke();
                });

            // ゲームオーバー後に出るTry Againボタンの処理の登録
            _onGameOverButton
                .OnClickAsObservable()
                .TakeUntilDestroy(this)
                .ThrottleFirst(TimeSpan.FromSeconds(_fadeDuration))
                .Subscribe(_ =>
                {
                    LoadSameScene();
                    OnGameOverButton?.Invoke();
                });
        }

        private void Init()
        {
            _isGameJudgePrinted = false;
        }

        /// <summary>
        /// 現在セーブされているシーンを読み込む
        /// </summary>
        private void LoadSavedScene()
        {
            SceneLoder.Instance.LoadScene(SaveDataManager.Instance.SaveData.SceneName);
        }

        /// <summary>
        /// 次のシーンをロードする
        /// </summary>
        private void LoadNextScene()
        {
            _gameClearCanvas.Disable(_fadeDuration);
            SceneLoder.Instance.LoadScene(SaveDataManager.Instance.SaveData.SceneName);
        }

        /// <summary>
        /// 同じシーンをロードする
        /// </summary>
        private void LoadSameScene()
        {
            _gameOverCanvas.Disable(_fadeDuration);
            SceneLoder.Instance.LoadScene();
        }

        #endregion
    }
}
