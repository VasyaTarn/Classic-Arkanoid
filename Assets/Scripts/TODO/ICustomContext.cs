
using strange.extensions.injector.api;

public interface ICustomContext
{
    void SetBinder(ICrossContextInjectionBinder binder);
    void LaunchContext();
}
