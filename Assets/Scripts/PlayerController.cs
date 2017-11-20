using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Animator Anime;
    public Rigidbody2D playerRigidbody;
    public int forceJump;
    public bool jump;
    public bool slide;
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform GroundCheck;
    public float slideTemp;
    public float timeTemp;
    public Transform colisor;
    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public UnityEngine.UI.Text txtPontos;
    public static int pontuacao ;

	// Use this for initialization
	void Start () {
        pontuacao = 0;
        PlayerPrefs.SetInt("pontuacao", pontuacao);
    }
	
	// Update is called once per frame
	void Update () {

        txtPontos.text = pontuacao.ToString();

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            audio.PlayOneShot(soundJump);
            audio.volume = 1;

            if (slide == true)
            {
           
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                slide = false;
            }
        }

        else if (Input.GetButtonDown("Slide") && grounded == true && slide==false)
        {
            audio.PlayOneShot(soundSlide);
            audio.volume = 0.5f;
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            slide = true;
            timeTemp = 0;
        }


        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);

        if(slide == true)
        {

            timeTemp += Time.deltaTime;
            if(timeTemp >= slideTemp)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                slide = false;
            }
        }

        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);
    }

    void OnTriggerEnter2D() {
        PlayerPrefs.SetInt("pontuacao", pontuacao);

        if (pontuacao > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", pontuacao);
        }


        Application.LoadLevel("gameover");

    }

}
