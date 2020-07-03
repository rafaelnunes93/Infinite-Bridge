using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private playerController _playerController;

    [Header("Config. Personagem")]
    public float velocidadeMovimento;
    public float limitMaxY;
    public float limitMinY;
    public float limitMaxX;
    public float limitMinX;

    [Header("Config. Objetos")]
    public float velocidadeObjeto;
    public float distanciaDestruir;

    public float tamanhoPonte;
    public GameObject pontePrefab;

    [Header("Config Barril")]
    public int orderDawn;
    public int orderTop;
    public float posYTop, posYDawn;

    public GameObject barrilPrefab;

    public float tempoSpaw;

    [Header("Globias")]
    public float posXPlayer;
    public Text txtScore;
    public int score;

    [Header("FX SOUND")]

    public AudioSource fxSource;
    public AudioClip fxPontos;


    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;
        StartCoroutine("spawnBarril");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = _playerController.transform.position.x;
    }

    IEnumerator spawnBarril()
    {
        yield return new WaitForSeconds(tempoSpaw);
        float posY = 0;
        int order = 0;

        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            posY = posYTop;
            order = orderTop;
        }
        else
        {
            posY = posYDawn;
            order = orderDawn;
        }

        GameObject temp = Instantiate(barrilPrefab);

        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;

        StartCoroutine("spawnBarril");
    }

    public void pontuar(int qtdPontos)
    {
        score += qtdPontos;
        txtScore.text = score.ToString();
        fxSource.PlayOneShot(fxPontos);

    }

    public void mudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }

}
