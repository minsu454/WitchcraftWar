using Common.EnumExtensions;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Common.SceneEx
{
    public static class SceneManagerEx
    {
        private static string nextScene;

        /// <summary>
        /// 씬 로드 함수
        /// </summary>
        public static void LoadScene(SceneType type)
        {
            SceneManager.LoadScene(type.EnumToString());
        }

        public static void OnLoadCompleted(UnityAction<Scene, LoadSceneMode> callback)
        {
            SceneManager.sceneLoaded += callback;
        }
    }
}
