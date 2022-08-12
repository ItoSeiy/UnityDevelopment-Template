namespace ISDevTemplate.Data
{
    [System.Serializable]
    public struct SaveData
    {
        public string SceneName;
        
        /// <summary>このシーンが何番目であるか</summary>
        public int SceneIndex;

        public SaveData(string sceneName, int sceneIndex)
        {
            SceneName = sceneName;
            SceneIndex = sceneIndex;
        }
    }
}
