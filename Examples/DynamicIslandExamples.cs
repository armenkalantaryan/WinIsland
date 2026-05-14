using System;
using System.Threading.Tasks;
using WinIsland.Services;

namespace WinIsland.Examples;

/// <summary>
/// Example usage of the Dynamic Island Manager
/// </summary>
public class DynamicIslandExamples
{
    private readonly DynamicIslandManager manager = DynamicIslandManager.Instance;

    /// <summary>
    /// Example: Display music player island
    /// </summary>
    public void ShowMusicExample()
    {
        manager.ShowMusic("Eminem - Lose Yourself", progress: 45.5, isPlaying: true);
    }

    /// <summary>
    /// Example: Display notification
    /// </summary>
    public void ShowNotificationExample()
    {
        manager.ShowNotification(
            title: "New Message",
            description: "You have a message from John Doe",
            icon: "💬"
        );
    }

    /// <summary>
    /// Example: Display timer (5 minutes)
    /// </summary>
    public void ShowTimerExample()
    {
        manager.ShowTimer(remainingSeconds: 300);
    }

    /// <summary>
    /// Example: Display recording (started 2 minutes ago)
    /// </summary>
    public void ShowRecordingExample()
    {
        manager.ShowRecording(durationSeconds: 120);
    }

    /// <summary>
    /// Example: Display incoming call
    /// </summary>
    public void ShowIncomingCallExample()
    {
        manager.ShowCall(contactName: "Jane Smith", status: "Incoming");
    }

    /// <summary>
    /// Example: Display outgoing call
    /// </summary>
    public void ShowOutgoingCallExample()
    {
        manager.ShowCall(contactName: "Jane Smith", status: "Calling...");
    }

    /// <summary>
    /// Example: Sequential notifications
    /// </summary>
    public async void ShowSequentialNotificationsExample()
    {
        manager.ShowNotification("Download Started", "Downloading file...", "⬇");
        await Task.Delay(3000);

        manager.ShowNotification("Download Complete", "file.zip", "✓");
        await Task.Delay(2000);

        manager.ClearCurrent();
    }

    /// <summary>
    /// Example: Music with progress simulation
    /// </summary>
    public async void SimulateMusicPlaybackExample()
    {
        double progress = 0;
        while (progress < 100)
        {
            manager.ShowMusic("Song - Artist", progress: progress, isPlaying: true);
            await Task.Delay(1000);
            progress += 5;
        }

        manager.ClearCurrent();
    }

    /// <summary>
    /// Example: Countdown timer
    /// </summary>
    public async void CountdownTimerExample()
    {
        int seconds = 60;
        while (seconds > 0)
        {
            manager.ShowTimer(remainingSeconds: seconds);
            await Task.Delay(1000);
            seconds--;
        }

        manager.ShowNotification("Time's Up!", "", "🔔");
        await Task.Delay(2000);
        manager.ClearCurrent();
    }

    /// <summary>
    /// Example: Multiple content types rotating
    /// </summary>
    public async void RotateContentTypesExample()
    {
        // Music
        manager.ShowMusic("The Weeknd - Blinding Lights", progress: 65, isPlaying: true);
        await Task.Delay(4000);

        // Timer
        manager.ShowTimer(remainingSeconds: 180);
        await Task.Delay(4000);

        // Notification
        manager.ShowNotification("Battery Low", "15% remaining", "🔋");
        await Task.Delay(4000);

        // Recording
        manager.ShowRecording(durationSeconds: 45);
        await Task.Delay(4000);

        manager.ClearCurrent();
    }

    /// <summary>
    /// Example: Listening for content changes
    /// </summary>
    public void ListenForChangesExample()
    {
        manager.ContentChanged += (sender, content) =>
        {
            if (content != null)
            {
                Console.WriteLine($"Island updated with: {content.Title}");
            }
            else
            {
                Console.WriteLine("Island cleared");
            }
        };
    }

    /// <summary>
    /// Example: Get current content
    /// </summary>
    public void GetCurrentContentExample()
    {
        var current = manager.GetCurrent();
        if (current != null)
        {
            Console.WriteLine($"Current island content: {current.Title}");
        }
    }
}
