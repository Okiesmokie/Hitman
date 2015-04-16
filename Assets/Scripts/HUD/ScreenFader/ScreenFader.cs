using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	private bool isFading = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnAnimationComplete() {
		isFading = false;
	}

	public IEnumerator HUD_FadeOut() {
		isFading = true;
		animator.SetTrigger("FadeOut");

		while(isFading)
			yield return null;
	}

	public IEnumerator HUD_FadeIn() {
		isFading = true;
		animator.SetTrigger("FadeIn");

		while(isFading)
			yield return null;
	}
}
