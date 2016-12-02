using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Client  {

    public bool writeToserver = false;
   

    Thread client;
    public string dataGottenFromServer = "";
    string ipAdress;
    bool sendData = false;
    string dataToSend = "data that was send";
    public string recivedData;

    public Client(string ipAdress)
    {
        this.ipAdress = ipAdress;
    }

    public void StartClient()
    {
        client = new Thread(Connect);
        client.Start();
    }

    public void Connect()
    {
        

        int port = 1700;
        TcpClient client = new TcpClient(ipAdress, port);
        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream);
        StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
      

        while (true)
        {
            if(writeToserver)
            {

                //dataGottenFromServer = reader.ReadLine();

                //dataToSend = dataGottenFromServer;
                
                writer.WriteLine(dataToSend);
                dataGottenFromServer = reader.ReadLine();
                
            
            }
            else
            {
                dataGottenFromServer = reader.ReadLine();

                dataToSend = dataGottenFromServer;
            }

          
            

               
        }
    }

    public void updateData(string data)
    {
        dataGottenFromServer = data;
        dataToSend = data;
    }
}
