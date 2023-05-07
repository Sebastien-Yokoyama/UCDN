using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperFadeIn : MonoBehaviour


{
    public float fadeInTime = 2f;
    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    void Start()
    {
        // Add all the MeshRenderers to the list
        foreach (Transform child in transform)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderers.Add(meshRenderer);
            }
        }

        // Set the alpha of each MeshRenderer to 0
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            Color color = meshRenderer.material.color;
            color.a = 0f;
            meshRenderer.material.color = color;
        }

        // Fade in each MeshRenderer
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            StartCoroutine(FadeIn(meshRenderer));
        }
    }

    IEnumerator FadeIn(MeshRenderer meshRenderer)
    {
        // Wait for the specified fade-in time
        yield return new WaitForSeconds(fadeInTime);

        // Gradually increase the alpha of the material
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeInTime)
        {
            Color color = meshRenderer.material.color;
            color.a = t;
            meshRenderer.material.color = color;
            yield return null;
        }

        // Set the alpha to 1 in case there is any slight variation due to floating point errors
        Color finalColor = meshRenderer.material.color;
        finalColor.a = 1f;
        meshRenderer.material.color = finalColor;
    }
}


