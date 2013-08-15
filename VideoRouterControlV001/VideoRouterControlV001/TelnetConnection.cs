using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace VideoRouterControlV001
{
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }




   
    public class TelnetConnection
    {
        TcpClient tcpSocket;

        int TimeOutMs = 500;

        public TelnetConnection(string Hostname, int Port)
        {
            try
            {
                tcpSocket = new TcpClient(Hostname, Port);
                Console.WriteLine("Telnet connection initialized");
            }
            catch
            {
                Console.WriteLine("connection Timed Out");
            }
        }



        public string Login(string Username, string Password, int LoginTimeOutMs)
        {
            try
            {

                int oldTimeOutMs = TimeOutMs;
                TimeOutMs = LoginTimeOutMs;
                string s = Read();
                if (!s.TrimEnd().EndsWith(":"))
                    throw new Exception("Failed to connect : no login prompt");
                //WriteLine(Username);

                s += Read();
                if (!s.TrimEnd().EndsWith(":"))
                    throw new Exception("Failed to connect : no password prompt");
                //WriteLine(Password);

                s += Read();
                TimeOutMs = oldTimeOutMs;
                return s;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        public void Write(string cmd)
        {
            try
            {

                if (!tcpSocket.Connected) return;
                byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
                tcpSocket.GetStream().Write(buf, 0, buf.Length);
            }
            catch
            {

            }

        }

        public string Read()
        {
            if (!tcpSocket.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (tcpSocket.Available > 0);
            return sb.ToString();
        }

        

        public bool IsConnected
        {
            get { try { return tcpSocket.Connected; } catch { return false; } }
        
        }
        



        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}
