using ISDevTemplate.Manager;
using UnityEngine;

namespace ISDevTemplate.Sound
{
    public class BGMSetter : MonoBehaviour
    {
        [SerializeField]
        [Header("このシーンで流したいBGMのクリップ")]
        AudioClip _bgmClip;

        [SerializeField]
        [Range(0f, 1f)]
        float _volumeScale;

        void Start()
        {
            SoundManager.Instance.PlayeBGM(_bgmClip, _volumeScale);
        }
    }
}
