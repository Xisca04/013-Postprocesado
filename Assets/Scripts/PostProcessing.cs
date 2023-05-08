using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void Start()
    {
        //Estas lineas se pueden poner en otro lado, no es necesario que siempre este en el Start
        volume.profile.TryGet(out vignette); // Intenar encontrar la vigneta
        vignette.active = true; // Para activar la vigneta o descativarla en algunos momentos, = que los paneles
           // Ahora modificamos la vigneta: intensidad y color, en este caso
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.yellow;

        StartCoroutine(Desactive());
    }

    private IEnumerator Desactive() // Corrutina cambio color
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}
