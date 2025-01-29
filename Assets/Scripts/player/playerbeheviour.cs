using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject playerCam;
    private GameObject player;
    //public GameObject Purple;
    //public GameObject Green;

    private Rigidbody2D m_Rigidbody;

    public int spawnState = 0;
    public int camState = 0;
    public bool respawnState = false;
    public bool isGreen = false;

    public bool movement = true;

    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
    }

    //input
    private void FixedUpdate()
    {
        if (movement == true)
        {
            m_Rigidbody.rotation += 2f;
            if (Input.GetAxis("Horizontal") > 0)
            {
                m_Rigidbody.AddForce(new Vector2(10, 0));
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                m_Rigidbody.AddForce(new Vector2(-10, 0));
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                m_Rigidbody.AddForce(new Vector2(0, 10));
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                m_Rigidbody.AddForce(new Vector2(0, -10));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("switch"))
        {
            if (isGreen == false)
            {
                isGreen = true;
            }
            else if (isGreen == true)
            {
                isGreen = false;
            }
        }
        if (other.gameObject.CompareTag("GoalT"))
        {
            SceneManager.LoadScene("Chapter 1");
        }
        if (other.gameObject.CompareTag("Chapter1Start"))
        {
            spawnState = 4;
            camState = 4;
        }
        if (other.gameObject.CompareTag("Goal 1-0"))
        {
            spawnState = 5;
            camState = 5;
            transform.position = new Vector2(65.89f, -21.4f);
        }
        if (other.gameObject.CompareTag("Goal 1-1"))
        {
            spawnState = 6;
            camState = 6;
            transform.position = new Vector2(36.74f, -43.5f);
        }
        if (other.gameObject.CompareTag("Goal 1-2"))
        {
            spawnState = 7;
            camState = 7;
            transform.position = new Vector2(65.13f, -95.92f);
        }
        if (other.gameObject.CompareTag("Goal 1-3"))
        {
            SceneManager.LoadScene("EndScreen");
        }
        if (isGreen == false && other.gameObject.CompareTag("Gwall"))
        {
            if (spawnState == 6)
            {
                transform.position = new Vector2(36.74f, -43.5f);
            }
            if (spawnState == 7)
            {
                transform.position = new Vector2(65.13f, -95.92f);
            }
        }
        if (isGreen == true && other.gameObject.CompareTag("Pwall"))
        {
            if (spawnState == 6)
            {
                transform.position = new Vector2(36.74f, -43.5f);
            }
            if (spawnState == 7)
            {
                transform.position = new Vector2(65.13f, -95.92f);
            }
        }

        if (other.gameObject.CompareTag("makePurple"))
        {
            Debug.Log("makePurple");
            isGreen = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pushG"))
        {
            Debug.Log("push");
            m_Rigidbody.AddForce(other.transform.up * 5);
        }
        if (other.gameObject.CompareTag("pushB"))
        {
            Debug.Log("PUSH");
            m_Rigidbody.AddForce(other.transform.up * 10);
        }
        if (other.gameObject.CompareTag("pushR"))
        {
            Debug.Log("PUSH!!!!");
            m_Rigidbody.AddForce(other.transform.up * 15);
        }
        if (other.gameObject.CompareTag("pullG"))
        {
            Debug.Log("pull");
            m_Rigidbody.AddForce(-other.transform.up * 5);
        }
        if (other.gameObject.CompareTag("pullB"))
        {
            Debug.Log("PULL");
            m_Rigidbody.AddForce(-other.transform.up * 10);
        }
        if (other.gameObject.CompareTag("pullR"))
        {
            Debug.Log("PULL!!!!");
            m_Rigidbody.AddForce(-other.transform.up * 15);
        }
    }
}