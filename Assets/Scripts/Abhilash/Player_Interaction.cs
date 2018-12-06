using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interaction : GunSelection_Controller
{

    AudioSource m_GunSound;
    // Stores the audio for the gun shot.
    GunSelection_Controller m_Test;
    // Instance of the class gun selection.
    public Sprite m_MySprite1;
    public Sprite m_MySprite2;
    public Sprite m_MySprite3;
    // Holds the three different gun png's.
    private SpriteRenderer m_SpriteRenderer;
    // Holds the required gun png sprite.
    private int m_Gun = 1;
    public static int numBullets = 0;
    public string stringToEdit = "";
    // Choice of gun.

    // Use this for initialization.
    void Start()
    {
        Debug.Log("Begin");
        m_GunSound = GetComponent<AudioSource>();
        m_Test = GetComponent<GunSelection_Controller>();
        this.m_Gun = m_Test.m_GetGunNumber();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;

        // Test gun selection.
        Debug.Log("Gun: " + this.m_Gun);

        if (this.m_Gun == 1)
        {
            m_SpriteRenderer.sprite = m_MySprite1;
            this.m_SpriteRenderer.transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
            numBullets = 30;
        } else if(this.m_Gun == 2)
        {
            m_SpriteRenderer.sprite = m_MySprite2;
            this.m_SpriteRenderer.transform.localScale += new Vector3(0.03f, 0.03f, 0f);
            numBullets = 45;
        } else if(this.m_Gun == 3)
        {
            m_SpriteRenderer.sprite = m_MySprite3;
            this.m_SpriteRenderer.transform.localScale += new Vector3(0.04f, 0.04f, 0f);
            numBullets = 60;
        }
        else
        {
            m_SpriteRenderer.sprite = m_MySprite3;
            this.m_SpriteRenderer.transform.localScale += new Vector3(0.9f, 0.9f, 0f);
            numBullets = 500;
        }

        /*
        Vector2 point = new Vector2();
        point = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log("World: " + point.ToString());*/
        // The commented code is for Chiru's reference.

    }

    // Update is called once per frame.
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;
        transform.position = newPos;

        // Testing mouse position to scope position.
        // Debug.Log(newPos);
        if (Input.GetMouseButtonDown(0) == true)
        {
            numBullets--;
            m_GunSound.Play();
            this.m_SpriteRenderer.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
            // Should figure out a way to put some delay here.
            StartCoroutine(ExecuteAfterTime(0.05f));
            // The delay should merely pass time by doing something else, but not pause the processing.
            //this.m_SpriteRenderer.transform.localScale -= new Vector3(0.1f, 0.1f, 0f);

            if(numBullets == 0)
            {
                Cursor.visible = true;
                SceneManager.LoadScene("Defeat Menu");
            }
        }
    }

    void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        fontStyle.fontSize = 24;

        stringToEdit = GUI.TextField(new Rect(250, 20, 200, 50), "Bullets Left: " + numBullets.ToString(), fontStyle);

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        this.m_SpriteRenderer.transform.localScale += new Vector3(0.05f, 0.05f, 0f);
    }

}
