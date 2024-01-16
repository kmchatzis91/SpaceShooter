using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields & Properties
    private float Speed = 4.0f;
    private float RightLimit = 9.4f;
    private float LeftLimit = -9.4f;
    private float UpLimit = 6.6f;
    private float DownLimit = -6.6f;
    private Player Player;
    private Animator Animator;
    private AudioSource audioSource;
    #endregion

    #region Methods
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        Animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if (transform.position.y < DownLimit)
        {
            float rx = Random.Range(LeftLimit, RightLimit);
            transform.position = new Vector3(rx, UpLimit, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            DestroyEnemy();

            if (Player != null)
            {
                Player.CalculateScore();
            }
        }

        if (other.tag == "Player")
        {
            var player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
                DestroyEnemy();
            }
        }
    }

    private void DestroyEnemy() 
    {
        Animator.SetTrigger("OnEnemyDestuction");
        Speed = 0;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        Destroy(this.gameObject, 2.4f);
    }
    #endregion
}
