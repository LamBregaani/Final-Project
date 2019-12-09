using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScriptHardcore : MonoBehaviour
{

    public float speed;

    public Text score;

    public Text lifeText;

    public Text winLoseText;

    public Text totalPointsText;

    public Text totalPointsText2;

    public Text point;

    public AudioClip musicClipBack;

    public AudioClip musicClipWin;

    public AudioClip musicClipJump;

    public AudioSource musicSource;

    public AudioSource jumpSource;

    public AudioSource coinSource;

    public AudioClip musicClipCoin;



    private Rigidbody2D rd2d;

    private int totalCoins;

    private int totalCoinsScore;

    private int totalKills;

    private int totalKillsScore;

    private int totalLivesScore;

    private int totalPoints;

    private int scoreValue = 0;

    private int lives = 1;

    private int points;

    private int level = 1;

    private int winState = 0;

    private bool facingRight = true;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        totalKills = 0;
        points = 0;
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Coins:" + scoreValue.ToString() + "/4";
        lifeText.text = "Lives: " + lives.ToString() + "/1";
        anim = GetComponent<Animator>();
        musicSource.clip = musicClipBack;
        musicSource.Play();
        winLoseText.text = "";
        totalPointsText.text = "";
        totalPointsText2.text = "";
    }


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()

    {


        lifeText.text = "Lives: " + lives.ToString() + "/1";
        score.text = "Coins:" + scoreValue.ToString() + "/4";
        point.text = points.ToString();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(moveHorizontal * speed, vertMovement * speed));

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

        if (lives == 0)
        {
            winLoseText.text = "YOU DIED\nPress 'R' to try again\n Press 'ESCAPE' to quit";
            Destroy(gameObject);
        }



        if (level == 1)
        {
            if (scoreValue == 4)
            {
                winState = 1;
                musicSource.Stop();
                musicSource.clip = musicClipWin;
                musicSource.Play();

            }

            if (winState == 1)
            {

                scoreValue = 0;



                winLoseText.text = "Level 1 complete press 'ENTER' to go to level 2!";
                if ((Input.GetKey("return")))

                {
                    lives = 1;
                    winState = 0;
                    musicSource.clip = musicClipBack;
                    musicSource.Play();
                    transform.position = new Vector2(-100f, -2.5f);
                    level = 2;
                    winLoseText.text = "";
                }
            }
        }
        if (level == 2)
        {
            if (scoreValue == 4)
            {
                winState = 1;

                musicSource.Stop();

                musicSource.clip = musicClipWin;

                musicSource.Play();
            }

            if (winState == 1)
            {
                totalCoinsScore = totalCoins * 100;
                totalKillsScore = totalKills * 10;
                totalLivesScore = lives * 50;
                totalPoints = totalCoinsScore + totalKillsScore + totalLivesScore + 1000;
                scoreValue = 0;
                totalPointsText2.text = "Coins: " + totalCoins.ToString() + "\nKills: " + totalKills.ToString() + "\nDifficulty: Hardcore" + "\nLives Bonus: " + lives.ToString();
                totalPointsText.text = "Total: " + totalCoinsScore.ToString() + "\nTotal: " + totalKillsScore.ToString() + "\nTotal: 1000\n" + "Total: " + totalLivesScore.ToString();
                winLoseText.text = " Total Score: " + totalPoints.ToString() + "\nYou have won the game!\nPress 'R' to play again\nCreated by Randall Forehand";
            }
        }
    }





    void OnCollisionEnter2D(Collision2D collision)
    {

        {

            if (collision.collider.tag == "Enemy")
            {
                Destroy(collision.collider.gameObject);
                lives = lives - 1;
                lifeText.text = "Lives: " + lives.ToString() + "/1";
            }
            if (collision.collider.tag == "Spikes")
            {
                lives = lives - 1;
                lifeText.text = "Lives: " + lives.ToString() + "/1";
            }
        }




    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coinSource.clip = musicClipCoin;
            coinSource.Play();
            totalCoins += 1;
            scoreValue += 1;
            score.text = "Coins:" + scoreValue.ToString() + "/4";
            points += 100;
            point.text = points.ToString();
            Destroy(other.gameObject);
        }
        if (other.tag == "EnemyTop")
        {
            coinSource.clip = musicClipCoin;
            coinSource.Play();
            totalKills += 1;
            lives = lives + 1;
            lifeText.text = "Lives: " + lives.ToString() + "/1";
            points += 10;
            point.text = points.ToString();
            Destroy(other.gameObject);
        }



    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GroundCheck();
        }
        if (collision.collider.tag == "Spikes")
        {
            GroundCheck();
        }

    }

    void GroundCheck()
    {
        {
            anim.SetBool("Jump", false);

            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                jumpSource.clip = musicClipJump;
                jumpSource.Play();

            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                jumpSource.clip = musicClipJump;
                jumpSource.Play();
            }
        }
    }
}

