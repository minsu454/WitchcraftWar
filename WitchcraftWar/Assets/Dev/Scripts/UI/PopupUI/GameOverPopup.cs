
using Common.SceneEx;

public class GameOverPopup : BasePopupUI
{
    public void GoTitleBtn()
    {
        SceneManagerEx.LoadScene(SceneType.Title_Scene);
    }

    public void RetryBtn()
    {
        SceneManagerEx.LoadScene(SceneType.InGame_Scene);
    }

    public void CollectionBtn()
    {
        Managers.UI.CreatePopup<CollectionPopup>();
    }
}
