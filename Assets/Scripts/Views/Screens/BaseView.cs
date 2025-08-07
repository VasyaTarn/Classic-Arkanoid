using System.Collections;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public bool IsShowed
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
