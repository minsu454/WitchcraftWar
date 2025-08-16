using Common.Event;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int coin = 100;
    public int Coin
    {
        get { return coin; }
    }

    private void Awake()
    {
        Instance = this;

        EventManager.Subscribe(GameEventType.GameOver, GameOver);
    }

    /// <summary>
    /// 코인 얻는 함수
    /// </summary>
    public void SetCoin(int coin)
    {
        this.coin += coin;
    }

    /// <summary>
    /// GameOver 함수
    /// </summary>
    private void GameOver(object args)
    {
        Managers.UI.CreatePopup<GameOverPopup>();
    }

    private void OnDestroy()
    {
        Instance = null;

        EventManager.Unsubscribe(GameEventType.GameOver, GameOver);
    }
}