using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

public static int Breakalbe_Count = 0;

public Sprite[] Sprites_hit;

public GameObject Smoke_Effect;

public int Index_sprite;

public int Maximum_Hits;
private int Times_Hit;
private bool isbreakable;
public AudioClip Sound_Crack;

private LevelManager level_Manager;
	// Use this for initialization
	void Start () {
	
	isbreakable = this.tag == "Breakable";
	
	if(isbreakable)
	{
	Breakalbe_Count = Breakalbe_Count + 1;
	//print (Breakalbe_Count);
	}
	level_Manager = GameObject.FindObjectOfType<LevelManager>();
	Times_Hit = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
		
	{	
	AudioSource.PlayClipAtPoint(Sound_Crack, transform.position);
	if(isbreakable)
	{
	handling_hits ();
	}

 	}
 	
 	void handling_hits ()
 	
 	{
		Times_Hit = Times_Hit +1;
		
		//Maximum_Hits = Sprites_hit.Length + 1;  // ==> you can also use this, this makes reducing to simplicity. doesnt need any change in unity interface.
		print(" collision invoked ");
		
		if( Times_Hit >=Maximum_Hits )
		{ 
			Breakalbe_Count = Breakalbe_Count - 1;
			level_Manager.Destroyed_Bricks();
			GameObject Smoke_Show = Instantiate(Smoke_Effect, transform.position, Quaternion.identity) as GameObject;
			
			Smoke_Show.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			
			
			Destroy(gameObject);
		}
		else 
			
		{
			
			LoadSprites();
			
		}		
 	
 	}
 	
void LoadSprites()
{
 
// Index_sprite = Times_Hit - 1 ;

 this.GetComponent<SpriteRenderer>().sprite = Sprites_hit[Index_sprite];
 Index_sprite++;
}
		
	 
	
	void Win_Simulation()  // simple fucntion --> will be removed afterwards.
	
	{
	
	level_Manager.LoadNextLevel();
	}
}
