using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller self;

    //public GameController gameController;
    //public Cam.CameraController cameraController;
    public PlayerController playerController;
   
    //public UIController uiController;
    //public LevelController levelController;
    //public EffectController effectController;
    //public EnvironmentController environmentController;

    

    void Awake()
    {
        if (self == null)
        {
            self = this;
        }
    }
}