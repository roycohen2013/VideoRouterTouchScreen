using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace VideoRouterControlV001
{
    
    [Serializable()]	//Set this attribute to all the classes that you define to be serialized
    public class Settings : ISerializable
    {
    
        public string[] inputs = new string[65];
        public string[] outputs = new string[65];
        public string[] inputIcons = new string[65];
        public string[] outputIcons = new string[65];
        public string[] salvos = new string[10];
        public string[] salvoIcons = new string[10];
        public string IpAdress = "192.0.2.2";
        public int port = 23;

        //  mp.IpAdress = "127.0.0.1";
        //  mp.port = 23;


        //Default constructor
        public Settings()
        {

        }

        //Deserialization constructor.
        public Settings(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            //EmpId = (int)info.GetValue("EmployeeId", typeof(int));

            inputs = (String[])info.GetValue("inputs", typeof(string[]));
            outputs = (String[])info.GetValue("outputs", typeof(string[]));
            inputIcons = (String[])info.GetValue("inputIcons", typeof(string[]));
            outputIcons = (String[])info.GetValue("outputIcons", typeof(string[]));
            salvos = (String[])info.GetValue("salvos", typeof(string[]));
            salvoIcons = (String[])info.GetValue("salvoIcons", typeof(string[]));




            IpAdress = (String)info.GetValue("IpAdress", typeof(string));
            port = (int)info.GetValue("port", typeof(int));
            
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            //info.AddValue("EmployeeId", EmpId);
            //info.AddValue("EmployeeName", EmpName);
            info.AddValue("outputs", outputs);
            info.AddValue("IpAdress", IpAdress);
            info.AddValue("port", port);
            info.AddValue("inputs", inputs);
            info.AddValue("inputIcons", inputIcons);
            info.AddValue("outputIcons", outputIcons);
            info.AddValue("salvos", salvos);
            info.AddValue("salvoIcons", salvoIcons);


            //info.AddValue("outputs", outputs);
            //info.AddValue("outputs", outputs);
            //info.AddValue("outputs", outputs);



        }


        public void FeedTestData(string[] target){
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = i.ToString();
            }
        }


    }









}
