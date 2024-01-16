using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    #region Fields & Properties
    private float RotateSpeed = 20.0f;
    [SerializeField] private GameObject ExplosionPrefab;
    private SpawnManager SpawnManager;
    #endregion

    #region Methods
    private void Start()
    {
        SpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            SpawnManager.StartSpawning();
        }
    }
    #endregion
}
