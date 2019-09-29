using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    public GameObject Sonne, Merkur, Venus, Erde, Mars, Jupiter, Saturn, Uranus, Neptun,  // Planeten
                      SonZ, MeZ, VZ, EZ, MaZ, JZ, SZ, UZ, NZ,                                // Ziel der Planeten
                      SonL, MerL, VenL, ErdL, MarL, JupL, SatL, UraL, NepL,               // Auswahlreihe Planeten
                      Sys, Planets;
    bool SunSnap,MeSnap,VeSnap,ErSnap,MaSnap,JuSnap,SaSnap,UrSnap,NeSpan;
  

    Vector2 SonneInitialPos, MarkurInitialPos, VenusInitialPos, ErdeInitialPos, 
                   MarsInitialPos, JupiterInitialPos, SaturnInitialPos, UranusInitialPos, NeptunInitialPos;

    [SerializeField]
    private GameObject Aw;



    void Start () {
        SonneInitialPos = Sonne.transform.position;
        ErdeInitialPos = Erde.transform.position;
        MarkurInitialPos = Erde.transform.position;
        VenusInitialPos = Erde.transform.position;
        MarsInitialPos = Erde.transform.position;
        JupiterInitialPos = Erde.transform.position;
        SaturnInitialPos = Erde.transform.position;
        UranusInitialPos = Erde.transform.position;
        NeptunInitialPos = Erde.transform.position;
        Aw.SetActive(false);
        SunSnap = false;
        MeSnap = false;
        VeSnap = false;
        ErSnap = false;
        MaSnap = false;
        JuSnap = false;
        SaSnap = false;
        UrSnap = false;
        NeSpan = false;
    }

    private void Update()
    {
        if ((SunSnap == true) && (MeSnap == true) && (VeSnap == true) && (ErSnap == true) &&
            (MaSnap == true) && (JuSnap == true) && (SaSnap == true) && (UrSnap == true) && (NeSpan == true))
        {
            Aw.SetActive(true);
            Debug.Log("Win");
        }
    }

    //################################################

    public void DragSonne () {
        if (SunSnap != true)
        {
            Sonne.transform.position = Input.mousePosition;
            Sonne.transform.SetParent(Sys.transform);
        }
    }

    public void DragMerkur()
    {
        if (MeSnap != true)
        {
            Merkur.transform.position = Input.mousePosition;
            Merkur.transform.SetParent(Sys.transform);
        }
    }

    public void DragVenus()
    {
        if (VeSnap != true)
        {
            Venus.transform.position = Input.mousePosition;
            Venus.transform.SetParent(Sys.transform);
        }
    }

    public void DragErde()
    {
        if (ErSnap != true)
        {
            Erde.transform.position = Input.mousePosition;
            Erde.transform.SetParent(Sys.transform);
        }
    }

    public void DragMars()
    {
        if (MaSnap != true)
        {
            Mars.transform.position = Input.mousePosition;
            Mars.transform.SetParent(Sys.transform);
        }
    }

    public void DragJupiter()
    {
        if (JuSnap != true)
        {
            Jupiter.transform.position = Input.mousePosition;
            Jupiter.transform.SetParent(Sys.transform);
        }
    }

    public void DragSaturn()
    {
        if (SaSnap != true)
        {
            Saturn.transform.position = Input.mousePosition;
            Saturn.transform.SetParent(Sys.transform);
        }
    }

    public void DragUranus()
    {
        if (UrSnap != true)
        {
            Uranus.transform.position = Input.mousePosition;
            Uranus.transform.SetParent(Sys.transform);
        }
    }

    public void DragNeptun()
    {
        if (NeSpan != true)
        {
            Neptun.transform.position = Input.mousePosition;
            Neptun.transform.SetParent(Sys.transform);
        }
    }


    //################################################

    public void DropSonne ()
    {
        float Distance = Vector3.Distance(Sonne.transform.position, SonZ.transform.position);
        if (Distance < 50)
        {
            Sonne.transform.position = SonZ.transform.position;
            Sonne.transform.SetParent(SonZ.transform);
            SunSnap = true;
        }
        else
        {
            Sonne.transform.position = SonL.transform.position;
            Sonne.transform.SetParent(Planets.transform);
        }
    }

    public void DropMerkur()
    {
        float Distance = Vector3.Distance(Merkur.transform.position, MeZ.transform.position);
        if (Distance < 50)
        {
            Merkur.transform.position = MeZ.transform.position;
            Merkur.transform.SetParent(MeZ.transform);
            MeSnap = true;
        }
        else
        {
            Merkur.transform.position = MerL.transform.position;
            Merkur.transform.SetParent(Planets.transform);
        }
    }

    public void DropVenus()
    {
        float Distance = Vector3.Distance(Venus.transform.position, VZ.transform.position);
        if (Distance < 50)
        {
            Venus.transform.position = VZ.transform.position;
            Venus.transform.SetParent(VZ.transform);
            VeSnap = true;
        }
        else
        {
            Venus.transform.position = VenL.transform.position;
            Venus.transform.SetParent(Planets.transform);
        }
    }

    public void DropErde()
    {
        float Distance = Vector3.Distance(Erde.transform.position, EZ.transform.position);
        if (Distance < 50)
        {
            Erde.transform.position = EZ.transform.position;
            Erde.transform.SetParent(EZ.transform);
            ErSnap = true;
        }
        else
        {
            Erde.transform.position = ErdL.transform.position;
            Erde.transform.SetParent(Planets.transform);
        }
    }

    public void DropMars()
    {
        float Distance = Vector3.Distance(Mars.transform.position, MaZ.transform.position);
        if (Distance < 50)
        {
            Mars.transform.position = MaZ.transform.position;
            Mars.transform.SetParent(MaZ.transform);
            MaSnap = true;
        }
        else
        {
            Mars.transform.position = MarL.transform.position;
            Mars.transform.SetParent(Planets.transform);
        }
    }

    public void DropJupiter()
    {
        float Distance = Vector3.Distance(Jupiter.transform.position, JZ.transform.position);
        if (Distance < 50)
        {
            Jupiter.transform.position = JZ.transform.position;
            Jupiter.transform.SetParent(JZ.transform);
            JuSnap = true;
        }
        else
        {
            Jupiter.transform.position = JupL.transform.position;
            Jupiter.transform.SetParent(Planets.transform);
        }
    }

    public void DropSaturn()
    {
        float Distance = Vector3.Distance(Saturn.transform.position, SZ.transform.position);
        if (Distance < 50)
        {
            Saturn.transform.position = SZ.transform.position;
            Saturn.transform.SetParent(SZ.transform);
            SaSnap = true;
        }
        else
        {
            Saturn.transform.position = SatL.transform.position;
            Saturn.transform.SetParent(Planets.transform);
        }
    }

    public void DropUranus()
    {
        float Distance = Vector3.Distance(Uranus.transform.position, UZ.transform.position);
        if (Distance < 50)
        {
            Uranus.transform.position = UZ.transform.position;
            Uranus.transform.SetParent(UZ.transform);
            UrSnap = true;
        }
        else
        {
            Uranus.transform.position = UraL.transform.position;
            Uranus.transform.SetParent(Planets.transform);
        }
    }

    public void DropNeptun()
    {
        float Distance = Vector3.Distance(Neptun.transform.position, NZ.transform.position);
        if (Distance < 50)
        {
            Neptun.transform.position = NZ.transform.position;
            Neptun.transform.SetParent(NZ.transform);
            NeSpan = true;
        }
        else
        {
            Neptun.transform.position = NepL.transform.position;
            Neptun.transform.SetParent(Planets.transform);
        }
    }
}
