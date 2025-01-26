using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndSQ : MonoBehaviour
{
    void Start() => StartCoroutine(Coroutine());

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}