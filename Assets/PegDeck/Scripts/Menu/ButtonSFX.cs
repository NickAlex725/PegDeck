using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public void PlaySFX()
    {
        AudioSFX.Instance.PlaySoundEffect(SFXType.ButtonPress);
    }
}
