using Microsoft.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using WinRT.Interop;

namespace WinIsland;

public sealed partial class MainWindow : Window
{
    private AppWindow? appWindow;
    private bool isExpanded = false;
    private DispatcherTimer? updateTimer;
    private bool isPlaying = true;
    private double musicProgress = 45;
    private const int EXPANDED_WIDTH = 380;
    private const int EXPANDED_HEIGHT = 220;
    private const int COMPACT_WIDTH = 260;
    private const int COMPACT_HEIGHT = 80;
    private const int ANIMATION_DURATION_MS = 300;

    public MainWindow()
    {
        this.InitializeComponent();
        SetupIslandWindow();
        InitializeStatusUpdater();

        // Show entrance animation after initialization
        DispatcherQueue.TryEnqueue(() => PlayEntranceAnimation());
    }

    private void SetupIslandWindow()
    {
        try
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            appWindow = AppWindow.GetFromWindowId(windowId);

            // Configure window
            if (appWindow?.Presenter is OverlappedPresenter presenter)
            {
                presenter.IsResizable = false;
                presenter.IsMaximizable = false;
                presenter.IsMinimizable = false;
                presenter.SetBorderAndTitleBar(false, false);
            }

            // Extend content into title bar
            if (appWindow != null)
            {
                appWindow.TitleBar.ExtendsContentIntoTitleBar = true;

                // Position at top center
                var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
                var workArea = displayArea.WorkArea;

                int x = (workArea.Width / 2) - (COMPACT_WIDTH / 2);
                int y = 10;

                appWindow.MoveAndResize(new Windows.Graphics.RectInt32(x, y, COMPACT_WIDTH, COMPACT_HEIGHT));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in SetupIslandWindow: {ex.Message}");
        }
    }

    private void InitializeStatusUpdater()
    {
        updateTimer = new DispatcherTimer();
        updateTimer.Interval = TimeSpan.FromSeconds(1);
        updateTimer.Tick += (s, e) => UpdateStatus();
        updateTimer.Start();
    }

    private void PlayEntranceAnimation()
    {
        try
        {
            // Create entrance animation programmatically
            var opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(300)),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var translateAnimation = new DoubleAnimation
            {
                From = -20,
                To = 0,
                Duration = new Duration(TimeSpan.FromMilliseconds(300)),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var storyboard = new Storyboard();

            if (Island != null)
            {
                Storyboard.SetTarget(opacityAnimation, Island);
                Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
                storyboard.Children.Add(opacityAnimation);

                Storyboard.SetTarget(translateAnimation, Island);
                Storyboard.SetTargetProperty(translateAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
                storyboard.Children.Add(translateAnimation);

                storyboard.Begin();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in PlayEntranceAnimation: {ex.Message}");
        }
    }

    private void UpdateStatus()
    {
        try
        {
            // Update time
            if (TimeStatus != null)
                TimeStatus.Text = DateTime.Now.ToString("HH:mm");

            // Update progress if playing
            if (isPlaying && musicProgress < 100 && ProgressBar != null && TimeDisplay != null)
            {
                musicProgress += 0.5;
                if (musicProgress > 100) musicProgress = 100;
                ProgressBar.Value = musicProgress;

                // Update time display
                int totalSeconds = 205; // 3:25 in seconds
                int currentSeconds = (int)(totalSeconds * (musicProgress / 100));
                int minutes = currentSeconds / 60;
                int seconds = currentSeconds % 60;
                TimeDisplay.Text = $"{minutes}:{seconds:D2} / 3:25";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in UpdateStatus: {ex.Message}");
        }
    }

    private void Island_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        if (!isExpanded)
        {
            ExpandIsland();
        }
    }

    private void Island_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        if (isExpanded)
        {
            CollapseIsland();
        }
    }

    private void Island_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        // Toggle expand/collapse on click
        if (isExpanded)
        {
            CollapseIsland();
        }
        else
        {
            ExpandIsland();
        }
    }

    private void ExpandIsland()
    {
        isExpanded = true;

        // Switch visibility
        CompactState.Visibility = Visibility.Collapsed;
        ExpandedState.Visibility = Visibility.Visible;

        // Create size animation
        var sizeStoryboard = new Storyboard();

        // Width animation
        var widthAnimation = new DoubleAnimation
        {
            From = Island.Width,
            To = EXPANDED_WIDTH,
            Duration = new Duration(TimeSpan.FromMilliseconds(ANIMATION_DURATION_MS)),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        };
        Storyboard.SetTarget(widthAnimation, Island);
        Storyboard.SetTargetProperty(widthAnimation, "Width");
        sizeStoryboard.Children.Add(widthAnimation);

        // Height animation
        var heightAnimation = new DoubleAnimation
        {
            From = Island.Height,
            To = EXPANDED_HEIGHT,
            Duration = new Duration(TimeSpan.FromMilliseconds(ANIMATION_DURATION_MS)),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        };
        Storyboard.SetTarget(heightAnimation, Island);
        Storyboard.SetTargetProperty(heightAnimation, "Height");
        sizeStoryboard.Children.Add(heightAnimation);

        sizeStoryboard.Begin();

        // Update app window
        UpdateWindowSize(EXPANDED_WIDTH, EXPANDED_HEIGHT);
    }

    private void CollapseIsland()
    {
        isExpanded = false;

        // Switch visibility
        CompactState.Visibility = Visibility.Visible;
        ExpandedState.Visibility = Visibility.Collapsed;

        // Create size animation
        var sizeStoryboard = new Storyboard();

        // Width animation
        var widthAnimation = new DoubleAnimation
        {
            From = Island.Width,
            To = COMPACT_WIDTH,
            Duration = new Duration(TimeSpan.FromMilliseconds(ANIMATION_DURATION_MS)),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        };
        Storyboard.SetTarget(widthAnimation, Island);
        Storyboard.SetTargetProperty(widthAnimation, "Width");
        sizeStoryboard.Children.Add(widthAnimation);

        // Height animation
        var heightAnimation = new DoubleAnimation
        {
            From = Island.Height,
            To = COMPACT_HEIGHT,
            Duration = new Duration(TimeSpan.FromMilliseconds(ANIMATION_DURATION_MS)),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        };
        Storyboard.SetTarget(heightAnimation, Island);
        Storyboard.SetTargetProperty(heightAnimation, "Height");
        sizeStoryboard.Children.Add(heightAnimation);

        sizeStoryboard.Begin();

        // Update app window
        UpdateWindowSize(COMPACT_WIDTH, COMPACT_HEIGHT);
    }

    private void UpdateWindowSize(int width, int height)
    {
        try
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            appWindow = AppWindow.GetFromWindowId(windowId);
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
            var workArea = displayArea.WorkArea;

            int x = (workArea.Width / 2) - (width / 2);
            int y = 10;

            appWindow?.MoveAndResize(new Windows.Graphics.RectInt32(x, y, width, height));
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in UpdateWindowSize: {ex.Message}");
        }
    }

    private void PlayPauseBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            isPlaying = !isPlaying;
            if (PlayPauseBtn != null)
                PlayPauseBtn.Content = isPlaying ? "⏸" : "▶";
            if (CompactIcon != null)
                CompactIcon.Text = isPlaying ? "▶" : "●";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in PlayPauseBtn_Click: {ex.Message}");
        }
    }

    private void SkipBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Reset music
            musicProgress = 0;
            if (ProgressBar != null)
                ProgressBar.Value = 0;
            if (TimeDisplay != null)
                TimeDisplay.Text = "0:00 / 3:25";
            if (ExpandedText != null)
                ExpandedText.Text = "Eminem - Without Me";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in SkipBtn_Click: {ex.Message}");
        }
    }
}
