using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

	private Object[] musics;
	private AudioSource source;
	private int currentMusic = 0;

	public Text musicLabel;

	void Awake() {
	}

	// Use this for initialization
	void Start () {
		musics = Resources.LoadAll ("Audio/Musics", typeof(AudioClip));

		Debug.Log (musics.Length);
		source = this.gameObject.GetComponent<AudioSource> ();

		source.clip = musics [currentMusic] as AudioClip;

		if (!source.isPlaying) {
			PlayRandomMusic ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			Next ();
		}
	}

	private void PlayRandomMusic() {
		source.clip = musics [Random.Range (0, musics.Length)] as AudioClip;
		source.Play ();
		musicLabel.text = source.clip.name;
	}

	public void Next() {
		currentMusic++;

		if (currentMusic >= musics.Length) {
			currentMusic = 0;
		}

		ChangeMusic ();
	}

	public void Previous() {
		currentMusic--;

		if (currentMusic < 0) {
			currentMusic = musics.Length - 1;
		}

		ChangeMusic ();
	}

	private void ChangeMusic() {
		source.Stop ();
		source.clip = musics [currentMusic] as AudioClip;
		source.Play ();

		musicLabel.text = source.clip.name;
	}
}
