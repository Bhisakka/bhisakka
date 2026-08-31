using System;
using System.Collections.Generic;
using System.Drawing;

namespace MaterialComponents
{
    /// <summary>Material 3 type-scale roles.</summary>
    public enum LMaterialTypeRole
    {
        DisplayLarge, DisplayMedium, DisplaySmall,
        HeadlineLarge, HeadlineMedium, HeadlineSmall,
        TitleLarge, TitleMedium, TitleSmall,
        BodyLarge, BodyMedium, BodySmall,
        LabelLarge, LabelMedium, LabelSmall
    }

    /// <summary>
    /// Material 3 type scale ported from _material_expressive_theme/Type.kt:
    /// display/headline/title roles use "ABeeZee", body/label roles use
    /// "Architects Daughter". When a font is not installed on the machine the
    /// scale silently falls back to Segoe UI (Semibold for medium-weight roles).
    /// Font sizes follow the M3 baseline scale (sp converted to points).
    /// </summary>
    public static class LMaterialTypography
    {
        private static string _displayFontName = "ABeeZee";
        private static string _bodyFontName = "Architects Daughter";
        private const string FallbackRegular = "Segoe UI";
        private const string FallbackMedium = "Segoe UI Semibold";

        private static readonly Dictionary<string, Font> _cache = new Dictionary<string, Font>();
        private static readonly Dictionary<string, bool> _installed = new Dictionary<string, bool>();

        /// <summary>Font used for display/headline/title roles ("ABeeZee" by default).</summary>
        public static string DisplayFontName
        {
            get { return _displayFontName; }
            set { _displayFontName = value; ClearCache(); }
        }

        /// <summary>Font used for body/label roles ("Architects Daughter" by default).</summary>
        public static string BodyFontName
        {
            get { return _bodyFontName; }
            set { _bodyFontName = value; ClearCache(); }
        }

        private static void ClearCache()
        {
            _cache.Clear();
            _installed.Clear();
        }

        private static bool IsInstalled(string family)
        {
            bool result;
            if (_installed.TryGetValue(family, out result)) return result;
            try { using (new FontFamily(family)) result = true; }
            catch { result = false; }
            _installed[family] = result;
            return result;
        }

        /// <summary>Gets the cached font for an M3 type role. Do not dispose the returned font.</summary>
        public static Font Get(LMaterialTypeRole role)
        {
            bool display, medium;
            float sp;
            switch (role)
            {
                case LMaterialTypeRole.DisplayLarge: display = true; medium = false; sp = 57f; break;
                case LMaterialTypeRole.DisplayMedium: display = true; medium = false; sp = 45f; break;
                case LMaterialTypeRole.DisplaySmall: display = true; medium = false; sp = 36f; break;
                case LMaterialTypeRole.HeadlineLarge: display = true; medium = false; sp = 32f; break;
                case LMaterialTypeRole.HeadlineMedium: display = true; medium = false; sp = 28f; break;
                case LMaterialTypeRole.HeadlineSmall: display = true; medium = false; sp = 24f; break;
                case LMaterialTypeRole.TitleLarge: display = true; medium = false; sp = 22f; break;
                case LMaterialTypeRole.TitleMedium: display = true; medium = true; sp = 16f; break;
                case LMaterialTypeRole.TitleSmall: display = true; medium = true; sp = 14f; break;
                case LMaterialTypeRole.BodyLarge: display = false; medium = false; sp = 16f; break;
                case LMaterialTypeRole.BodyMedium: display = false; medium = false; sp = 14f; break;
                case LMaterialTypeRole.BodySmall: display = false; medium = false; sp = 12f; break;
                case LMaterialTypeRole.LabelLarge: display = false; medium = true; sp = 14f; break;
                case LMaterialTypeRole.LabelMedium: display = false; medium = true; sp = 12f; break;
                default: display = false; medium = true; sp = 11f; break; // LabelSmall
            }
            return GetFont(display ? _displayFontName : _bodyFontName, sp * 0.75f, medium);
        }

        /// <summary>Gets a themed font at an arbitrary point size.</summary>
        public static Font GetFont(string preferredFamily, float points, bool medium)
        {
            string key = preferredFamily + "|" + points.ToString("0.##") + "|" + medium;
            Font font;
            if (_cache.TryGetValue(key, out font)) return font;

            string family;
            FontStyle style = FontStyle.Regular;
            if (IsInstalled(preferredFamily))
            {
                family = preferredFamily;
                // Google display/body fonts here ship regular-only; simulate
                // medium weight with GDI bold only for the fallback face.
            }
            else if (medium && IsInstalled(FallbackMedium))
            {
                family = FallbackMedium;
            }
            else
            {
                family = FallbackRegular;
            }

            try { font = new Font(family, points, style, GraphicsUnit.Point); }
            catch { font = new Font(FontFamily.GenericSansSerif, points, style, GraphicsUnit.Point); }
            _cache[key] = font;
            return font;
        }
    }
}
