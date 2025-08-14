using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public DirType dir;

    // Use this for initialization
    void Start()
    {
        switch (dir)
        {
            case DirType.Up:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, Screen.height));
                break;
            case DirType.Down:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, 0));
                break;
            case DirType.Left:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2f));
                break;
            case DirType.Right:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2f));
                break;
        }
    }
}
