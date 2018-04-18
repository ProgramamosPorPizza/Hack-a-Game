using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour {
    public int llave;
    public int llaveInglesa;
    public int cerilla;
    public int TrozodeCristal;
    public int cerealesRanciosBajosEnGrasa;

	// Use this for initialization
	void Start () {
        this.llave = 1;
        this.llaveInglesa = 0;
        this.cerilla = 0;
        this.TrozodeCristal = 0;
        this.cerealesRanciosBajosEnGrasa = 0;
	}

    public List<int> getLista()
    {
        /*This will be with the indexs:
         * 
         * 0:llave
         * 1:llave inglesa
         * 2:cerilla
         * 3:trozo de cristal
         * 4:cereales rancios bajos en grasa
        */
        List<int> a = new List<int>();
        a.Add(this.llave);
        a.Add(this.llaveInglesa);
        a.Add(this.cerilla);
        a.Add(this.TrozodeCristal);
        a.Add(this.cerealesRanciosBajosEnGrasa);


        return a;
    }
}
