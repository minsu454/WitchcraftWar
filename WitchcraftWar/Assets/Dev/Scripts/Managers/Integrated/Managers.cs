using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    private static Managers instance;

    public static UIManager UI { get { return instance.uiManager; } }
    public static AnimatorContainer Container { get { return instance.characterContainer; } }

    private UIManager uiManager;
    private AnimatorContainer characterContainer = new AnimatorContainer();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        GameObject go = new GameObject("Managers");
        instance = go.AddComponent<Managers>();

        DontDestroyOnLoad(go);

        instance.uiManager = CreateManager<UIManager>(go.transform);

        DataServices.Init();

        instance.characterContainer.Init();
    }

    private void Start()
    {
        SkillManager.Init();
    }

    /// <summary>
    /// 매니저 생성 함수
    /// </summary>
    private static T CreateManager<T>(Transform parent) where T : Component, IInit
    {
        GameObject go = new GameObject(typeof(T).Name);
        T t = go.AddComponent<T>();
        go.transform.parent = parent;

        t.Init();

        return t;
    }
}