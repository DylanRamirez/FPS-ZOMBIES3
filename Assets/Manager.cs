using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public CiudadanosInformacion ciuInformacion; //Declara la estructura que contiene la información del ciudadano
    public ZombiesInformacion zomInformacion; //Declara la estructura que contiene la información del zombie
    List<GameObject> lista = new List<GameObject>(); // lista creada para almacenar la cantidad de zombies y ciudadanos
    public int contador1; // Variable creada para el contador de los Zombies
    public int contador2; // Variable creada para el contador de los Ciudadanos

    Text ciudadano;
    Text zombie;


    void Start()
    {
        int puntoApa = -1; //Inicia variable en -1 para iniciar el default del switch y crear el heroe
        zomInformacion.color = new Color[] { Color.cyan, Color.green, Color.magenta }; //Asigna los valores de color al array del color del zombie
        for (int i = 0; i < Random.Range(10, 20); i ++) //Bucle que crea las primitivas de cubo para ciudadano, zobie y heroe. Contiene un switch que asigna la identidad a cada primitiva
        {
            GameObject humanoide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            humanoide.transform.position = pos;
            switch (puntoApa)
            {
                case 1:
                    humanoide.name = "Ciudadano";
                    humanoide.AddComponent<Ciudadanos>();
                    lista.Add(humanoide); // esta almacenando la cantidad de ciudadanos a la lista creada
                    break;

                case 2:
                    humanoide.name = "Zombie";
                    humanoide.AddComponent<Zombies>();
                    humanoide.GetComponent<Renderer>().material.color = zomInformacion.color[Random.Range(0, 3)];
                    lista.Add(humanoide); // esta almacenando la cantidad de ciudadanos a la lista creada
                    break;

                default:
                    humanoide.name = "Hero";
                    humanoide.gameObject.tag = "Player";
                    humanoide.AddComponent<Hero>();
                    humanoide.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
                    break;
            }
            puntoApa = Random.Range(1, 3); //Valor aleatorio para añadir la identidad al cubo
        }

        foreach(GameObject objeto in lista) // Metodo que se utiliza para los contadores de lo zombies y ciudadanos
        {
            if (objeto.GetComponent<Zombies>())
            {
                contador1 += 1;
            }
            else
            {
                contador2 += 1;
            }
        }

        ciudadano = GameObject.Find("Ciudadano").GetComponent<Text>(); // Nombre Ciudadano que se le pone al texto en el canvas
        zombie = GameObject.Find("Zombie").GetComponent<Text>(); // Nombre Zombie que se le pones al texto en el canvas
    }

    void Update() // llama y coloca en la pantalla el texto Ciudadanos = y Zombies = y la cantidad del contador
    {
        ciudadano.text = "Ciudadanos = " + contador2; 
        zombie.text = "Zombies = " + contador1; 
    }
}
