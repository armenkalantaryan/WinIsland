# WinIsland - Dynamic Island for Windows

A sophisticated Dynamic Island implementation for Windows using WinUI 3 and C#, fully replicating iOS Dynamic Island behavior.

## Features

### ✨ Core Features
- **Compact State**: Displays minimal information (icon + title) at top of screen
- **Expanded State**: Full interactive panel with controls and detailed information
- **Smooth Animations**: CubicEase easing for natural expand/collapse transitions
- **Always-on-Top**: Window stays at top center of screen
- **Frameless Window**: No title bar, custom rounded corners
- **Status Indicators**: Time, signal, and battery display

### 🎵 Built-in Scenarios

1. **Music Player**
   - Show currently playing track
   - Play/Pause and Skip controls
   - Progress bar with time display
   - Visual indicator for playing status

2. **Notifications**
   - Display incoming messages
   - Custom icons
   - Expandable content

3. **Timer**
   - Show remaining time
   - MM:SS format
   - Compact display

4. **Recording**
   - Duration display
   - Recording indicator
   - Status feedback

5. **Incoming Calls**
   - Contact name
   - Call status
   - Action buttons

## Usage

### Basic Setup
The main window automatically initializes the Dynamic Island. It starts in compact mode and expands on hover.

```csharp
// The island is already running!
// Just interact with it using your mouse
```

### Programmatic Control

Use the `DynamicIslandManager` to show different content:

```csharp
using WinIsland.Services;

// Get the manager instance
var manager = DynamicIslandManager.Instance;

// Show music
manager.ShowMusic("Artist - Song Title", progressPercentage, isPlaying);

// Show notification
manager.ShowNotification("Title", "Description", "ℹ");

// Show timer
manager.ShowTimer(180); // 3 minutes in seconds

// Show recording
manager.ShowRecording(45); // 45 seconds

// Show call
manager.ShowCall("Contact Name", "Incoming");

// Clear current content
manager.ClearCurrent();
```

## Architecture

### File Structure
```
WinIsland/
├── MainWindow.xaml          - Main UI definition
├── MainWindow.xaml.cs       - Island logic and animations
├── Services/
│   └── DynamicIslandManager.cs   - Content management service
└── Models/
    └── ContentModels.cs     - Data models for different content types
```

### Key Components

#### MainWindow
- Handles window setup and positioning
- Manages expand/collapse animations
- Processes pointer events
- Updates time and progress

#### DynamicIslandManager
- Singleton service for managing island content
- Supports content queue
- Notifies on content changes
- Provides helper methods for different content types

#### Models
- `IslandContent`: Base content wrapper
- `MusicContent`: Music-specific data
- `TimerContent`: Timer-specific data
- `RecordingContent`: Recording-specific data
- `CallContent`: Call-specific data

## Customization

### Appearance
Edit `MainWindow.xaml` to customize:
- Colors: Change `Background="#1A1A1A"` and `Foreground="#00D084"`
- Size: Modify `COMPACT_WIDTH`, `COMPACT_HEIGHT`, `EXPANDED_WIDTH`, `EXPANDED_HEIGHT`
- Shape: Adjust `CornerRadius="40"`

### Animation Speed
Edit constants in `MainWindow.xaml.cs`:
```csharp
private const int ANIMATION_DURATION_MS = 300;
```

### Position
The island is positioned at top center. To change:
```csharp
int y = 10; // Change this value (pixels from top)
```

## Behavior Details

### Expand/Collapse
- **Hover**: Island expands on mouse enter, collapses on mouse leave
- **Click**: Toggle expand/collapse with click
- **Animation**: Smooth 300ms cubic easing

### Content Management
- Queue system for multiple notifications
- Shows current content while others wait
- Automatic transition when content is cleared

### Status Updates
- Time updates every second
- Music progress auto-advances when playing
- All updates happen on main thread via DispatcherQueue

## System Requirements
- Windows 10.0.19041.0 or later
- .NET 8.0
- WinUI 3 (Windows App SDK 2.0)

## Performance Notes
- Lightweight: Single window with efficient animations
- GPU-accelerated: Uses system GPU for smooth rendering
- Memory: Minimal footprint, ~50-100MB depending on content
- CPU: Negligible when idle, minimal during animations

## Future Enhancements
- [ ] Drag to relocate
- [ ] Keyboard shortcuts
- [ ] Multiple content types simultaneously
- [ ] Gesture support
- [ ] Theme customization UI
- [ ] Content persistence

## License
This project demonstrates WinUI 3 capabilities for building modern Windows applications.
