using System;
using System.Threading;
namespace EventsDelegates
{
    /*Delegates and events enables the VideoEncoder and other logic to be loosely coupled
     for example if we want another way of notifying for example SMSService then we dont need to 
     do any modification in the VideoEncoder class. We just need to subscribe the method in SMSService class
     to the evnent in this class--like wise to MessageService and MailService
   */
    public class VideoEncoder
    {
        //Define delegate and event of type of the defined delegate
        //public delegate void VideoEncodedEventHandler(Object source, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;

        //Instead of using the above lines of code we can use single line of code as follows
        //But the first way is also fine---this is just to save key strokes
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            //Impliment video encoding logic
            Console.WriteLine("Encoding video...");

            //To simulate video encoding just wait 3 sec using thread
            Thread.Sleep(3000);

            //After completing the encoding fire the event declaed above
            //When a mose is clicked a click event accours and in this case
            //when video encoding is completed a VideoEncoded event is fired
            //and all other methods that are subscribed to this event are notified
            onVideoEncoded(video);
        }

        //Event handlers should be protected and virtual
        //This enables drived classes to fire this event as well
        //The dervied classes can  override this method 
        protected virtual void onVideoEncoded(Video video)
        {
            //If there are  subscribers to the event then notify them using the delegate
            //The videoEncoded is pointing to the methods subscribed
            //These methods should have matching parameters with the event handler
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() {video = video});
        }
    }

    //We can also create our own VideoEventArgs
    //This holds message about the event in this case the Title of the video encoded
    //So that the notified methods can utilize this data for further processing
    public class VideoEventArgs : EventArgs
    {
        public Video video { get; set; }
    }


    //The dervived classes of VideoEncoder can also use the event handler
    //Because it is declared as virtual in Base class
    class DerivedVideoEncoder : VideoEncoder
    {
        protected override void onVideoEncoded(Video video)
        {
            //Do something private to this class
            Console.WriteLine("The derived class have done some thing...");

            //And then Call base class method to fire the event
            base.onVideoEncoded(video);
        }
    }
}
