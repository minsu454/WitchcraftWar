using DG.Tweening;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int spawnWaringCount = 2;               //스폰 전 표시 카운트
    private SpriteRenderer waringSpriteRenderer;    //스폰 이미지
    [SerializeField]
    private Color32 waringColor;                    //표시 색상

    private void Awake()
    {
        waringSpriteRenderer = GetComponent<SpriteRenderer>();
        waringSpriteRenderer.enabled = false;
    }

    /// <summary>
    /// 넘어온 몬스터 스폰해주는 함수
    /// </summary>
    public void Spawn(GameObject monster)
    {
        waringSpriteRenderer.enabled = true;
        waringSpriteRenderer.DOFade(0, 0.5f).SetLoops(spawnWaringCount).OnComplete(() =>
        {
            if (this == null)
                return;

            monster.transform.position = transform.position;
            monster.SetActive(true);

            waringSpriteRenderer.color = waringColor;
            waringSpriteRenderer.enabled = false;
        });
    }
}
