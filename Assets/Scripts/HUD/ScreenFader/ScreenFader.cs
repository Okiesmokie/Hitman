using UnityEngine;
using System.Collections;

public class ScreenFader : HitmanBase {
	private bool isFading = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnAnimationComplete() {
		isFading = false;
		GameController.instance.UnPauseGame();
	}

	public IEnumerator HUD_FadeOut() {
		GameController.instance.PauseGame();

		isFading = true;
		animator.SetTrigger("FadeOut");

		while(isFading)
			yield return null;
	}

	public IEnumerator HUD_FadeIn() {
		GameController.instance.PauseGame();

		isFading = true;
		animator.SetTrigger("FadeIn");

		while(isFading)
			yield return null;
	}
}
