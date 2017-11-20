using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public string scene;

	void Start () {
	
	}

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(scene);
           
        }
	}
}
