using System.Threading.Tasks;
using UnityEngine;

namespace ISDevTemplate
{
    /// <summary>
    /// オブジェクトが有効化された後に時間で無効化するスクリプト
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class GameObjectDisabler : MonoBehaviour
    {
        [SerializeField]
        [Header("無効化する時間(ミリ秒)")]
        private int _disableTime = 2000;

        private async void OnEnable()
        {
            await Task.Delay(_disableTime);
            gameObject?.SetActive(false);
        }
    }
}
