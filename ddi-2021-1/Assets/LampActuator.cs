using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;

public class LampActuator : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org"; //"192.168.1.255";
	public int brokerPort = 1883;
	public string luzTopic = "casa/sala/luz";
    private MqttClient client;
    string lastMessage;
    public GameObject lampObject;
    volatile bool lampState = false;
    public AudioSource audioSource;
    public bool isPlaying = false;

    void Start ()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Subscribe(new string[] { luzTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
	}

    // Update is called once per frame
    void Update()
    {
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

        //if(lastMessage.ToLower() == "on")
        //    lampState = true;
        //else if(lastMessage.ToLower() == "off")
        //    lampState = false;
        if(lastMessage.ToLower() == "play")
        {
            isPlaying = true;
            Debug.Log("playing sound...");
        }
	}
}