using System;
namespace EventsDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create video to be encoded and assign its title property
            var v1 = new Video() { Title=" Video 1"};

            //Create the encoder object that will encode the above video
            //This is the event publisher---event generator
            //This class has and event handler 
            var videoEncoder=new VideoEncoder();

            //Or you can also call the dervived class of VideoEncoder
            //This class has the same ability to fire event events defined in the base class
            //var videoEncoder = new DerivedVideoEncoder();

            //Create Mailservice and MessageService objects to notify by email and Text when we recive
            //VideoEncoded even from Event Handler in VideoEncoder class
            //These are the event subscribers objects which will be notified when event accurs
            var mailService = new MailService();
            var messageService = new MessageService();

            //Now lets do the subscription so that the VideoEncoder class will know about the subscribers
            //And it will notify them when video encoding is finished so that they can continue their task
            //That is sending email and Text
            //Here the delegate is pointing to method onVideoEncoded in Mail and Message services
            videoEncoder.VideoEncoded += messageService.onVideoEncoded;
            videoEncoder.VideoEncoded += mailService.onVideoEncoded;

            //After subscribing the objects to the EventHandler in the Encoder class then
            //Encode the video by calling the method in the VideoEncoder class
            videoEncoder.Encode(v1);

            Console.ReadKey();

        }
    }
}
