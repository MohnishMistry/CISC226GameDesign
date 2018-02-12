using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public Transform Canvas;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Canvas.gameObject.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                Canvas.gameObject.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                Canvas.gameObject.SetActive(false);

            }
        }
    }
}
