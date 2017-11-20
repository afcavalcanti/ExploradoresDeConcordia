using UnityEngine;
using System.Collections;

public class spawnController : MonoBehaviour {

    public GameObject[] barreriraUp;
    public GameObject[] barreriraDown;

    public float rateSpawn;
    private float currentTime;
    private int posicao;
    private float y;
    public float posA;
    public float posB;

	void Start () {
        currentTime = 0;

    }
	
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime >= rateSpawn)
        {
            GameObject tempPrefab;

            currentTime = 0;
            posicao = Random.Range(1, 100);
            if (posicao > 50)
            {
                y = posA;

                tempPrefab = Instantiate(barreriraDown[Random.Range(0, barreriraDown.Length)]) as GameObject;

            }
            else
            {
                y = posB;

                tempPrefab = Instantiate(barreriraUp[Random.Range(0, barreriraUp.Length)]) as GameObject;
            }
            
            tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);

        }
    }
}
