using System;
using System.Diagnostics;
using ISDevTemplate.Data;
using UnityEditor;
using static ISDevTemplate.Utility.FileUtils;
using static ISDevTemplate.Utility.JsonUtils;

namespace ISDevTemplateEditor
{
    public class MenuItemEditor
    {
        [MenuItem("ISDevTemplate/セーブデータのJsonファイルを作成、リセット %j", false, 1)]
        static void CreateSaveDataJson()
        {
            try
            {
                _ = SaveDataManager.Instance.ResetSaveDataAsync();

            }
            catch (Exception)
            {
                CreateJson(new SaveData(), $"{GetWritableDirectoryPath()}/{SAVE_DATA_JSON_FILE_NAME}");
            }
        }

        [MenuItem("ISDevTemplate/セーブデータが保存されているフォルダを開く %q", false, 1)]
        static void OpenSaveDataFolder()
        {
            Process.Start($"{GetWritableDirectoryPath()}");
        }
    }
}
