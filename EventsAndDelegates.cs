using System;
using System.Threading;

namespace EventsAndDelegates;

public class Program
{
    public static void Main()
    {
        var video = new Video() { Title = "Video 1" };
        var videoEncoder = new VideoEncoder();
        var mailService = new MailService();
         var textMessageService = new TextMessageService();

        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
        videoEncoder.VideoEncoded += textMessageService.OnVideoEncoded;
        videoEncoder.Encode(video);
    }
}

public class Video
{
    public string Title { get; set; }
}

public class VideoEncoderEventArgs : EventArgs 
{
    public Video Video { get; set; }
}

public class VideoEncoder
{
    //Steps to create a event: 
    //1 - Define delegate
    //2 - Define an avent based on this delegate
    //3 - Raise event

    public event EventHandler<VideoEncoderEventArgs> VideoEncoded;
    public void Encode(Video video)
    {
        Console.WriteLine("Enconding Video...");
        Thread.Sleep(3000);

        OnVideoEncoded(video);
    }

    protected virtual void OnVideoEncoded(Video video) 
    {
        if(VideoEncoded != null)
            VideoEncoded(this, new VideoEncoderEventArgs(){ Video = video }); 
    }
}

public class MailService 
{
    public void OnVideoEncoded(object source, VideoEncoderEventArgs args) => 
        System.Console.WriteLine($"MailService: sending a email about {args.Video.Title}");
}

public class TextMessageService
{
    public void OnVideoEncoded(object source, VideoEncoderEventArgs args) => 
        System.Console.WriteLine($"TextMessageService: sending message text about {args.Video.Title}");
}