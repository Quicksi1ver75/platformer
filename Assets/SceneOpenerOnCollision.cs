using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpenerOnCollision : MonoBehaviour


{

    public string NextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)

    {

       SceneManager.LoadScene(NextLevelName);

    }

}
 