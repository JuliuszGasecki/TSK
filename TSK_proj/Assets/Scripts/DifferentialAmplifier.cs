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
        private double Uo;
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
            calculateAlternatingCurrent();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }


        private void calculateUwy()
        {
            time = Time.time - time;
            //Uwy = -R2 * Capacitor * getDifferentialUwe();
            Uwy = 2 * Mathf.PI * frequency * R2 * Capacitor * Uwe * Mathf.Sin((float)(2 * Mathf.PI * frequency * Time.time * simulationSpeed - Mathf.PI / 2));
        }

        private double getDifferentialUwe()
        {
            return Uo * 4 * Mathf.PI * frequency * Mathf.Cos((float)(2 * Mathf.PI * frequency * Time.time * simulationSpeed));
        }

        private void calculateAlternatingCurrent()
        {
            Uwe = Uo * Mathf.Sin((float)(2*Mathf.PI * (float)frequency * Time.time * simulationSpeed));
        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateUwy();
            Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}