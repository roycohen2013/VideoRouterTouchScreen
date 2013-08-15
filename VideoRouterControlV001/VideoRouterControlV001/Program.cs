using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;     
using System.Drawing;
//using System.Threading;
namespace VideoRouterControlV001
{


    

    
 class Program
    {
        
        static public void InitializeForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


       //public TelnetConnection tc;


        

         static void Main(string[] args)
        {
            Console.WriteLine("test");

            //Console.WriteLine("form starting");
//----------------------------------------------------------------------------------------------

            Thread thread;
            //Console.WriteLine("form starting");
            thread = new Thread(InitializeForm);
            thread = new Thread(new ThreadStart(InitializeForm));
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
            Console.WriteLine("form initialized");
//----------------------------------------------------------------------------------------------
            /*
                        Settings mp = new Settings();
                        mp.FeedTestData(mp.outputs);

                        Stream stream = File.Open("SettingsInfo.osl", FileMode.Create);
                        BinaryFormatter bformatter = new BinaryFormatter();
                        Console.WriteLine("Writing Setting Information");
                        bformatter.Serialize(stream, mp);
                        stream.Close();
                        mp = null;

                        stream = File.Open("SettingsInfo.osl", FileMode.Open);
                        bformatter = new BinaryFormatter();



                        Console.WriteLine("Reading Setting Information");
                        mp = (Settings)bformatter.Deserialize(stream);

                        stream.Close();
                        //Console.WriteLine("Employee Id: {0}", mp.EmpId.ToString());
                        //Console.WriteLine("Employee Name: {0}", mp.EmpName);

                        for (int i = 0; i < mp.outputs.Length - 1; i++)
                        {
                            Console.Write(mp.outputs[i]);

                        }
             * 

            //----------------------------------------------------------------------------------------------


           




                        Console.WriteLine("test0");
                        //create a new telnet connection to hostname "IP address" on port "23"
                        TelnetConnection tc = new TelnetConnection("127.0.0.1", 23);
                        //tc.WriteLine("can you see this");
                        //TelnetConnection tc = new TelnetConnection("192.0.2.2", 23);

                       // RouterControler controler = new RouterControler(tc);

                        Console.WriteLine("test1");
            

                        //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
                        //string s = "test";


                        // server output should end with "$" or ">", otherwise the connection failed
                        string prompt = "";


                        // while connected
            


                        while (tc.IsConnected)
                        {
                            // display server output
                            Console.Write(tc.Read());

                            // send client input to server
                            prompt = Console.ReadLine();
                            tc.WriteLine(prompt);

                            // display server output
                            Console.Write(tc.Read());
                        }
                        Console.WriteLine("***DISCONNECTED");
                        Console.ReadLine();


             */

        }
   
            






     

    }
}
