using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure4Alexa.Models
{

    public class AlexRequest
    {
        public string version { get; set; }
        public Session session { get; set; }
        public Context context { get; set; }
        public Request request { get; set; }
    }

    public class Session
    {
        public bool _new { get; set; }
        public string sessionId { get; set; }
        public Application application { get; set; }
        public User user { get; set; }
    }

    public class Application
    {
        public string applicationId { get; set; }
    }

    public class User
    {
        public string userId { get; set; }
    }

    public class Context
    {
        public Audioplayer AudioPlayer { get; set; }
        public Display Display { get; set; }
        public System System { get; set; }
    }

    public class Audioplayer
    {
        public string playerActivity { get; set; }
    }

    public class Display
    {
        public string token { get; set; }
    }

    public class System
    {
        public Application1 application { get; set; }
        public User1 user { get; set; }
        public Device device { get; set; }
        public string apiEndpoint { get; set; }
        public string apiAccessToken { get; set; }
    }

    public class Application1
    {
        public string applicationId { get; set; }
    }

    public class User1
    {
        public string userId { get; set; }
    }

    public class Device
    {
        public string deviceId { get; set; }
        public Supportedinterfaces supportedInterfaces { get; set; }
    }

    public class Supportedinterfaces
    {
        public Audioplayer1 AudioPlayer { get; set; }
        public Display1 Display { get; set; }
    }

    public class Audioplayer1
    {
    }

    public class Display1
    {
        public string templateVersion { get; set; }
        public string markupVersion { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string requestId { get; set; }
        public DateTime timestamp { get; set; }
        public string locale { get; set; }
        public Intent intent { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string confirmationStatus { get; set; }
    }

}