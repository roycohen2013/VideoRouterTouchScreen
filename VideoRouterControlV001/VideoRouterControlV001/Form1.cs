using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;    




namespace VideoRouterControlV001
{

    public partial class Form1 : Form
    {
        TelnetConnection tc;        
        Settings mp;                // global object for loading and unloading the settings and presets
        //bool formState = false; //true = control form false = settings form
        bool settingToggle = true;
        bool buttonType;  // false is salvo true is channel
        bool buttonSubType = true; //if true sub Type is inputs, if false sub Type is outputs 

        int stateMachineState = 0;
        int stateDstInt = 0;
        int stateSrcInt = 0;


        string buttonValue = "1";



        Button[] mainButtonArray;
        Button[] salvoButtonArray;

        



        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)
        {


            mp = new Settings();

            UnserializeSettingsOLD();
            
            Console.WriteLine("SYSTEM TEST CONFIRMATION:   " + mp.inputIcons[0]);
            Console.WriteLine("Telnet IP Adress: " + mp.IpAdress);

            CreateButtonArray();

            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Cancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            button3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Settings.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);


            ChannelInputTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            RadioInput.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            RadioOutput.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            ButtonLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            EnterButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            buttonSettingControlsVisibility(false);


            mp.IpAdress = "192.0.2.2";
            mp.port = 23;
            Console.WriteLine("Requesting connection");
            tc = new TelnetConnection(mp.IpAdress, mp.port);
            //tc = new TelnetConnection("127.0.0.1", 23);
            //tc = new TelnetConnection("192.0.2.2", 23);

            Thread thread;
            Console.WriteLine("form starting");
            thread = new Thread(InitializeTelnetInterface);
            thread = new Thread(new ThreadStart(InitializeTelnetInterface));
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
            Console.WriteLine("Telnet Interface initialized");



            //Console.WriteLine("test0");
            //create a new telnet connection to hostname "IP address" on port "23"

            //tc.WriteLine("can you see this");
            //TelnetConnection tc = new TelnetConnection("192.0.2.2", 23);

           // RouterControler controler = new RouterControler(tc);

            //Console.WriteLine("test1");
            

            //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
            //string s = "test";


            // server output should end with "$" or ">", otherwise the connection failed
            

            /*
            // while connected
            Settings test1 = new Settings();
            Settings test2 = new Settings();
            
            test1.inputs[1] = "1";
            test2.inputs[0] = "0";

            Settings test3 = new Settings();
            

            Console.WriteLine();
            */
        


            //CreateButtonArray();
        }




/////====================================Communication===================================================

        public void InitializeTelnetInterface()
        {

            string prompt = "";

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
        }

///=====================================================================================================




////====================================Router Control===================================================
        public void TakeChannel(string dstName, string srcName)
        {
            string package = "";

            
            package = "t " + "\"" + dstName + "\" " + ", " + "\"" + srcName + "\"";

            Console.WriteLine(package);
            tc.WriteLine(package);

        }

        public void TakeSalvo(string salvoName)
        {
            string package = "";
            package = "ts " + "\"" + salvoName + "\"";

            Console.WriteLine(package);
            tc.WriteLine(package);

        }


///=======================================SETTINGS Object & SERIALIZATION+++===============================

        public void SerializeSettingsOLD()
        {
            //mp.FeedTestData(mp.outputs);
            Stream stream;
            stream = File.Open("SettingsInfo.osl", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            Console.WriteLine("Writing Setting Information");
            bformatter.Serialize(stream, mp);
            stream.Close();

        }

        public void UnserializeSettingsOLD()
        {
            try
            {

                mp = null;

                Stream stream = File.Open("SettingsInfo.osl", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();

                Console.WriteLine("Reading Setting Information");
                mp = (Settings)bformatter.Deserialize(stream);

                stream.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
                SerializeSettingsOLD();
            }


            


        }

        public void TestSettingObjectWriting(Settings settingObject)
        {
            for (int i = 0; i < settingObject.outputs.Length - 1; i++)
            {
                Console.Write(settingObject.outputs[i]);

            }
            Console.WriteLine("");



            Console.WriteLine("Telnet IP Adress: " + settingObject.IpAdress);


        }

        public void RefreshSettingObject(Settings settingObject, string SettingFileName)
        {
            SerializeSettingsOLD();
            UnserializeSettingsOLD();
            //SerializeSettings(settingObject, SettingFileName);
            //UnserializeSettings(settingObject, SettingFileName);

        }

        
//=======================================USER INTERFACE===================================================

        public void ChannelSendStateMachine(string addButtonNum)
        {
            stateMachineState++;

            Console.WriteLine("StateMachineState: "+stateMachineState);
            UnserializeSettingsOLD();

            switch (stateMachineState)
            {

                case 1:
                    buttonSubType = false;
                    stateSrcInt = Convert.ToInt32(addButtonNum);
                    stateSrcInt = stateSrcInt - 1;

                    Console.WriteLine("SRC STRING: " + mp.inputs[stateSrcInt] + "   Index location:" + stateSrcInt);
                    break;

                case 2:
                    buttonSubType = true;

                    
                    stateDstInt = Convert.ToInt32(addButtonNum);
                    stateDstInt = stateDstInt - 1;
                    Console.WriteLine("DST STRING: " + mp.outputs[stateDstInt] + "   Index location:" + stateDstInt);
                    TakeChannel(mp.outputs[stateDstInt], mp.inputs[stateSrcInt]);
                    stateDstInt = 0;
                    stateSrcInt = 0;
                    stateMachineState = 0;
                    //stateMachineState++;

                    //TakeSalvo(mp.salvos[Convert.ToInt32(buttonValue)]);

                    break;
                    

                case 3:

                    break;
            }

            CreateButtonArray();


        }

        private void mainButtonArray_Click(object sender, EventArgs e)
        {
            Button selected = sender as Button;
            //Console.WriteLine("SYSTEM TEST CONFIRMATION:   " + mp.inputIcons[0]);
            //Console.Write();
            String package = "KALEIDO".Trim() + selected.Name.Trim();



            ButtonLabel.Text = ReturnButtonLabelString(true, selected.Name); // false is salvo, true is channel
            buttonType = true;                                               // false is salvo, true is channel
            buttonValue = selected.Name.Trim();


            if (settingToggle)
            {

                ChannelSendStateMachine(selected.Name);


                //TakeChannel(package, "THS BARS");

                Console.WriteLine(selected.Name);
                //tc.WriteLine(selected.Name);
            }
        }

        private void salvoButtonArray_Click(object sender, EventArgs e)
        {


            Button selected = sender as Button;

            ButtonLabel.Text = ReturnButtonLabelString(false, selected.Name); // false is salvo, true is channel
            buttonType = false;                                               // false is salvo, true is channel
            buttonValue = selected.Name.Trim();
            //Console.WriteLine(buttonValue);

            if (settingToggle)
            {
                 TakeSalvo(mp.salvos[Convert.ToInt32(buttonValue)]);
                 //Console.WriteLine(selected.Name);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
          
            mp.inputIcons[0] = "Validated";
            //mp.FeedTestData(mp.outputs);

            Console.WriteLine("SYSTEM TEST:   " + mp.inputIcons[0]);

            //SerializeSettings(mp, "SettingsInfo.osl");
            SerializeSettingsOLD();

            
            //UnserializeSettings(mp, "SettingsInfo.osl");
            UnserializeSettingsOLD();

            Console.WriteLine("SYSTEM TEST CONFIRMATION:   " + mp.inputIcons[0]);


        }

        public void CreateButtonArray()
        {

            //http://www.codeproject.com/Questions/172557/identify-a-clicked-button-from-a-dynamically-creat-- example for creating dynamic button arrays



            int width = this.Width - 150;
            int height = this.Height - 150;
            int offset = 10;
            int topPadding = 50;



            int buttonDimension = ((Width - (2 * offset)) / 10);
            int buttonDimensionHeight = ((height - (2 * offset)) / 10);
            int buttonCounter = 0;





            try
            {
                //this.Controls[0].Dispose();
                //mainButtonArray[0].Dispose();
                buttonCounter = 0;
                for (int A = 0; A < mainButtonArray.Length; A++)
                {
                    this.Controls.Remove(mainButtonArray[A]);
                    //mainButtonArray[A].Dispose();
                    // Controls[A].ToString();                   
                    //Console.WriteLine(mainButtonArray[A].Disposing.ToString());

                    buttonCounter++;
                    //Console.WriteLine(Controls.ToString());      
                }
                mainButtonArray = null;

            }
            catch (NullReferenceException)
            {


            }


            try
            {
                buttonCounter = 0;
                for (int A = 0; A < salvoButtonArray.Length; A++)
                {
                    this.Controls.Remove(salvoButtonArray[A]);
                    //mainButtonArray[A].Dispose();
                    // Controls[A].ToString();                   
                    //Console.WriteLine(mainButtonArray[A].Disposing.ToString());

                    buttonCounter++;
                    //Console.WriteLine(Controls.ToString());      
                }
                salvoButtonArray = null;
            }
            catch (NullReferenceException)
            {

            }



            mainButtonArray = new System.Windows.Forms.Button[65];
            salvoButtonArray = new System.Windows.Forms.Button[8];




            //buttonArray = new System.Windows.Forms.Button[64];

            // Control ButtonControler = new System.Windows.Forms.Control();


            //this.buttonArray[i] = new System.Windows.Forms.Button();

            //if (settingToggle)
            if (true)
            {

                buttonCounter = 0;
                for (int k = 0; k <= 7; k++)
                {

                    for (int i = 0; i <= 7; i++)
                    {
                        buttonCounter++;
                        mainButtonArray[buttonCounter] = new System.Windows.Forms.Button();
                        mainButtonArray[buttonCounter].Location = new System.Drawing.Point(offset + ((width - (2 * offset)) / 8) * i, (offset + ((height - (2 * offset)) / 8) * k) + topPadding );
                        mainButtonArray[buttonCounter].UseVisualStyleBackColor = true;
                        //this.buttonArray[i].Location = new System.Drawing.Point(offset + ((width-(2*offset))/8)*i , 43*k+offset);

                        //this.buttonArray[i].Name = i.ToString();
                        mainButtonArray[buttonCounter].Name = buttonCounter.ToString();

                        mainButtonArray[buttonCounter].Size = new System.Drawing.Size(buttonDimension, buttonDimensionHeight);
                        mainButtonArray[buttonCounter].TabIndex = buttonCounter;

                       // mainButtonArray[buttonCounter].Text = "button" + buttonCounter.ToString();


                        //    buttonSubType -- if true sub Type is inputs, if false sub Type is outputs 

                        

                        if (buttonSubType == true)
                        {
                            mainButtonArray[buttonCounter].BackColor = System.Drawing.Color.LightGreen;
                            //Console.WriteLine("button Counter: "+buttonCounter);
                            if (mp.inputs[buttonCounter-1] == null || mp.inputs[buttonCounter-1].Trim() == "")
                            {
                                
                                mainButtonArray[buttonCounter].Text = "Input"+ "\n" + buttonCounter.ToString();

                                //mp.inputs[buttonCounter - 1] = " Input " + buttonCounter.ToString();

                            }
                            else
                            {

                                //mp.inputs[buttonCounter - 1] = " Input" + "\n" + buttonCounter.ToString();
                                try
                                {
                                    mainButtonArray[buttonCounter].Text = mp.inputs[buttonCounter - 1];

                                }
                                catch (NullReferenceException)
                                {
                                    Console.WriteLine("null debug");
                                }
                                //mainButtonArray[buttonCounter].Text = mp.inputs[buttonCounter];

                                StatusLabel.Text = "Inputs";

                                //Console.WriteLine("null value in array");
             
                            }

                            //salvoButtonArray[buttonCounter].Text = mp.salvos[k];

                        }
                        else
                        {
                            mainButtonArray[buttonCounter].BackColor = System.Drawing.Color.LightSkyBlue;

                            if (mp.outputs[buttonCounter - 1] == null || mp.outputs[buttonCounter - 1] == "")
                            {
                                mainButtonArray[buttonCounter].Text = "Output" + "\n" + buttonCounter.ToString();
                                //mp.outputs[buttonCounter - 1] = "Output" + "\n" + buttonCounter.ToString();
                                //mainButtonArray[buttonCounter].Text = mp.outputs[buttonCounter - 1];
                            }
                            else
                            {

                                //mp.outputs[buttonCounter - 1] = "Output" + "\n" + buttonCounter.ToString();
                               
                                mainButtonArray[buttonCounter].Text = mp.outputs[buttonCounter-1];
                                StatusLabel.Text = "Outputs";

                            }




                            //mainButtonArray[buttonCounter].Text = "Output" + buttonCounter.ToString();
                        }


                        //mainButtonArray[buttonCounter].UseVisualStyleBackColor = true;
                        mainButtonArray[buttonCounter].Click += new System.EventHandler(this.mainButtonArray_Click);
                        
                        mainButtonArray[buttonCounter].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                        //this.buttonArrad[i].Name += new System.EventHandler(buttonArray_Click);
                        this.Controls.Add(mainButtonArray[buttonCounter]);
                        //ButtonControler.Add(mainButtonArray[i]);

                    }
                }

                SerializeSettingsOLD();
                UnserializeSettingsOLD();
                buttonCounter = 0;


                for (int k = 0; k <= 7; k++)                        // Create Salvo Buttons in a for loop
                {


                    salvoButtonArray[buttonCounter] = new System.Windows.Forms.Button();
                    salvoButtonArray[buttonCounter].Location = new System.Drawing.Point(offset + ((width - (2 * (offset - 10))) / 8) * 8, (offset + ((height - (2 * offset)) / 8) * k) + topPadding);

                    //this.buttonArray[i].Location = new System.Drawing.Point(offset + ((width-(2*offset))/8)*i , 43*k+offset);

                    //this.buttonArray[i].Name = i.ToString();
                    salvoButtonArray[buttonCounter].Name = buttonCounter.ToString();
                    //salvoButtonArray[buttonCounter].Name = mp.salvos[k];

                    salvoButtonArray[buttonCounter].Size = new System.Drawing.Size(buttonDimension, buttonDimensionHeight);
                    salvoButtonArray[buttonCounter].TabIndex = buttonCounter;


                    if (mp.salvos[k] == null)
                    {
                        salvoButtonArray[buttonCounter].Text = "Salvo" + buttonCounter.ToString();
                    }
                    else
                    {
                        salvoButtonArray[buttonCounter].Text = mp.salvos[k];
                    }



                    salvoButtonArray[buttonCounter].UseVisualStyleBackColor = true;
                    salvoButtonArray[buttonCounter].Click += new System.EventHandler(this.salvoButtonArray_Click);

                    salvoButtonArray[buttonCounter].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                    //this.buttonArrad[i].Name += new System.EventHandler(buttonArray_Click);
                    this.Controls.Add(salvoButtonArray[buttonCounter]);
                    //ButtonControler.Add(mainButtonArray[i]);
                    buttonCounter++;
                }


              

            }

        }

        public void SaveButtonString()
        {
            
            
            int buttonValueInteger = Convert.ToInt32(buttonValue);

            if (RadioInput.Checked == true)
            {
                buttonSubType = true;

                if (buttonType)                                 // false is salvo, true is channel
                {
                    mp.inputs[buttonValueInteger-1] = ChannelInputTextBox.Text.Trim();
                }
                else
                {
                    mp.salvos[buttonValueInteger] = ChannelInputTextBox.Text.Trim();
                }


            }
            else if (RadioOutput.Checked == true)
            {
                buttonSubType = false;

                if (buttonType)                              // false is salvo, true is channel
                {
                    mp.outputs[buttonValueInteger-1] = ChannelInputTextBox.Text.Trim();




                }
                else
                {
                    mp.salvos[buttonValueInteger] = ChannelInputTextBox.Text.Trim();
                }
            }

            
            //SerializeSettings(mp, "SettingsInfo.osl");
            //UnserializeSettings(mp, "SettingsInfo.osl");
            SerializeSettingsOLD();
            UnserializeSettingsOLD();

            

            CreateButtonArray();

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            SaveButtonString();
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SaveButtonString(); // Then Enter key was pressed
            }
        }

        private void ChannelInputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //updateButtonArray();
            CreateButtonArray();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void RadioInput_CheckedChanged(object sender, EventArgs e)
        {



             if (RadioInput.Checked == true)
            {
                buttonSubType = true;
                

            }
             else if (RadioOutput.Checked == true)
             {
                 buttonSubType = false;
             }


             CreateButtonArray();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stateMachineState = 0;
            buttonSubType = true;
            Console.WriteLine("Canceled package");
            CreateButtonArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //mp.FeedTestData(mp.outputs);

            //for(int i = 0;)

            foreach (string s in mp.inputs)
            {
                Console.WriteLine(s);
            }

            foreach (string s in mp.outputs)
            {
                Console.WriteLine(s);
            }


            //Console.WriteLine(mp.inputs);
            //Console.WriteLine(mp.outputs);
            //mainButtonArray[buttonCounter].Text = mp.inputs[buttonCounter];


            //mp.IpAdress = "127.0.0.1";
            //mp.port = 23;

            CreateButtonArray();

        }

        private void Settings_Click(object sender, EventArgs e)
        {

            settingToggle = !settingToggle;


            if (settingToggle)
            {
                //CreateButtonArray();
                Settings.Text = "Settings";
                buttonSettingControlsVisibility(false);
            }
            else
            {
                //CreateButtonArray();
                Settings.Text = "Control";
                buttonSettingControlsVisibility(true);
            }
        }

        private void buttonSettingControlsVisibility(bool state)
        {
            RadioInput.Checked = true;
            EnterButton.Visible = state;
            ButtonLabel.Visible = state;
            ChannelInputTextBox.Visible = state;
            RadioInput.Visible = state;
            RadioOutput.Visible = state;
        }

        public string ReturnButtonLabelString(bool buttonType, string Number)
        {
            string finalString = "";

            //if button type is true then its a channel.
            //if button type is false then its a salvo.

            if (buttonType == false)
            {
                finalString = "S" + "-" + Number;
            }
            else if (buttonType == true)
            {
                finalString = "C" + "-" + Number;
            }

            return (finalString);
        }

        }

    }

