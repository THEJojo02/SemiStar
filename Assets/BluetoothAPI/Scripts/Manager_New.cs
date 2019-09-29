using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArduinoBluetoothAPI;
using System;

public class Manager_New : MonoBehaviour
{

    public int k1_Bew, r1_Bew, m1_Bew, z1_Bew, z2_Bew, d1_Bew;
    public int x_Bew, y_Bew, z_Bew;

    public float schwellwert;
    public Text mytext;
    public Text mytext2;
    public Text mytext3;
    public Text mytext4;
    public Text mytext5;
    public Text mytext6;
    public Text text;

    UInt16[] sensordata = new UInt16[17];
    byte[] buffer = new byte[2];


    int[] zu = new int[6];
    int[] auf = new int[6];

    float[] proz = new float[6]; // Prozent der Fingerneigug

    public bool lauf;
    public bool greif;
    public bool info;



    // Initialisierung 
    BluetoothHelper bluetoothHelper;
    string deviceName;
    string debugfilter = "Help: ";


    public GameObject sphere;

    string received_message;

    void Start()
    {

        lauf = false;
        greif = false;
        info = false;

    for (int i=0; i<=5; i++)  // Setzt die Begrenzungs Werte
        {
            zu[i] = 0;
            auf[i] = 1023;
        }
  

        deviceName = "HC05"; //Wichtig: Bluethoot AN !

        try
        {
            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
            bluetoothHelper.OnDataReceived += OnMessageReceived; //list die Daten ein

            bluetoothHelper.setLengthBasedStream();

            if (bluetoothHelper.isDevicePaired())
                sphere.GetComponent<Renderer>().material.color = Color.blue;
            else
                sphere.GetComponent<Renderer>().material.color = Color.grey;
        }
        catch (Exception ex)
        {
            sphere.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log(ex.Message);
            text.text = ex.Message;
        }

    }


    IEnumerator blinkSphere()
    {
        sphere.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(0.5f);
        sphere.GetComponent<Renderer>().material.color = Color.green;
    }




    //Asyncrone Methode des Dtaneempfangens
    void OnMessageReceived()
    {
        char[]data = bluetoothHelper.Read().ToCharArray();
        for (int i = 0; i < data.Length/2; i++)
        {
            buffer[0] = (byte)data[2 * i];
            buffer[1] = (byte)data[2 * i + 1];
            sensordata[i] = BitConverter.ToUInt16(buffer, 0);
            Debug.Log(debugfilter + "Sensor[ " + i + " ] " + sensordata[i]);

        }


        k1_Bew = sensordata[0];
        r1_Bew = sensordata[1];
        m1_Bew = sensordata[2];
        z1_Bew = sensordata[3];
        z2_Bew = sensordata[4];
        d1_Bew = sensordata[5];
        x_Bew = sensordata[6];
        y_Bew = sensordata[7];
        z_Bew = sensordata[8];



         
        for (int i = 0; i <= 5; i++)
        {
            setauf(i); // Auf Wert (Max Wert) setzen
            setzu(i); // Zu Wert (Min Wert) setzen
            pro(i);  //Prozente der Öffnung der Hand bekommen
        }


        // Faust - Greifen
        if (proz[0] <= 30 && proz[1] <= 30 && proz[4] <= 30)
            { greif = true;}
        else
            { greif = false;}

       

       //Zeigen - Laufen
        //if (proz[0] >= 60 && proz[1] >= 60 && proz[2] >= 60 && proz[3] >= 60 && proz[4] <= 40)
         //   { lauf = true;}
       // else
          //  {lauf = false;
      
       // }


    //Dubug Hilfen
       mytext2.text = auf[3].ToString() + zu[3].ToString();
       mytext3.text = proz[3].ToString(); 
       mytext.text = proz[3].ToString() + "=" + sensordata[3].ToString() + "*"+ (100f / (auf[3] - zu[3])).ToString(); 

    }



    void pro(int i)
    {
        proz[i] = (sensordata[i] - zu[i]) * (100f / (auf[i]-zu[i]));
    }

    // Begerenzen den Min bzw. Max Wert
    void setauf(int i)
    {
        if (auf[i] > sensordata[i])
        {
            auf[i] = sensordata[i];
        }
    }

    void setzu(int i)
    {
        if (zu[i] < sensordata[i])
        {
            zu[i] = sensordata[i];
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }



    // Bluetooth Verbingungs-Funktionen
    void OnConnected()
    {
        sphere.GetComponent<Renderer>().material.color = Color.green;
        try
        {
            bluetoothHelper.StartListening();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }

    void OnConnectionFailed()
    {
        sphere.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Connection Failed");
    }

    public void button()
    {
        if (!bluetoothHelper.isConnected())
            if (bluetoothHelper.isDevicePaired())
                bluetoothHelper.Connect(); // tries to connect
    }

    void OnDestroy()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.Disconnect();
    }
}

