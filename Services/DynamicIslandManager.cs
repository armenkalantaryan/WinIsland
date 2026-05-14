using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;

namespace WinIsland.Services;

public enum IslandContentType
{
    Music,
    Timer,
    Recording,
    Hotspot,
    Notification,
    Call
}

public class IslandContent
{
    public IslandContentType Type { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Icon { get; set; }
    public Dictionary<string, object> Data { get; set; } = [];
}

public class DynamicIslandManager
{
    private static DynamicIslandManager? _instance;
    private Queue<IslandContent> contentQueue;
    private IslandContent? currentContent;

    public event EventHandler<IslandContent>? ContentChanged;

    private DynamicIslandManager()
    {
        contentQueue = new Queue<IslandContent>();
    }

    public static DynamicIslandManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DynamicIslandManager();
            }
            return _instance;
        }
    }

    public void ShowContent(IslandContent content)
    {
        if (currentContent != null)
        {
            contentQueue.Enqueue(content);
        }
        else
        {
            currentContent = content;
            ContentChanged?.Invoke(this, content);
        }
    }

    public void ShowNotification(string title, string description, string icon = "ℹ")
    {
        var content = new IslandContent
        {
            Type = IslandContentType.Notification,
            Title = title,
            Description = description,
            Icon = icon,
            Data = new Dictionary<string, object>()
        };
        ShowContent(content);
    }

    public void ShowMusic(string title, double progress = 0, bool isPlaying = true)
    {
        var content = new IslandContent
        {
            Type = IslandContentType.Music,
            Title = "Playing",
            Description = title,
            Icon = isPlaying ? "▶" : "⏸",
            Data = new Dictionary<string, object>
            {
                { "Progress", progress },
                { "IsPlaying", isPlaying }
            }
        };
        ShowContent(content);
    }

    public void ShowTimer(int remainingSeconds)
    {
        int minutes = remainingSeconds / 60;
        int seconds = remainingSeconds % 60;

        var content = new IslandContent
        {
            Type = IslandContentType.Timer,
            Title = "Timer",
            Description = $"{minutes:D2}:{seconds:D2}",
            Icon = "⏱",
            Data = new Dictionary<string, object>
            {
                { "RemainingSeconds", remainingSeconds }
            }
        };
        ShowContent(content);
    }

    public void ShowRecording(int durationSeconds)
    {
        int minutes = durationSeconds / 60;
        int seconds = durationSeconds % 60;

        var content = new IslandContent
        {
            Type = IslandContentType.Recording,
            Title = "Recording",
            Description = $"{minutes:D2}:{seconds:D2}",
            Icon = "●",
            Data = new Dictionary<string, object>
            {
                { "Duration", durationSeconds }
            }
        };
        ShowContent(content);
    }

    public void ShowCall(string contactName, string status = "Incoming")
    {
        var content = new IslandContent
        {
            Type = IslandContentType.Call,
            Title = status,
            Description = contactName,
            Icon = "☎",
            Data = new Dictionary<string, object>
            {
                { "Status", status }
            }
        };
        ShowContent(content);
    }

    public void ClearCurrent()
    {
        currentContent = null;
        if (contentQueue.Count > 0)
        {
            currentContent = contentQueue.Dequeue();
            ContentChanged?.Invoke(this, currentContent);
        }
        else
        {
            ContentChanged?.Invoke(this, null);
        }
    }

    public IslandContent? GetCurrent()
    {
        return currentContent;
    }
}
