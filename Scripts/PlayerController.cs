using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private bool saltoMejorado;
    [SerializeField] private float saltoLargo = 1.5f;
    [SerializeField] private float saltoCorto = 1f;
    [SerializeField] private Transform checkGround;
    [SerializeField] private float checkGroundRadio;
    [SerializeField] private LayerMask capaSuelo;

    public float velocidad;
    public bool atacar;
    public bool agacharse;
    public bool invulnerabilidad;
    public int nLivesMax, nLivesMin;
    public float startTime, endTime, limiteTime;

    private Rigidbody2D rPlayer;
    private Animator aPlayer;
    private GameObject gameManagerObj;
    private GameManager gameManager;
    private float moveHorizontal;
    private bool miraDerecha = true;
    private bool saltando = false;
    private bool puedoSaltar = false;
    private bool tocaSuelo = false;
    private Vector2 nuevaVelocidad;

    AudioSource aS;
    [SerializeField] private ParticleSystem particulas;

    private void Awake()
    {
        atacar = false;
        agacharse = false;
        nLivesMax = 10;
        nLivesMin = 0;
        invulnerabilidad = false;
        saltoMejorado= true;
        aS = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        moveHorizontal = 1f;
        velocidad = 3f;
        fuerzaSalto = 5f;
        startTime = Time.time;
        endTime = Time.time;
        limiteTime = 3f;

        gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }
       
        rPlayer = GetComponent<Rigidbody2D>();
        aPlayer = GetComponent<Animator>();
    }
    private void Update()
    {
        RecibePulsaciones();
        
        if (invulnerabilidad)
        {
            if (endTime - startTime >= limiteTime)
            {
                invulnerabilidad = false;
                startTime = Time.time;
                endTime = Time.time;
            }
            else
            {
                endTime += Time.deltaTime;
            }
        }
    }
    private void LateUpdate()
    {
        VariablesAnimator();
    }
    void FixedUpdate()
    {
        CheckTocaSuelo();
        MovimientoPlayer();
    }
    private void MovimientoPlayer()
    {
        if (tocaSuelo && !saltando)
        {
            nuevaVelocidad.Set(velocidad * moveHorizontal, 0.0f);
            rPlayer.velocity = nuevaVelocidad;

        }
        else
        {
            if (!tocaSuelo)
            {
                nuevaVelocidad.Set(velocidad * moveHorizontal, rPlayer.velocity.y);
                rPlayer.velocity = nuevaVelocidad;
            }
        }
    }
    private void RecibePulsaciones()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if ((moveHorizontal > 0 && !miraDerecha) || (moveHorizontal < 0 && miraDerecha))
        {
            giraPlayer();
        }
        if(Input.GetButtonDown("Jump") && puedoSaltar) 
        {
            Salto();
            particulas.Play(); 
        }
        if (saltoMejorado)
        {
            SaltoMejorado();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            agacharse = true;
        } else
        {
            agacharse = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            atacar = true;
        }
        else
        {
            atacar = false;
        }
    }
    private void Salto()
    {
        saltando = true;
        puedoSaltar = false;
        rPlayer.velocity = new Vector2(rPlayer.velocity.x, 0);
        rPlayer.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
    }
    private void CheckTocaSuelo()
    {
        tocaSuelo = Physics2D.OverlapCircle(checkGround.position, checkGroundRadio, capaSuelo);
        if (rPlayer.velocity.y <= 0f)
        {
            saltando = false;
        }
        if (tocaSuelo && !saltando)
        {
            puedoSaltar = true;
        }
    }
  
    private void SaltoMejorado()
    {
        if (rPlayer.velocity.y < 0)
        {
            rPlayer.velocity = new Vector2(rPlayer.velocity.x, rPlayer.velocity.y) + (Vector2.up * Physics2D.gravity * saltoLargo * Time.deltaTime);
        }
        else if (rPlayer.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rPlayer.velocity = new Vector2(rPlayer.velocity.x, rPlayer.velocity.y) + (Vector2.up * Physics2D.gravity * saltoCorto * Time.deltaTime);
        }
    }
    private void VariablesAnimator()
    {
        aPlayer.SetFloat("Vidas", gameManager.PlayersLives);
        aPlayer.SetFloat("VelocidadX", Mathf.Abs(rPlayer.velocity.x));
        aPlayer.SetFloat("VelocidadY", rPlayer.velocity.y);
        aPlayer.SetBool("TocaSuelo", tocaSuelo);
        aPlayer.SetBool("Atacar", atacar);
        aPlayer.SetBool("Agacharse", agacharse);
        aPlayer.SetBool("Saltando", saltando);

    }
    void giraPlayer()
    {
        miraDerecha = !miraDerecha;
        gameObject.GetComponent<SpriteRenderer>().flipX = miraDerecha;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGround.position, checkGroundRadio);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (gameManager.PlayersLives > nLivesMin && invulnerabilidad == false)
            {
                RestarVida();
                invulnerabilidad = true;
                aS.Play();
            }

        }
    }
    public void RestarVida()
    {
        gameManager.PlayersLives--;
    }

}
