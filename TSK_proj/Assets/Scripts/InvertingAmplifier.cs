using UnityEngine;

namespace Assets.Scripts
{
    public class InvertingAmplifier : MonoBehaviour
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
        private double R3;
        [SerializeField]
        private double K;
        [SerializeField]
        private double simulationSpeed;

        public void SetSimulationSpeed(float val)
        {
            simulationSpeed = val;
        }

        public void SetUwo(float val)
        {
            Uo = val;
        }

        public float GetUwo()
        {
            return (float)Uo;
        }

        public float GetUwe()
        {
            return (float)Uwe;
        }

        public float GetUwy()
        {
            return (float)Uwy;
        }


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
            K = -R2 / R1;
        }

        private void calculateUwy()
        {
            Uwy = -Uwe * R2 / R1;
        }

        private void calculateAlternatingCurrent()
        {
            Uwe = Uo * Mathf.Sin((float)(2 * Mathf.PI * (float)frequency * Time.time * simulationSpeed));
        }

        public float GetR1()
        {
            return (float)R1;
        }

        public void SetR1(float R1)
        {
            this.R1 = R1;
        }

        public float GetR2()
        {
            return (float)R2;
        }

        public void SetR2(float R2)
        {
            this.R2 = R2;
        }

        public float GetC()
        {
            return -1;
        }

        public void SetC(float C)
        {

        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateK();
            calculateUwy();
           // Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}
