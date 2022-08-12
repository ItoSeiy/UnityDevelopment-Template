using System;
using UnityEngine;

namespace ISDevTemplate.UI
{
    /// <summary>
    /// UI関連のクラスの基底クラス
    /// UIではTransformをRectTransformの変換を行うことが多いので基底クラスを用いる
    /// 
    /// RectTransformはTransformのサブクラスなので as演算子でキャストが可能
    /// https://qiita.com/divideby_zero/items/a5dd8f2f5a1a721a1957
    /// </summary>
    public abstract class UIMonoBehaviour : MonoBehaviour
    {
        /// <summary>アタッチされているコンポーネントのRectTransform</summary>
        public RectTransform RectTransform => transform as RectTransform;
    }

    /// <summary>
    ///  UI関連のクラスの基底クラス
    ///  シングルトンの基底クラスも同時に実装
    /// </summary>
    public class UIMonoBehaviourWithSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>アタッチされているコンポーネントのRectTransform</summary>
        public RectTransform RectTransform => transform as RectTransform;

        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Type t = typeof(T);

                    instance = (T)FindObjectOfType(t);
                    if (instance == null)
                    {
                        Debug.LogWarning($"{t}をアタッチしているオブジェクトがありません");
                    }
                }
                return instance;
            }
        }

        virtual protected void Awake()
        {
            // 他のゲームオブジェクトにアタッチされているか調べる
            // アタッチされている場合は破棄する。
            CheckInstance();
        }

        protected bool CheckInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                return true;
            }
            else if (Instance == this)
            {
                return true;
            }
            Destroy(this);
            return false;
        }
    }
}
