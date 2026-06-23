using System.IO;
using System.Text.Json;
using ReadCity.DataAccess.Models;

namespace ReadCity.Desktop.Services
{
    /// <summary>
    /// Данные о текущем пользователе, сохраняемые в настройках приложения.
    /// </summary>
    public class CurrentUserSettings
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;
    }

    /// <summary>
    /// Сохраняет и загружает настройки приложения для текущего пользователя.
    /// </summary>
    public static class AppSettings
    {
        private static readonly string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Читай город", "settings.json");

        public static void SaveCurrentUser(User user)
        {
            var settings = new CurrentUserSettings
            {
                UserId = user.Id,
                FullName = user.FullName,
                RoleName = user.RoleName ?? string.Empty
            };

            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)!);
            File.WriteAllText(SettingsPath, JsonSerializer.Serialize(settings));
        }

        public static CurrentUserSettings? LoadCurrentUser()
        {
            if (!File.Exists(SettingsPath))
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<CurrentUserSettings>(File.ReadAllText(SettingsPath));
            }
            catch
            {
                return null;
            }
        }

        public static void ClearCurrentUser()
        {
            if (File.Exists(SettingsPath))
            {
                File.Delete(SettingsPath);
            }
        }
    }
}
