using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;

public class cameraZoomController : MonoBehaviour
    //lerp used to change between the camera position and the alpha value of the text box, the mathf.damp method is used to gradually change the zoom/size of the camera. 

{
    public float fadeSpeed; //how quickly the TextBox alpha value is able to fade in or out
    private bool fadeOut, fadeIn; //these variables are used to show when the camera has zoomed passed a certain point, and therefore what state to be in and what code to run - again relates to the opacity of the textbox. 
    private Vector3 des; //both of these vectors are used in the lerp, which is to gradually move an object between two known vectors. 
    private Vector3 start;
    private float fraction = 0; //this is the value used to interpolate between the two vectors. 
    public float lerpSpeed = 0.01f; //this is multiplied with time to work out the fraction to be used in the lerp function. 
    public CanvasGroup CanvasAlpha; //gets the canvas of the text information box for the atom. 
    public bool FadeOutRunning, FadeInRunning; //variables more so for testing to see in the inspector. 
    private Camera cam; //allows us to put whatever cam we want as this variable - Secondary camera in this case. 
    private float targetZoom; // this is the original size value / zoom of the camera which is changed throughout the script. 
    public float zoomFactor; //how much we want to increase or decrease the zoom of the camera by multiplying this with how the scroll wheel is used. 
    private float yVelocity; //used in the mathf.damp function - with this value being modified by the function every time it is called
    [SerializeField] private float zoomLerpSpeed = 10; //serialize field saves the state of an object in order to be able to recreate it when needed. public variables automatically do this in unity. 

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("SecondaryCamera").GetComponent<Camera>(); //finds the secondary camera, adds it to the cam variable and gets the objects camera component. 
        targetZoom = cam.orthographicSize; //finds the size of the camera and therefore its zoom 
     

    }

    void ZoomOutReallyFar() //nearly the same code as other subs. basically moves the camera back to the centre position when zoomed out very far. when mid range, the camera is slightly to the left, and when zoomed in centred again 
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

    void ZoomOutTooFar() //this run when you zoom out far enough so the text box has to be faded back in. 
    {
        start = cam.transform.position;
        des = new Vector3(815.3f, -4.5f, 0.691836f); //slight difference in x axis position 

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
      
            StartCoroutine(FadeInCR()); //runs co routine to fade in 
            FadeInRunning = true;

            if (FadeOutRunning == true) //makes sure if the fade out co routine is running it should be stopped in order to allow the fade in to run. co routine can run at the same time, so we must check to stop them before running any others to prevent confusion
            {
                StopCoroutine(FadeOutCR()); //stops fade out co routine. 
                FadeOutRunning = false;
            }

        }

        fadeIn = false;

    }

    public void ZoomInTooFar() //zoomed in too far, so the text box must gradually fade out 
    {
        start = cam.transform.position; //gets the starting position of the cam
        des = new Vector3(815, -4.5f, 0.691836f); //this is the new destination we want the cam to go to

        if (fraction < 1) //when the fraction is less than 1 (aka the lerp has not finished moving to its final position 
        {
            fraction += Time.deltaTime * lerpSpeed; //updates the value fraction based on the time taken and the lerp speed 

            cam.transform.position = Vector3.Lerp(start, des, fraction); //moves the cameras position using the lerp function on its pos vector, using the starting position, the destination and the fraction. 
        }

        if (fraction >= 1) //this is hear as https://answers.unity.com/questions/265439/vector3lerp-only-working-once.html 
            //if the fraction becomes more than 1, then the lerp is finished and wont run (as 0 means it needs to start, 1 is finished). this means if we get here and the lerp code has already been run, then it wont run without this code here turning the fraction back to 0 
        {
            fraction = 0;
        }

        if (fadeOut == true) //if this is true then we want to fade out the textbox. 
        {

            StartCoroutine(FadeOutCR()); //calls the fade out co routine. this is the function that does the gradual fading out 
            FadeOutRunning = true;

            if (FadeInRunning == true) //if the fadein co routine is running it needs to be stopped in order for the fade out to occur
            {                              
                StopCoroutine(FadeInCR()); //stops the co routine.
                FadeInRunning = false;
            }
        }

        fadeOut = false; //fade out becomes false again so it doesnt enter the loop again whilst still faded out

    }

    // Update is called once per frame
    void Update()

    {

        float size = cam.orthographicSize; //this gets the size of thew ortho cam again

        if (size * 2  < 0.46f && fadeIn == false) //if the size of the camera doubled is less than 0.46 and fadein is not running (meaning the box is fully faded back in)
        {
          
            fadeOut = true; //fade out becomes true 
            ZoomInTooFar(); //zoom in too far is called
     
        }

        if (size * 2 > 0.46f && fadeOut == false || size * 2 < 0.69 && fadeOut == true) //if camera size * 2 is more than 0.46 and fade out is false or the size * 2 is more than 0.69 and fade out = true then 
        {
           
            fadeIn = true; //fade in becomes true 
            ZoomOutTooFar(); //runs this sub. //the zoom subs all change the position of the camera using a lerp, and use a co routine in order to change the alpha value of the canvas to clear or not in order to get the best view or information. 

        }

        if (size * 2 > 0.70f && fadeIn == false) //if the size of the camera * 2 > 0.7 and the box is not faded in 
        {
           
            fadeOut = true; //fade out = true 
            ZoomOutReallyFar();

        }

        float scrollData;

        scrollData = Input.GetAxis("Mouse ScrollWheel"); //gets the float value from the scroll wheel. 
        targetZoom = targetZoom - scrollData * zoomFactor; //changes the target zoom value by taking away the scroll data which has been multiplied by the zoom factor. target zoom is just the value of the ortho cam's size

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)) //if the user presses the down or the user presses the up arrow 
        {

            float DownArrowData = Input.GetAxis("Vertical"); //get the data from the key press so we know how far to move the object. 
            targetZoom = targetZoom - DownArrowData * zoomFactor; //changes the zoom of the camera based on the down arrow data being multiplied by the zoom factor. the larger the zoom factor, the quicker the zoom.

        }

        targetZoom = Mathf.Clamp(targetZoom, 0.13f, 0.70f); //returns the minimum value if the given float value is less than the minimum. returns the maximum value if the given value is greater than the max value.

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref yVelocity, Time.deltaTime * zoomLerpSpeed); //this method gradually changes a value towards a desired goal over time. 
        //velocity parameter is used in order to know how fast you are going in order for the function to either accelerate or decelerate. the function tries to accelerate your position towards target if it is far away, and decelerate it if it is getting close.
        //every time the function gets called, the latest velocity value is updated into the ref parameter and then the function also returns a value. 
    }

    private IEnumerator FadeOutCR() //this is a co routine. a coroutine is a function that can suspend its execution until the given yieldinstruction is given 
        //this just gradually decreases the object colour until it becomes zero. 
    {
        //DONT DO STOP ALL COROUTINES ON EITHER CO ROUTINE LOGIC BECOMES A MESS
       
        fadeSpeed = 4f; //this variable is the fade speed for fading out. 

        float objectColor = CanvasAlpha.alpha; //this gets the alpha value for the colour of the text box to be faded. alpha value controls the opacity of an objects material. 
        if (objectColor > 0) //if the alpha value is above 0 (so is still viewable and not clear)
        {
            float fadeAmount = objectColor - (fadeSpeed * Time.deltaTime); //this codes gradually fades the object colour. gradually changes the alpha of the canvas by taking away the fade speed * time from the object colour. this becomes the new alpha value. 

            objectColor = fadeAmount;
            CanvasAlpha.alpha = objectColor; 

            //Debug.Log("alpha value of faded text " + text.color.a);
            //Debug.Log("Still running out");

            yield return null; // WaitForSeconds(1f); //once 0 is returned then the code stops. 
        }
        yield break;    //yield break statements are like a return statements which dont return a value. once a loop has completed all its cycles
    }

    private IEnumerator FadeInCR() //use a different method to fade in the box. this utilises the lerp function, which i found much easier to use. 
    {
        

        float duration = 0.3f; //these two values are used to work out the value used to interpolate between a and b
        float currentTime = 0.1f;
        while (currentTime < duration) //while the current time value is smaller than the duration. 
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration); //gradually decrease the alpha value from 0 to 1 (aka invisible to visible). rather than it being instant, the current time/duration allows the lerp to be over a set time period duration. 
            CanvasAlpha.alpha = alpha; //sets the new alpha value for the canvas.
            currentTime += Time.deltaTime;

            //Debug.Log("Still running in");
            yield return null; // WaitForSeconds(1f);
        }
        yield break;
    }

}
