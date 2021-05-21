import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.Socket;

public class Client {

    public static void main(String[] args) {
        Socket socket;
        String host ="localhost";
        int port = 1777;
        BufferedReader strumienWe, strumienEcho;
        PrintStream strumienWy;
        String request;
        String response;
        try {
            socket = new Socket(host,port);
            strumienWy = new PrintStream(socket.getOutputStream());
            strumienEcho = new BufferedReader(new InputStreamReader(System.in));
            System.out.println("Wprowadz komende GET");
            request = strumienEcho.readLine().toUpperCase()+"/";
            System.out.println("Wprowadź strone:");
            System.out.println("strona1.html");
            System.out.println("strona2.html");
            System.out.println("Zostaw puste by wczytać obie");
            request += strumienEcho.readLine();
            request += " HTTP/1.1\n";
            strumienWy.println(request);
            strumienWe = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            while ((response = strumienWe.readLine()) != null){
                System.out.println(response);
            }

            strumienWy.close();
            strumienWe.close();

        } catch (IOException e) {
            e.printStackTrace();
        }

    }



}
