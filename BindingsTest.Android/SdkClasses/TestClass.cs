using Android.Util;
using BindingsTest.Interfaces;
using viso = Com.Visioglobe;

namespace BindingsTest.Droid.SdkClasses
{
    public class TestClass : ISdkTest
    {
        public void Speak(string text)
        {
            string tag = "myapp";
            Log.Info(tag, text);
        }
    }
}
