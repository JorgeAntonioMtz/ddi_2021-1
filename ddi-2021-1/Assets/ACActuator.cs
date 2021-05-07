using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System;

public class ACActuator : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala";
    public float temperatureUpperThreshold = 30f;
    public float temperatureLowerThreshold = 20f;
    private MqttClient client;
    string lastMessage;
    public GameObject acObject;
    public GameObject lampObject;
    public GameObject cubeObject;
    volatile bool acState = true;
    volatile bool lampState = false;
    volatile bool cubeState = false;
    private bool isBig = false;

    public AudioSource audioSource;
    public bool isPlaying = false;

    void Start ()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
	}

    void Update()
    {
        if(cubeState)
        {
            if(isBig)
                cubeObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            else
                cubeObject.transform.localScale = new Vector3(1,1,1);
            cubeState = false;
        }
        if (acState != acObject.activeSelf)
			acObject.SetActive(acState);
        if(lampState != lampObject.activeSelf)
            lampObject.SetActive(lampState);
        
        if(isPlaying)
        {
            audioSource.Play();
            isPlaying = false;
        }
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		float temp;
        float.TryParse(lastMessage, out temp);
        if ( temp >= temperatureUpperThreshold)
        {
            // acObject.SetActive(true);
            acState = true;
        }
        else if (temp <= temperatureLowerThreshold)
        {
            // acObject.SetActive(false);
            acState = false;
        }

        if(lastMessage.ToLower() == "on")
            lampState = true;
        else if(lastMessage.ToLower() == "off")
            lampState = false;

        if(lastMessage.ToLower() == "play")
        {
            isPlaying = true;
            Debug.Log("playing sound...");
        }
        else if(lastMessage.ToLower() == "transform")
            cubeState = true;
	}
}