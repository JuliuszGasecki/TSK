using UnityEngine;

namespace Assets.Scripts
{
    public class DifferentialAmplifier : MonoBehaviour
    {
        [SerializeField]
        private bool directCurrent;
        [SerializeField]
        private double frequency;
        [SerializeField]
        private double Uwe;
        [SerializeField]
        private double Uwy;
        [SerializeField]
        private double R2;
        [SerializeField]
        private double Capacitor;
        [SerializeField]
        private double simulationSpeed;
        private float time;

        SoundGenerator soundGen;
        // Start is called before the first frame update
        void Start()
        {
            time = Time.time;
            soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }


        private void calculateUwy()
        {
            time = Time.time - time;
            Uwy = -R2 * Capacitor * (Uwe / time);
        }

        // Update is called once per frame
        void Update()
        {
            calculateUwy();
            Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}