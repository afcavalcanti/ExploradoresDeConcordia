using UnityEngine;
using System.Collections;

public class moveObjeto : MonoBehaviour {
    public float speed;
    private float x;
    public GameObject Player;
    private bool pontuado;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;
        x += speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if(x <= -7)
        {
            Destroy(transform.gameObject);
        }

        if (x < Player.transform.position.x && pontuado == false)
        {
            pontuado = true;
            PlayerController.pontuacao += 1;
        }
	}
}
