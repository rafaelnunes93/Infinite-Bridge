using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private GameController _gameController;

    private Rigidbody2D playerRb;


    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float posY = transform.position.y;
        float posX = transform.position.x;


        playerRb.velocity = new Vector2(horizontal * _gameController.velocidadeMovimento, vertical * _gameController.velocidadeMovimento);

        //verifica limite X
        if (transform.position.x < _gameController.limitMinX)
        {
            posX = _gameController.limitMinX;

        }
        else if (transform.position.x > _gameController.limitMaxX)
        {
        }

        //Verifica limite Y
        if (transform.position.y > _gameController.limitMaxY)
        {
            posY = _gameController.limitMaxY;
        }
        else if (transform.position.y < _gameController.limitMinY)
        {
            posY = _gameController.limitMinY;
        }

        transform.position = new Vector3(posX, posY, 0);
    }

    private void OnTriggerEnter2D()
    {
        _gameController.mudarCena("_GameOver");
    }
}
