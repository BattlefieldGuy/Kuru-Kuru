using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start() => offset = transform.position - player.transform.position;

    void LateUpdate() => transform.position = player.transform.position + offset;
}
