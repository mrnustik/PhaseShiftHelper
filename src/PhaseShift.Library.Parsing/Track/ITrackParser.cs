namespace PhaseShift.Library.Parsing.Track
{
    public interface ITrackParser
    {
        Models.Track Parse(string text);
    }
}