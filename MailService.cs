using System;
namespace EventsDelegates
{
    class MailService
    {
        public void onVideoEncoded(Object source, VideoEventArgs e)
        {
            //Displays the class which is the source of the evnt
            Console.WriteLine("Source: {0}", source.ToString());

            //Additionnal information about the event
            Console.WriteLine("Video Title: {0}", e.video.Title);

            //Sending Mail to notify that vidio is encoded
            Console.WriteLine("Mail Service: Sending Mail...");
        }
    }
}
