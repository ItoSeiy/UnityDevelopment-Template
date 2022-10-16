using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static ISDevTemplate.Utility.FileUtils;
using static ISDevTemplate.Utility.JsonUtils;

namespace ISDevTemplate.Data
{
    public class SaveDataManager : SingletonMonoBehaviour<SaveDataManager>
    {
        public SaveData SaveData => _saveData;

        [SerializeField]
        [Header("初回のセーブデータ")]
        private SaveData _initialSaveData;

        [SerializeField]
        [Header("ステージの名前一覧")]
        private string[] _sceneNames;

        private SaveData _saveData;

        private int _sceneIndex;

        public event Action OnSaveDataLoded;

        public event Action OnSaveDataLoadFailed;

        public async UniTask SaveAsync(SaveData saveData)
        {
            _saveData = saveData;
            await CreateJsonAsync(_saveData, $"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");
        }

        public async UniTask ResetSaveDataAsync()
        {
            _saveData = _initialSaveData;
            await CreateJsonAsync(_saveData, $"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");
        }

        public async UniTask IncrementSaveData()
        {
            try
            {
                _sceneIndex++;
                _saveData = new SaveData(_sceneNames[_sceneIndex], _sceneIndex);
            }
            catch (IndexOutOfRangeException)
            {
                _sceneIndex = 0;
                _saveData = new SaveData(_sceneNames[_sceneIndex], _sceneIndex);
            }

            await SaveAsync(_saveData);
        }

        public async UniTask LoadSaveData()
        {
            await UniTask.WaitForFixedUpdate();

            // セーブデータのロードを試みる
            try
            {
                _saveData = await LoadJsonAsync<SaveData>($"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");
                CheckSaveData();
            }
            catch (Exception) // 初回ロード時はデータが作成されてないので例外をキャッチする
            {
                // セーブデータを作る
                await CreateJsonAsync(_initialSaveData, $"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");

                try
                {
                    // 作ったデータのロードを試みる
                    _saveData = await LoadJsonAsync<SaveData>($"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");
                    CheckSaveData();
                }
                catch (Exception)
                {
                    OnSaveDataLoadFailed?.Invoke();
                    return;
                }
            }

            _sceneIndex = _saveData.SceneIndex;
            OnSaveDataLoded?.Invoke();
        }

        private void CheckSaveData()
        {
            if (string.IsNullOrWhiteSpace(_saveData.SceneName))
            {
                throw new Exception("データが空です");
            }
        }
    }
}
