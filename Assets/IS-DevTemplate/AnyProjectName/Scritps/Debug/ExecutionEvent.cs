using UnityEngine;
using UnityEngine.Events;
using System;

namespace NickGamesDebug
{
    /// <summary>
    /// デバッグを行うクラス
    /// </summary>
    public class ExecutionEvent : MonoBehaviour
    {
        [SerializeField]
        [Header("実行したい関数 変更したいプロパティ")]
        UnityEvent _unityEvent;

        /// <summary>
        /// 登録した関数やプロパティの変更を行う
        /// Editorで設定した関数が実行される
        /// </summary>
        public void Execution()
        {
            _unityEvent?.Invoke();
        }
    }
}
