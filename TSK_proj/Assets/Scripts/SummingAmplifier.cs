using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SummingAmplifier : MonoBehaviour
    {
        [SerializeField]
        private bool directCurrent;
        [SerializeField]
        private double frequency;
        [SerializeField]
        private double Uo;
        [SerializeField]
        List<double> Uwes;
        [SerializeField]
        private double Uwy;
        [SerializeField]
        List<double> resistors;
        [SerializeField]
        private double Rf;
        [SerializeField]
        private double simulationSpeed;
        // Start is called before the first frame update
        SoundGenerator soundGen;

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
            return (float)Uwes[0];
        }

        public float GetUwy()
        {
            return (float)Uwy;
        }

        public float GetR1()
        {
            return (float)resistors[0];
        }

        public void SetR1(float R1)
        {
           for(int i = 0; i < resistors.Count; i++)
            {
                resistors[i] = R1;
            }
        }

        public float GetR2()
        {
            return (float)Rf;
        }

        public void SetR2(float R2)
        {
            Rf = R2;
        }

        public float GetC()
        {
            return -1;
        }

        public void SetC(float C)
        {

        }
        void Start()
        {
            soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
            calculateAlternatingCurrent();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }

        private void calculateUwy()
        {
            Uwy = -Rf * calculateSumOfRatioOfWeAndR();
        }

        private double calculateSumOfRatioOfWeAndR()
        {
            double sum = 0;
            for(int i = 0; i < resistors.Count; i++)
            {
                sum += Uwes[i] / resistors[i];
            }
            return sum;
        }

        private void calculateAlternatingCurrent()
        {
            for(int i = 0; i < Uwes.Count; i++) {
                Uwes[i] = Uo * Mathf.Sin((float)(2 * Mathf.PI * (float)frequency * Time.time * simulationSpeed));
            }  
        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }
    }
}
