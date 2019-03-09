using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestTimeLine : MonoBehaviour
{
    private void Start()
    {
        _director = GetComponent<PlayableDirector>();
        var asset = Resources.Load<PlayableAsset>("TestTimeLine");
        _director.playableAsset = asset;
        _director.Play();
    }

    private PlayableDirector _director;
}
