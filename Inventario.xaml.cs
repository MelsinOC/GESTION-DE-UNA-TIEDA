using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Celltech
{
    /// <summary>
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        public Inventario()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            // Inicializar datos de ejemplo
            LoadSampleData();
        }

        #region Window Controls

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Navigation

        private void NavigateToInventory_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }

        private void NavigateToCategories_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void NavigateToPrices_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        #endregion

        #region Product Modal

        private void ShowNewProductModal_Click(object sender, RoutedEventArgs e)
        {
            ShowModal();
        }

        private void CloseProductModal_Click(object sender, RoutedEventArgs e)
        {
            HideModal();
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateProductForm())
            {
                // Guardar producto
                SaveProductData();
                HideModal();
                ClearProductForm();
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Imágenes|*.jpg;*.jpeg;*.png|Todos los archivos|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var image = new BitmapImage(new Uri(openFileDialog.FileName));
                    ProductImage.Source = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void ShowModal()
        {
            ProductModal.Visibility = Visibility.Visible;

            var modalAnimation = new DoubleAnimation
            {
                From = 50,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            ModalTransform.BeginAnimation(TranslateTransform.YProperty, modalAnimation);
        }

        private void HideModal()
        {
            var modalAnimation = new DoubleAnimation
            {
                From = 0,
                To = 50,
                Duration = TimeSpan.FromMilliseconds(200),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };

            modalAnimation.Completed += (s, e) => ProductModal.Visibility = Visibility.Collapsed;
            ModalTransform.BeginAnimation(TranslateTransform.YProperty, modalAnimation);
        }

        private bool ValidateProductForm()
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("El código es requerido", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("El nombre es requerido", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtProductStock.Text) ||
                !int.TryParse(txtProductStock.Text, out _))
            {
                MessageBox.Show("El stock debe ser un número válido", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtProductPrice.Text) ||
                !decimal.TryParse(txtProductPrice.Text, out _))
            {
                MessageBox.Show("El precio debe ser un número válido", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void SaveProductData()
        {
            // Aquí implementarías la lógica para guardar en tu base de datos
            MessageBox.Show("Producto guardado exitosamente", "Éxito",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearProductForm()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductStock.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            cmbProductCategory.SelectedIndex = -1;
            ProductImage.Source = null;
        }

        #endregion

        private void LoadSampleData()
        {
            // Cargar datos de ejemplo para el ComboBox de categorías
            var categories = new[] { "Smartphones", "Accesorios", "Tablets", "Otros" };
            cmbProductCategory.ItemsSource = categories;

          
        }


    }
}
