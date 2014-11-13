namespace Beddit.Net.Model
{
    public abstract class BedditTimeValueTrack<T>
    {
        public double TimeStamp { get; set; }
        public T Event { get; set; }
    }
}