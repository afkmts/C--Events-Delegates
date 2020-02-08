using System;

namespace EventsDelegates
{
    //The dervived classes of VideoEncoder can also use the event handler
    //Because it is declared as virtual in Base class 
    //this class can override the event handler method in the base class
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
