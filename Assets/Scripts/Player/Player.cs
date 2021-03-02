using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int vida;
    public float velocidade;
    public bool estaVoando;
    public float forcaPulo;
    public bool estaNoChao;
    public bool estaNaRampa;

	void Start () {
        
      
    }
	
	
	void Update () {
        
        movimentacao();
        pulo();

        
        

    }


    void movimentacao()
    {
  


        if (!Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {

            GetComponent<Animator>().SetBool("Andando", false);


        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * velocidade);
            GetComponent<Animator>().SetBool("Andando", true);

            GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -velocidade);
            GetComponent<Animator>().SetBool("Andando", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }


    }


    void pulo()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaNoChao == true)
            {
                rigidbody.AddForce(Vector2.up * forcaPulo);
                estaNoChao = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Plataformas") && estaNaRampa == false)
        {
            estaNoChao = true;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rampa"))
        {
            estaNaRampa = true;
            
            this.transform.rotation = Quaternion.Euler(0, 0, -45);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rampa"))
        {
            estaNaRampa = false;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }








}
