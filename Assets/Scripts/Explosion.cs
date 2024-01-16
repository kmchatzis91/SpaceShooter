using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region Fields & Properties

    #endregion

    #region Methods
    private void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }

    private void Update()
    {

    }
    #endregion
}
