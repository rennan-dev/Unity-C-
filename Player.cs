using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidadePlayer;
    public float velocidadeCorrida;
    public float velocidadeAndar;
    private bool dancaIniciada = false;
    public Camera cameraPlayer;
    private Vector3 direcoes;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");
        float InputRun = Input.GetAxis("correr");

        direcoes = new Vector3(InputX,0,InputZ);
        if((InputX!=0 || InputZ!=0) && dancaIniciada==false) {
            var camrotation = cameraPlayer.transform.rotation;
            camrotation.x = 0;
            camrotation.z = 0;
            anim.SetBool("walk", true);
            transform.Translate(0, 0, velocidadePlayer * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcoes) * camrotation, 5 * Time.deltaTime);

            if(InputRun != 0) {
                anim.SetBool("run", true);
                velocidadePlayer = velocidadeCorrida;
            }else {
                anim.SetBool("run", false);
                velocidadePlayer = velocidadeAndar;
            }
        }else if(InputX==0 && InputZ==0) {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }

        //dança
        if (Input.GetKey(KeyCode.B) && dancaIniciada==false)
        {
            // Inicie a animação de dança
            anim.SetBool("dance2", true);
            dancaIniciada = true;
        }

        // Verifique se a animação de dança está completa
        if (dancaIniciada && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            // Pare a animação de dança
            anim.SetBool("dance2", false);
            dancaIniciada = false;
        }

    }
}
