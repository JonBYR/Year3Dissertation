using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.CodeDom;
using System.Dynamic;

public class Films
{
    public string[] shots; //these arrays will be filled with the corresponding arrays in the json file
    public string[] shotPaths;
    public string genre;
}
public class ImageLoader : MonoBehaviour
{
    
    public Image image;
    public TMP_Text toggleText;
    private bool toggle = false;
    public TMP_Text shotText;
    public TMP_Text genreText;
    public TextAsset jsonFile;
    public TMP_Text errorText;
    public TMP_Text stillText;
    public GameObject panel;
    Sprite filmSprite;
    int index;
    int maxLength;
    Films film;
    private Vector3 startPos;
    private float view;
    public GameObject actor;
    private Vector3 actorPosition;
    private Quaternion actorRotation;
    List<GameObject> secondaryActors;
    public CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        secondaryActors = new List<GameObject>();
        startPos = Camera.main.transform.position;
        view = Camera.main.fieldOfView;
        actorPosition = actor.transform.position;
        actorRotation = actor.transform.rotation;
        //json tutorial from here https://forum.unity.com/threads/how-to-read-json-file.401306/
        film = JsonUtility.FromJson<Films>(jsonFile.text); //parse the json file into the film object
        genreText.text = (char.ToUpper(film.genre[0]) + film.genre.Substring(1).ToLower()); //Display the film genre
        shotText.text = film.shots[0]; //gets first shot from the json file
        stillText.text = (index + 1).ToString();
        filmSprite = Resources.Load<Sprite>(film.shotPaths[0]); //loads the file path of the shot
        image.sprite = filmSprite;
        index = 0;
        maxLength = film.shotPaths.Length;
        errorText.enabled = false;
        shotLoader();
    }
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            Forward();
        }
        else if (Input.GetKeyDown("left")) Back();
        if (Input.GetKeyDown(KeyCode.I)) ToggleInfo(); //If I is pressed shotText object is displayed/undisplayed
        
        if (shotText.text == "Full") toggleText.text = "A full shot is where you want a whole subjects body in frame";
        else if (shotText.text == "Medium Full") toggleText.text = "A medium full shot contains a subject from head to around knee height";
        else if (shotText.text == "Medium") toggleText.text = "A medium shot films a subject from torso up to head";
        else if (shotText.text == "Medium Close Up") toggleText.text = "A medium close up shot films a subject from shoulder length to their head";
        else if (shotText.text == "Close Up") toggleText.text = "A close up shot would film a subjects face or a specific part of the body";
        else if (shotText.text == "Extreme Close Up") toggleText.text = "An extreme close up shot would film a very specific area of the body, such as the eyes";
        else if (shotText.text == "Establishing") toggleText.text = "An establishing shot would establish the location of the scene";
        else if (shotText.text == "Master") toggleText.text = "A master shot would clarify what characters are in the scene and where they are in relation to each other";
        else if (shotText.text == "Wide") toggleText.text = "A wide shot positions characters far from the camera to represent their relationship to the enviornment";
        else if (shotText.text == "Insert") toggleText.text = "An insert shot films a specific object";
    }
    public void Forward()
    {
        index++;
        if (index >= maxLength)
        {
            index = maxLength - 1; //ensure that we do not exceed the size of the array
            shotText.text = film.shots[maxLength - 1];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[maxLength - 1]);
            errorText.enabled = true;
            errorText.text = "Final previs shot reached!";
        }
        else
        {
            shotText.text = film.shots[index];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[index]); //loads the required image based on the value of index
            image.sprite = filmSprite;
            errorText.enabled = false;
            errorText.text = "";
        }
        shotLoader(); //Load the next shot based on the value of index
    }
    public void Back()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            shotText.text = film.shots[0]; //ensures we do not go into the negatives with index
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[0]);
            errorText.enabled = true;
            errorText.text = "First previs shot reached!";
        }
        else
        {
            shotText.text = film.shots[index];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[index]);
            image.sprite = filmSprite;
            errorText.enabled = false;
            errorText.text = "";
        }
        shotLoader();
    }
    void Reset()
    {
        Debug.Log("And this is called");
        cam.cameraPos = startPos;
        Camera.main.fieldOfView = view;
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
        actor.transform.position = actorPosition;
        actor.transform.rotation = actorRotation;
        foreach(GameObject act in secondaryActors)
        {
            Destroy(act);
        }
    }
    void shotLoader()
    {
        Debug.Log(startPos);
        Reset();
        if(shotText.text == "Full")
        {
            cam.cameraPos = new Vector3(0, 4.3000004f, -10);
        }
        else if(shotText.text == "Medium Close Up")
        {
            Camera.main.fieldOfView = 33f;
            cam.cameraPos = new Vector3(1.27f, 9.03f, -10);
        }
        else if(shotText.text == "Medium")
        {
            Camera.main.fieldOfView = 33f;
            cam.cameraPos = new Vector3(0.19f, 7.5f, -10);
        }
        else if(shotText.text == "Medium Full")
        {
            Camera.main.fieldOfView = 33f; //change camera view to match with the shot type
            cam.cameraPos = new Vector3(0.2f, 6.05f, -10);
        }
        else if(shotText.text == "Close Up")
        {
            Camera.main.fieldOfView = 15f;
            cam.cameraPos = new Vector3(0.2f, 8.91f, -10);
        }
        else if(shotText.text == "Extreme Close Up")
        {
            Camera.main.fieldOfView = 2f;
            cam.cameraPos = new Vector3(0.2f, 8.61f, -10);
        }
        else if(shotText.text == "Establishing")
        {
            Camera.main.fieldOfView = 160f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Master")
        {
            Camera.main.fieldOfView = 130f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Wide")
        {
            actor.transform.position = new Vector3(-10, 0, 0);
            actor.transform.rotation = Quaternion.Euler(0, 90, 0);
            GameObject newActor = Instantiate(actor, new Vector3(20, 0, 0), Quaternion.Euler(0, -90, 0));
            secondaryActors.Add(newActor);
            Camera.main.fieldOfView = 110f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Insert")
        {
            cam.cameraPos = new Vector3(3.84f, 0.22f, -10);
            Camera.main.fieldOfView = 7f;
        }
    }
    public void ToggleInfo()
    {
        toggle = !toggle;
        if (toggle == true)
        {
            panel.gameObject.SetActive(true);
            toggleText.gameObject.SetActive(true);
        }
        else if (toggle == false) 
        { 
            toggleText.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
        }
    }
}
