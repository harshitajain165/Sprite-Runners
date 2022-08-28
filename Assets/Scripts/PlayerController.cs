using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // public List<GameObject> players;

    [SerializeField]private Rigidbody playerRb;
    [SerializeField]private AudioSource playerAudio;
    [SerializeField]private Animator playerAnim;
    
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float score = 0;
    public TMP_Text ScoreTxt;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public GameObject GameOverMenu;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    // Start is called before the first frame update
    void Start()
    {
        //SetPlayerActive(CharacterManager.instance.selectedOption);
        Debug.Log(CharacterManager.instance.selectedOption);

        int playerNum = CharacterManager.instance.selectedOption;

        playerRb = GetComponent<Rigidbody>();
        //playerRb = GetComponent<Rigidbody>();
        
        playerAnim = gameObject.transform.GetChild(playerNum).GetComponent<Animator>();
        //playerAnim = GetComponent<Animator>();

        playerAudio = gameObject.transform.GetChild(playerNum).GetComponent<AudioSource>();
        //playerAudio = GetComponent<AudioSource>();

        if(playerAnim == null)
            Debug.Log("Animator not found");

        // playerAudio = GetComponentInChildren<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
             playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             isOnGround = false;
             playerAnim.SetTrigger("Jump_trig");
             dirtParticle.Stop();
             playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (isOnGround && gameOver == false){
        score += Time.deltaTime * 2;
        ScoreTxt.text = "" + score.ToString("F");
    }   
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            GameOverMenu.gameObject.SetActive(true);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

        // else if(collision.gameObject.CompareTag("Reward")){
        //     PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

        //  if(playerInventory != null){
        // playerInventory.RewardCollected();
        // gameObject.SetActive(false);
        // }

        // }
    }

    // private void OnCollisionEnter(Collision collision){
    //     PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

    //      if(playerInventory != null){
    //     playerInventory.RewardCollected();
    //     gameObject.SetActive(false);
    // }
    
    // }

}
