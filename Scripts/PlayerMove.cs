using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;

    public int speed;
    public int health;
    public int BasicKills;
    public Animator anim;
    public Image health1;
    public Image health2;
    public Image health3;
    public Image theKeyItself;
    public float vert;
    public float horz;
    private bool BattingStance;
    public FightFromDist FightScript;
    public bool gotKey;
    //public GameObject Heart;
    //public GameObject AttackCollision;

   

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //m_SpriteRenderer.color = Color.blue;
        health = 3;
        health1.enabled = true;
        health2.enabled = true;
        health3.enabled = true;
        theKeyItself.enabled = false;
        BattingStance = false;
        gotKey = false;
        //AttackCollision.SetActive(false);
        //StartCoroutine("Fight");
    }

    //private bool faceR = true;


    void Update () {
    	//using Raw allows movement to be more 1:1, and not floaty/sliding,
    	//goes from 0 to 1 instead of building up to 1 through acceleration
        vert = Input.GetAxisRaw ("Vertical")*speed;
        horz = Input.GetAxisRaw ("Horizontal")*speed;

        vert *= Time.deltaTime;
        horz *= Time.deltaTime;

        transform.Translate(horz, vert, 0);

        GoodLookingOut();
        LoseToston();


       //  if (faceR == false && horz > 0){
       //  	Flip();
       //  }
       // else if (faceR == true && horz < 0)
       // {
       //     Flip();
       // }

        if(BattingStance == true)
        {
            FinallyBatting();
        }

        if (gotKey == true)
        {
            theKeyItself.enabled = true;
        }
    }

    void GoodLookingOut()
    {
        if (Input.GetKeyDown("up"))
        {
            anim.SetBool("LookUp", true);
            anim.SetBool("LookRight", false);
            anim.SetBool("LookDown", false);
            anim.SetBool("LookLeft", false);
        }
        if (Input.GetKeyDown("left"))
        {
            anim.SetBool("LookUp", false);
            anim.SetBool("LookLeft", true);
            anim.SetBool("LookDown", false);
            anim.SetBool("LookRight", false);
        }
        if (Input.GetKeyDown("right"))
        {
            anim.SetBool("LookUp", false);
            anim.SetBool("LookLeft", false);
            anim.SetBool("LookDown", false);
            anim.SetBool("LookRight", true);
        }
        if (Input.GetKeyDown("down"))
        {
            anim.SetBool("LookUp", false);
            anim.SetBool("LookLeft", false);
            anim.SetBool("LookDown", true);
            anim.SetBool("LookRight", false);
        }
    }

    public void BatterUp()
    {
        anim.SetBool("BatRight", true);
        BattingStance = true;
        FightScript.SmackEm = true;
    }

    void LoseToston()
    {
        if (health == 2)
        {
            health1.enabled = false;
        }
        if (health == 1)
        {
            health2.enabled = false;
        }
        if (health == 0)
        {
            health3.enabled = false;
        }
        if (health == 3)
        {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = true;
        }

    }

    void FinallyBatting()
    {
        if (Input.GetKeyDown("up"))
        {
            anim.SetBool("BatUp", true);
            anim.SetBool("BatRight", false);
            anim.SetBool("BatDown", false);
            anim.SetBool("BatLeft", false);
            anim.SetBool("RightAttack", false);
        }
        if (Input.GetKeyDown("left"))
        {
            anim.SetBool("BatUp", false);
            anim.SetBool("BatLeft", true);
            anim.SetBool("BatDown", false);
            anim.SetBool("BatRight", false);
            anim.SetBool("RightAttack", false);
        }
        if (Input.GetKeyDown("right"))
        {
            anim.SetBool("BatUp", false);
            anim.SetBool("BatLeft", false);
            anim.SetBool("BatDown", false);
            anim.SetBool("BatRight", true);
            anim.SetBool("RightAttack", false);
        }
        if (Input.GetKeyDown("down"))
        {
            anim.SetBool("BatUp", false);
            anim.SetBool("BatLeft", false);
            anim.SetBool("BatDown", true);
            anim.SetBool("BatRight", false);
            anim.SetBool("RightAttack", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
        //     IEnumerator Fight()
        // {
        //     anim.SetBool("RightAttack", true);
        //     yield return new WaitForSeconds(5);
        //     anim.SetBool("goBack", true);
        // }
            anim.SetBool("goBack", false);
            StartCoroutine("Fight");
            //anim.SetBool("RightAttack", true);
            //anim.SetBool("goBack", true);

            anim.SetBool("BatUp", false);
            anim.SetBool("BatRight", false);
            anim.SetBool("BatDown", false);
            anim.SetBool("BatLeft", false);
        }
    }

        IEnumerator Fight()
        {
            anim.SetBool("RightAttack", true);
            //AttackCollision.SetActive(true);
            yield return new WaitForSeconds(.3f);
            anim.SetBool("RightAttack", false);
            //AttackCollision.SetActive(false);
            anim.SetBool("goBack", true);
        }

    // }

 




    // void Flip()
    // {
    //    faceR = !faceR;
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;
    // }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (Input.GetButtonDown("Jump"))
    //     {
    //         if (other.gameObject.tag == "BasicEnemy")
    //         {
    //             Destroy(other.gameObject);
    //             BasicKills += 1;
    //         }
    //         //Destroy(other.gameObject);
    //         //other.gameObject.transform.Translate(0,8,0);
    //         //transform.Translate(0,-8,0);
    //         // if (Input.GetButtonDown("Jump")){
    //         //     Destroy(other.gameObject);
    //         //     BasicKills += 1;
    //         // }
    //         else
    //         {
    //             other.gameObject.transform.Translate(0,8,0);
    //             health -= 1;
    //         }

    //     }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BasicEnemy")
        {
            other.gameObject.transform.Translate(0,8,0);
            health -= 1;
        }
        if (other.gameObject.tag == "Heart"){
            health = 3;
            Destroy(other.gameObject);
            FightScript.BasicKills = 0;
        }
        if (other.gameObject.tag == "Key"){
            ;
            Destroy(other.gameObject);
            FightScript.BasicKills = 0;
            gotKey = true;
        }
    }
}

