using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleBarril : MonoBehaviour
{
    private GameController _gameController;
    private Rigidbody2D barrielRb;
    private bool pontuado;


    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        barrielRb = GetComponent<Rigidbody2D>();

        barrielRb.velocity = new Vector2(_gameController.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _gameController.distanciaDestruir)
        {
            Destroy(this.gameObject, 1);
        }
    }

    private void LateUpdate()
    {
        if(pontuado == false && transform.position.x < _gameController.posXPlayer)
        {

                pontuado = true;
            _gameController.pontuar(1);

        }
    }
}
