using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;         // 화면을 덮는 UI Image 컴포넌트에 대한 참조
    public float fadeDuration = 1.5f; // 페이드 효과의 지속 시간(초)

    private bool isFading = false; // 페이드 효과 중인지 여부를 나타내는 플래그

    // 페이드 아웃 효과를 위한 코루틴
    private IEnumerator FadeOut(string sceneName)
    {
        if (isFading) yield break; // 페이드 효과 중인 경우 또 다른 페이드 효과를 시작하지 않음

        isFading = true;
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 0f);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void StartFadeOut(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // 페이드 효과가 끝나면 호출하여 플래그를 리셋합니다.
    private void OnFadeComplete()
    {
        isFading = false;
    }
}