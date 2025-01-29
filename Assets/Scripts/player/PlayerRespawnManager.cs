using System.Collections;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip RespawnClip;

    private Vector2 respawnPoint = Vector2.zero;

    private Rigidbody2D playerRB;

    private PlayerBehaviour player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerBehaviour>();
        src = this.GetComponent<AudioSource>();
        playerRB = this.GetComponent<Rigidbody2D>();
    }
    public void Respawn()
    {
        this.gameObject.transform.position = respawnPoint;
        src.PlayOneShot(RespawnClip);
        StartCoroutine(ResetAfter());
    }

    private IEnumerator ResetAfter()
    {
        yield return new WaitForSeconds(1f);
        playerRB.velocity = Vector3.zero;
        player.movement = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit something");
        if (other.gameObject.CompareTag("RespawnPoint"))
        {

            respawnPoint = other.transform.position;
            Debug.Log("point set");
        }
    }
}