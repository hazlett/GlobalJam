using UnityEngine;
using System.Collections;

public class FootStepTestCode : MonoBehaviour {

	public AudioSource sound1;
	public AudioSource sound2; 
	public AudioSource sound3;
	public AudioSource sound4;
	public AudioSource sound5;
	public AudioSource sound6;
	public AudioSource sound7;
	public AudioSource sound8;
	public AudioSource sound9;
	public AudioSource sound10;

	int playSound = 0;
	int lastSound = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown (KeyCode.Q))
		   {
			//roll to see which sound will play.
			playSound = Random.Range(1, 11);
		
			if(lastSound > 0 && playSound == lastSound)
			{
				if(lastSound < 5)
				{
					playSound++;
				}
				else
				{
					playSound--;
				}

			//cheap fix, I could use random range with a float value and then round, but the chance of actually
			//rolling 11 is incredibly low so I will just round it down if it does.
			if(playSound == 11)
				{
				playSound = 10;
				}
			}
		}

		//big if else to play the sound that was selected.
		//now that I think about it I should do this in an array. fix it later.
		if(playSound>0){
			
			if(playSound == 1){

				sound1.audio.Play();
			}
			
			else if(playSound == 2){
				
				sound2.audio.Play();
			}
			
			else if(playSound == 3){
				
				sound3.audio.Play();
			}
			
			else if(playSound == 4){
				
				sound4.audio.Play();
			}
			
			else if(playSound == 5){
				
				sound5.audio.Play();
			}

			if(playSound == 6){
				
				sound6.audio.Play();
			}
			
			else if(playSound == 7){
				
				sound7.audio.Play();
			}
			
			else if(playSound == 8){
				
				sound8.audio.Play();
			}
			
			else if(playSound == 9){
				
				sound9.audio.Play();
			}
			
			else if(playSound == 10){
				
				sound10.audio.Play();
			}

				lastSound = playSound;
			playSound = 0;
			
		}

	}
}
