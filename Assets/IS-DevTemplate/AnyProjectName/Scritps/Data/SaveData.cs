using UnityEngine;

namespace ISDevTemplate.Data
{
    [System.Serializable]
    public struct SaveData
    {
        public string SceneName;
        
        /// <summary>このシーンがインゲームの中で何番目であるか</summary>
        [Header("このシーンがインゲームの中で何番目であるか")]
        public int SceneIndex;

        public SaveData(string sceneName, int sceneIndex)
        {
            SceneName = sceneName;
            SceneIndex = sceneIndex;
        }
    }
}
