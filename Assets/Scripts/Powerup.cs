using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    #region Fields & Properties
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private int PowerUpId;
    private float DownLimit = -6.6f;
    [SerializeField] private AudioClip audioClip;
    #endregion

    #region Methods
    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if (transform.position.y < DownLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip,transform.position);
            Destroy(this.gameObject);
            var player = other.GetComponent<Player>();

            if (player != null)
            {
                if (PowerUpId == 1)
                {
                    player.ActivateTripleShot();
                }
                else if (PowerUpId == 2)
                {
                    player.ActivateSpeed();
                }
                else if (PowerUpId == 3)
                {
                    player.ActivateShield();
                }
            }
        }
    }
    #endregion
}
