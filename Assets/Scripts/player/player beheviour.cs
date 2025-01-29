using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject player;
    public GameObject MMCam;
    //public GameObject Purple;
    //public GameObject Green;

    private Rigidbody2D m_Rigidbody;

    public int spawnState = 0;
    public int camState = 0;
    public bool respawnState = false;
    public bool isGreen = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (camState == 0)
        {
            MMCam.transform.position = new Vector3(25.8f, -8.7f, -5.76518f);
        }
        if (camState == 1)
        {
            MMCam.transform.position = new Vector3(-45.8f, -50.5f, -5.76518f);
        }
        if (camState == 2)
        {
            MMCam.transform.position = new Vector3(-114.8f, -6.7f, -5.76518f);
        }
        if (camState == 3)
        {
            MMCam.transform.position = new Vector3(-162.1f, -50.4f, -5.76518f);
        }
        if (camState == 4)
        {
            MMCam.transform.position = new Vector3(-23.6f, 6.9f, -5.76518f);
        }
        if (camState == 5)
        {
            MMCam.transform.position = new Vector3(109.8f, 6.9f, -5.76518f);
        }
        if (camState == 6)
        {
            MMCam.transform.position = new Vector3(-16.8f, -72.8f, -5.76518f);
        }
        if (camState == 7)
        {
            MMCam.transform.position = new Vector3(117f, -72.8f, -5.76518f);
        }
        if (isGreen == false)
        {
            //Purple.SetActive(true);
            //Green.SetActive(false);
        }
        if (isGreen == true)
        {
            //Purple.SetActive(false);
            //Green.SetActive(true);
        }

    }

    private void FixedUpdate()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wal"))
        {
            if (spawnState == 0 || spawnState == 4)
            {
                transform.position = Vector2.zero;
            }
            if (spawnState == 1)
            {
                transform.position = new Vector2(2.73f, -30.23f);
            }
            else if (spawnState == 2)
            {
                transform.position = new Vector2(-68.68f, -33.47f);
            }
            else if (spawnState == 3)
            {
                transform.position = new Vector2(-123.11f, -26.88f);
            }
            else if (spawnState == 5)
            {
                transform.position = new Vector2(65.89f, -21.4f);
            }
            else if (spawnState == 6)
            {
                transform.position = new Vector2(36.74f, -43.5f);
            }
            else if (spawnState == 7)
            {
                transform.position = new Vector2(65.13f, -95.92f);
            }
            m_Rigidbody.velocity = Vector3.zero;


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
        if (other.gameObject.CompareTag("Respawn1"))
        {
            //transform.position = Vector2.Lerp(Player.transform.position, Circle.transform.position, 3f * (5 % Time.deltaTime));
            spawnState = 1;
            camState = 1;
        }
        if (other.gameObject.CompareTag("Respawn2"))
        {
            spawnState = 2;
            camState = 2;
        }
        if (other.gameObject.CompareTag("Respawn3"))
        {
            spawnState = 3;
            camState = 3;
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