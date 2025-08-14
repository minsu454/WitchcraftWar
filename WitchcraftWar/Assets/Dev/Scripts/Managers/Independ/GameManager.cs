using Common.Event;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Subscribe(GameEventType.GameOver, GameOver);
    }

    private void GameOver(object args)
    {
        Managers.UI.CreatePopup<GameOverPopup>();
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(GameEventType.GameOver, GameOver);
    }
}