using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet
   public float speed; //Recebe a velocidade do bala.

    void Update()
    {
       transform.Translate(Vector2.right * speed * Time.deltaTime); //Movimenta a bala sempre para a direita, levando em consideração que seu angulo sempre é dado pelo angulo da arma;
    }

    private void OnTriggerEnter2D(Collider2D collision) // quando a bala conlide com qualquer objeto.
    {
       Destroy(gameObject);  //a bala se destroi.
    }
}
