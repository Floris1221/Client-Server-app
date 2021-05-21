using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;


namespace Server
{
    class Users 
    {
        public static int clients = 0;
        TcpClient socet;
        StreamReader strumienWe;
        StreamWriter strumienWy;
        string request;
        string strona1 = "<html>\n\t<body>\n\t\t<h1>Politechnika Gdańska</h1>\n\t</body>\n</html>\n";
        string strona2 = "<html>\n\t<body>\n\t\t<h1>Inżynieria biomedyczna</h1>\n\t</body>\n</html>\n";
        ArrayList outputList = new ArrayList();
        string message;

        public Users(TcpClient socet)
        {
            this.socet = socet;
            clients++;
            message = null;
        }

        public void run()
        {
            strumienWe = new StreamReader(socet.GetStream());
            strumienWy = new StreamWriter(socet.GetStream());
            request = strumienWe.ReadLine();
            Console.WriteLine(request);
            if (request.StartsWith("GET/"))
            {
                //response header                                              
                outputList.Add("HTTP/1.0 200 OK\r\n");
                outputList.Add("Content-Type: text/html\r\n");
                outputList.Add("Content-Length: \r\n");
                outputList.Add("\r\n");
                //response resource
                if (request.Contains("strona1.html"))
                {
                    outputList.Add(strona1);
                }
                else if (request.Contains("strona2.html"))
                {
                    outputList.Add(strona2);
                }
                else if (request.Length==13)
                {
                    outputList.Add(strona1);
                    outputList.Add(strona2);
                }
                else
                {
                    outputList.Add("Brak zasobu\n");
                }
            } 
            else
            {
                outputList.Add("Nie znana komenda\n");
            }
            

            outputList.Add("IP Address: "+ Serwer.ipaddresss + "\r\n Port: "+ Serwer.port + "\r\n Data " + DateTime.Now.ToString());
            for (int i = 0; i < outputList.Count; i++)
            {
                message += outputList[i];
            }
            Console.WriteLine(message);
            strumienWy.Write(message);
            strumienWy.Flush();
            strumienWy.Close();

        }
        
    }
}
