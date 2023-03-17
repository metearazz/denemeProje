using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (yürümeSu.instance.isDead || yürüme.instance.isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
