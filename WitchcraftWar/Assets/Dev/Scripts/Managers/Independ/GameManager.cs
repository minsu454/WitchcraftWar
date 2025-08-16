using Common.Event;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int coin = 200;
    public int Coin
    {
        get { return coin; }
    }

    private void Awake()
    {
        instance = this;

        EventManager.Subscribe(GameEventType.GameOver, GameOver);
    }

    /// <summary>
    /// 코인 얻는 함수
    /// </summary>
    public void GetCoin(object coin)
    {
        this.coin += (int)coin;
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
        instance = null;

        EventManager.Unsubscribe(GameEventType.GameOver, GameOver);
    }
}