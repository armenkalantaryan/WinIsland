# 🚀 WinIsland - Getting Started Guide

## What You Have

A complete Dynamic Island implementation for Windows that mimics iOS behavior with full customization.

## 🎬 Quick Start (5 Minutes)

### 1. Launch the Application
```
Press F5 in Visual Studio
or
Click the "Run" button
```

You'll see the Dynamic Island appear at the top center of your screen.

### 2. Interact with It
- **Hover over it** → Island expands smoothly
- **Move mouse away** → Island collapses back
- **Click on it** → Toggle between expanded and compact
- **Click Play/Pause** → Control music playback
- **Click Skip** → Jump to next track

### 3. See It in Action
The island shows:
- 🟢 Green dot (indicator)
- Text label
- On hover: Full player with controls, progress bar, time display

## 📦 What's Included

### Core Files
- `MainWindow.xaml` - UI Design
- `MainWindow.xaml.cs` - Island Logic
- `Services/DynamicIslandManager.cs` - Content Manager
- `Models/ContentModels.cs` - Data Types

### Documentation
- `README.md` - Feature Overview
- `DEVELOPER_GUIDE.md` - Detailed Documentation
- `PROJECT_SUMMARY.md` - Complete Summary
- `CONFIG.cs` - Configuration Reference

### Examples
- `Examples/DynamicIslandExamples.cs` - Usage Patterns

## 🎨 Customization (Easy)

### Change Colors
Edit `MainWindow.xaml`:

```xaml
<!-- Find these lines and change hex values -->
<Border Background="#1A1A1A">        <!-- Change to any hex color -->
<TextBlock Foreground="#00D084">     <!-- Change accent color -->
```

Popular colors:
- Dark: `#1A1A1A`
- Blue: `#0078D4`
- Green: `#107C10`
- Purple: `#7B2CBF`
- Red: `#D13438`

### Change Size
Edit `MainWindow.xaml.cs`, look for:

```csharp
private const int COMPACT_WIDTH = 260;      // Default compact width
private const int COMPACT_HEIGHT = 80;      // Default compact height
private const int EXPANDED_WIDTH = 380;     // Default expanded width
private const int EXPANDED_HEIGHT = 220;    // Default expanded height
```

Make it bigger:
- Increase all values by 50px (comfortable)
- Increase all values by 100px (very large)

### Change Animation Speed
Still in `MainWindow.xaml.cs`:

```csharp
private const int ANIMATION_DURATION_MS = 300;
```

- `200` = Very fast
- `300` = Normal (default)
- `500` = Slow and smooth

### Move Position
Find in `MainWindow.xaml.cs`:

```csharp
int y = 10; // Distance from top (pixels)
```

- `10` = Very top (default)
- `30` = A bit lower
- `100` = More visible from content

After any change:
1. Save file (Ctrl+S)
2. Rebuild (Ctrl+Shift+B)
3. Run (F5)

## 💻 Use in Your Code

### Show Music
```csharp
using WinIsland.Services;

var manager = DynamicIslandManager.Instance;
manager.ShowMusic("Artist - Song Name", 50, true);
```

### Show Notification
```csharp
manager.ShowNotification("Title", "Your message here", "🔔");
```

### Show Timer
```csharp
manager.ShowTimer(300); // 5 minutes in seconds
```

### Show Recording
```csharp
manager.ShowRecording(120); // 2 minutes duration
```

### Show Call
```csharp
manager.ShowCall("Contact Name", "Incoming");
```

## 📁 File Organization

```
WinIsland/
├── MainWindow.xaml           ← Change appearance here
├── MainWindow.xaml.cs        ← Change behavior here
├── Services/
│   └── DynamicIslandManager.cs  ← Use this in your code
├── Models/
│   └── ContentModels.cs      ← Data types
├── Themes/
│   └── IslandThemes.cs       ← Color schemes
└── Examples/
    └── DynamicIslandExamples.cs  ← See examples
```

## 🔄 Basic Workflow

### For UI Changes
1. Edit `MainWindow.xaml`
2. Rebuild: Ctrl+Shift+B
3. Run: F5

### For Behavior Changes
1. Edit `MainWindow.xaml.cs`
2. Rebuild: Ctrl+Shift+B
3. Run: F5

### For Content Display
1. Edit your application code
2. Use `DynamicIslandManager.Instance`
3. Call `ShowMusic()`, `ShowNotification()`, etc.
4. Run your application

## 🎯 Common Tasks

### Make it Dark (Default)
Already done! ✓

### Make it Light
Edit `MainWindow.xaml`:
```xaml
<Border Background="#F5F5F5">  <!-- Light background -->
<TextBlock Foreground="#0078D4"> <!-- Blue text -->
```

### Make it Very Large
Edit `MainWindow.xaml.cs`:
```csharp
private const int COMPACT_WIDTH = 350;
private const int COMPACT_HEIGHT = 120;
private const int EXPANDED_WIDTH = 480;
private const int EXPANDED_HEIGHT = 300;
```

### Make Animation Super Smooth
Edit `MainWindow.xaml.cs`:
```csharp
private const int ANIMATION_DURATION_MS = 500; // Smooth 500ms
```

### Make It Respond Instantly
Edit `MainWindow.xaml.cs`:
```csharp
private const int ANIMATION_DURATION_MS = 150; // Instant 150ms
```

### Show Music from Your Player
```csharp
// In your media player's play event
void OnMediaPlay(string artistName, string songName)
{
    var manager = DynamicIslandManager.Instance;
    manager.ShowMusic($"{artistName} - {songName}", 0, true);
}

// When progress updates
void OnProgressUpdate(double percentage)
{
    manager.ShowMusic(currentTrackName, percentage, true);
}
```

## ✅ Verification

### Island appears
- ✓ At top center of screen
- ✓ Dark appearance
- ✓ Rounded corners
- ✓ Green indicator dot

### Island responds
- ✓ Expands on hover
- ✓ Collapses on mouse leave
- ✓ Toggles on click
- ✓ Shows music controls

### Music player works
- ✓ Play/Pause button toggles
- ✓ Progress bar moves
- ✓ Time updates
- ✓ Skip button changes track

## 🆘 Troubleshooting

### Island doesn't appear
- Ensure application is running (F5)
- Check if window is hidden (shouldn't happen)
- Rebuild project (Ctrl+Shift+B)

### Animations are choppy
- Increase `ANIMATION_DURATION_MS`
- Close other applications
- Update graphics drivers

### Content doesn't show
- Ensure you're using `DynamicIslandManager.Instance`
- Check code is on main thread
- Use `DispatcherQueue.TryEnqueue()` if needed

### Colors don't change
- Make sure to save (Ctrl+S)
- Rebuild (Ctrl+Shift+B)
- Run (F5)
- Use valid hex colors

## 📚 Learn More

- **README.md** - Feature list and capabilities
- **DEVELOPER_GUIDE.md** - Complete reference
- **PROJECT_SUMMARY.md** - Overview
- **Examples/DynamicIslandExamples.cs** - Code examples
- **CONFIG.cs** - All settings reference

## 🎓 Next Steps

1. ✅ Run the application
2. ✅ Play with expand/collapse
3. ✅ Change colors (optional)
4. ✅ Change sizes (optional)
5. ✅ Look at examples
6. ✅ Integrate into your app

## 🌟 Key Concepts

- **Island** = The rounded box at top of screen
- **Compact** = Small state (just icon + text)
- **Expanded** = Large state (full content with controls)
- **Manager** = `DynamicIslandManager` - controls what shows
- **Animation** = Smooth transition between compact/expanded

## 💡 Tips

- Island updates in real-time with `DynamicIslandManager`
- Multiple content types can be queued
- Colors use hex format (like web colors)
- Sizes are in pixels
- Animation in milliseconds

## 🚀 Ready!

You're all set! The Dynamic Island is ready to use:

1. **Run it**: F5
2. **Play with it**: Hover and click
3. **Customize it**: Edit colors and sizes
4. **Integrate it**: Use in your applications
5. **Extend it**: Add new content types

---

**Questions?** Check the documentation files:
- Quick questions → README.md
- Detailed help → DEVELOPER_GUIDE.md
- Code examples → Examples/DynamicIslandExamples.cs
