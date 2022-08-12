using UnityEngine;
using System.Collections.Generic;

namespace ISDevTemplate.Extensions
{
    /// <summary>
    /// Vector2の拡張メソッドを宣言したクラス
    /// </summary>
    public static class Vector2Extension
    {
        /// <summary>
        /// ワールド座標(0, 0)を基準に回転を行った値を返すメソッド
        /// </summary>
        /// <param name="vec2">渡されてくる値</param>    
        /// <param name="degrees">回転させる角度</param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 vec2, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = vec2.x;
            float ty = vec2.y;

            vec2.x = (cos * tx) - (sin * ty);
            vec2.y = (sin * tx) + (cos * ty);

            return vec2;
        }

        /// <summary>
        /// Vector2を基準に円形のIEnumerble<Vector2>を返す
        /// </summary>
        /// <param name="count">いくつVector2を返すか</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static IEnumerable<Vector2> Rotate(this Vector2 parentPos, int count, float radius)
        {
            float radian = Mathf.PI * 2 / count;

            for (int i = 0; i < count; i++)
            {
                Vector2 pos;
                pos.x = Mathf.Sin(radian * (i + 1)) * radius + parentPos.x;
                pos.y = Mathf.Cos(radian * (i + 1)) * radius + parentPos.y;
                yield return pos;
            }
        }
    }
}
