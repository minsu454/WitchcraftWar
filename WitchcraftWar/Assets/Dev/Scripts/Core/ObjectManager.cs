
using System.Collections.Generic;
using UnityEngine;

namespace Common.Objects
{
    public static class ObjectManager
    {
        private static readonly Dictionary<string, Object> objectContainerDict = new Dictionary<string, Object>();  //비동기 캐시해주는 Dictionary

        /// <summary>
        /// 개별 오브젝트를 비동기로 로드하고 딕셔너리에 추가하는 함수
        /// </summary>
        private static void LoadAndAddObjectAsync(string primaryKey)
        {
        }

        /// <summary>
        /// Dictionary 초기화 함수
        /// </summary>
        public static void Clear()
        {
            objectContainerDict.Clear();
        }

        /// <summary>
        /// 재너릭 변환 오브젝트 반환 함수
        /// </summary>
        public static T Return<T>(string path) where T : Object
        {
            if (!objectContainerDict.TryGetValue(path, out Object value))
            {
                Debug.LogError($"Is Not Found Object : {path}");
                return default(T);
            }

            if (!value is T)
            {
                Debug.LogError($"Object Is Not Inheritance : {typeof(T).Name}");
                return default(T);
            }

            return (T)value;
        }

        /// <summary>
        /// 재너릭 변환 오브젝트 반환 함수
        /// </summary>
        public static GameObject Instantiate(string path)
        {
            if (!objectContainerDict.TryGetValue(path, out Object value))
            {
                Debug.LogError($"Is Not Found Object : {path}");
                return null;
            }

            GameObject go = value as GameObject;

            if (go == null)
            {
                Debug.LogError($"Object Is Not GameObject : {path}");
                return null;
            }

            return Object.Instantiate(go);
        }

        /// <summary>
        /// 재너릭 변환 오브젝트 반환 함수
        /// </summary>
        public static GameObject Instantiate(string path, Transform parent)
        {
            if (!objectContainerDict.TryGetValue(path, out Object value))
            {
                Debug.LogError($"Is Not Found Object : {path}");
                return null;
            }

            GameObject go = value as GameObject;

            if (go == null)
            {
                Debug.LogError($"Object Is Not GameObject : {path}");
                return null;
            }

            return Object.Instantiate(go, parent);
        }
    }
}
