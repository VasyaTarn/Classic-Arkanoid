using System.Collections.Generic;
using UnityEngine;

public class BricksService : MonoBehaviour
{
    public void EnableBricks()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public bool HasAnyActiveChild()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
                return true;
        }

        return false;
    }
}
