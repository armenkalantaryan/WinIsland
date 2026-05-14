namespace WinIsland.Themes;

/// <summary>
/// Color schemes and themes for Dynamic Island
/// </summary>
public static class IslandThemes
{
    // Dark Theme (Default)
    public static class Dark
    {
        public const string BackgroundColor = "#1A1A1A";
        public const string AccentColor = "#00D084";
        public const string TextColor = "#FFFFFF";
        public const string SecondaryTextColor = "#CCCCCC";
        public const string DimTextColor = "#888888";
        public const string BorderColor = "#333333";
    }

    // Light Theme
    public static class Light
    {
        public const string BackgroundColor = "#F5F5F5";
        public const string AccentColor = "#0078D4";
        public const string TextColor = "#000000";
        public const string SecondaryTextColor = "#333333";
        public const string DimTextColor = "#666666";
        public const string BorderColor = "#E0E0E0";
    }

    // High Contrast Theme
    public static class HighContrast
    {
        public const string BackgroundColor = "#000000";
        public const string AccentColor = "#FFFF00";
        public const string TextColor = "#FFFFFF";
        public const string SecondaryTextColor = "#FFFFFF";
        public const string DimTextColor = "#FFFFFF";
        public const string BorderColor = "#FFFFFF";
    }

    // Neon Theme
    public static class Neon
    {
        public const string BackgroundColor = "#0D0221";
        public const string AccentColor = "#3A86FF";
        public const string TextColor = "#FB5607";
        public const string SecondaryTextColor = "#FF006E";
        public const string DimTextColor = "#8338EC";
        public const string BorderColor = "#FFBE0B";
    }

    // Minimal Theme
    public static class Minimal
    {
        public const string BackgroundColor = "#FAFAFA";
        public const string AccentColor = "#404040";
        public const string TextColor = "#202020";
        public const string SecondaryTextColor = "#565656";
        public const string DimTextColor = "#8A8A8A";
        public const string BorderColor = "#D9D9D9";
    }

    // Material Theme
    public static class Material
    {
        public const string BackgroundColor = "#121212";
        public const string AccentColor = "#BB86FC";
        public const string TextColor = "#FFFBFE";
        public const string SecondaryTextColor = "#CAC4D0";
        public const string DimTextColor = "#938F99";
        public const string BorderColor = "#49454E";
    }
}

/// <summary>
/// Animation configuration constants
/// </summary>
public static class AnimationSettings
{
    public const int FastAnimationMs = 200;
    public const int NormalAnimationMs = 300;
    public const int SlowAnimationMs = 500;

    public const double CompactWidth = 260;
    public const double CompactHeight = 80;

    public const double ExpandedWidth = 380;
    public const double ExpandedHeight = 220;
}

/// <summary>
/// Icon collection for different scenarios
/// </summary>
public static class IslandIcons
{
    public const string Music = "▶";
    public const string Pause = "⏸";
    public const string Playing = "●";
    public const string Recording = "●";
    public const string Timer = "⏱";
    public const string Call = "☎";
    public const string Message = "💬";
    public const string Battery = "🔋";
    public const string Signal = "📶";
    public const string Time = "⏰";
    public const string Success = "✓";
    public const string Error = "✕";
    public const string Info = "ℹ";
    public const string Download = "⬇";
    public const string Upload = "⬆";
    public const string Share = "↗";
    public const string Notification = "🔔";
}
