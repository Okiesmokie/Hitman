using UnityEngine;
using System.Collections;

/// <summary>
/// Class responsible for fading the screen in and out.
/// </summary>
public class ScreenFader : HitmanBase {
	private bool isFading = false;
	private Animator animator;

	/// <inheritdoc/>
	protected override void OnStart () {
		animator = GetComponent<Animator>();
	}


	/// <summary>
	/// Event that is called when the animation is complete.
	/// </summary>
	protected void OnAnimationComplete() {
		isFading = false;
		GameController.instance.UnPauseGame();
	}


	/// <summary>
	/// Fades the screen out.
	/// </summary>
	public IEnumerator HUD_FadeOut() {
		GameController.instance.PauseGame();

		isFading = true;
		animator.SetTrigger("FadeOut");

		while(isFading)
			yield return null;
	}


	/// <summary>
	/// Fades the screen in.
	/// </summary>
	public IEnumerator HUD_FadeIn() {
		GameController.instance.PauseGame();

		isFading = true;
		animator.SetTrigger("FadeIn");

		while(isFading)
			yield return null;
	}

}
