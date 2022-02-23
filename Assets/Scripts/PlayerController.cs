using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//using PixelCrushers.DialogueSystem;

[RequireComponent(typeof(MoveableCharacter))]
public class PlayerController : MonoBehaviour
{
    // public static Player instance = null;
    Vector2 movement;
    public float moveSpeed = 5f;

    Vector3 originMeleeAttackPosition;
    bool firstClear = true;
    bool spawned = false;

    MoveableCharacter moveable;

    //public AnimatorOverrideController animatorController;

    // private void Awake()
    //{
    //if (instance == null)

    //    //if not, set instance to this
    //    instance = this;

    ////If instance already exists and it's not this:
    //else if (instance != this)
    //{
    //    instance.gameObject.transform.position = transform.position;
    //    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
    //    Destroy(gameObject);
    //}


    ////Sets this to not be destroyed when reloading scene
    //DontDestroyOnLoad(gameObject);
    //}
    // Start is called before the first frame update
    private void Awake()
    {
        moveable = GetComponent<MoveableCharacter>();
    }
    protected void Start()
    {

        //animator = transform.Find("Sprites").GetComponent<Animator>();
        //spriteObject = animator.gameObject;
    }

    //public void Damage(int dam = 1)
    //{

    //    GameOver();
    //}

    //void GameOver()
    //{
    //    if (GameManager.instance.dontDie)
    //    {
    //        return;
    //    }
    //    SoundManager.instance.playBGM(gameoverClip);
    //    GameManager.instance.GameOver();


    //}

    //public void pause()
    //{
    //    GameManager.instance.isPaused = true;
    //}
    //public void resume()
    //{
    //    GameManager.instance.isPaused = false;
    //}
    // Update is called once per frame
    protected void Update()
    {
        if (moveable.isDead)
        {
            return;
        }
        //if (GameManager.instance.isCheatOn && Input.GetKeyDown(KeyCode.M))
        //{
        //    GameOver();
        //    return;
        //}
        //if (GameManager.instance.isPaused)
        //{
        //    moveSpeed = 0;
        //    movement = Vector2.zero;
        //    return;
        //}


        movement.x = Input.GetAxisRaw("Horizontal");

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        movement.y = Input.GetAxisRaw("Vertical");
        float speed = movement.sqrMagnitude;
        movement = Vector2.ClampMagnitude(movement, 1);
        // animator.SetFloat("speed", movement.sqrMagnitude);




        // transform

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    getDamage(1000);
        //}

    }


    private void LateUpdate()
    {
        if (moveable.isDead)
        {
            return;
        }
        moveable.rb.MovePosition(moveable.rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        moveable.testFlip(movement);
        // rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "coat" && !isCamouflage)
    //    {
    //        isCamouflage = true;
    //        Destroy(collision.gameObject);
    //        GetComponent<SpriteRenderer>().sprite = camouflagedSprite;
    //        animator.runtimeAnimatorController = camouflagedAnimator;
    //        isCamouflage = true;
    //        exit.SetActive(true);
    //        DialogueManager.ShowAlert("You are camouflaged");
    //    }
    //}
    protected void Die()
    {
        if (moveable.isDead)
        {
            return;
        }
        moveable.isDead = true;
        //animator.SetTrigger("die");

        Invoke("gameover", 1);
    }
    void gameover()
    {
        //GameOver.Instance.Gameover();
    }
}