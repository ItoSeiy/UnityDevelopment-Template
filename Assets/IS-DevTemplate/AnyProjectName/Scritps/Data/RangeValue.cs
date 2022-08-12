using System;
using UnityEngine;

namespace ISDevTemplate.Data
{
    /// <summary>
    /// 値型<T>の2つの値を格納する構造体
    /// </summary>
    /// <typeparam name="T">System.Int32, System.Singleなどの値型</typeparam>
    [Serializable]
    public struct RangeValueStruct<T> where T : struct
    {
        public T Min => _min;

        public T Max => _max;

        [SerializeField]
        private T _min;

        [SerializeField]
        private T _max;

        public RangeValueStruct(T min, T max)
        {
            _min = min;
            _max = max;
        }
    }

    /// <summary>
    /// 参照型<T>の範囲(最大値,最小値)を格納するクラス
    /// </summary>
    /// <typeparam name="T">System.Int32, System.Singleなどの値型</typeparam>
    [Serializable]
    public class RangeValueClass<T> where T : class
    {
        public T Min => _min;

        public T Max => _max;

        [SerializeField]
        private T _min;

        [SerializeField]
        private T _max;

        public RangeValueClass(T min, T max)
        {
            _min = min;
            _max = max;
        }
    }
}
