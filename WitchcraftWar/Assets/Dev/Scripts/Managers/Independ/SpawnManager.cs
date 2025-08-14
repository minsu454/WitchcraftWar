using Common.Event;
using Common.Pool;
using Common.Yield;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpawnManager : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField]
    private List<Spawner> spawnerList = new List<Spawner>();
    [SerializeField]
    private float spawnTerm = 4f;           //스폰 텀 저장 변수
    private int enemyTypeLength;            //적 갯수 변수

    private Coroutine coSpawn;              //스폰 코루틴 저장 함수

    [Header("EnemyPool")]
    [SerializeField]
    private GameObject baseEnemyPrefab;     //적 기본 프리팹
    private ObjectPool<Enemy> enemyPool;    //적 오브젝트 풀

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// 초기화
    /// </summary>
    private void Init()
    {
        new GameObject("-------------EnemyPool-----------------");
        enemyPool = new ObjectPool<Enemy>("Enemy", baseEnemyPrefab, null, 30);

        enemyTypeLength = Enum.GetValues(typeof(EnemyIDType)).Length;

        EventManager.Subscribe(GameEventType.GameOver, UnSpawn);
    }

    /// <summary>
    /// 스폰 함수
    /// </summary>
    public void Spawn(int spawnCount, Action enemyDieEvent)
    {
        coSpawn = StartCoroutine(CoSpawn(spawnCount, enemyDieEvent));
    }

    public void UnSpawn(object args)
    {
        StopCoroutine(coSpawn);
    }

    /// <summary>
    /// 스폰 코루틴 함수
    /// </summary>
    private IEnumerator CoSpawn(int spawnCount, Action returnEvent)
    {
        int randomNum;
        for (int i = 0; i < spawnCount; i++)
        {
            Enemy enemy = enemyPool.GetObject();
            randomNum = UnityEngine.Random.Range(0, enemyTypeLength);
            enemy.Set((EnemyIDType)randomNum, returnEvent);

            randomNum = UnityEngine.Random.Range(0, spawnerList.Count);
            spawnerList[randomNum].Spawn(enemy.gameObject);

            yield return YieldCache.WaitForSeconds(spawnTerm);
        }
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(GameEventType.GameOver, UnSpawn);
    }
}
