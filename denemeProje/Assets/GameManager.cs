using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (y�r�meSu.instance.isDead || y�r�me.instance.isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
