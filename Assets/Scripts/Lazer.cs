using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    #region Fields & Properties
    private float Speed = 12f;
    private float UpLimit = 6f;
    #endregion

    #region Methods
    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);

        if (transform.position.y > UpLimit)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
    #endregion
}
