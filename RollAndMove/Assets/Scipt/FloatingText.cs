using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    #region Fields;

    public float Duration = 3.0f;

    #endregion

    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Duration);
    }

    #endregion
}
