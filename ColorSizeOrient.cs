using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorSizeOrient : MonoBehaviour
{
    public bool scaleUniform;
    public float uniScaleMin = .1f;
    public float uniScaleMax = 1f;

    public float xScaleMin = .1f;
    public float xScaleMax = 1f;
    public float yScaleMin = .1f;
    public float yScaleMax = 1f;
    public float zScaleMin = .1f;
    public float zScaleMax = 1f;
   
    Renderer rend;
    private GameObject scaler;
  

    // Start is called before the first frame update
    void Start()
    {
       
        Color newColor = Random.ColorHSV(0f, 0.8f, 0.1f, 0.8f, 0.1f, 0.9f);
        if (gameObject.tag == "body")
        {

            rend = GetComponent<Renderer>();
            rend.material.SetFloat("_Glossiness", 0);
            rend.material.SetColor("_Color", newColor);
            RandomizeScale();

        }
        
        if (gameObject.tag == "bodypart")
        {
            float hue, sat, val;
            Color.RGBToHSV(newColor, out hue, out sat, out val);
            float hueInc = Random.Range(0.95f, 1.05f);
            float satInc = Random.Range(0.60f, 1.1f);   
            float valInc = Random.Range(0.7f, 1.1f); 
            Color childColor = Color.HSVToRGB(hue * hueInc, sat * satInc, val * valInc);  //Set color proportional to the random body color
            rend = GetComponent<Renderer>();
            rend.material.SetFloat("_Glossiness", 0);
            rend.material.SetColor("_Color", childColor);
            RandomizeScale();
            
        }

        Debug.Log(newColor);
        //For use in objects made up of children to also color the children the same random color.
        if (gameObject.tag == "limbs")
        {

            Component[] rendMult = GetComponents<Renderer>();
            float hue, sat, val;
            Color.RGBToHSV(newColor, out hue, out sat, out val);
            float hueInc = Random.Range(0.95f, 1.05f);
            float satInc = Random.Range(0.60f, 1.1f);
            float valInc = Random.Range(0.7f, 1.1f);
            Color childColor = Color.HSVToRGB(hue * hueInc, sat * satInc, val * valInc);
            rendMult = GetComponentsInChildren<Renderer>();
            foreach (Renderer childRen in rendMult)
            {
                childRen.material.SetFloat("_Glossiness", 0);
                childRen.material.SetColor("_Color", childColor);
                RandomizeScale();

            }




        }

        if (gameObject.tag == "rock")
        {
            Color newerColor = Random.ColorHSV(0.5f, 0.9f, 0.1f, 0.8f, 0.1f, 0.5f);
            rend = GetComponent<Renderer>();
            rend.material.SetFloat("_Glossiness", 0);
            rend.material.SetColor("_Color", newerColor);
            RandomizeScale();
        }
        if (gameObject.tag == "stump")
        {
            Color newerColor = Random.ColorHSV( 0.7f, 0.9f, 0.1f, 0.5f, 0.1f, 0.4f);
            rend = GetComponent<Renderer>();
            rend.material.SetFloat("_Glossiness", 0);
            rend.material.SetColor("_Color", newerColor);
            RandomizeScale();
        }
        
    }

    void RandomizeScale()
    {
        Vector3 randomizedScale = Vector3.one;
        if (scaleUniform)
        {
            float uniformScale = Random.Range(uniScaleMin, uniScaleMax);
            randomizedScale = new Vector3(uniformScale, uniformScale, uniformScale);
        }
        else
        {
            randomizedScale = new Vector3(Random.Range(xScaleMin, xScaleMax), Random.Range(yScaleMin, yScaleMax), Random.Range(zScaleMin, zScaleMax));
        }

        transform.localScale = randomizedScale;
    }

}
