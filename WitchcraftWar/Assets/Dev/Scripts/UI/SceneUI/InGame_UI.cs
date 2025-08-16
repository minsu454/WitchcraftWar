using Common.Event;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class InGame_UI : BaseSceneUI
{
    public TextMeshProUGUI text;
    [SerializeField] private UISkillDescription UISkillDescription;         //스킬 설명

    [SerializeField] private TextMeshProUGUI coinText;                      //코인 텍스트
    [SerializeField] private TextMeshProUGUI skillCountText;                //스킬카운트 텍스트
    [SerializeField] private TextMeshProUGUI skillBuyPriceText;             //스킬가격 텍스트

    private UISkillBtn btn;

    public override void Init()
    {
        EventManager.Subscribe(GameEventType.NextRound, NextRound);
    }

    private void Update()
    {
        CoinEvent(GameManager.Instance.Coin);
        SkillCountEvent(SkillManager.CurSkillCount, SkillManager.MaxSkillCount);
        SkillBuyPriceTextEvent(SkillManager.SkillBuyPrice);
    }

    private void NextRound(object args)
    {
        DOTween.To(() => 0f, x => text.alpha = x, 1f, 0.5f).SetLoops(2, LoopType.Yoyo);
    }

    /// <summary>
    /// 스킬 사는 버튼 함수
    /// </summary>
    public void BuySkillBtn()
    {
        SkillManager.BuySkill();
    }

    /// <summary>
    /// 스킬 눌렀을 때 효과 함수
    /// </summary>
    public void UISkillBtn(UISkillBtn btn)
    {
        if (this.btn == btn)
        {
            Upgrade();
            return;
        }

        UISkillDescription.gameObject.SetActive(true);

        var data = SkillManager.GetSkillData(btn.IDType);
        UISkillDescription.Set(data);

        this.btn = btn;
    }

    /// <summary>
    /// 스킬 업그레이드 함수
    /// </summary>
    private void Upgrade()
    {
        SkillManager.UpgradeSkill(btn.IDType);
        UISkillDescription.gameObject.SetActive(false);
        btn = null;
    }

    /// <summary>
    /// 코인 보여주는 함수
    /// </summary>
    private void CoinEvent(int coin)
    {
        coinText.text = $"{coin}";
    }

    /// <summary>
    /// 스킬 카운트 보여주는 함수
    /// </summary>
    private void SkillCountEvent(int skillCount, int maxSkillCount)
    {
        skillCountText.text = $"{skillCount} / {maxSkillCount}";
    }

    /// <summary>
    /// 스킬 카운트 보여주는 함수
    /// </summary>
    private void SkillBuyPriceTextEvent(int skillBuyPrice)
    {
        skillBuyPriceText.text = $"{skillBuyPrice}";
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(GameEventType.NextRound, NextRound);
    }
}
