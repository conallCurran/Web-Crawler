using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main()
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create("http://www.conallcurran.com");

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();

            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            // Display the content.
            Console.WriteLine(responseFromServer);

            //write console out put to a file.
            StreamWriter SW;
            SW = File.CreateText("C:\\Users\\Conal_Curran\\OneDrive\\C#\\MyProjects\\Web Crawler\\webcrawler\\response.htm");
            SW.WriteLine(responseFromServer);


            // Clean up the streams and the response.
            reader.Close();
            response.Close();


            Console.Read();
        }
    }
}