using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ISDevTemplate.Scene
{
    public class SceneLoder : SingletonMonoBehaviour<SceneLoder>
    {
        #region Properties

        public bool IsLoading { get; private set; } = false;

        public string ActiveSceneName => SceneManager.GetActiveScene().name;

        #endregion

        #region Inspector Variables

        [SerializeField]
        private float _fadeDuaration = 0.5f;

        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        #endregion

        #region Events

        /// <summary>シーンの読み込み前</summary>
        public event Action OnLoadStart;

        /// <summary>シーンの読み込み後</summary>
        public event Action OnLoadEnd;

        #endregion

        #region Public Methods

        /// <summary>
        /// シーンをロードする関数
        /// フェードも行う
        /// </summary>
        /// <param name="sceneName">シーン名</param>
        /// <returns></returns>
        public void LoadScene(string sceneName)
        {
            // 既にロード中であればロードを行わない
            if (IsLoading == true) return;

            Fade(sceneName);
        }

        /// <summary>
        /// 現在のシーンを再度読み込むオーバーロード
        /// </summary>
        /// <returns></returns>
        public void LoadScene()
        {
            if (IsLoading == true) return;
            
            Fade(ActiveSceneName);
        }

        #endregion

        #region Privete Methods

        private async void Fade(string sceneName)
        {
            IsLoading = true;
            OnLoadStart?.Invoke();

            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            await _canvasGroup.DOFade(1f, _fadeDuaration).AsyncWaitForCompletion();

            await SceneManager.LoadSceneAsync(sceneName);

            OnLoadEnd?.Invoke();
            IsLoading = false;

            await _canvasGroup.DOFade(0f, _fadeDuaration).AsyncWaitForCompletion();
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        #endregion

    }
}
