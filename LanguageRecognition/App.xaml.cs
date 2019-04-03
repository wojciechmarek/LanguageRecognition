﻿using LanguageRecognition.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LanguageRecognition.ViewModel;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using LanguageRecognition.View;

namespace LanguageRecognition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialize DI container
        /// </summary>
        /// <remarks>
        /// We use OnStarup to init DI on the beginning of life of app.
        /// We mustn't use ctor because use can't block main thread.
        /// </remarks>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //create DI container
            WindsorContainer container = new WindsorContainer();

            //registers classes to take easy reference of them later
            //and dependency injection(class is injected)
            container.Register(Component.For<MainWindow>());
            container.Register(Component.For<SamplesWindow>());
            container.Register(Component.For<LearnWindow>());
            container.Register(Component.For<RecognizeWindow>());
            container.Register(Component.For<MainWindowViewModel>());

            //Dependency injection(interface is injected)
            container.Register(Component.For<IServices>().ImplementedBy<Services>());

            //in easy way we can take reference to object registered earier
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
