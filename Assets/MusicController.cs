using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

	private Object[] musics;
	private AudioSource source;
	private int currentMusic = 0;

    private static MusicController instance = null;

    public Text musicLabel;
    public static MusicController Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        musics = Resources.LoadAll("Audio/Musics", typeof(AudioClip));

        Debug.Log(musics.Length);
        source = this.gameObject.GetComponent<AudioSource>();

        source.clip = musics[currentMusic] as AudioClip;

        if (!source.isPlaying)
        {
            PlayRandomMusic();
        }

        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			Next ();
		}
	}

	public void PlayRandomMusic() {
		source.clip = musics [Random.Range (0, musics.Length)] as AudioClip;
		source.Play ();
		musicLabel.text = source.clip.name;

        Debug.Log("qsfq");
        ChangeMusic();
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

	public void ChangeMusic() {
		source.Stop ();
		source.clip = musics [currentMusic] as AudioClip;
		source.Play ();

		musicLabel.text = source.clip.name;
	}
}
