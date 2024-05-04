namespace GeoServerNet.Client.Enums;

public enum TaskProcessState
{
    Inactive,
    Sending,
    Running,
    Paused,
    Completed,
    Terminated,
    ConfigureStarted,
    ConfigureCompleted,
    SendingCompleted,
    Deleted,
    Archiving,
    Downloading
}