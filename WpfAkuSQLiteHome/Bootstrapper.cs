using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAkuSQLiteHome.ViewModels;

namespace WpfAkuSQLiteHome
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();


            _container
                .PerRequest<ICalculatorViewModel, CalculatorViewModel>()
                .PerRequest<IInputCalculatorViewModel, InputCalculatorViewModel>()
                .PerRequest<IDayViewModel, DayViewModel>()
                .PerRequest<ITableCalculatorViewModel, TableCalculatorViewModel>()
                .PerRequest<IGraphCalculatorViewModel, GraphCalculatorViewModel>()
                .PerRequest<ITableRestCalculatorViewModel, TableRestCalculatorViewModel>()
                .PerRequest<IScrollCalculatorViewModel, ScrollCalculatorViewModel>()
                .PerRequest<ICalendarViewModel, CalendarViewModel>();


            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            Dictionary<string, object> window_settings = new Dictionary<string, object>();
            window_settings.Add("WindowStartupLocation", System.Windows.WindowStartupLocation.CenterScreen);
            window_settings.Add("WindowState", System.Windows.WindowState.Maximized);
            window_settings.Add("SizeToContent", System.Windows.SizeToContent.WidthAndHeight);

            DisplayRootViewFor<ShellViewModel>(window_settings);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }


    }
}
