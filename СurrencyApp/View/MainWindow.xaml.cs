using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NbrbAPI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<Rate> Currencies { get; set; }
    private ApiService _apiService;
    private FileService _fileService;

    public ICommand LoadCurrenciesCommand { get; }

    public MainViewModel()
    {
        _apiService = new ApiService();
        _fileService = new FileService();
        Currencies = new ObservableCollection<Rate>();
        LoadCurrenciesCommand = new RelayCommand(LoadCurrencies);
    }

    private async void LoadCurrencies()
    {
        var currencies = await _apiService.GetCurrenciesAsync();

        Currencies.Clear();

        foreach (var currency in currencies)
        {
            Currencies.Add(currency);
        }
        _fileService.SaveCurrenciesToFile(currencies);
    }
}