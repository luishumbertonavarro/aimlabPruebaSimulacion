using UnityEngine;
using System.Collections;

public class FormulasRepository
{
    public FormulasRepository() { }



    public float NormalDistribution(float average, float standardDesviation)
    {
        float coefZ = ZCoeficient();
        float xValue = average - (coefZ * standardDesviation) ;
        return xValue;
    }
    public float Exponencial(float average, float did){
        float lambda=1/did;
        float euler=2.71828f;
        float pxLessAverage=1-Mathf.Pow(euler,lambda*average*-1);
        return pxLessAverage;
    }
    

    public float ZCoeficient()
    {
        float rand_1 = Random.Range(0f, 1f);
        float rand_2 = Random.Range(0f, 1f);
        float z_coef = Mathf.Sqrt(-2 * Mathf.Log(rand_1)) * Mathf.Cos(2* Mathf.PI * rand_2);
        return rand_1;
    }
	
	public float inverseTramsform(float lambda)
    {
		float rand = Random.Range(0f, 1f);
		float tValue = (-(1/lambda)) * (Mathf.Log(rand));
        if (tValue < 0) {
            tValue = -(tValue);
        }
		return tValue;
	}

    public bool getBinomial(float success)
    {
        float rand = Random.Range(0f, 1f);
        if (rand <= success)
        {
            return true;
        }
        return false;
        
    }
}
