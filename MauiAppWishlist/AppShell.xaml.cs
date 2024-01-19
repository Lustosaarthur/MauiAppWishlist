namespace MauiAppWishlist
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("startpage/addpage", typeof(Views.AddProductPage));
            Routing.RegisterRoute("startpage/detail", typeof(Views.DetailPage));
        }
    }
}
