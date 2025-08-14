using UnityEngine;

public sealed class EntityManager : MonoBehaviour
{
    public static Player player;        //플레이어
    public Transform SpawnPlayerTr;

    private void Awake()
    {
        player = Instantiate(Resources.Load<Player>("Prefabs/Player"), SpawnPlayerTr.position, Quaternion.identity);

        player.name = "Player";
        player.Init();
    }
}
