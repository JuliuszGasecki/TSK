using UnityEngine;

namespace Assets.Scripts
{
    public class NonInvertingAmplifier : MonoBehaviour
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
        private double R1;
        [SerializeField]
        private double R2;
        [SerializeField]
        private double K;
        [SerializeField]
        private double simulationSpeed;
        // Start is called before the first frame update
        SoundGenerator soundGen;
        void Start()
        {
            soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
            calculateAlternatingCurrent();
            calculateK();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }

        private void calculateK()
        {
            K = 1 + R2/R1;
        }

        private void calculateUwy()
        {
            Uwy = Uwe * (R1 + R2) / R1;
        }

        private void calculateAlternatingCurrent()
        {
            Uwe = Uo * Mathf.Sin((1 / (float)frequency) * Time.time * (float)simulationSpeed);
        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateK();
            calculateUwy();
            Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}
