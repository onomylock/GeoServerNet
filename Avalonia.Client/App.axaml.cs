using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Client.ViewModels;
using Avalonia.Client.Views;
using Splat;

namespace Avalonia.Client;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                try
                {
                    DataContext = Locator.Current.GetService<MainViewModel>();
                    desktop.MainWindow = new MainWindow
                    {
                        DataContext = DataContext
                    };
                }
                catch (Exception e)
                {
                    Log.Error(e, "");
                    throw;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        base.OnFrameworkInitializationCompleted();
    }
}