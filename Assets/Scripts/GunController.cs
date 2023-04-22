using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
  //GunController
    private Vector3 mousePos;//Irá receber a posição do Mouse na cena;
    private Vector3 screenPoint;//Irá receber a posição da arma na cena;
    private Vector2 offeset;//Diferença entre a posição da arma e do mouse;
    private float angle;//Receberá o calculo do anglu entre a arma e o mouse para girar a arma;
    private SpriteRenderer sprite; //Receberá as infomações do render da arma
    public GameObject bullet; //Recebe o prefab das balas para que possam ser criadas na cena;
    public Transform spawnBullet; //Recebe a posição do objeto que criará as balas;
    public AudioSource bulletSound; //Recebe as propriedade de audio para controlar o som dos disparos;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); //Pega as configurações do Render da Arma;
    }

    void Update()
    {
        GunRotation(); //Chama o metódo para mirar;
        Shoot(); //Chama o metódo para atirar;
    }

    void GunRotation()
    {
        mousePos = Input.mousePosition; //Recebendo a posição do cursor do mouse;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position); //Recebendo a posição da arma levando em consideração a visão da camera;
        offeset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);//Diferença entre os pontos anteriores;

        angle = Mathf.Atan2(offeset.y, offeset.x) * Mathf.Rad2Deg; //Calculo do anglo que a arma deve ser girada

        transform.rotation = Quaternion.Euler(0, 0, angle); //Aplicando a rotação na arma;

        sprite.flipY = mousePos.x < screenPoint.x; //invertendo a orientação da arma dependendo da posição do mouse.

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1")) //Quando o botão esquedo do mouse ou o ctrl esquedo for pressionado.
        {
            bulletSound.Play();//Ativa o audio do disparo;
            Instantiate(bullet, spawnBullet.position, transform.rotation);//cria na cena uma bala na posição do spawnBullet.
        }
    }

}
