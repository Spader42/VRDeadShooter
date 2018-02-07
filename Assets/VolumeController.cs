using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public AudioSource source;
	private Slider slider;

	// Use this for initialization
	void Start () {
		slider = this.gameObject.GetComponent<Slider> ();
        source = MusicController.Instance.gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVolume() {
		source.volume = this.slider.value;
	}
}
