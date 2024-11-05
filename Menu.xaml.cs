using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Celltech
{
 
    public partial class Menu : Window
    {
        private bool isMaximized = true;
        private TextBlock? maximizeIcon;

        public Menu()
        {
            InitializeComponent();
            this.SourceInitialized += Window_SourceInitialized!;

            // Iniciar maximizado
            WindowState = WindowState.Maximized;

            // Configurar dimensiones
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            this.MaxWidth = screenWidth;
            this.MaxHeight = screenHeight;
            this.Width = screenWidth;
            this.Height = screenHeight;

            // Inicializar el ícono de maximizar
            maximizeIcon = FindName("MaximizeIcon") as TextBlock;
            if (maximizeIcon != null)
            {
                maximizeIcon.Text = "❐";
            }
        }

        private void CenterWindow()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double left = (screenWidth - this.Width) / 2;
            double top = (screenHeight - this.Height) / 2;

            this.Left = left;
            this.Top = top;
        }

        #region Botones de control de ventana
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized)
            {
                // Restaurar
                WindowState = WindowState.Normal;
                Width = 1080;
                Height = 720;
                CenterWindow();
                isMaximized = false;

                if (maximizeIcon != null)
                {
                    maximizeIcon.Text = "☐";
                }
            }
            else
            {
                // Maximizar
                WindowState = WindowState.Maximized;
                isMaximized = true;

                if (maximizeIcon != null)
                {
                    maximizeIcon.Text = "❐";
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Funcionalidad de arrastre y redimensionamiento
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void Window_SourceInitialized(object? sender, EventArgs e)
        {
            var handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle)?.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST && WindowState != WindowState.Maximized)
            {
                int x = (int)((uint)lParam & 0xFFFF);
                int y = (int)((uint)lParam >> 16);
                Point point = PointFromScreen(new Point(x, y));

                double width = ActualWidth;
                double height = ActualHeight;
                const int borderWidth = 5;

                if (point.X <= borderWidth)
                {
                    if (point.Y <= borderWidth)
                    {
                        handled = true;
                        return (IntPtr)HTTOPLEFT;
                    }
                    if (point.Y >= height - borderWidth)
                    {
                        handled = true;
                        return (IntPtr)HTBOTTOMLEFT;
                    }
                    handled = true;
                    return (IntPtr)HTLEFT;
                }
                if (point.X >= width - borderWidth)
                {
                    if (point.Y <= borderWidth)
                    {
                        handled = true;
                        return (IntPtr)HTTOPRIGHT;
                    }
                    if (point.Y >= height - borderWidth)
                    {
                        handled = true;
                        return (IntPtr)HTBOTTOMRIGHT;
                    }
                    handled = true;
                    return (IntPtr)HTRIGHT;
                }
                if (point.Y <= borderWidth)
                {
                    handled = true;
                    return (IntPtr)HTTOP;
                }
                if (point.Y >= height - borderWidth)
                {
                    handled = true;
                    return (IntPtr)HTBOTTOM;
                }
            }
            return IntPtr.Zero;
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Inventario menuWindow = new Inventario();
            menuWindow.Show(); // Muestra el menú
            this.Close();
        }
    }
}
