using System.Linq;
using System.Windows;
using ValidationFramework.Implement.ValidateRules;
using ValidationLib.UIControl;
using ValidationFramework.Common;
using System.Windows.Controls;

namespace ValidationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Sự kiện PasswordChanged
        private void OnConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị Password từ PasswordBox của mật khẩu chính
            var password = passwordBox.Password;

            // Cập nhật BaseValue cho ConfirmPasswordRule trong ValidateObserver
            var observer = confirmPasswordBox.GetValue(ValidationLib.UIControl.ValidationAttachedProperties.ObserverProperty) as ValidationFramework.Common.ValidateObserver; 
            if (observer != null)
            {
                var rule = observer.Rules.OfType<ConfirmPasswordRule>().FirstOrDefault();
                if (rule != null)
                {
                    rule.BaseValue = password; // Cập nhật BaseValue của ConfirmPasswordRule
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if( addressComboBox.SelectedItem == null)
            {
                addressComboBox.SelectedIndex = 0;
                addressComboBox.Text = null;
                //addressComboBox.SelectedItem = null;
            }

            if (termsCheckBox.IsChecked == false)
            {
                termsCheckBox.IsChecked = true;
                termsCheckBox.IsChecked = false;
            }

        }
    }
}
