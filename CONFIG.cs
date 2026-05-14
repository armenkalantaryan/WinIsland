// Configuration settings for WinIsland Dynamic Island

// ======================
// WINDOW POSITIONING
// ======================

/// Distance from top of screen (pixels)
const int TOP_OFFSET = 10;

/// Distance from left edge when centered
// Calculated automatically: (screenWidth / 2) - (windowWidth / 2)

// ======================
// SIZING
// ======================

/// Compact state dimensions
const int COMPACT_WIDTH = 260;
const int COMPACT_HEIGHT = 80;

/// Expanded state dimensions
const int EXPANDED_WIDTH = 380;
const int EXPANDED_HEIGHT = 220;

/// Corner radius for rounded effect
const int CORNER_RADIUS = 40;

// ======================
// ANIMATIONS
// ======================

/// Duration of expand/collapse animations (milliseconds)
const int ANIMATION_DURATION_MS = 300;

/// Easing function for animations
// Use: CubicEase with EasingMode.EaseOut

// ======================
// COLORS (Default Dark Theme)
// ======================

/// Main background color (hex)
const string BACKGROUND_COLOR = "#1A1A1A";

/// Accent/highlight color (hex)
const string ACCENT_COLOR = "#00D084";

/// Primary text color (hex)
const string TEXT_COLOR = "#FFFFFF";

/// Secondary text color (hex)
const string SECONDARY_TEXT = "#CCCCCC";

/// Dim/tertiary text color (hex)
const string DIM_TEXT = "#888888";

/// Border color (hex)
const string BORDER_COLOR = "#333333";

// ======================
// CONTENT SETTINGS
// ======================

/// Maximum items in content queue
const int MAX_QUEUE_SIZE = 10;

/// Auto-hide timeout for notifications (seconds)
/// Set to 0 to disable auto-hide
const int NOTIFICATION_TIMEOUT_SEC = 0;

// ======================
// STATUS INDICATORS
// ======================

/// Show time in status bar
const bool SHOW_TIME = true;

/// Show battery indicator
const bool SHOW_BATTERY = true;

/// Show signal indicator
const bool SHOW_SIGNAL = true;

/// Update status every (milliseconds)
const int STATUS_UPDATE_INTERVAL_MS = 1000;

// ======================
// BEHAVIOR
// ======================

/// Expand island on pointer hover
const bool EXPAND_ON_HOVER = true;

/// Allow collapse by clicking
const bool ALLOW_CLICK_TOGGLE = true;

/// Collapse island on pointer exit
const bool COLLAPSE_ON_EXIT = true;

/// Always stay on top of other windows
const bool ALWAYS_ON_TOP = true;

/// Allow window dragging/repositioning
const bool ALLOW_DRAG = false; // Feature for future release

// ======================
// MUSIC PLAYER
// ======================

/// Progress auto-increment speed (percentage per second)
/// Only when isPlaying = true
const double PROGRESS_INCREMENT = 0.5;

/// Total track duration (seconds) - for demo
const int DEMO_TRACK_DURATION = 205; // 3:25

// ======================
// DEBUG SETTINGS
// ======================

/// Enable debug console output
const bool DEBUG_MODE = false;

/// Log all content changes
const bool LOG_CONTENT_CHANGES = false;

/// Show performance metrics
const bool SHOW_PERFORMANCE = false;

// ======================
// HOW TO MODIFY
// ======================

// 1. COLORS: Edit hex values above
//    Example: "#1A1A1A" = dark gray
//
// 2. SIZES: Change COMPACT_WIDTH, EXPANDED_WIDTH, etc.
//    Pixels are used throughout
//
// 3. ANIMATION: Adjust ANIMATION_DURATION_MS
//    Higher = slower animation
//    Lower = faster animation
//
// 4. BEHAVIOR: Toggle boolean constants
//    true = feature enabled
//    false = feature disabled

// ======================
// THEME COLOR PALETTES
// ======================

// LIGHT THEME
// Background: #F5F5F5
// Accent: #0078D4
// Text: #000000
// Dim: #666666

// NEON THEME
// Background: #0D0221
// Accent: #3A86FF
// Text: #FB5607
// Dim: #8338EC

// MATERIAL THEME
// Background: #121212
// Accent: #BB86FC
// Text: #FFFBFE
// Dim: #938F99

// MINIMAL THEME
// Background: #FAFAFA
// Accent: #404040
// Text: #202020
// Dim: #8A8A8A

// HIGH CONTRAST THEME
// Background: #000000
// Accent: #FFFF00
// Text: #FFFFFF
// Dim: #FFFFFF

// ======================
// QUICK CUSTOMIZATION GUIDE
// ======================

// TO CHANGE THEME:
// 1. Find your theme colors above
// 2. Copy hex values
// 3. Paste into MainWindow.xaml Background/Foreground properties
// 4. Rebuild and run

// TO MAKE IT BIGGER:
// 1. Increase COMPACT_WIDTH and COMPACT_HEIGHT
// 2. Increase EXPANDED_WIDTH and EXPANDED_HEIGHT
// 3. Proportionally increase CORNER_RADIUS
// 4. Rebuild and run

// TO MAKE ANIMATIONS FASTER:
// 1. Decrease ANIMATION_DURATION_MS
// 2. Example: 300ms (default) -> 200ms (faster)
// 3. Rebuild and run

// TO MOVE POSITION:
// 1. Change TOP_OFFSET value
// 2. Higher value = lower on screen
// 3. Rebuild and run
