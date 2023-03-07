using System.Reflection;

namespace ListViewBinding.ViewModels
{
    public sealed class NamedColor
    {
        static readonly List<NamedColor> _colors = new List<NamedColor>();

        static NamedColor()
        {
            foreach (FieldInfo info in typeof(Colors).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (info.FieldType == typeof(Color))
                {
                    _colors.Add(new(info.Name, (Color)info.GetValue(null)));
                }
            }
        }

        public static IEnumerable<NamedColor> Colors
        {
            get => _colors;
        }

        NamedColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public Color Color
        {
            get;
        }

        public string Name
        {
            get;
        }
    }
}
