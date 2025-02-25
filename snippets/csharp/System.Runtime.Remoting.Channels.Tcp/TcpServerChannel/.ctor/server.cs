﻿/// Class: System.Runtime.Remoting.Channels.Tcp.TcpServerChannel
///    21    Ctor(string, int, IServerChannelSinkProvider)
///    22    GetChannelUri();
///    23    Parse();

///    !    Ctor(string, int)

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        //<snippet21>
        // Create the server channel.
        TcpServerChannel channel = new TcpServerChannel(
            "Server Channel", 9090, null);
        //</snippet21>

        // Register the server channel.
        ChannelServices.RegisterChannel(channel);

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem",
            WellKnownObjectMode.Singleton);

        //<snippet22>
        // Display the channel's URI.
        Console.WriteLine("The channel URI is {0}.",
            channel.GetChannelUri());
        //</snippet22>

        //<snippet23>
        // Parse the channel's URI.
        string[] urls = channel.GetUrlsForUri("RemoteObject.rem");
        if (urls.Length > 0)
        {
            string objectUrl = urls[0];
            string objectUri;
            string channelUri = channel.Parse(objectUrl, out objectUri);
            Console.WriteLine("The object URI is {0}.", objectUri);
            Console.WriteLine("The channel URI is {0}.", channelUri);
            Console.WriteLine("The object URL is {0}.", objectUrl);
        }
        //</snippet23>

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
    }
}
