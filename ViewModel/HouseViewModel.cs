using AccountingInHousing.DAL;

namespace AccountingInHousing
{
    public class HouseViewModel : Notifier, IHouse
    {
        private int _КодДома;
        private string _Улица;
        private int _НомерДома;
        private int _КодЖПК;
        private string _НаименованиеДома;
        public string НаименованиеДома
        {
            get { return _НаименованиеДома; }
            set { NotifyPropertyChanged("НаименованиеДома"); }
        }
        public int КодДома
        {
            get { return _КодДома; }
            set
            {
                _КодДома = value;
                NotifyPropertyChanged("КодДома");

            }
        }
        public string Улица
        {
            get { return _Улица; }
            set
            {
                _Улица = value;
                NotifyPropertyChanged("Улица");

            }
        }
        public int НомерДома
        {
            get { return _НомерДома; }
            set
            {
                _НомерДома = value;
                NotifyPropertyChanged("НомерДома");

            }
        }
        public int КодЖПК
        {
            get { return _КодЖПК; }
            set
            {
                _КодЖПК = value;
                NotifyPropertyChanged("КодЖПК");

            }
        }
        public HouseViewModel()
        { }
        public HouseViewModel(IHouse house)
        {
            if (house == null) return;
            Update(house);
        }
        public void Update(IHouse house)
        {
            КодДома = house.КодДома;
            Улица = house.Улица;
            НомерДома = house.НомерДома;
            КодЖПК = house.КодЖПК;
        }
    }
}
