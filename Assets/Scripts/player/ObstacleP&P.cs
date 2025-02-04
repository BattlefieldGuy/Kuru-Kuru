using UnityEngine;

public class ObstaclePP : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;

    [Header("Vars")]
    [SerializeField] private float pushForce;
    [SerializeField] private float pullForce;
    void Start()
    {
        if (player == null)
            player = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pushG"))
        {
            player.AddForce(other.transform.up * 5);
        }
        else if (other.gameObject.CompareTag("pushB"))
        {
            player.AddForce(other.transform.up * 10);
        }
        else if (other.gameObject.CompareTag("pushR"))
        {
            player.AddForce(other.transform.up * 15);
        }
        else if (other.gameObject.CompareTag("pullG"))
        {
            player.AddForce(-other.transform.up * 5);
        }
        else if (other.gameObject.CompareTag("pullB"))
        {
            player.AddForce(-other.transform.up * 10);
        }
        else if (other.gameObject.CompareTag("pullR"))
        {
            player.AddForce(-other.transform.up * 15);
        }
    }
}