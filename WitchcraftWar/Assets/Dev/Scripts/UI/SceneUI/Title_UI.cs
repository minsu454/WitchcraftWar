using Common.SceneEx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_UI : BaseSceneUI
{
    public override void Init()
    {
        
    }

    public void GoInGameBtn()
    {
        SceneManagerEx.LoadScene(SceneType.InGame_Scene);
    }

    public void CollectionBtn()
    {
        Managers.UI.CreatePopup<CollectionPopup>();
    }
}
