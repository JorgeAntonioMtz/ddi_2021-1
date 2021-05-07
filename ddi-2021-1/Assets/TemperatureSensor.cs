using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System;

public class TemperatureSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala";
    public float reportRate = 5f;
    public float temperatureValue = 20.3f;
    private MqttClient client;
    private float reportTimer;

    void Start ()
    {
		// create client instance 
		//client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
	}

    void Update()
    {
        if (!client.IsConnected)
        {
            Debug.LogWarning("No conectado");
            return;
        }
        if ((reportTimer += Time.deltaTime) >= reportRate)
        {
            Debug.Log($"sending to topic {temperatureTopic}, value: {temperatureValue}");
            string message = temperatureValue.ToString();
			client.Publish(temperatureTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer = 0f;
        }
    }
}