using Prism;
using Prism.Ioc;

namespace ArcMovies.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.GetContainer().Register<CachedImageRenderer>(made: Made.Of(() => new CachedImageRenderer(Arg.Of<Android.Content.Context>())));
            // OR with Reflection
            //containerRegistry.GetContainer().Register<CachedImageRenderer>(made: Made.Of(typeof(CachedImageRenderer).GetConstructor(new[] { typeof(Android.Content.Context) })));
        }
    }
}