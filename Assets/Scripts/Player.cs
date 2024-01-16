using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields & Properties
    private float Speed = 6.0f;
    private float SpeedMultiplier = 2.0f;
    private float RightLimit = 9.4f;
    private float LeftLimit = -9.4f;
    private float UpLimit = 4.6f;
    private float DownLimit = -4.6f;

    [SerializeField] private GameObject LazerPrefab = null;
    [SerializeField] private GameObject TripleShotPrefab = null;
    private int Lives = 3;
    private float FireRate = 0.5f;
    private float LastFired = -0.5f;
    private SpawnManager SpawnManager;
    private bool TripleShotActive = false;
    private bool SpeedActive = false;
    private bool ShieldActive = false;
    [SerializeField] private GameObject ShieldObject;
    private int Score = 0;
    private UIManager UIManager;
    [SerializeField] private GameObject rightEngine;
    [SerializeField] private GameObject leftEngine;
    private AudioSource audioSource;
    #endregion

    #region Methods
    private void Start()
    {
        transform.position = new Vector3(0, -4.6f, 0);
        SpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>();

        if (SpawnManager == null)
        {
            Debug.LogError("Spawn Manager GameObject is null!");
        }
    }

    private void Update()
    {
        PlayerMovement();
        PlayerFire();
    }

    private void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var newSpeed = Speed;

        if (SpeedActive == true)
        {
            newSpeed = Speed * SpeedMultiplier;
        }

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * newSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftLimit, RightLimit), transform.position.y, 0);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, DownLimit, UpLimit), 0);
    }

    private void PlayerFire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastFired + FireRate)
        {
            if (TripleShotActive == true)
            {
                Instantiate(TripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(LazerPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }

            LastFired = Time.time;
        }
    }

    public void Damage()
    {
        if (ShieldActive == true)
        {
            ShieldActive = false;
            ShieldObject.SetActive(false);
            return;
        }

        Lives -= 1;

        if (Lives == 2)
        {
            rightEngine.SetActive(true);
        }
        else if (Lives == 1)
        {
            leftEngine.SetActive(true);
        }

        UIManager.UpdateLives(Lives);

        if (Lives <= 0)
        {
            Destroy(this.gameObject);

            if (SpawnManager != null)
            {
                SpawnManager.PlayerDied();
            }
        }
    }

    public void ActivateTripleShot()
    {
        TripleShotActive = true;
        StartCoroutine(DeactivateTripleShot());
    }

    IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(5.0f);
        TripleShotActive = false;
    }

    public void ActivateSpeed()
    {
        SpeedActive = true;
        StartCoroutine(DeactivateSpeed());
    }

    IEnumerator DeactivateSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        SpeedActive = false;
    }

    public void ActivateShield()
    {
        ShieldActive = true;
        ShieldObject.SetActive(true);
        StartCoroutine(DeactivateShield());
    }

    IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(5.0f);
        ShieldActive = false;
        ShieldObject.SetActive(false);
    }

    public void CalculateScore()
    {
        Score++;

        if (UIManager != null)
        {
            UIManager.UpdateScore(Score);
        }
    }
    #endregion
}
