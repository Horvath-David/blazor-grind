using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace GeneralUI;

public class AppState
{
    public int? UserId { get; set; } = null;
    public string? UserName { get; set; } = null;

    public static AppState Load() =>
        JsonSerializer.Deserialize<AppState>(Preferences.Get("appState", "{}")) ?? new();

    public void Save()
    {
        Preferences.Set("appState", JsonSerializer.Serialize(this));
    }
}
