using AccountingInHousing.DAL;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace AccountingInHousing
{
    /// <summary>
    /// Модель. Содержит или представляет данные, с которыми работают пользователи.
    /// </summary>
    public class DataModel
    {
        public AccountingInHousingContext DbContext { get; private set; }
        public ObservableCollection<ЖПК> Cooperatives { get; set; }                         // коллекция ObservableCollection<> привязанная к свойству Projects модель-представления ProjectsViewModel
        public ObservableCollection<МногоквартирныйЖилойДом> Houses1 { get; set; }   
       // {
            //get
            //{
            //    //NotifyPropertyChanged("КодДома");
            //   // return GetHouses();
            //}
            //set { }
        //}                         // коллекция ObservableCollection<> привязанная к свойству Projects модель-представления ProjectsViewModel

        public event EventHandler<CooperativeEventArgs> CooperativeUpdated = delegate { };  // событие обновления данных кооператива.Обновление данных в модели приводит к автоматическому обновлению всех представлений в приложении
        public DataModel()
        {
            DbContext = new AccountingInHousingContext();
            Cooperatives = this.GetCooperatives();
            Houses1 = this.GetHouses();
        }
        public void UpdateCooperative(ICooperative cooperative)                             // обработчик события CooperativeUpdated, сохраняющий экземпляр Cooperative.
        {
            //ЖПК selectedCooperative = Cooperative.Where(p => p.КодЖПК == cooperative.КодЖПК).FirstOrDefault() as ЖПК;

            ЖПК selectedCooperative = GetCooperative(cooperative.КодЖПК);

            selectedCooperative.НаименованиеЖПК = cooperative.НаименованиеЖПК;
            selectedCooperative.ЮридическийАдрес = cooperative.ЮридическийАдрес;
            selectedCooperative.УНП = cooperative.УНП;
            selectedCooperative.РасчетныйСчет = cooperative.РасчетныйСчет;
            selectedCooperative.НаименованиеБанка = cooperative.НаименованиеБанка;
            selectedCooperative.КодБанка = cooperative.КодБанка;
            selectedCooperative.ПлощадьЗемельногоУчастка = cooperative.ПлощадьЗемельногоУчастка;
            selectedCooperative.ПлощадьЗастройки = cooperative.ПлощадьЗастройки;
            selectedCooperative.ОбщаяПлощадьЖилыхПомещений = cooperative.ОбщаяПлощадьЖилыхПомещений;

            selectedCooperative.ПолноеНаименованиеЖПК = cooperative.ПолноеНаименованиеЖПК;
            selectedCooperative.ОКПО = cooperative.ОКПО;
            selectedCooperative.УНПФ = cooperative.УНПФ;
            selectedCooperative.РегистрационныйНомерВБелгосстрахе = cooperative.РегистрационныйНомерВБелгосстрахе;

            CooperativeUpdated(this, new CooperativeEventArgs(cooperative));
            this.SaveChanges();
        }
        private ЖПК GetCooperative(int cooperativeID)
        {
            return Cooperatives.FirstOrDefault(cooperative => cooperative.КодЖПК == cooperativeID);
        }
        public bool SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return false;
            }
        }
        public ObservableCollection<ЖПК> GetCooperatives()
        {
            DbContext.ЖПК.Load();
            return DbContext.ЖПК.Local;
        }
        public ObservableCollection<МногоквартирныйЖилойДом> GetHouses()
        {
            DbContext.МногоквартирныйЖилойДом.Load();
            return DbContext.МногоквартирныйЖилойДом.Local;
        }
    }
    public class CooperativeEventArgs : EventArgs
    {
        public ICooperative Cooperative { get; set; }
        public CooperativeEventArgs(ICooperative cooperative)
        {
            Cooperative = cooperative;
        }
    }
    /// <summary>
    /// Класс реализует интерфейс INotifyPropertyChanged, используеться в модели и модели-представлении для уведомлении об изменениях
    /// </summary>
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
