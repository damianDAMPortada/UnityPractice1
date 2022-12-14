using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingItem : MonoBehaviour
{
    [SerializeField][Range(0.01f, 1)] float amplitud = 0.25f;
    [SerializeField][Range(0.1f, 5f)] float tiempoMovimiento = 1f;
    [SerializeField][Range(1f, 50f)] float velGiro = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpBounce());
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * velGiro * Time.deltaTime;
    }
    private IEnumerator LerpBounce()
    {
        int direccion = 1;
        float tiempoUsado = tiempoMovimiento / 2 - Time.deltaTime;
        Vector3 posInferior = transform.position - Vector3.up * amplitud;
        Vector3 posSuperior = posInferior + 2 * Vector3.up * amplitud;
        Vector3 posInicio = posInferior;
        Vector3 posFinal = posSuperior;
        while (true)
        {
            if (tiempoUsado > tiempoMovimiento)
            {
                posInicio = direccion == 1 ? posInferior : posSuperior;
                posFinal = direccion == 1 ? posSuperior : posInferior;
                transform.position = posFinal;
                direccion *= -1;
                tiempoUsado = 0;
            }
            tiempoUsado += Time.deltaTime;
            transform.position = Vector3.Lerp(posInicio, posFinal, tiempoUsado / tiempoMovimiento);

            yield return null;
        }

    }
}
