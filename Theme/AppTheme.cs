using MudBlazor;

public static class AppTheme
{
    public static MudTheme MyTheme = new MudTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#CA252B",
            Secondary = "#94A3B8",
            Success = "#22C55E",
            Warning = "#EAB308",

            Background = "#F8FAFC",
            Surface = "#FFFFFF",

            AppbarBackground = "#CA252B",
            AppbarText = "#FFFFFF",

            DrawerBackground = "#FFFFFF",
            DrawerText = "#1E293B",

            TextPrimary = "#1E293B",
            TextSecondary = "#64748B",
        },

        Typography = new Typography()
        {
            Default = new DefaultTypography()
            {
                FontFamily = new[] { "Inter", "sans-serif" }
            }
        }
    };
}