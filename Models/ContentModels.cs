using System;
using Microsoft.UI.Xaml;

namespace WinIsland.Models;

public class NotificationContent
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public Action? ActionCallback { get; set; }
}

public class MusicContent
{
    public string? Artist { get; set; }
    public string? Title { get; set; }
    public string? Album { get; set; }
    public double Progress { get; set; }
    public bool IsPlaying { get; set; }
    public TimeSpan CurrentTime { get; set; }
    public TimeSpan Duration { get; set; }

    public string DisplayText => $"{Artist} - {Title}";
}

public class TimerContent
{
    public TimeSpan RemainingTime { get; set; }
    public string DisplayText => $"{(int)RemainingTime.TotalMinutes:D2}:{RemainingTime.Seconds:D2}";
}

public class RecordingContent
{
    public TimeSpan Duration { get; set; }
    public string DisplayText => $"{(int)Duration.TotalMinutes:D2}:{Duration.Seconds:D2}";
    public bool IsRecording { get; set; }
}

public class CallContent
{
    public string? ContactName { get; set; }
    public string? ContactNumber { get; set; }
    public string? Status { get; set; }
    public bool IsIncoming { get; set; }
}
