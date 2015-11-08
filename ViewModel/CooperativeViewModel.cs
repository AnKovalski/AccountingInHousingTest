using AccountingInHousing.DAL;

namespace AccountingInHousing
{
    public class CooperativeViewModel : Notifier, ICooperative
    {

        private int _КодЖПК;
        private string _НаименованиеЖПК;
        private string _ЮридическийАдрес;
        private decimal? _УНП;
        private decimal? _РасчетныйСчет;
        private string _НаименованиеБанка;
        private decimal? _КодБанка;
        private float? _ПлощадьЗемельногоУчастка;
        private float? _ПлощадьЗастройки;
        private float? _ОбщаяПлощадьЖилыхПомещений;

        private string _ПолноеНаименованиеЖПК;
        private decimal? _ОКПО;
        private decimal? _УНПФ;
        private decimal? _РегистрационныйНомерВБелгосстрахе;
        public string Тест
        {
            get { return _ПолноеНаименованиеЖПК + " " + "!"; }
            set { NotifyPropertyChanged("Тест"); }
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
        public string НаименованиеЖПК
        {
            get { return _НаименованиеЖПК; }
            set
            {
                _НаименованиеЖПК = value;
                NotifyPropertyChanged("НаименованиеЖПК");
            }
        }
        public string ЮридическийАдрес
        {
            get { return _ЮридическийАдрес; }
            set
            {
                _ЮридическийАдрес = value;
                NotifyPropertyChanged("ЮридическийАдрес");
            }
        }
        public decimal? УНП
        {
            get { return _УНП; }
            set
            {
                _УНП = value;
                NotifyPropertyChanged("УНП");
            }
        }
        public decimal? РасчетныйСчет
        {
            get { return _РасчетныйСчет; }
            set
            {
                _РасчетныйСчет = value;
                NotifyPropertyChanged("РасчетныйСчет");
            }
        }
        public string НаименованиеБанка
        {
            get { return _НаименованиеБанка; }
            set
            {
                _НаименованиеБанка = value;
                NotifyPropertyChanged("НаименованиеБанка");
            }
        }
        public decimal? КодБанка
        {
            get { return _КодБанка; }
            set
            {
                _КодБанка = value;
                NotifyPropertyChanged("КодБанка");
            }
        }
        public float? ПлощадьЗемельногоУчастка
        {
            get { return _ПлощадьЗемельногоУчастка; }
            set
            {
                _ПлощадьЗемельногоУчастка = value;
                NotifyPropertyChanged("ПлощадьЗемельногоУчастка");
            }
        }
        public float? ПлощадьЗастройки
        {
            get { return _ПлощадьЗастройки; }
            set
            {
                _ПлощадьЗастройки = value;
                NotifyPropertyChanged("ПлощадьЗастройки");
            }
        }
        public float? ОбщаяПлощадьЖилыхПомещений
        {
            get { return _ОбщаяПлощадьЖилыхПомещений; }
            set
            {
                _ОбщаяПлощадьЖилыхПомещений = value;
                NotifyPropertyChanged("ОбщаяПлощадьЖилыхПомещений");
            }
        }
        public string ПолноеНаименованиеЖПК
        {
            get { return _ПолноеНаименованиеЖПК; }
            set
            {
                _ПолноеНаименованиеЖПК = value;
                NotifyPropertyChanged("ПолноеНаименованиеЖПК");
            }
        }
        public decimal? ОКПО
        {
            get { return _ОКПО; }
            set
            {
                _ОКПО = value;
                NotifyPropertyChanged("ОКПО");
            }
        }
        public decimal? УНПФ
        {
            get { return _УНПФ; }
            set
            {
                _УНПФ = value;
                NotifyPropertyChanged("УНПФ");
            }
        }
        public decimal? РегистрационныйНомерВБелгосстрахе
        {
            get { return _РегистрационныйНомерВБелгосстрахе; }
            set
            {
                _РегистрационныйНомерВБелгосстрахе = value;
                NotifyPropertyChanged("РегистрационныйНомерВБелгосстрахе");
            }
        }
        public CooperativeViewModel()
        { }
        public CooperativeViewModel(ICooperative cooperative)
        {
            if (cooperative == null) return;
            Update(cooperative);
        }
        public void Update(ICooperative cooperative)
        {
            КодЖПК = cooperative.КодЖПК;
            НаименованиеЖПК = cooperative.НаименованиеЖПК;
            ЮридическийАдрес = cooperative.ЮридическийАдрес;
            УНП = cooperative.УНП;
            РасчетныйСчет = cooperative.РасчетныйСчет;
            НаименованиеБанка = cooperative.НаименованиеБанка;
            КодБанка = cooperative.КодБанка;
            ПлощадьЗемельногоУчастка = cooperative.ПлощадьЗемельногоУчастка;
            ПлощадьЗастройки = cooperative.ПлощадьЗастройки;
            ОбщаяПлощадьЖилыхПомещений = cooperative.ОбщаяПлощадьЖилыхПомещений;

            ПолноеНаименованиеЖПК = cooperative.ПолноеНаименованиеЖПК;
            ОКПО = cooperative.ОКПО;
            УНПФ = cooperative.УНПФ;
            РегистрационныйНомерВБелгосстрахе = cooperative.РегистрационныйНомерВБелгосстрахе;

            Тест = this.Тест;               //!!!!
        }
    }
}