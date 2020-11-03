using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using Avalonia.Media;

namespace Example
{
    public class MainWindow : Window
    {
        Button[] buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new[] { "Red", "Green", "Blue" }
                .Select(s => this.FindControl<Button>(s + " button"))
                .ToArray();
            foreach (Button b in buttons)
            {
                var bg = b.Background;
                b.Click += (sender, e) => {
                    foreach (Button b in buttons) 
                        b.Background = bg;
                };
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}