using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FreindText : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _timeBetweenLetters = 0.05f;
    [SerializeField]
    private float _timeToDisappear = 1f;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _showTextAnimationName = "ShowText";
    [SerializeField]
    private string _hideTextAnimationName = "HideText";

    private string _fullText;
    private Coroutine _showTextCouroutine;

    private void StopText()
    {
        if (_showTextCouroutine != null)
        {
            StopCoroutine(_showTextCouroutine);
            _showTextCouroutine = null;
        }
        _text.text = "";
    }
    public void ShowText(string text)
    {
        StopText();
        _animator.Play(_showTextAnimationName);
        _showTextCouroutine = StartCoroutine(ShowTextCouroutine(text));

    }
    private IEnumerator ShowTextCouroutine(string text)
    {
        _fullText = text;
        _text.text = "";
        foreach (char letter in _fullText)
        {
            _text.text += letter;
            yield return new WaitForSeconds(_timeBetweenLetters);

        }
        yield return new WaitForSeconds(_timeToDisappear);
        _showTextCouroutine = null;
        _animator.Play(_hideTextAnimationName);
    }
}
