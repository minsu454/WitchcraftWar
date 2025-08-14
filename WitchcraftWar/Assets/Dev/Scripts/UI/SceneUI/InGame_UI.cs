using Common.Event;
using DG.Tweening;
using TMPro;

public class InGame_UI : BaseSceneUI
{
    public TextMeshProUGUI text;

    public override void Init()
    {
        EventManager.Subscribe(GameEventType.NextRound, NextRound);
    }

    private void NextRound(object args)
    {
        DOTween.To(() => 0f, x => text.alpha = x, 1f, 0.5f).SetLoops(2, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(GameEventType.NextRound, NextRound);
    }
}
