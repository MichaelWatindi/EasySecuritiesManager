using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.UI.WPF.ViewModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasySecuritiesManager.UI.WPF.Controls
{
    /// <summary>
    /// Interaction logic for AssetListingControl.xaml
    /// </summary>
    public partial class AssetListingControl : UserControl
    {
        public IEnumerable<Asset> Assets
        {
            get { return ( IEnumerable<Asset> )GetValue( AssetsProperty ); }
            set { SetValue( AssetsProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for Assets.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssetsProperty =
            DependencyProperty.Register( "Assets", typeof( IEnumerable<Asset> ), typeof( AssetListingControl ));

        public AssetListingControl()
        {
            InitializeComponent();
        }
    }
}
