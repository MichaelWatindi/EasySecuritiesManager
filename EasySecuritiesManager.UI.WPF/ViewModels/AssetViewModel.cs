namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class AssetViewModel : ViewModelBase
    {
        public string   Symbol { get ; }
        public int      Shares { get ; }

        public AssetViewModel( string symbol, int shares ) : base() 
        {
            Symbol = symbol.ToUpper() ;
            Shares = shares ;
        }
    }
}
