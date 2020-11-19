using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace OffersParser
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Вызывается метод, отвечающий за парсинг
            XmlParser.Parse();
            //Устанавливается и заполняется данными список с id предложений
            ListView listView = FindViewById<ListView>(Resource.Id.listViewOffers);
            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>
                (this, Android.Resource.Layout.SimpleListItem1, XmlParser.Ids);
            listView.Adapter = arrayAdapter;

            //При нажатии на элемент, выводится детальное представление
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Определяется какой именно элемент был выбран и запускается окно, в которое передаются нужные данные
            var intent = new Intent(this, typeof(OfferActivity));
            intent.PutExtra("json", XmlParser.jsones[e.Position]);
            StartActivity(intent);
        }
    }
}