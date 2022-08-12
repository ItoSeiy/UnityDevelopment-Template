using ISDevTemplate.Data;
using UnityEditor;
using UnityEngine;

namespace ISDevTemplateEditor
{
    [CustomEditor(typeof(SaveDataManager))]
    internal class SaveDataManagerEditor : Editor
    {
        string _sceneName;
        int _sceneIndex;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var manager = target as SaveDataManager;

            EditorGUILayout.Space(5f);

            _sceneName = EditorGUILayout.TextField("保存したいシーン名", _sceneName);

            _sceneIndex = EditorGUILayout.IntField("保存したいシーンのIndex", _sceneIndex);

            if (GUILayout.Button("保存"))
            {
                _ = manager.SaveAsync(new SaveData(_sceneName, _sceneIndex));
            }

            EditorGUILayout.Space(10f);

            if (GUILayout.Button("リセット"))
            {
                _ = manager.ResetSaveDataAsync();
            }
        }
    }
}
