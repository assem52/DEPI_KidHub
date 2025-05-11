using System;
using System.Security.Cryptography.X509Certificates;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Options;



public class MyService
{
    private readonly CloudinarySettings _cloudinarySettings;

    public string CloudName { get; set; }
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }

    public MyService(IOptions<CloudinarySettings> cloudinarySettings)
    {
        _cloudinarySettings = cloudinarySettings.Value;
    }

    public void DoSomethingWithCloudinary()
    {
        string cloudName = _cloudinarySettings.CloudName;
        string apiKey = _cloudinarySettings.ApiKey;
        string apiSecret = _cloudinarySettings.ApiSecret;

        // Use these credentials to interact with the Cloudinary API
    }
}