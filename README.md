
# Proyecto de Juego en Unity

Este proyecto ha sido desarrollado en la asignatura de **Interfaces Inteligentes** del itinerario de computación del **_Grado en Ingeniería Informática_** de la **ULL**.

Práctica realizada con **José Manuel Hernández Hernández** (alu0100697032).


## Descripción del proyecto

Crear un juego de realidad virtual con lo aprendido en las diferentes prácticas del módulo de Realidad Virtual.  

sarrollando en las diferentes prácticas del módulo de Realidad Virtual. Se debe subir:

* Enlace al repositorio de github utilizado por el equipo. Debe incluir un documento de ayuda en el que se indique cuestiones importantes para el uso así como hitos logrados que destacarías en la aplicación.
* Proyecto completo comprimido en un .zip para guardar copia.

## Desarrollo
Hemos desarrollado un juego de varios niveles en que el objetivo es llevar la pelota del inicio al final con el movimiento de nuestra cabeza, para ello haremos uso de las Cardboard.

#### Nivel 0

![Level 1](Level_0.jpg)
> Este es un **nivel básico** para que el jugador aprenda las bases del juego, con ello se acostumbrará a los controles.

#### Nivel 1
![Level 1](Level_1.jpg)
> Con la introducción de este nuevo nivel el jugador esta mejorando sus capacidades para afrontar cada nivel.

#### Nivel 2
![Level 3](Level_2.jpg)
> Este nivel sigue el esquema perseguido por los anteriores.

## Hitos conseguidos
#### Script cuenta atrás
```` c++
using UnityEngine;
using System.Collections;

public class StartCountdown : UnityEngine.MonoBehaviour
{
    int time, a;
    float x;
    public bool count;
    public string timeDisp;

    void Start()
    {
        GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = false;
        time = 3;
        count = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count)
        {
            timeDisp = time.ToString();

            TextMesh textObject = GameObject.Find("StartCounter").GetComponent<TextMesh>();
            textObject.text = timeDisp;
            x += UnityEngine.Time.deltaTime;
            a = (int)x;
            switch (a)
            {

                case 0: textObject.text = "3"; break;
                case 1: textObject.text = "2"; break;
                case 2: textObject.text = "1"; break;
                case 3: textObject.text = "Start!"; break;
                case 4:
                    //GameObject.Find("StartCounter").GetComponent<UnityEngine.UI.Text>().enabled = false;
                    textObject.text = "";
                    count = false;
                    GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = true;
                    break;
            }
        }
    }
}
````

> **Script hecho para el inicio del juego.** Se trata de una cuenta atrás antes de comenzar el nivel. Cuando el contador llegue a 0 bajara la pelota y permitirá al jugador entrar en juego.

#### Script finish
```` c++
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class finish : MonoBehaviour
{
    public TextMesh textObject;

    void Start()
    {

        textObject = GameObject.Find("Win").GetComponent<TextMesh>();
        textObject.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("la esfera ha tocado al Cube.");
            SetCountText();
        }
    }

    void SetCountText()
    {

        textObject.text = "Win!";
    }
}
````
> **Script hecho para completar cada nivel.** Se trata de una vez el jugador llegue a la meta darle la victoria mostrando el mensaje **win!**. A partir de aquí se pasará a un nuevo nivel o se concluira el juego en caso de que el nivel actual sea el último.


## Ayúdame a mejorar este tutorial

Cada **bugs** que encuentres házmelo saber a [gcpmendez@gmail.com](mailto:gcpmendez@gmail.com)

## Enlaces Externos

  [1]: [ETSII ULL](http://www.ull.es/view/centros/etsii/Tercero_7/es), Escuela Técnica Superior de Ingeniería Informática - Graduado en Ingeniería Informática.
  [2]: [Unity](http://unity3d.com/es/get-unity/download/archive), Archivos de descarga de UNITY.
  [3]: [SDK de Vuforia para Unity](https://developer.vuforia.com/downloads/sdk), portal para desarrolladores de vuforia.

## Licencia
 <a rel="license"  href="http://creativecommons.org/licenses/by-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-sa/4.0/88x31.png" /></a>  <br />Este trabajo tiene una licencia <a rel="license" href="http://creativecommons.org/licenses/by-sa/4.0/">Creative Commons Attribution-ShareAlike 4.0 International License</a>.
