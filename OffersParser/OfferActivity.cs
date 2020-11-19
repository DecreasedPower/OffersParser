using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace OffersParser
{
    [Activity(Label = "Детали предложения")]
    public class OfferActivity : MainActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_offer);
            // Create your application here
            TextView textView = FindViewById<TextView>(Resource.Id.textView1);
            // Получаются данные из предыдущего окна и выводятся на экран
            string json = Intent.GetStringExtra("json");
            textView.Text = json;
        }
    }
}