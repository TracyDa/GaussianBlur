using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var blur = new GaussianBlurEffect();
            blur.BlurAmount = 10.0f;
            blur.Source = bitmapTiger;
            args.DrawingSession.DrawImage(blur);
        }

        void myWidget_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            // Create any resources needed by the Draw event handler.

            // Asynchronous work can be tracked with TrackAsyncAction:
            args.TrackAsyncAction(myWidget_CreateResourcesAsync(sender).AsAsyncAction());
        }
        CanvasBitmap bitmapTiger;

        async Task myWidget_CreateResourcesAsync(CanvasControl sender)
        {
            // Load bitmaps, create brushes, etc.
            bitmapTiger = await CanvasBitmap.LoadAsync(sender, "sun0.jpg");
        }
 
    }
}
