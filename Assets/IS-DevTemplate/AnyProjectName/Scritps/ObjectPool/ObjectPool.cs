using System;
using System.Collections.Generic;
using UnityEngine;

namespace ISDevTemplate.Pool
{
    public class ObjectPool : SingletonMonoBehaviour<ObjectPool>
    {
        [SerializeField]
        ObjectPoolParams _objParam;

        [SerializeField]
        [Header("プールするプレハブの親のトランスフォーム")]
        Transform _poolPrefabParent;

        List<Pool> _pool = new List<Pool>();

        int _poolCountIndex = 0;

        protected override void Awake()
        {
            base.Awake();
            CreatePool();
            //デバッグ用
            //_pool.ForEach(x => Debug.Log($"オブジェクト名:{x.Object.name}種類: {x.Type}"));
        }

        /// <summary>
        /// 設定したオブジェクトの種類,数だけプールにオブジェクトを生成して追加する
        /// 再帰呼び出しを用いている
        /// </summary>
        private void CreatePool()
        {
            if (_poolCountIndex >= _objParam.Params.Count)
            {
                //デバッグ用
                //Debug.Log("すべてのオブジェクトを生成しました。");
                return;
            }

            for (int i = 0; i < _objParam.Params[_poolCountIndex].MaxCount; i++)
            {
                var prefab = Instantiate(_objParam.Params[_poolCountIndex].Prefab, _poolPrefabParent.transform);

                prefab.gameObject.SetActive(false);
                _pool.Add(new Pool { Prefab = prefab, Name = _objParam.Params[_poolCountIndex].Name });
            }

            _poolCountIndex++;
            CreatePool();
        }

        /// <summary>
        /// オブジェクトを使いたいときに呼び出す関数
        /// </summary>
        /// <param name="name">使いたいオブジェクトの名前</param>
        /// <param name="pos">生成したい場所</param>
        /// <returns>呼び出したゲームオブジェクト</returns>
        public GameObject UseObject(string name, Vector3 pos)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.LogWarning("名前が指定されていません");
                return null;
            }

            foreach (var pool in _pool)
            {
                if (pool.Prefab.gameObject.activeSelf == false && pool.Name == name)
                {
                    pool.Prefab.transform.position = pos;
                    pool.Prefab.SetActive(true);
                    return pool.Prefab;
                }
            }

            var findedObject = _objParam.Params.Find(x => x.Name == name);

            if (findedObject == null)
            {
                Debug.LogError($"{name}というオブジェクトが見つかりませんでした 誤字又は設定のし忘れがあります。");
                return null;
            }
                
            var prefab = Instantiate(findedObject.Prefab , _poolPrefabParent.transform);
            prefab.transform.position = pos;
            prefab.SetActive(true);
            _pool.Add(new Pool { Prefab = prefab, Name = name });
            return prefab;
        }

        /// <summary>
        /// オブジェクトを使いたいときに呼び出す関数
        /// 指定した型引数<T>を戻り値として返す
        /// </summary>
        /// <param name="name">使いたいオブジェクトの名前</param>
        /// <param name="pos">生成したい場所</param>
        /// <returns>呼び出したゲームオブジェクト</returns>
        public T UseObject<T>(string name, Vector3 pos) where T : Component
        {
            if(UseObject(name, pos).TryGetComponent(out T component))
            {
                return component;
            }
            else
            {
                Debug.LogError($"{typeof(T).Name}を取得しようとしましたが取得できませんでした");
                return null;
            }
        }

        private class Pool
        {
            public GameObject Prefab { get; set; }
            public string Name { get; set; }
        }

        [Serializable]
        public class ObjectPoolParams
        {
            public List<ObjectPoolParam> Params =>  _params;

            [SerializeField]
            private List<ObjectPoolParam> _params;

            [Serializable]
            public class ObjectPoolParam
            {
                public string Name => name;
                public GameObject Prefab => prefab;
                public int MaxCount => maxCount;

                [SerializeField]
                private string name;

                [SerializeField]
                private GameObject prefab;

                [SerializeField]
                private int maxCount;
            }
        }
    }
}
