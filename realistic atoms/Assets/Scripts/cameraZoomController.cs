using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;

public class cameraZoomController : MonoBehaviour


{
    public float fadeSpeed;
    private bool fadeOut, fadeIn;
    private Vector3 des;
    private Vector3 start;
    private float fraction = 0;
    public float lerpSpeed = 0.01f;
    public CanvasGroup CanvasAlpha;
    public bool FadeOutRunning, FadeInRunning;

    //public GameObject TextObject;
    //TextObject = GameObject.Find("Element Information");

    private Camera cam;
    private float targetZoom;
    public float zoomFactor = 2;
    private float yVelocity = 0.0f;
    [SerializeField] private float zoomLerpSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("SecondaryCamera").GetComponent<Camera>();
        targetZoom = cam.orthographicSize;
        targetZoom = targetZoom + 0.000001f;

    }

    void ZoomOutReallyFar()
    {
        start = cam.transform.position;
        des = new Vector3(815f, -4.5f, 0.691836f);
        fadeIn = false;

        if (fraction < 1)
        {
            fraction += Time.deltaTime * lerpSpeed;

            cam.transform.position = Vector3.Lerp(start, des, fraction);
        }

        if (fraction >= 1)
        {
            fraction = 0;
        }

        if (fadeOut == true)
        {


            StartCoroutine(FadeOutCR());
            FadeOutRunning = true;

            if (FadeInRunning == true)
            {
                StopCoroutine(FadeInCR());
                FadeInRunning = false;
            }
        }

    }

    //void ZoomInReallyFar()
    //{
    //    start = cam.transform.position;
    //    des = new Vector3(815f, -4.5f, 0.691836f);
    //    fadeIn = false;

    //    if (fraction < 1)
    //    {
    //        fraction += Time.deltaTime * lerpSpeed;

    //        cam.transform.position = Vector3.Lerp(start, des, fraction);
    //    }

    //    if (fraction >= 1)
    //    {
    //        fraction = 0;
    //    }

    //    if (fadeOut == true)
    //    {


    //        StartCoroutine(FadeInCR());
    //        FadeInRunning = true;

    //        if (FadeInRunning == true)
    //        {
    //            StopCoroutine(FadeOutCR());
    //            FadeOutRunning = false;
    //        }
    //    }

    //}



    void ZoomOutTooFar()
    {
        start = cam.transform.position;
        des = new Vector3(815.3f, -4.5f, 0.691836f);

        if (fraction < 1)
        {
            fraction += Time.deltaTime * lerpSpeed;

            cam.transform.position = Vector3.Lerp(start, des, fraction);
        }

        if (fraction >= 1)
        {
            fraction = 0;
        }

        if (fadeIn == true)
        {
           
                       

            

            StartCoroutine(FadeInCR());
            FadeInRunning = true;

            if (FadeOutRunning == true)
            {
                StopCoroutine(FadeOutCR());
                FadeOutRunning = false;
            }



        }

        fadeIn = false;

        //if (fadeIn == true)
        //{
        //    Debug.Log("Trying to fadein");

        //    //Color objectColor = this.GetComponent<Renderer>().material.color;
        //    Color objectColor = text.color;

        //    Debug.Log(objectColor + "Object colour");
        //    float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

        //    Debug.Log(objectColor + "Object colour new");
        //    objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        //    text.color = objectColor;

        //    if (objectColor.a <= 1)
        //    {
        //        fadeIn = false;
        //    }
        //}

    }

    public void ZoomInTooFar()
    {
        start = cam.transform.position;
        des = new Vector3(815, -4.5f, 0.691836f);



        if (fraction < 1)
        {
            fraction += Time.deltaTime * lerpSpeed;

            cam.transform.position = Vector3.Lerp(start, des, fraction);
        }

        if (fraction >= 1) //this is hear as https://answers.unity.com/questions/265439/vector3lerp-only-working-once.html
        {
            fraction = 0;
        }

        if (fadeOut == true)
        {
          

            StartCoroutine(FadeOutCR());
            FadeOutRunning = true;

            if (FadeInRunning == true)
            {                              
                StopCoroutine(FadeInCR());
                FadeInRunning = false;
            }
        }

        fadeOut = false; 

        //if (fadeOut == true)
        //{
        //    Debug.Log("Trying to fadeout");

        //    //Color objectColor = this.GetComponent<Renderer>().material.color;

        //    Color objectColor = text.color;



        //    float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
        //    text.color = objectColor;
        //    this.GetComponent<Renderer>().material.color = text.color;


        //    //unity lerp library if this doesnt work.these 3 lines above are the issue
        //    //objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);


        //    //this.GetComponent<Renderer>().material.color = objectColor;

        //    if (objectColor.a <= 0)
        //    {
        //        fadeOut = false;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()

    {

        float size = GameObject.Find("SecondaryCamera").GetComponent<Camera>().orthographicSize;

        if (size * 2  < 0.46f && fadeIn == false)
        {
            //Debug.Log("Enter zoomed in too far");

            //cam.transform.position = new Vector3(815, -4.5f, 0.691836f);
            //want it to fade out here
            fadeOut = true;

            ZoomInTooFar();
            StopCoroutine("ZoomInTooFar");
            //zoom in and out really far
            StopCoroutine("ZoomOutReallyFar");
            //StopCoroutine("ZoomInReallyFar");


        }

        //FOR SOME REASON DEPENDENT ON TIME WHICH IS VERY CONFUSING 
        //NEED TO MAKE IT SO THAT IT CAN ALSO WORK IN REVERSE

        if (size * 2 > 0.46f && fadeOut == false || size * 2 < 0.69 && fadeOut == true)
        {
            //cam.transform.position = new Vector3(815.3f, -4.5f, 0.691836f); //slightly to the right, normal secondary camera just has 815
            //Debug.Log("Zoom out again");
            
            fadeIn = true;

            ZoomOutTooFar();

            StopCoroutine("ZoomOutTooFar");
            StopCoroutine("ZoomOutReallyFar");
            //StopCoroutine("ZoomInReallyFar");

            //zoom in and out really far
        }

        if (size * 2 > 0.70f && fadeIn == false)
        {
            //cam.transform.position = new Vector3(815.3f, -4.5f, 0.691836f); //slightly to the right, normal secondary camera just has 815
            //Debug.Log("Zoom out again");

            fadeOut = true;

            ZoomOutReallyFar();

            StopCoroutine("ZoomOutTooFar");
            StopCoroutine("ZoomInTooFar");
            //zoom in really far 
            //StopCoroutine("ZoomInReallyFar");
        }

        //if (size * 2 < 0.75f && fadeOut == false)
        //{
        //    //cam.transform.position = new Vector3(815.3f, -4.5f, 0.691836f); //slightly to the right, normal secondary camera just has 815
        //    //Debug.Log("Zoom out again");

        //    fadeIn = true;

        //    ZoomInReallyFar();

        //    StopCoroutine("ZoomOutTooFar");
        //    StopCoroutine("ZoomInTooFar");
        //    //zoom out really far
        //    StopCoroutine("ZoomOutReallyFar");
        //}





        float scrollData;

        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom = targetZoom - scrollData * zoomFactor;



        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {

            float DownArrowData = Input.GetAxis("Vertical");

            targetZoom = targetZoom - DownArrowData * zoomFactor;
        }

        targetZoom = Mathf.Clamp(targetZoom, 0.13f, 0.70f);

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref yVelocity, Time.deltaTime * zoomLerpSpeed);

        //TOMORROW WORK ON WORKING OUT A FORMULA FOR ELECTRONS. 




    }
    //TRY TO SNMOOTH OUT THE CO ROUTINES
    private IEnumerator FadeOutCR()
    {
        //DONT DO STOP ALL COROUTINES ON EITHER CO ROUTINE VERY BUGGY
        //float duration = 0.3f; //0.5 secs
        //float currentTime = 0f;
        float fadeSpeed = 4f;

        float objectColor = CanvasAlpha.alpha;
        if (objectColor > 0)
        {
            //float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            //text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            //currentTime += Time.deltaTime;

           // Color objectColor = text.color;
            float fadeAmount = objectColor - (fadeSpeed * Time.deltaTime);

            objectColor = fadeAmount;
            CanvasAlpha.alpha = objectColor;
           //currentTime += Time.deltaTime; 

            //Debug.Log("alpha value of faded text " + text.color.a);
            //Debug.Log("Still running out");

            yield return null; // WaitForSeconds(1f);
        }
        yield break;    
    }

    private IEnumerator FadeInCR()
    {
        

        float duration = 0.3f; //0.5 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            CanvasAlpha.alpha = alpha;
            currentTime += Time.deltaTime;

            //Debug.Log("Still running in");
            yield return null; // WaitForSeconds(1f);
        }
        yield break;
    }

}
