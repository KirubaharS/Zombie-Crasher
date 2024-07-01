using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject",timer);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
