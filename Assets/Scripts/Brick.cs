using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crackSound;
    public Sprite[] hitSprites;
    public static int brickCount = 0;

    private LevelManager levelManager;
    private int timesHit;
    private int maxHits;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            brickCount += 1;
        }


        timesHit = 0;
        maxHits = hitSprites.Length + 1;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
       

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crackSound, transform.position);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable)
        {
            timesHit += 1;
            if (timesHit >= maxHits)
            {
                brickCount -= 1;
                levelManager.BrickDestroyed();
                Destroy(gameObject);
            }
            else
            {
                LoadSprites();
            }
            //SimulateWin();
        }

    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO Remove this method once we can actually win.
    void SimulateWin()
    {
        levelManager.loadNextLevel();       
    }

}
