using System;
namespace EventsDelegates
{
    class MessageService
    {
        public void onVideoEncoded(Object source, VideoEventArgs e)
        {
            //Displays the class which is the source of the evnt
            Console.WriteLine("Source: {0}", source.ToString());

            //Additionnal information about the event
            Console.WriteLine("Video Title: {0}",e.video.Title);

            //Sends text message to notify that video is encoded
            Console.WriteLine("Message Service: Sending Text Message...");
        }
    }
}
