using Common.Event;
using Common.Timer;
using UnityEngine;

public sealed class StageManager : MonoBehaviour
{
    [SerializeField] private int round = 0;             //라운드
    [SerializeField] private int roundSpawnCount = 5;   //라운드 별 스폰 카운트

    private SpawnManager spawnManager;                  //스폰 매니저
    private int enemyCount;                             //현재 스폰되어있는 적 숫자
    private bool isGameOver = false;                    //게임이 종료되었는지 확인하는 변수
    private Coroutine coroutine;

    private void Awake()
    {
        spawnManager = GetComponent<SpawnManager>();

        EventManager.Subscribe(GameEventType.GameOver, GameOver);
    }

    private void Start()
    {
        round++;
        enemyCount = round;
        spawnManager.Spawn(false, OnReturnRound);
        coroutine = StartCoroutine(CoTimer.StartLoop(10f, () => NextRound()));
    }

    /// <summary>
    /// 다음라운드 호출 함수
    /// </summary>
    public void NextRound()
    {
        round++;
        enemyCount = round;
        EventManager.Dispatch(GameEventType.NextRound, round);
    }
    
    /// <summary>
    /// 적 죽은 후 리턴 이벤트 함수
    /// </summary>
    private void EnemyDieEvent()
    {
        
    }

    private int OnReturnRound()
    {
        return round;
    }

    private void GameOver(object args)
    {
        isGameOver = true;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = null;
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(GameEventType.GameOver, GameOver);
    }
}
