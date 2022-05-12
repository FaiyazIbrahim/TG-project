using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller self;
    public CameraController cameraController;
    public PlayerController playerController;
    public UIController uiController;
    public EffectController effectController;

    

    void Awake()
    {
        if (self == null)
        {
            self = this;
        }
    }
}