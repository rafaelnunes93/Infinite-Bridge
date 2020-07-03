using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlePonte : MonoBehaviour
{
    private GameController _gameController;
    private Rigidbody2D ponteRb;

    private bool instanciado;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        ponteRb = GetComponent<Rigidbody2D>();

        ponteRb.velocity = new Vector2(_gameController.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(instanciado == false)
        {
            if(transform.position.x <= 0)
            {
                instanciado = true;
                GameObject temp = Instantiate(_gameController.pontePrefab);
                float posX = transform.position.x + _gameController.tamanhoPonte;
                float posY = transform.position.y;
                temp.transform.position = new Vector3(posX, posY, 0);
            }
        }

        if(transform.position.x < _gameController.distanciaDestruir)
        {
            Destroy(this.gameObject,1);
        }
    }
}
