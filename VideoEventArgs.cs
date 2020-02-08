using System;
namespace EventsDelegates
{
    //We can also create our own VideoEventArgs
    //This holds message about the event in this case the Title of the video encoded
    //So that the notified methods can utilize this data for further processing
    public class VideoEventArgs : EventArgs
    {
        public Video video { get; set; }
    }
}
