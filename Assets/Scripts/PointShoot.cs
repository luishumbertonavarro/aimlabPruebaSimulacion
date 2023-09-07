using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointShoot : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;

    public GameObject timeIsUp;
    public GameObject restart;
    public GameObject crosshairs;
    public GameObject robot;
    public GameObject bullet;
    public GameObject blancos;

    public Text resultado;

    private Rigidbody2D rb;

    private Vector2 limite;
    public float bulletSpeed=20.0f;
    public float spawnTargetTime=1.0f;
    public static int contador=0;
    public float calculo;

    FormulasRepository rep=new FormulasRepository();

    void Start()
    {
        Cursor.visible=false;
        rb=this.GetComponent<Rigidbody2D>();

        limite=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Objectivos());
    }

    // Update is called once per frame
    void Update()
    {
        if(ClockScript.timeLeft<=0){
            Time.timeScale=0;
            timeIsUp.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            calculo=rep.Exponencial(15,contador)*100;
            ResultScript.calculado=calculo;
            ResultScript.veces=contador;
            resultado.text="Hay una probabilidad de "+rep.Exponencial(15,contador)*100+"% de que acierten menos de 15 veces en el blanco, ud. le dio "+contador+" veces al blanco";
            resultado.gameObject.SetActive(true);

        }
        target=transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));
        crosshairs.transform.position=new Vector2(target.x,target.y);

        Vector3 difference= target-robot.transform.position;
        float rotationZ=Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
        robot.transform.rotation=Quaternion.Euler(0.0f,0.0f,rotationZ);
        if(Input.GetMouseButtonDown(0)){
            float distance=difference.magnitude;
            Vector2 direction=difference/distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
       
    }
    void fireBullet(Vector2 direccion, float rotationZ){
        GameObject aux= Instantiate(bullet) as GameObject;
        aux.transform.position=robot.transform.position;
        aux.transform.rotation=Quaternion.Euler(0.0f,0.0f,rotationZ);
        aux.GetComponent<Rigidbody2D>().velocity=direccion*bulletSpeed;
         if(transform.position.x < limite.x){

            Destroy(aux,5);
        }
    }
    
    private void spawnTarget(){
        GameObject aux=Instantiate(blancos) as GameObject;
        aux.transform.position=new Vector2(Random.Range(-limite.x,limite.x),Random.Range(-limite.y,limite.y));
        if(transform.position.x < limite.x){

            Destroy(aux,2);
        }
    }
    public void restartScene(){
        timeIsUp.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        resultado.gameObject.SetActive(false);
        Time.timeScale=1;
        ClockScript.timeLeft=20.0f;
        //Debug.Log(rep.Exponencial(15,contador));
        contador=0;
        SceneManager.LoadScene("Main");
    }
    IEnumerator Objectivos(){
        while(true){
            yield return new WaitForSeconds(spawnTargetTime);
            spawnTarget();

        }
    }
}
