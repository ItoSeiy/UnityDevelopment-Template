using System;
using System.Collections.Generic;

namespace ISDevTemplate.Extensions
{
    /// <summary>
    /// インターフェイスIEnumerbleの拡張メソッドを宣言したクラス
    /// </summary>
    public static class IEnumerbleExtensions
    {
        /// <summary>
        /// IEnumerable<T>をForEach出来るようにする拡張メソッド
        /// 
        /// IEnumerable<T>をForEach出来るようにした理由
        /// 
        /// LinqのEnumerableクラスでクエリをした後にList<T>.ForEachをしようとするとToList()しないといけない。
        /// (Enumaerbleクラスのメソッドの戻り値はIEnumerbleであるため)
        /// しかしToListするとパフォーマンスが下がる。
        /// 
        /// そのためIEnumerbleに拡張メソッドを作りIEmumerbleの状態でForEachを実装した
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceT">渡されてくる値(チェーンメソッド)</param>
        /// <param name="action">反復処理</param>
        public static void ForEachExt<T>(this IEnumerable<T> sourceT, Action<T> action)
        {
            foreach (var st in sourceT)
            {
                action(st);
            }
        }
    }
}
