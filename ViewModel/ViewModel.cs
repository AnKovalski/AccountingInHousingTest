using AccountingInHousing.DAL;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;


namespace AccountingInHousing
{
    public class ViewModel : Notifier
    {
        public const string SELECTED_COOPERATIVE_NAME = "SelectedCooperative";
        public const string SELECTED_HOUSE_NAME = "SelectedHouse";

        private readonly DataModel _model;
        private CooperativeViewModel _selectedCooperative;
        private bool _detailsEnabled = false;
        private readonly ICommand _updateCooperativeCommand;

        private HouseViewModel _selectedHouse;

        public ObservableCollection<ЖПК> Cooperatives
        {
            get { return _model.Cooperatives; }
        }
        public ObservableCollection<МногоквартирныйЖилойДом> Houses
        {
            get { return _model.Houses1; }
        }
        public int? SelectedCooperativeValue               // Свойство SelectedValue привязывается в представлении к номеру выбранного элемента в ComboBox
        {
            set
            {
                if (value == null)
                    return;
                ЖПК cooperative = GetCooperative((int)value);
                if (SelectedCooperative == null)
                {
                    SelectedCooperative = new CooperativeViewModel(cooperative);
                }
                else
                {
                    SelectedCooperative.Update(cooperative);
                }
            }
        }
        public int? SelectedHauseValue               // Свойство SelectedValue привязывается в представлении к номеру выбранного элемента в ComboBox
        {
            set
            {
                if (value == null)
                    return;
                МногоквартирныйЖилойДом house = GetHouse((int)value);
                if (SelectedHouse == null)
                {
                    SelectedHouse = new HouseViewModel(house);
                }
                else
                {
                    SelectedHouse.Update(house);
                }
            }
        }
        public HouseViewModel SelectedHouse
        {
            get
            {
                return _selectedHouse;
            }
            set
            {
                if (value == null)
                {
                    _selectedHouse = value;
                    DetailsEnabled = false;
                }
                else
                {
                    if (_selectedHouse == null)
                    {
                        _selectedHouse = new HouseViewModel(value);
                    }
                    _selectedHouse.Update(value);

                    NotifyPropertyChanged(SELECTED_COOPERATIVE_NAME);
                }
            }
        }

            public CooperativeViewModel SelectedCooperative
        {
            get
            {
                return _selectedCooperative;
            }
            set
            {
                if (value == null)
                {
                    _selectedCooperative = value;
                    DetailsEnabled = false;
                }
                else
                {
                    if (_selectedCooperative == null)
                    {
                        _selectedCooperative = new CooperativeViewModel(value);
                    }
                    _selectedCooperative.Update(value);

                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_COOPERATIVE_NAME);
                }
            }
        }
        public bool DetailsEnabled
        {
            get { return _detailsEnabled; }
            set
            {
                _detailsEnabled = value;
                NotifyPropertyChanged("DetailsEnabled");
            }
        }
        public ICommand UpdateCooperativeCommand
        {
            get { return _updateCooperativeCommand; }
        }
        //public ICommand TextChanged
        //{
        //    get { return _updateCooperativeCommand; }
        //}
        public ViewModel(DataModel dataModel)
        {
            _model = dataModel;
            _model.CooperativeUpdated += model_CooperativeUpdated;
            _updateCooperativeCommand = new UpdateCommand(this);
        }
        public void UpdateCooperative()
        {
            _model.UpdateCooperative(SelectedCooperative);
        }
        private void model_CooperativeUpdated(object sender, CooperativeEventArgs e)
        {
            GetCooperative(e.Cooperative.КодЖПК).Update(e.Cooperative);
            if (SelectedCooperative != null && e.Cooperative.КодЖПК == SelectedCooperative.КодЖПК)
            {
                SelectedCooperative.Update(e.Cooperative);
            }
        }
        private ЖПК GetCooperative(int cooperativeID)
        {
            return (from p in Cooperatives where p.КодЖПК == cooperativeID select p).FirstOrDefault();
        }
        private МногоквартирныйЖилойДом GetHouse(int houseID)
        {
            return (from p in Houses where p.КодДома == houseID select p).FirstOrDefault();
        }
    }
    internal class UpdateCommand : ICommand
    {
        private const int ARE_EQUAL = 0;
        private const int NONE_SELECTED = -1;
        private ViewModel _vm;
        public UpdateCommand(ViewModel viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }
        private void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, ViewModel.SELECTED_COOPERATIVE_NAME) == ARE_EQUAL)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
        public bool CanExecute(object parameter)        // кнопка становится доступной когда SelectedCooperative != 0
        {
            if (_vm.SelectedCooperative == null)
                return false;
            return ((CooperativeViewModel)_vm.SelectedCooperative).КодЖПК > NONE_SELECTED;
        }

        public event EventHandler CanExecuteChanged = delegate { };     //     Происходит при возникновении изменений, влияющие на должна ли команда для выполнения.

        public void Execute(object parameter)           //     Определяет метод, вызываемый, когда команда запускается.
        {
            _vm.UpdateCooperative();
        }
    }
}