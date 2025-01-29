using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip hitClip;

    [SerializeField] private GameObject respawnButton;

    private PlayerBehaviour player;

    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerBehaviour>();
        if (respawnButton == null)
            Debug.LogError("Respawn button not setup");
        if (src == null)
            src = this.GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            player.movement = false;
            playerRB.velocity = Vector3.zero;
            respawnButton.SetActive(true);
            if (src != null)
                src.PlayOneShot(hitClip);
        }
    }
}